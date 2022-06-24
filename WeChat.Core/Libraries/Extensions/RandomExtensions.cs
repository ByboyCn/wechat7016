using System.Security.Cryptography;

namespace System
{
    public static partial class RandomExtension
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="random"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static byte[] NextBytes(this Random random, int count)
        {
            byte[] array = new byte[count];
            random.NextBytes(array);
            return array;
        }

        ///<summary>
        ///创建随机字符串
        ///</summary>
        ///<param name="length">目标字符串的长度</param>
        ///<param name="custom">要包含的自定义字符，直接输入要包含的字符列表</param>
        ///<param name="useNum">是否包含数字，1=包含，默认为包含</param>
        ///<param name="useLow">是否包含小写字母，1=包含，默认为包含</param>
        ///<param name="useUpp">是否包含大写字母，1=包含，默认为包含</param>
        ///<param name="useSpe">是否包含特殊字符，1=包含，默认为不包含</param>
        ///<returns>指定长度的随机字符串</returns>
        public static string CreateRandomString(this Random random, int length = 16, string custom = "", bool useNum = true, bool useLow = true, bool useUpp = true, bool useSpe = false)
        {
            byte[] b = new byte[4];
            new RNGCryptoServiceProvider().GetBytes(b);
            random = new Random(BitConverter.ToInt32(b, 0));
            string s = null, str = custom;
            if (useNum == true) { str += "0123456789"; }
            if (useLow == true) { str += "abcdefghijklmnopqrstuvwxyz"; }
            if (useUpp == true) { str += "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; }
            if (useSpe == true) { str += "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~"; }
            for (int i = 0; i < length; i++)
            {
                s += str.Substring(random.Next(0, str.Length - 1), 1);
            }
            return s;
        }

        /// <summary>
        /// 创建随机MAC地址
        /// </summary>
        /// <returns></returns>
        public static string CreateRandomMacAddress(this Random random)
        {
            return $"{random.Next(0, 255):X2}:{random.Next(0, 255):X2}:{random.Next(0, 255):X2}:{random.Next(0, 255):X2}:{random.Next(0, 255):X2}:{random.Next(0, 255):X2}";
        }
    }
}
