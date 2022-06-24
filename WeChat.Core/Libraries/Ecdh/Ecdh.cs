using System.Linq;
using System.Numerics;

namespace System
{
    public enum CurveType
    {
        Prime256v1 = 415,
        SecP192k1 = 711,
        SecP224k1 = 712,
        SecP224r1 = 713
    }

    internal class BigIntPoint
    {
        public BigInteger X;
        public BigInteger Y;
    }

    internal class CurveDef
    {
        internal int KeySize;
        internal BigInteger A;
        internal BigInteger B;
        internal BigIntPoint G;
        internal BigInteger Prime = BigInteger.Zero;

        internal CurveDef(CurveType type)
        {
            switch (type)
            {
                case CurveType.Prime256v1:
                    {
                        this.KeySize = 32;
                        this.Prime = BigInteger.Parse("115792089210356248762697446949407573530086143415290314195533631308867097853951");
                        this.A = BigInteger.Parse("115792089210356248762697446949407573530086143415290314195533631308867097853948");
                        this.B = BigInteger.Parse("41058363725152142129326129780047268409114441015993725554835256314039467401291");
                        this.G = new BigIntPoint
                        {
                            X = BigInteger.Parse("48439561293906451759052585252797914202762949526041747995844080717082404635286"),
                            Y = BigInteger.Parse("36134250956749795798585127919587881956611106672985015071877198253568414405109")
                        };
                        break;
                    }
                case CurveType.SecP192k1:
                    {
                        this.KeySize = 24;
                        this.Prime = BigInteger.Parse("6277101735386680763835789423207666416102355444459739541047");
                        this.A = 0;
                        this.B = 3;
                        this.G = new BigIntPoint
                        {
                            X = BigInteger.Parse("5377521262291226325198505011805525673063229037935769709693"),
                            Y = BigInteger.Parse("3805108391982600717572440947423858335415441070543209377693")
                        };
                        break;
                    }
                case CurveType.SecP224k1:
                    {
                        this.KeySize = 28;
                        this.Prime = BigInteger.Parse("26959946667150639794667015087019630673637144422540572481099315275117");
                        this.A = 0;
                        this.B = 5;
                        this.G = new BigIntPoint
                        {
                            X = BigInteger.Parse("16983810465656793445178183341822322175883642221536626637512293983324"),
                            Y = BigInteger.Parse("13272896753306862154536785447615077600479862871316829862783613755813")
                        };
                        break;
                    }
                case CurveType.SecP224r1:
                    {
                        this.KeySize = 28;
                        this.Prime = BigInteger.Parse("26959946667150639794667015087019630673557916260026308143510066298881");
                        this.A = BigInteger.Parse("26959946667150639794667015087019630673557916260026308143510066298878");
                        this.B = BigInteger.Parse("18958286285566608000408668544493926415504680968679321075787234672564");
                        this.G = new BigIntPoint
                        {
                            X = BigInteger.Parse("19277929113566293071110308034699488026831934219452440156649784352033"),
                            Y = BigInteger.Parse("19926808758034470970197974370888749184205991990603949537637343198772")
                        };
                        break;
                    }
                default:
                    break;
            }
        }
    }

    public class ECDH
    {
        public delegate byte[] KeyDeriveFunction(byte[] input);

        private CurveDef Curve;
        private Random Rng;

        public byte[] PrivateKey { get; }
        public byte[] PublicKey { get; }

        public ECDH(CurveType type)
        {
            Curve = new CurveDef(type);
            Rng = new Random();

            PrivateKey = new byte[Curve.KeySize];
            Rng.NextBytes(PrivateKey);
            PrivateKey[Curve.KeySize - 1] = 0;

            var myPublicKey = ScalarMult(Curve, ToBigInteger(Curve, PrivateKey), Curve.G);
            var x = ToByteArray(Curve, myPublicKey.X);
            PublicKey = new byte[Curve.KeySize * 2 + 1];
            Buffer.BlockCopy(x, 0, PublicKey, Curve.KeySize + 1 - x.Length, x.Length);
            var y = ToByteArray(Curve, myPublicKey.Y);
            Buffer.BlockCopy(y, 0, PublicKey, Curve.KeySize * 2 + 1 - y.Length, y.Length);
            PublicKey[0] = 0x04;
        }

