using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Zlib;

namespace System
{
    /// <summary>
    /// 字节序
    /// </summary>
    public enum Endian
    {
        /// <summary>
        /// 将低序字节存储在起始地址
        /// </summary>
        Little,
        /// <summary>
        /// 将高序字节存储在起始地址
        /// </summary>
        Big
    }

    public static partial class ByteArrayExtensions
    {
        /// <summary>
        /// 返回由字节数组中前两个字节转换来的16位有符号整数
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="endian">字节序</param>
        /// <returns></returns>
        public static short GetInt16(this byte[] bytes, Endian endian)
        {
            return bytes.GetInt16(endian, 0);
        }

        /// <summary>
        /// 返回由字节数组中指定位置的两个字节转换来的16位有符号整数
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="endian">字节序</param>
        /// <param name="index">偏移位置</param>
        /// <returns></returns>
        public static short GetInt16(this byte[] bytes, Endian endian, int index)
        {
            if (endian == Endian.Little)
            {
                return (short)(bytes[index++] | (bytes[index] << 8));
            }
            return (short)((bytes[index++] << 8) | bytes[index]);
        }

        /// <summary>
        /// 返回由字节数组中前两个字节转换来的32位无符号整数
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="endian">字节序</param>
        /// <returns></returns>
        public static ushort GetUInt16(this byte[] bytes, Endian endian)
        {
            return (ushort)bytes.GetInt16(endian, 0);
        }

        /// <summary>
        /// 返回由字节数组中指定位置的两个字节转换来的32位无符号整数
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="endian">字节序</param>
        /// <param name="index">偏移位置</param>
        /// <returns></returns>
        public static ushort GetUInt16(this byte[] bytes, Endian endian, int index)
        {
            return (ushort)bytes.GetInt16(endian, index);
        }

        /// <summary>
        /// 返回由字节数组中前四个字节转换来的32位有符号整数
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="endian">字节序</param>
        /// <returns></returns>
        public static int GetInt32(this byte[] bytes, Endian endian)
        {
            return bytes.GetInt32(endian, 0);
        }

        /// <summary>
        /// 返回由字节数组中指定位置的四个字节转换来的32位有符号整数
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="endian">字节序</param>
        /// <param name="index">偏移位置</param>
        /// <returns></returns>
        public static int GetInt32(this byte[] bytes, Endian endian, int index)
        {
            if (endian == Endian.Little)
            {
                return bytes[index++] | (bytes[index++] << 8) | (bytes[index++] << 16) | (bytes[index] << 24);
            }
            return (bytes[index++] << 24) | (bytes[index++] << 16) | (bytes[index++] << 8) | bytes[index];
        }

        /// <summary>
        /// 返回由字节数组中前四个字节转换来的32位无符号整数
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="endian">字节序</param>
        /// <returns></returns>
        public static uint GetUInt32(this byte[] bytes, Endian endian)
        {
            return (uint)bytes.GetInt32(endian, 0);
        }

        /// <summary>
        /// 返回由字节数组中指定位置的四个字节转换来的32位无符号整数
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="endian">字节序</param>
        /// <param name="index">偏移位置</param>
        /// <returns></returns>
        public static uint GetUInt32(this byte[] bytes, Endian endian, int index)
        {
            return (uint)bytes.GetInt32(endian, index);
        }

        /// <summary>
        /// 返回由字节数组中前四个字节转换来的64位有符号整数
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="endian">字节序</param>
        /// <returns></returns>
        public static long GetInt64(this byte[] bytes, Endian endian)
        {
            return bytes.GetInt64(endian, 0);
        }

        /// <summary>
        /// 返回由字节数组中指定位置的四个字节转换来的64位有符号整数
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="endian">字节序</param>
        /// <param name="index">偏移位置</param>
        /// <returns></returns>
        public static long GetInt64(this byte[] bytes, Endian endian, int index)
        {
            if (endian == Endian.Little)
            {
                return bytes.GetUInt32(endian, index) | ((long)bytes.GetInt32(endian, index + 4) << 32);
            }
            return ((long)bytes.GetInt32(endian, index) << 32) | bytes.GetUInt32(endian, index + 4);
        }

        /// <summary>
        /// 返回由字节数组中前四个字节转换来的64位有符号整数
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="endian">字节序</param>
        /// <returns></returns>
        public static ulong GetUInt64(this byte[] bytes, Endian endian)
        {
            return (ulong)bytes.GetInt64(endian, 0);
        }

