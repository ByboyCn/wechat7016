using System.Text;

namespace System
{
    public static partial class UInt64Extensions
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="value"></param>
        /// <param name="radix"></param>
        /// <returns></returns>
        public static string ToString(this ulong value, int radix)
        {
            StringBuilder stringBuilder = new StringBuilder();
            do
            {
                ulong num = value / (ulong)radix;
                ulong num2 = (ulong)((long)value - (long)num * (long)radix);
                if (num2 < 10)
                {
                    stringBuilder.Insert(0, num2);
                }
                else
                {
                    stringBuilder.Insert(0, (char)(65 + num2 - 10));
                }
                value = num;
            }
            while (value != 0);
            return stringBuilder.ToString();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="value"></param>
        /// <param name="endian"></param>
        /// <returns></returns>
        public static byte[] ToByteArray(this ulong value, Endian endian)
        {
            if (endian == Endian.Little)
            {
                return new byte[8]
                {
                (byte)value,
                (byte)(value >> 8),
                (byte)(value >> 16),
                (byte)(value >> 24),
                (byte)(value >> 32),
                (byte)(value >> 40),
                (byte)(value >> 48),
                (byte)(value >> 56)
                };
            }
            return new byte[8]
            {
            (byte)(value >> 56),
            (byte)(value >> 48),
            (byte)(value >> 40),
            (byte)(value >> 32),
            (byte)(value >> 24),
            (byte)(value >> 16),
            (byte)(value >> 8),
            (byte)value
            };
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ulong Reverse(this ulong value)
        {
            ulong num = 0uL;
            for (int i = 0; i < 64; i++)
            {
                num <<= 1;
                num |= (value & 1);
                value >>= 1;
            }
            return num;
        }
    }
}
