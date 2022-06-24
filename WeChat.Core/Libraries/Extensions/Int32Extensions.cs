namespace System
{
    public static partial class Int32Extension
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="value"></param>
        /// <param name="radix"></param>
        /// <returns></returns>
        public static string ToString(this int value, int radix)
        {
            return ((ulong)value).ToString(radix);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="value"></param>
        /// <param name="endian"></param>
        /// <returns></returns>
        public static byte[] ToByteArray(this int value, Endian endian)
        {
            return ((uint)value).ToByteArray(endian);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int Reverse(this int value)
        {
            return (int)((uint)value).Reverse();
        }

        public static byte[] ToVariant(this int value)
        {
            return ((uint)value).ToVariant();
        }
    }
}