        /// <summary>
        /// 返回由字节数组中指定位置的四个字节转换来的64位有符号整数
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="endian">字节序</param>
        /// <param name="index">偏移位置</param>
        /// <returns></returns>
        public static ulong GetUInt64(this byte[] bytes, Endian endian, int index)
        {
            return (ulong)bytes.GetInt64(endian, index);
        }

        /// <summary>
        /// 将字节数组转换为指定进制字符串
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="radix">数字的基数，必须为2 ~ 36</param>
        /// <param name="width"></param>
        /// <returns></returns>
        public static string ToString(this byte[] bytes, int radix, int width)
        {
            if (bytes == null || bytes.Length == 0)
            {
                return string.Empty;
            }
            StringBuilder stringBuilder = new StringBuilder(bytes.Length * width);
            for (int i = 0; i < bytes.Length; i++)
            {
                stringBuilder.Append(bytes[i].ToString(radix).PadLeft(width, '0'));
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// 将字节数组转换成指定编码的字符串
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string ToString(this byte[] bytes, Encoding encoding)
        {
            encoding ??= Encoding.UTF8;
            return encoding.GetString(bytes);
        }

        /// <summary>
        /// 插入字节数组
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="data"></param>
        /// <param name="offset">倒数偏移</param>
        /// <returns></returns>
        public static byte[] InsertLast(this byte[] bytes, byte[] data, int offset)
        {
            return bytes.Take(bytes.Length - offset).Concat(data).Concat(bytes.TakeLast(offset)).ToArray();
        }

        /// <summary>
        /// 将json字节数组转换成对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static T ToJObject<T>(this byte[] context, Encoding encoding = null)
        {
            return context.ToString(encoding).ToJObject<T>();
        }

        /// <summary>
        /// 转换成Base64
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string Base64Encode(this byte[] data)
        {
            if (data == null || data?.Length == 0) { return string.Empty; }
            try
            {
                return Convert.ToBase64String(data);
            }
            catch { return string.Empty; }
        }

        /// <summary>
        /// 从二进制反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static T DeserializeFromBinary<T>(this byte[] data)
        {
            T t = default; BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                t = (T)formatter.Deserialize(new MemoryStream(data));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return t;
        }

        /// <summary>
        /// AES加密
        /// </summary>
        /// <param name="data"></param>
        /// <param name="key"></param>
        /// <param name="mode"></param>
        /// <param name="padding"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static byte[] AESEncrypt(this byte[] data, byte[] key, CipherMode mode = CipherMode.CBC, PaddingMode padding = PaddingMode.PKCS7)
        {
            var aes = new AesCryptoServiceProvider() { Key = key, Mode = mode, Padding = padding };
            if (mode == CipherMode.CBC) { aes.IV = key; }
            var enc = aes.CreateEncryptor();
            var ret = enc.TransformFinalBlock(data, 0, data.Length);
            enc.Dispose(); aes.Dispose();
            return ret;
        }

        /// <summary>
        /// AES解密
        /// </summary>
        /// <param name="data"></param>
        /// <param name="key"></param>
        /// <param name="mode"></param>
        /// <param name="padding"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static byte[] AESDecrypt(this byte[] data, byte[] key, CipherMode mode = CipherMode.CBC, PaddingMode padding = PaddingMode.PKCS7)
        {
            var aes = new AesCryptoServiceProvider() { Key = key, Mode = mode, Padding = padding };
            if (mode == CipherMode.CBC) { aes.IV = key; }
            var dec = aes.CreateDecryptor();
            var ret = dec.TransformFinalBlock(data, 0, data.Length);
            dec.Dispose(); aes.Dispose();
            return ret;
        }

        /// <summary>
        /// DES3加密
        /// </summary>
        /// <param name="data"></param>
        /// <param name="key"></param>
        /// <param name="mode"></param>
        /// <param name="padding"></param>
        /// <returns></returns>
        public static byte[] DES3Encrypt(this byte[] data, byte[] key, CipherMode mode = CipherMode.CBC, PaddingMode padding = PaddingMode.Zeros)
        {
            var des = new TripleDESCryptoServiceProvider() { Key = key, Mode = mode, Padding = padding };
            var enc = des.CreateEncryptor();
            return enc.TransformFinalBlock(data, 0, data.Length);
        }

        /// <summary>
        /// DES3解密
        /// </summary>
        /// <param name="data"></param>
        /// <param name="key"></param>
        /// <param name="mode"></param>
        /// <param name="padding"></param>
        /// <returns></returns>
        public static byte[] DES3Decrypt(this byte[] data, byte[] key, CipherMode mode = CipherMode.CBC, PaddingMode padding = PaddingMode.Zeros)
        {
            var des = new TripleDESCryptoServiceProvider() { Key = key, Mode = mode, Padding = padding };
            var dec = des.CreateDecryptor();
            return dec.TransformFinalBlock(data, 0, data.Length);
        }

        /// <summary>
        /// RSA加密
        /// </summary>
        /// <param name="data"></param>
        /// <param name="key"></param>
        /// <param name="exponent"></param>
        /// <returns></returns>
        public static byte[] RSAEncrypt(this byte[] data, byte[] key, string exponent = "010001")
        {
            var result = new byte[] { };
            using (var rsa = RSA.Create())
            {
                rsa.ImportParameters(new RSAParameters() { Exponent = exponent.ToByteArray(16, 2), Modulus = key });
                var rsa_len = rsa.KeySize / 8;
                if (data.Length > rsa_len - 12)
                {
                    int blockCnt = (data.Length / (rsa_len - 12)) + (((data.Length % (rsa_len - 12)) == 0) ? 0 : 1);
                    for (int i = 0; i < blockCnt; ++i)
                    {
                        int blockSize = rsa_len - 12;
                        if (i == blockCnt - 1) blockSize = data.Length - i * blockSize;
                        var temp = data.Copy(i * (rsa_len - 12), blockSize);
                        result = result.Concat(rsa.Encrypt(temp, RSAEncryptionPadding.Pkcs1)).ToArray();
                    }
                }
                else
                {
                    result = rsa.Encrypt(data, RSAEncryptionPadding.Pkcs1);
                }
            }
            return result;
        }

        public static int DecodeVByte32(this byte[] data, int offset, ref int apuValue)
        {
            int num3;
            int num = 0;
            int num2 = 0;
            int num4 = 0;
            byte num5 = data[offset + num++];
            while ((num5 & 0xff) >= 0x80)
            {
                num3 = num5 & 0x7f;
                num4 += num3 << num2;
                num2 += 7;
                num5 = data[offset + num++];
            }
            num3 = num5;
            num4 += num3 << num2;
            apuValue = num4;
            return num;
        }

        /// <summary>
        /// MD5编码
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] MD5(this byte[] data)
        {
            using MD5 provider = new MD5CryptoServiceProvider();
            return provider.ComputeHash(data);
        }

        /// <summary>
        /// SHA1计算
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] SHA1(this byte[] data)
        {
            using SHA1 provider = new SHA1CryptoServiceProvider();
            return provider.ComputeHash(data);
        }

