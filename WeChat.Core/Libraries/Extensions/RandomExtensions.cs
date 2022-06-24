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
        ///��������ַ���
        ///</summary>
        ///<param name="length">Ŀ���ַ����ĳ���</param>
        ///<param name="custom">Ҫ�������Զ����ַ���ֱ������Ҫ�������ַ��б�</param>
        ///<param name="useNum">�Ƿ�������֣�1=������Ĭ��Ϊ����</param>
        ///<param name="useLow">�Ƿ����Сд��ĸ��1=������Ĭ��Ϊ����</param>
        ///<param name="useUpp">�Ƿ������д��ĸ��1=������Ĭ��Ϊ����</param>
        ///<param name="useSpe">�Ƿ���������ַ���1=������Ĭ��Ϊ������</param>
        ///<returns>ָ�����ȵ�����ַ���</returns>
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
        /// �������MAC��ַ
        /// </summary>
        /// <returns></returns>
        public static string CreateRandomMacAddress(this Random random)
        {
            return $"{random.Next(0, 255):X2}:{random.Next(0, 255):X2}:{random.Next(0, 255):X2}:{random.Next(0, 255):X2}:{random.Next(0, 255):X2}:{random.Next(0, 255):X2}";
        }
    }
}
