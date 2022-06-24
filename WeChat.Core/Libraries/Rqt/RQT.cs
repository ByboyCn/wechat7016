using System.IO;
using System.Reflection;

namespace System
{
    public static class RQT
    {
        static RQT()
        {
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream($"WeChat.Core.Libraries.Rqt.rqt.dat"))
            {
                var content = new byte[stream.Length];
                stream.Read(content, 0, content.Length);
            }
        }

        /// <summary>
        /// RQT签名
        /// </summary>
        /// <param name="md5"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private static int SignRqtBufByAutoChosenKey(string md5, byte[] key)
        {
            var hashmessage = md5.ToBytes().HMACSHA1(key);
            int temp0 = 0, temp1 = 0, temp2 = 0;
            for (int i = 0; i + 2 < 20; i++)
            {
                temp0 = (temp0 & 0xff) * 0x83 + hashmessage[i];
                temp1 = (temp1 & 0xff) * 0x83 + hashmessage[i + 1];
                temp2 = (temp2 & 0xff) * 0x83 + hashmessage[i + 2];
            }
            var result = (temp2 << 16) & 0x7f0000 | temp0 & 0x7f | (1 & 0x1f | 0x20) << 24 | ((temp1 & 0x7f) << 8);
            return result;
        }

        /// <summary>
        /// RQT签名
        /// </summary>
        /// <param name="body">包体</param>
        /// <returns></returns>
        public static int SignRqt(this byte[] body)
        {
            var key = "6a664d5d537c253f736e48273a295e4f";
            return SignRqtBufByAutoChosenKey(body.MD5().ToString(16, 2).ToLower(), key.ToByteArray(16, 2));
        }
    }
}
