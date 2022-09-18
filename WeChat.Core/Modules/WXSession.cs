using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WeChat.Core
{
    [Serializable]
    public class WXSession
    {
        #region 属性
        public long ServerSequence { get; private set; }
        public long ClientSequence { get; private set; }
        public byte[] SecretEcdhKey { get; private set; }
        public byte[] PskKey { get; private set; }
        public byte[] PskAccessKey { get; private set; }
        public byte[] PskRefreshKey { get; private set; }
        public byte[] LongLinkEncryptKey { get; private set; }
        public byte[] LongLinkDecryptKey { get; private set; }
        public byte[] LongLinkEncryptIV { get; private set; }
        public byte[] LongLinkDecryptIV { get; private set; }
        public bool Initialized { get; set; }
        #endregion

        #region 辅助功能
        /// <summary>
        /// IV异或计算
        /// </summary>
        /// <param name="iv"></param>
        /// <param name="seq"></param>
        /// <returns></returns>
        private byte[] IVXor(byte[] iv, long seq)
        {
            var old_last = iv.Skip(8).Take(4).ToArray().Reverse();
            var new_last = BitConverter.GetBytes(BitConverter.ToUInt32(old_last, 0) ^ (uint)seq);
            return iv.Take(8).Concat(new_last.Reverse()).ToArray();
        }
        private byte[] MMtlsDecrypt(byte[] data, long seq, byte[] key, byte[] iv)
        {
            var content = data.Skip(5).Take(data.Length - 5 - 16).ToArray();    //去除开头的5字节和后面16字节的tag
            var aad = new MemoryStream();
            aad.Write(seq, Endian.Big);
            aad.Write(data.Take(5).ToArray());
            return content.AESGCMDecrypt(key, IVXor(iv, seq), aad.ToArray(), data.TakeLast(16).ToArray());
        }
        private byte[] MMtlsEncrypt(byte[] data, long seq, byte[] key, byte[] iv, byte[] prefix)
        {
            var aad = new MemoryStream();
            aad.Write(seq, Endian.Big);
            aad.Write(prefix);
            aad.Write((ushort)(data.Length + 16), Endian.Big);

            var packet = data.AESGCMEncrypt(key, IVXor(iv, seq), aad.ToArray());
            if (packet == null) { return null; }

            var result = new MemoryStream();
            result.Write(prefix);
            result.Write((ushort)packet.Length, Endian.Big);
            result.Write(packet);
            return result.ToArray();
        }
        private (byte[], ushort, byte[]) MMtlsUnPack(byte[] data)
        {
            if ((data?.Length ?? 0) <= 5) return (null, 0, null);
            var head = data.Take(5).ToArray();
            var len = BitConverter.ToUInt16(data.Skip(3).Take(2).ToArray().Reverse(), 0);
            var body = data.Skip(5).Take(len).ToArray();
            return (head, len, body);
        }
        #endregion

        #region 初始化
        public void ResetSequence()
        {
            ServerSequence = 1;
            ClientSequence = 1;
        }
        public byte[] BuildRequest(byte[] PskKey,out ECKeyPair[] ecdhkey, out byte[] hash)
        {
            var r = new Random(DateTime.Now.Millisecond);
            var request = new MemoryStream();
            var ecdh1 = new ECKeyPair(Curve.SecP256r1);
            var ecdh2 = new ECKeyPair(Curve.SecP256r1);
            ecdhkey = new ECKeyPair[] { ecdh1,ecdh2 };
            //第一个公钥
            var pubOperate1 = new PackOperate()
                .SetDwordToken(
                    new PackOperate()
                        .SetDword (5)
                        .SetWordToken(ecdh1.PublicKey)
                );

            //第二个公钥
            var pubOperate2 = new PackOperate()
                .SetDwordToken(
                    new PackOperate()
                        .SetDword(6)
                        .SetWordToken(ecdh2.PublicKey)
                );

            var ecdhOperate = new PackOperate()
                .SetBytes(new byte[] { 0x00,0x10,0x02 })
                .SetBytes(pubOperate1.Array)
                .SetBytes(pubOperate2.Array)
                .SetByte(0)
                .SetDword(2)
                .SetDword(3)
                .SetDword(4);

            var buffer = new byte[0x20];
            r.NextBytes(buffer);
            var pskData = new byte[0];
            var adap = new PackOperate()
                .SetByte(1)
                .SetBytes(new byte[] { 0xc0,0x2b })
                .Array;

            if(PskKey != null && PskKey.Length > 100) {
                pskData = new PackOperate()
                    .SetBytes(new byte[] { 0x00,0x0f,0x01 })
                    .SetBytes(PskKey[109..]).Array;
                adap = new PackOperate()
                 .SetByte(2)
                 .SetBytes(new byte[] { 0xc0,0x2b })
                 .SetBytes(new byte[] { 0x00,0xa8 })
                 .Array;
            }

            var operate = new PackOperate()
                .SetBytes(new byte[] { 0x01,0x04,0xF1 })
                .SetBytes(adap)
                .SetBytes(buffer)
                .SetDword(DateTime.UtcNow.ToTimeStamp());

            var keys = new PackOperate();
            if(pskData.Length != 0) {
                keys.SetByte(2).SetDwordToken(pskData);
            } else {
                keys.SetByte(0x1);
            }
            keys.SetDwordToken(ecdhOperate);
            operate.SetDwordToken(keys);

            hash = new PackOperate().SetDwordToken(operate.Array).Array;
            request.Write(new byte[] { 0x16,0xf1,0x04 });
            request.Write((ushort)hash.Length,Endian.Big);
            request.Write(hash);
            return request.ToArray();
        }
        public byte[] Initialize(List<byte[]> psk,ECKeyPair[] ecdhkey, byte[] hash)
        {
            var result = default(byte[]);

            var handshakehash = new MemoryStream();
            handshakehash.Write(hash);

            #region 第一步：解析KEY

            //var ecdh = new ECKeyPair(Curve.SecP256r1, ecdhkey, null);
            var d = psk[0][60];

            var pubkey = psk[0].Skip(0x3f).Take(0x41).ToArray();
            var seckey = new byte[] { };
            if(d == 5) {
                seckey = ecdhkey[0].GetSharedKey(pubkey,k => k.SHA256());
            } else {
                seckey = ecdhkey[1].GetSharedKey(pubkey,k => k.SHA256());
            }
            if ((seckey?.Length ?? 0) <= 0) { return result; }

            handshakehash.Write(psk[0].Skip(5).ToArray());
            var hanshake256hashpart1 = handshakehash.ToArray().SHA256();

            var expandkey = "handshake key expansion".ToBytes().Concat(hanshake256hashpart1).ToArray().Expand(seckey, 56);
            var encrypt_key = expandkey.Take(16).ToArray();
            var dectypt_key = expandkey.Skip(16).Take(16).ToArray();
            var encrypt_iv = expandkey.Skip(32).Take(12).ToArray();
            var decrypt_iv = expandkey.Skip(44).ToArray();
            #endregion

            ResetSequence();

            #region 第二步：解析证书
            var certificate = MMtlsDecrypt(psk[1], ServerSequence++, dectypt_key, decrypt_iv);
            if (certificate == null) { return result; }
            handshakehash.Write(certificate);
            var hanshake256hashpart2 = handshakehash.ToArray().SHA256();
            #endregion

            #region 第三步：解析短链PSK KEY
            var psk_access_key = "PSK_ACCESS".ToBytes().Concat(hanshake256hashpart2).ToArray().Expand(seckey, 32);
            var psk_refresh_key = "PSK_REFRESH".ToBytes().Concat(hanshake256hashpart2).ToArray().Expand(seckey, 32);
            var psk_key = MMtlsDecrypt(psk[2], ServerSequence++, dectypt_key, decrypt_iv);
            if (psk_key == null) { return result; }
            handshakehash.Write(psk_key);
            var hanshake256hashpart3 = handshakehash.ToArray().SHA256();
            #endregion

            #region 第四步：完成
            var finish = MMtlsDecrypt(psk[3], ServerSequence++, dectypt_key, decrypt_iv);
            if (finish == null) { return result; }
            var finishhash = hanshake256hashpart3.HMACSHA256("client finished".ToBytes().Expand(seckey, 32));
            result = MMtlsEncrypt(new byte[] { 0x00, 0x00, 0x00, 0x23, 0x14, 0x00, 0x20 }.Concat(finishhash).ToArray(), ClientSequence++, encrypt_key, encrypt_iv, new byte[] { 0x16, 0xf1, 0x04 });
            #endregion

            #region 第五步：保存KEY
            var hkdf_ret = "expanded secret".ToBytes().Concat(hanshake256hashpart3).ToArray().Expand(seckey, 32);
            hkdf_ret = "application data key expansion".ToBytes().Concat(hanshake256hashpart3).ToArray().Expand(hkdf_ret, 56);
            LongLinkEncryptKey = hkdf_ret.Take(16).ToArray();
            LongLinkDecryptKey = hkdf_ret.Skip(16).Take(16).ToArray();
            LongLinkEncryptIV = hkdf_ret.Skip(32).Take(12).ToArray();
            LongLinkDecryptIV = hkdf_ret.Skip(44).ToArray();
            SecretEcdhKey = seckey;
            PskKey = psk_key;
            PskAccessKey = psk_access_key;
            PskRefreshKey = psk_refresh_key;
            #endregion

            Initialized = true;
            return result;
        }
        #endregion

        #region 组包解包
        public byte[] LongLinkPack(byte[] data)
        {
            if (!Initialized) return data;
            return MMtlsEncrypt(data, ClientSequence++, LongLinkEncryptKey, LongLinkEncryptIV, new byte[] { 0x17, 0xf1, 0x04 });
        }
        public byte[] LongLinkUnPack(byte[] data)
        {
            if (!Initialized) return data;
            return MMtlsDecrypt(data, ServerSequence++, LongLinkDecryptKey, LongLinkDecryptIV);
        }
        public byte[] ShortLinkHead(string host, string cgiurl, byte[] data)
        {
            var content = default(byte[]);
            using (var packet = new MemoryStream())
            {
                packet.Write((ushort)cgiurl.Length, Endian.Big);
                packet.Write(cgiurl.ToBytes());
                packet.Write((ushort)host.Length, Endian.Big);
                packet.Write(host.ToBytes());
                packet.Write(data.Length, Endian.Big);
                packet.Write(data);
                content = packet.ToArray();
            }
            return content.Length.ToByteArray(Endian.Big).Concat(content).ToArray();
        }
        public byte[] ShortLinkPack(byte[] data, out byte[] hash)
        {
            hash = null;
            if (!Initialized) { return data; }

            var shortlinkhash = new MemoryStream();
            var result = new MemoryStream();
            var ticket = DateTime.UtcNow.ToTimeStamp();

            var packet1 = PskKey.Skip(0x06).Take(103).ToArray();                                            // 写入PSKKEY
            packet1 = new byte[] { 0x00, 0x0f, 0x01 }.Concat(packet1).ToArray();                            // 写入标志
            packet1 = packet1.Length.ToByteArray(Endian.Big).Concat(packet1).ToArray();                     // 写入长度
            packet1 = new byte[] { 0x01 }.Concat(packet1).ToArray();                                        // 写入数据个数
            packet1 = packet1.Length.ToByteArray(Endian.Big).Concat(packet1).ToArray();                     // 写入长度
            packet1 = ticket.ToByteArray(Endian.Big).Concat(packet1).ToArray();                             // 写入时间戳
            packet1 = new Random(Guid.NewGuid().GetHashCode()).NextBytes(32).Concat(packet1).ToArray();     // 写入随机数
            packet1 = new byte[] { 0x01, 0x04, 0xf1, 0x01, 0x00, 0xa8 }.Concat(packet1).ToArray();          // 写入头部
            packet1 = packet1.Length.ToByteArray(Endian.Big).Concat(packet1).ToArray();                     // 写入长度

            byte[] hkdfret = "early data key expansion".ToBytes().Concat(packet1.SHA256()).ToArray().Expand(PskAccessKey, 28);
            byte[] encrypt_key = hkdfret.Take(16).ToArray();
            byte[] encrypt_iv = hkdfret.Skip(16).ToArray();

            shortlinkhash.Write(packet1);
            result.Write(new byte[] { 0x19, 0xf1, 0x04 });
            result.Write((ushort)packet1.Length, Endian.Big);
            result.Write(packet1);                                                                          // 写入第一个包

            var packet2 = ticket.ToByteArray(Endian.Big).ToArray();                                         // 写入时间戳
            packet2 = new byte[] { 0x00, 0x12 }.Concat(packet2).ToArray();                                  // 写入标志
            packet2 = packet2.Length.ToByteArray(Endian.Big).Concat(packet2).ToArray();                     // 写入长度
            packet2 = new byte[] { 0x01 }.Concat(packet2).ToArray();                                        // 写入数据个数
            packet2 = packet2.Length.ToByteArray(Endian.Big).Concat(packet2).ToArray();                     // 写入长度
            packet2 = new byte[] { 0x08 }.Concat(packet2).ToArray();                                        // 写入标志
            packet2 = packet2.Length.ToByteArray(Endian.Big).Concat(packet2).ToArray();                     // 写入长度

            shortlinkhash.Write(packet2);
            packet2 = MMtlsEncrypt(packet2, 1, encrypt_key, encrypt_iv, new byte[] { 0x19, 0xf1, 0x04 });
            result.Write(packet2);                                                                          // 写入第二个包

            var packet3 = MMtlsEncrypt(data, 2, encrypt_key, encrypt_iv, new byte[] { 0x17, 0xf1, 0x04 });
            result.Write(packet3);                                                                          // 写入第三个包业务包

            var packet4 = new byte[] { 0x00, 0x01, 0x01 };
            packet4 = packet4.Length.ToByteArray(Endian.Big).Concat(packet4).ToArray();                     // 写入长度
            packet4 = MMtlsEncrypt(packet4, 3, encrypt_key, encrypt_iv, new byte[] { 0x15, 0xf1, 0x04 });
            result.Write(packet4);
            hash = shortlinkhash.ToArray();
            return result.ToArray();
        }
        public byte[] ShortLinkUnPack(byte[] data, byte[] hash)
        {
            if (!Initialized) return data;
            var decrypt_key = default(byte[]);
            var decrypt_iv = default(byte[]);
            var result = new MemoryStream();
            var shortlinkhash = new MemoryStream();
            shortlinkhash.Write(hash);

            if ((data?.Length ?? 0) < 5) return null;
            var packets = Parse(data);
            if ((packets.Item2?.Count ?? 0) < 4) return null;

            for (var index = 0; index < packets.Item2.Count; index++)
            {
                var packet = packets.Item2[index];
                if (index == 0)
                {
                    var pack = MMtlsUnPack(packet);
                    shortlinkhash.Write(pack.Item3);
                    var hkdfret = "handshake key expansion".ToBytes().Concat(shortlinkhash.ToArray().SHA256()).ToArray().Expand(PskAccessKey, 28);
                    decrypt_key = hkdfret.Take(16).ToArray();
                    decrypt_iv = hkdfret.Skip(16).ToArray();
                }
                if (index > 1 && packet[0] == 0x17)
                {
                    var ret = MMtlsDecrypt(packet, index, decrypt_key, decrypt_iv);
                    result.Write(ret);
                }
            }
            return result.ToArray();
        }
        #endregion

        #region 辅助方法
        /// <summary>
        /// 解析MMTLS包
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns>返回解析长度和结果</returns>
        public static (int, List<byte[]>) Parse(byte[] buffer) => Parse(new ArraySegment<byte>(buffer));
        /// <summary>
        /// 解析MMTLS包
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns>返回解析长度和结果</returns>
        public static (int, List<byte[]>) Parse(ArraySegment<byte> buffer)
        {
            var offset = 0;
            var result = new List<byte[]>();
            while (buffer.Count - offset > 5 && buffer.Array[offset + 1] == 0xf1 && buffer.Array[offset + 2] == 0x04)
            {
                var datalen = buffer.Array.Skip(offset + 3).Take(2).ToArray().GetUInt16(Endian.Big);
                if (buffer.Count - offset < datalen + 5) { break; }
                result.Add(buffer.Array.Skip(offset).Take(datalen + 5).ToArray());
                offset += (datalen + 5);
            }
            return (offset, result);
        }
        #endregion
    }
}