        public static byte[] GetSharedKey(CurveType type, byte[] publicKey, byte[] privateKey, KeyDeriveFunction kdf = null)
        {
            var curve = new CurveDef(type);
            var publicKeyX = new byte[curve.KeySize + 1];
            Buffer.BlockCopy(publicKey, 1, publicKeyX, 1, curve.KeySize);
            var publicKeyY = new byte[curve.KeySize + 1];
            Buffer.BlockCopy(publicKey, curve.KeySize + 1, publicKeyY, 1, curve.KeySize);
            var publick = new BigIntPoint
            {
                X = new BigInteger(publicKeyX.Reverse().ToArray()),
                Y = new BigInteger(publicKeyY.Reverse().ToArray())
            };
            var mySharedSecret = ToByteArray(curve, ScalarMult(curve, ToBigInteger(curve, privateKey), publick).X);
            return (kdf == null) ? mySharedSecret : kdf(mySharedSecret);
        }

        private static byte[] ToByteArray(CurveDef curve, BigInteger i)
        {
            var value = i.ToByteArray().Reverse().ToArray();
            if (value.Length == curve.KeySize)
            {
                return value;
            }
            if (value.Length == curve.KeySize + 1 && value[0] == 0)
            {
                return value.Skip(1).ToArray();
            }
            if (value.Length == curve.KeySize - 1)
            {
                var data = value.ToList();
                data.Insert(0, 0);
                return data.ToArray();
            }
            throw new Exception("密钥长度错误");
        }

        private static BigInteger InverseMod(BigInteger k, BigInteger p)
        {
            if (k == 0)
            {
                throw new DivideByZeroException();
            }

            if (k < 0)
            {
                return p - InverseMod(-k, p);
            }

            (BigInteger s, BigInteger oldS) = (0, 1);
            (BigInteger t, BigInteger oldT) = (1, 0);
            var (r, oldR) = (p, k);
            while (r != 0)
            {
                var quotient = oldR / r;
                (oldR, r) = (r, oldR - quotient * r);
                (oldS, s) = (s, oldS - quotient * s);
                (oldT, t) = (t, oldT - quotient * t);
            }

            return Mod(oldS, p);
        }

        private static BigIntPoint PointAdd(CurveDef curve, BigIntPoint p1, BigIntPoint p2)
        {
            if (p1 == null)
            {
                return p2;
            }

            if (p2 == null)
            {
                return p1;
            }

            if (p1.X == p2.X && p1.Y != p2.Y)
            {
                return null;
            }

            var m = p1.X == p2.X
                ? (3 * p1.X * p1.X + curve.A) * InverseMod(2 * p1.Y, curve.Prime)
                : (p1.Y - p2.Y) * InverseMod(p1.X - p2.X, curve.Prime);
            var x3 = m * m - p1.X - p2.X;
            var y3 = p1.Y + m * (x3 - p1.X);
            return new BigIntPoint
            {
                X = Mod(x3, curve.Prime),
                Y = Mod(-y3, curve.Prime)
            };
        }

        private static BigIntPoint ScalarMult(CurveDef curve, BigInteger k, BigIntPoint point)
        {
            if (k < 0)
            {
                return ScalarMult(curve, -k, new BigIntPoint
                {
                    X = point.X,
                    Y = Mod(-point.Y, curve.Prime)
                });
            }

            BigIntPoint result = null;
            var addend = point;

            while (k != 0)
            {
                if ((k & 1) == 1)
                {
                    result = PointAdd(curve, result, addend);
                }

                addend = PointAdd(curve, addend, addend);
                k >>= 1;
            }

            return result;
        }

        private static BigInteger Mod(BigInteger a, BigInteger b)
        {
            var result = a % b;
            if (result < 0)
            {
                result += b;
            }

            return result;
        }

        private static BigInteger ToBigInteger(CurveDef curve, byte[] array)
        {
            var newarray = new byte[curve.KeySize + 1];
            Buffer.BlockCopy(array, 0, newarray, 1, curve.KeySize);
            newarray = newarray.Reverse().ToArray();
            return new BigInteger(newarray);
        }
    }
}
