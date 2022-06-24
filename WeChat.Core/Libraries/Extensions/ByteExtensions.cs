namespace System
{
    public static partial class ByteExtensions
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="value"></param>
        /// <param name="radix"></param>
        /// <returns></returns>
        public static string ToString(this byte value, int radix)
        {
            return UInt64Extensions.ToString(value, radix);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte Reverse(this byte value)
        {
            byte b = 0;
            for (int i = 0; i < 8; i++)
            {
                b = (byte)(b << 1);
                b = (byte)(b | (value & 1));
                value = (byte)(value >> 1);
            }
            return b;
        }
    }
}
