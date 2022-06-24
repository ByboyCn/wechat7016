using System.Collections.Generic;

namespace System
{
    public static partial class UInt32Extension
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="value"></param>
        /// <param name="radix"></param>
        /// <returns></returns>
        public static string ToString(this uint value, int radix)
        {
            return UInt64Extensions.ToString(value, radix);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="value"></param>
        /// <param name="endian"></param>
        /// <returns></returns>
        public static byte[] ToByteArray(this uint value, Endian endian)
        {
            if (endian == Endian.Little)
                return new byte[4] { (byte)value, (byte)(value >> 8), (byte)(value >> 16), (byte)(value >> 24) };
            return new byte[4] { (byte)(value >> 24), (byte)(value >> 16), (byte)(value >> 8), (byte)value };
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static uint Reverse(this uint value)
        {
            uint num = 0u;
            for (int i = 0; i < 32; i++)
            {
                num <<= 1;
                num |= (value & 1);
                value >>= 1;
            }
            return num;
        }

        public static byte[] ToVariant(this uint value)
        {
            var result = new List<byte>();
            while (value >= 0x80)
            {
                result.Add((byte)(0x80 + (value & 0x7f)));
                value = value >> 7;
            }
            result.Add((byte)value);
            return result.ToArray();
        }
    }
}
