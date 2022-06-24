using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace WeChat.Core.Libraries.Dev
{
    public static class Dev
    {
        private static List<string> _dev = new List<string>();

        static Dev()
        {
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream($"WeChat.Core.Libraries.Dev.dev.txt"))
            {
                StreamReader reader = new StreamReader(stream);
                string dev = reader?.ReadToEnd();
                _dev = dev?.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)?.ToList();
            }
        }

        public static string GetDevStr()
        {
            if (_dev?.Count > 0)
            {
                Random random = new Random();
                return _dev[random.Next(0, _dev.Count - 1)];
            }
            return "%2BZ3VASQ5V0k1aUlhPB5Q1DtcH3TXBb7mdjPHDeJzCKb9OQLPyzGyDXiWI87uzeTT6ZtBYcEdJBg1Y4OM5VtTtlYg76TmBGanxWwuipJWlpjozqZGk7Pepsjx5tDJKL8bePNUkcl0Z5pu";
        }
    }
}
