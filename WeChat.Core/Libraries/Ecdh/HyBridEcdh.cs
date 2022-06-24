using System.IO;
using System.Linq;

namespace System
{
    public struct HyBridEcdhData
    {
        public byte[] HashFinal;
        public byte[] EncryptKeyData;
        public byte[] EncryptKeyExtendData;
        public byte[] EncryptData;
    }

    public class HyBridEcdh
    {
        public const string HYBRID_EEDH_PUBKEY = "044bb81879aff459ca8f1db3d38eea5d789afaed14765a859a6f70bf06b663f37c6bd9e05c9f5def4ab796ca2c45b9d9a0f553ac8be51c0f60e087faee24d14510";
        //public const string HYBRID_EEDH_PUBKEY = "047ebe7604acf072b0ab0177ea551a7b72588f9b5d3801dfd7bb1bca8e33d1c3b8fa6e4e4026eb38d5bb365088a3d3167c83bdd0bbb46255f88a16ede6f7ab43b5";
        public ECKeyPair Ecdh { get; }
        public HyBridEcdh()
        {
            Ecdh = new ECKeyPair(Curve.SecP256r1);
        }
        public HyBridEcdh(byte[] prikey, byte[] pubkey)
        {
            Ecdh = new ECKeyPair(Curve.SecP256r1, prikey, pubkey);
        }

        public HyBridEcdhData Encrypt(byte[] src, byte[] extern_key = null)
        {
            var rnd = new Random();
            var ecdhkey = Ecdh.GetSharedKey(HYBRID_EEDH_PUBKEY.ToByteArray(16, 2), k => k.SHA256());

            var hash = new byte[] { };
            hash = hash.Concat("1".ToBytes()).ToArray();
            hash = hash.Concat("415".ToBytes()).ToArray();
            hash = hash.Concat(Ecdh.PublicKey).ToArray();
            hash = hash.SHA256();

            var rndkey = rnd.NextBytes(32);
            var nonce = rnd.NextBytes(12);

            var zip = rndkey.ZIPCompress();
            var encrypt_data = zip.AESGCMEncrypt(ecdhkey.Take(24).ToArray(), nonce, hash).InsertLast(nonce, 16);

            var extern_encrypt_data = (extern_key?.Length == 0x20 ? zip.AESGCMEncrypt(extern_key.Take(24).ToArray(), nonce, hash).InsertLast(nonce, 16) : new byte[0]);
            var hkdfexpand_security_key = hash.Expand(rndkey.HMACSHA256("security hdkf expand".ToBytes()), 56);

            var hashfinal = new byte[] { };
            hashfinal = hashfinal.Concat("1".ToBytes()).ToArray();
            hashfinal = hashfinal.Concat("415".ToBytes()).ToArray();
            hashfinal = hashfinal.Concat(Ecdh.PublicKey).ToArray();
            hashfinal = hashfinal.Concat(encrypt_data).ToArray();
            hashfinal = hashfinal.Concat(extern_encrypt_data).ToArray();
            hashfinal = hashfinal.SHA256();

            zip = src.ZIPCompress();
            var encrypt_data_final = zip.AESGCMEncrypt(hkdfexpand_security_key.Take(24).ToArray(), nonce, hashfinal).InsertLast(nonce, 16);
            var result = new HyBridEcdhData
            {
                HashFinal = hkdfexpand_security_key.Skip(24).Take(32).Concat(src).ToArray(),
                EncryptKeyData = encrypt_data,
                EncryptKeyExtendData = extern_encrypt_data?.Length > 0 ? extern_encrypt_data : null,
                EncryptData = encrypt_data_final
            };
            return result;
        }

        public byte[] Decrypt(byte[] src, byte[] sec_ecdh_key, byte[] hash_final)
        {
            var memory = new MemoryStream();
            var ecdhkey = Ecdh.GetSharedKey(sec_ecdh_key, k => k.SHA256());
            memory.Write(hash_final);
            memory.Write("415".ToBytes());
            memory.Write(sec_ecdh_key);
            memory.Write("1".ToBytes());
            var aad = memory.ToArray().SHA256();
            var result = src.AESGCMDecrypt(ecdhkey.Take(24).ToArray(), aad).ZIPDECompress();
            return result;
        }
    }
}