        /// <summary>
        /// BCD码转String
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string BCDToString(this byte[] data)
        {
            var result = new StringBuilder(data.Length * 2);
            for (int i = 0; i < data.Length; i++)
            {
                result.Append((byte)((data[i] & 0xf0) >> 4));
                result.Append((byte)(data[i] & 0x0f));
            }
            //return result.ToString().Substring(0, 1).Equals("0") ? result.ToString().Substring(1) : result.ToString();
            return result.ToString().Substring(0, 1).Equals("0") ? result.ToString()[1..] : result.ToString();
        }

        public static string BCDEncode(this byte[] data)
        {
            var bcd_to_ascii = new byte[data.Length * 2];
            for (int i = 0; i < data.Length; i++)
            {
                bcd_to_ascii[2 * i] = (byte)(data[i] >> 4);
                bcd_to_ascii[2 * i + 1] = (byte)(data[i] & 0xF);
            }
            var strbcd = bcd_to_ascii.ToString(16, 2);
            var stream = new MemoryStream();
            for (int i = 0; i < strbcd.Length; i++)
            {
                if (i % 2 != 0)
                {
                    stream.WriteByte((byte)strbcd[i]);
                }
            }
            return stream.ToArray().ToString(Encoding.UTF8).ToUpper();
        }

        /// <summary>
        /// SHA256计算
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] SHA256(this byte[] data)
        {
            using SHA256 provider = Security.Cryptography.SHA256.Create();
            return provider.ComputeHash(data);
        }

        /// <summary>
        /// HMACSHA1计算
        /// </summary>
        /// <param name="data"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static byte[] HMACSHA1(this byte[] data, byte[] key)
        {
            using HMACSHA1 provider = new HMACSHA1(key);
            return provider.ComputeHash(data);
        }

