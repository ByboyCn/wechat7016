namespace System
{
    public static partial class ArrayExtensions
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static T[] Resize<T>(this T[] array, int size)
        {
            Array.Resize(ref array, size);
            return array;
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <returns></returns>
        public static T[] Copy<T>(this T[] array)
        {
            return array.Copy(0L, array.LongLength);
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static T[] Copy<T>(this T[] array, int length)
        {
            return array.Copy(0, length);
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static T[] Copy<T>(this T[] array, long length)
        {
            return array.Copy(0L, length);
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static T[] Copy<T>(this T[] array, int index, int length)
        {
            return array.Copy((long)index, (long)length);
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static T[] Copy<T>(this T[] array, long index, long length)
        {
            T[] array2 = new T[length];
            Array.Copy(array, index, array2, 0L, length);
            return array2;
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <returns></returns>
        public static T[] ReverseCopy<T>(this T[] array)
        {
            return array.ReverseCopy(array.LongLength - 1, array.LongLength);
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static T[] ReverseCopy<T>(this T[] array, int length)
        {
            return array.ReverseCopy(length - 1, length);
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static T[] ReverseCopy<T>(this T[] array, long length)
        {
            return array.ReverseCopy(length - 1, length);
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static T[] ReverseCopy<T>(this T[] array, int index, int length)
        {
            return array.ReverseCopy((long)index, (long)length);
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static T[] ReverseCopy<T>(this T[] array, long index, long length)
        {
            T[] array2 = new T[length];
            for (int i = 0; i < length; i++)
            {
                T[] array3 = array2;
                int num = i;
                long num2 = index;
                index = num2 - 1;
                array3[num] = array[num2];
            }
            return array2;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static T[] Reverse<T>(this T[] array)
        {
            Array.Reverse(array);
            return array;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static T[] Reverse<T>(this T[] array, int index, int count)
        {
            Array.Reverse(array, index, count);
            return array;
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int IndexOf<T>(this T[] array, T[] value)
        {
            return IndexOf(array, value, 0, array.Length);
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="value"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public static int IndexOf<T>(this T[] array, T[] value, ref int[] next)
        {
            return array.IndexOf(value, 0, array.Length, ref next);
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="value"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static int IndexOf<T>(this T[] array, T[] value, int index)
        {
            return IndexOf(array, value, index, array.Length - index);
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="value"></param>
        /// <param name="index"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public static int IndexOf<T>(this T[] array, T[] value, int index, ref int[] next)
        {
            return array.IndexOf(value, index, array.Length - index, ref next);
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="value"></param>
        /// <param name="index"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static int IndexOf<T>(this T[] array, T[] value, int index, int count)
        {
            int[] next = null;
            return array.IndexOf(value, index, count, ref next);
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="value"></param>
        /// <param name="index"></param>
        /// <param name="count"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public static int IndexOf<T>(this T[] array, T[] value, int index, int count, ref int[] next)
        {
            int num = 0;
            int num2 = -1;
            if (next == null)
            {
                next = new int[value.Length];
                next[0] = -1;
                while (num < value.Length - 1)
                {
                    if (num2 == -1 || Array.IndexOf(value, value[num], num2, 1) >= 0)
                    {
                        if (Array.IndexOf(value, value[++num], ++num2, 1) >= 0)
                        {
                            next[num] = next[num2];
                        }
                        else
                        {
                            next[num] = num2;
                        }
                    }
                    else
                    {
                        num2 = next[num2];
                    }
                }
            }
            num = index;
            num2 = 0;
            while (num < index + count && num2 < value.Length)
            {
                if (num2 == -1 || Array.IndexOf(array, value[num2], num, 1) >= 0)
                {
                    num++;
                    num2++;
                }
                else
                {
                    num2 = next[num2];
                }
            }
            if (num2 < value.Length)
            {
                return -1;
            }
            return num - value.Length;
        }
    }
}
