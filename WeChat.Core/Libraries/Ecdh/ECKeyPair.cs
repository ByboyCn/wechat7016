using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Tls;
using Org.BouncyCastle.Security;

namespace System
{
    public enum Curve
    {
        SecP256r1 = 415,
        SecP192k1 = 711,
        SecP224k1 = 712,
        SecP224r1 = 713
    }
    public class ECKeyPair
    {
        private static readonly SecureRandom _srnd;
        public byte[] PublicKey { get; }
        public byte[] PrivateKey { get; }
        public Curve Curve { get; }

        static ECKeyPair()
        {
            _srnd = new SecureRandom();
        }
        public ECKeyPair(Curve name)
        {
            var curve = 0;
            Curve = name;
            switch (Curve)
            {
                case Curve.SecP192k1: curve = NamedCurve.secp192k1; break;
                case Curve.SecP224k1: curve = NamedCurve.secp224k1; break;
                case Curve.SecP224r1: curve = NamedCurve.secp224r1; break;
                case Curve.SecP256r1: curve = NamedCurve.secp256r1; break;
            }
            var domain = TlsEccUtilities.GetParametersForNamedCurve(curve);
            var pair = TlsEccUtilities.GenerateECKeyPair(_srnd, domain);
            PrivateKey = ((ECPrivateKeyParameters)pair.Private).D.ToByteArray();
            PublicKey = ((ECPublicKeyParameters)pair.Public).Q.GetEncoded();
        }
        public ECKeyPair(Curve name, byte[] prikey, byte[] pubkey)
        {
            Curve = name;
            PrivateKey = prikey;
            PublicKey = pubkey;
        }
        public byte[] GetSharedKey(byte[] pubkey, Func<byte[], byte[]> kdf = null)
        {
            var curve = 0;
            switch (Curve)
            {
                case Curve.SecP192k1: curve = NamedCurve.secp192k1; break;
                case Curve.SecP224k1: curve = NamedCurve.secp224k1; break;
                case Curve.SecP224r1: curve = NamedCurve.secp224r1; break;
                case Curve.SecP256r1: curve = NamedCurve.secp256r1; break;
            }
            var domain = TlsEccUtilities.GetParametersForNamedCurve(curve);
            var public_key = TlsEccUtilities.DeserializeECPublicKey(null, domain, pubkey);
            var privte_key = new ECPrivateKeyParameters(new Org.BouncyCastle.Math.BigInteger(PrivateKey), domain);
            var result = TlsEccUtilities.CalculateECDHBasicAgreement(public_key, privte_key);
            return kdf == null ? result : kdf.Invoke(result);
        }
    }
}