        /// <summary>
        /// HMACSHA256计算
        /// </summary>
        /// <param name="data"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static byte[] HMACSHA256(this byte[] data, byte[] key)
        {
            using HMACSHA256 provider = new HMACSHA256(key);
            return provider.ComputeHash(data);
        }

        public static byte[] Expand(this byte[] info, byte[] key, int outputLength)
        {
            var resultBlock = new byte[0];
            var result = new byte[outputLength];//返回结果
            var bytesRemaining = outputLength;//剩余字节==输出字节
            for (int i = 1; bytesRemaining > 0; i++)//剩余字节大于0
            {
                var currentInfo = new byte[resultBlock.Length + info.Length + 1];//当前要hash的数据,长度为message+1
                Array.Copy(resultBlock, 0, currentInfo, 0, resultBlock.Length);
                Array.Copy(info, 0, currentInfo, resultBlock.Length, info.Length);
                //currentInfo[currentInfo.Length - 1] = (byte)i;
                currentInfo[^1] = (byte)i;
                resultBlock = currentInfo.HMACSHA256(key);
                Array.Copy(resultBlock, 0, result, outputLength - bytesRemaining, Math.Min(resultBlock.Length, bytesRemaining));
                bytesRemaining -= resultBlock.Length;
            }
            return result;
        }

        /// <summary>
        /// 从ProtoBuf反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static T DeserializeFromProtoBuf<T>(this byte[] data)
        {
            T t = default;
            try { t = ProtoBuf.Serializer.Deserialize<T>(new MemoryStream(data)); } catch { }
            return t;
        }

        /// <summary>
        /// ZIP压缩
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] ZIPCompress(this byte[] data)
        {
            MemoryStream input = new MemoryStream(data);
            Stream output = input.ZIPCompress();
            byte[] result = new byte[output.Length];
            output.Position = 0;
            output.Read(result, 0, result.Length);
            output.Close();
            input.Close();
            return result;
        }

        /// <summary>
        /// ZIP解压
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] ZIPDECompress(this byte[] data)
        {
            MemoryStream input = new MemoryStream(data);
            Stream output = input.ZIPDECompress();
            byte[] result = new byte[output.Length];
            output.Position = 0;
            output.Read(result, 0, result.Length);
            output.Close();
            input.Close();
            return result;
        }

        /// <summary>
        /// CRC32计算
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static uint Crc32(this byte[] data)
        {
            return zlib.crc32(0, data, data.Length);
        }

        /// <summary>
        /// AES-GCM 加密
        /// </summary>
        /// <param name="data"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        /// <param name="aad"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        public static byte[] AESGCMEncrypt(this byte[] data, byte[] key, byte[] iv, byte[] aad, byte[] tag = null)
        {
            var ret = new byte[data.Length];
            using (var aesgcm = new AesGcm(key))
            {
                tag ??= new Random(Guid.NewGuid().GetHashCode()).NextBytes(16);
                aesgcm.Encrypt(iv, data, ret, tag, aad);
                ret = ret.Concat(tag).ToArray();
            }
            return ret;
        }

        /// <summary>
        /// AES-GCM 解密
        /// </summary>
        /// <param name="data"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        /// <param name="aad"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        public static byte[] AESGCMDecrypt(this byte[] data, byte[] key, byte[] iv, byte[] aad, byte[] tag)
        {
            var ret = new byte[data.Length];
            try
            {
                using var aesgcm = new AesGcm(key);
                tag ??= new Random(Guid.NewGuid().GetHashCode()).NextBytes(16);
                aesgcm.Decrypt(iv, data, tag, ret, aad);
            }
            catch (Exception)
            {
                //System.Diagnostics.Debug.WriteLine($"{ex.Message}\r\n{ex.StackTrace}");
                return ret;
            }
            return ret;
        }

        /// <summary>
        /// AES-GCM 解密
        /// </summary>
        /// <param name="data"></param>
        /// <param name="key"></param>
        /// <param name="aad"></param>
        /// <returns></returns>
        public static byte[] AESGCMDecrypt(this byte[] data, byte[] key, byte[] aad = null)
        {
            var cipher = data?.Take(data.Length - 28).ToArray();
            var nonce = data?.Skip(cipher.Length).Take(12).ToArray();
            var tag = data?.Skip(cipher.Length + 12).ToArray();
            return cipher?.AESGCMDecrypt(key, nonce, aad, tag);
        }
    }
}
