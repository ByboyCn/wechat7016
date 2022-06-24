using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Xml;

namespace System
{
    public static partial class StringExtensions
    {
        /// <summary>
        /// 是否是空
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsEmpty(this string value) => string.IsNullOrEmpty(value);
        /// <summary>
        /// json字符串转JObject
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static JObject ToJObject(this string value) => string.IsNullOrEmpty(value) ? null : JObject.Parse(value);
        /// <summary>
        /// 将json字符串反序列化成对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T ToJObject<T>(this string value)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(value);
            }
            catch (Exception)
            {
                return default(T);
            }
        }
        /// <summary>
        /// 计算MD5
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string MD5(this string value)
        {
            if (string.IsNullOrEmpty(value)) { return ""; }
            return Security.Cryptography.MD5.Create().ComputeHash(value.ToBytes(Encoding.UTF8)).ToString(16, 2);
        }
        /// <summary>
        /// 以指定编码获取字节集，默认UTF8
        /// </summary>
        /// <param name="value"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static byte[] ToBytes(this string value, Encoding encoding = null)
        {
            if (string.IsNullOrEmpty(value)) { return new byte[0] { }; }
            if (encoding == null) { encoding = Encoding.UTF8; }
            return encoding.GetBytes(value);
        }
        /// <summary>
        /// 取两个指定字符串中间的字符串
        /// </summary>
        /// <param name="value"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static string Between(this string value, string left, string right)
        {
            //Regex rg = new Regex("(?<=(" + left + "))[.\\s\\S]*?(?=(" + right + "))", RegexOptions.Multiline | RegexOptions.Singleline);
            //return rg.Match(value).Value;
            if (string.IsNullOrEmpty(value))
            {
                return "";
            }
            string result = string.Empty;
            int startindex, endindex;
            try
            {
                startindex = value.IndexOf(left);
                if (startindex == -1)
                    return result;
                string tmpstr = value.Substring(startindex + left.Length);
                endindex = tmpstr.IndexOf(right);
                if (endindex == -1)
                    return result;
                result = tmpstr.Remove(endindex);
            }
            catch (Exception ex)
            {
                //result = value;
                Diagnostics.Debug.WriteLine($"{ex.Message}\r\n{ex.StackTrace}");
            }
            return result;
        }
        public static string Substring(this string value, string start, int length)
        {
            if (string.IsNullOrEmpty(value))
            {
                return "";
            }
            string result = string.Empty;
            try
            {
                int startIndex = value.IndexOf(start);
                if (startIndex <= -1)
                {
                    return result;
                }
                result = value.Substring(startIndex + start.Length, length);
            }
            catch (Exception ex)
            {
                //result = value;
                Diagnostics.Debug.WriteLine($"{ex.Message}\r\n{ex.StackTrace}");
            }
            return result;
        }
        /// <summary>
        /// Base64编码
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Base64Encode(this string value)
        {
            if (string.IsNullOrEmpty(value)) { return string.Empty; }
            try
            {
                return Convert.ToBase64String(Encoding.UTF8.GetBytes(value));
            }
            catch { return string.Empty; }
        }

        /// <summary>
        /// Base64解码
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] Base64Decode(this string value)
        {
            if (string.IsNullOrEmpty(value)) { return null; }
            try
            {
                return Convert.FromBase64String(value);
            }
            catch { return null; }
        }

        public static string GetXmlNodeInnerText(this string value, string xpath)
        {
            XmlNode node = null; XmlDocument doc = new XmlDocument();
            value = value?.Substring(Math.Max(0, value?.IndexOf("<e>") ?? 0));
            try { doc.LoadXml(value); } catch { }
            try { node = doc.SelectSingleNode(xpath); } catch { }
            return node?.InnerText ?? "";
        }
        public static string GetXmlNodeProperty(this string value, string xpath, string name)
        {
            XmlNode node = null; XmlDocument doc = new XmlDocument();
            value = value?.Substring(Math.Max(0, value?.IndexOf("<e>") ?? 0));
            try { doc.LoadXml(value); } catch { }
            try { node = doc.SelectSingleNode(xpath); } catch { }
            return node?.Attributes?[name]?.Value ?? "";
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string value)
        {
            if (DateTime.TryParse(value, out DateTime result))
            {
                return result;
            }
            return default;
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="value"></param>
        /// <param name="provider"></param>
        /// <param name="style"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string value, IFormatProvider provider, DateTimeStyles style)
        {
            if (DateTime.TryParse(value, provider, style, out DateTime result))
            {
                return result;
            }
            return default;
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="value"></param>
        /// <param name="format"></param>
        /// <param name="provider"></param>
        /// <param name="style"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string value, string format, IFormatProvider provider, DateTimeStyles style)
        {
            if (DateTime.TryParseExact(value, format, provider, style, out DateTime result))
            {
                return result;
            }
            return default;
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="value"></param>
        /// <param name="formats"></param>
        /// <param name="provider"></param>
        /// <param name="style"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string value, string[] formats, IFormatProvider provider, DateTimeStyles style)
        {
            if (DateTime.TryParseExact(value, formats, provider, style, out DateTime result))
            {
                return result;
            }
            return default;
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static decimal ToDecimal(this string value)
        {
            if (decimal.TryParse(value, out decimal result))
            {
                return result;
            }
            return 0;
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="value"></param>
        /// <param name="style"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static decimal ToDecimal(this string value, NumberStyles style, IFormatProvider provider)
        {
            if (decimal.TryParse(value, style, provider, out decimal result))
            {
                return result;
            }
            return 0;
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double ToDouble(this string value)
        {
            if (double.TryParse(value, out double result))
            {
                return result;
            }
            return 0;
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="value"></param>
        /// <param name="style"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static double ToDouble(this string value, NumberStyles style, IFormatProvider provider)
        {
            if (double.TryParse(value, style, provider, out double result))
            {
                return result;
            }
            return 0;
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ulong ToUInt64(this string value)
        {
            if (ulong.TryParse(value, out ulong result))
            {
                return result;
            }
            return 0;
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="value"></param>
        /// <param name="style"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static ulong ToUInt64(this string value, NumberStyles style, IFormatProvider provider)
        {
            if (ulong.TryParse(value, style, provider, out ulong result))
            {
                return result;
            }
            return 0;
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static long ToInt64(this string value)
        {
            if (long.TryParse(value, out long result))
            {
                return result;
            }
            return 0;
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="value"></param>
        /// <param name="style"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static long ToInt64(this string value, NumberStyles style, IFormatProvider provider)
        {
            if (long.TryParse(value, style, provider, out long result))
            {
                return result;
            }
            return 0;
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static uint ToUInt32(this string value)
        {
            if (uint.TryParse(value, out uint result))
            {
                return result;
            }
            return 0;
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="value"></param>
        /// <param name="style"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static uint ToUInt32(this string value, NumberStyles style, IFormatProvider provider)
        {
            if (uint.TryParse(value, style, provider, out uint result))
            {
                return result;
            }
            return 0;
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int? ToInt32(this string value)
        {
            if (int.TryParse(value, out int result))
            {
                return result;
            }
            return null;
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="value"></param>
        /// <param name="style"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static int ToInt32(this string value, NumberStyles style, IFormatProvider provider)
        {
            if (int.TryParse(value, style, provider, out int result))
            {
                return result;
            }
            return 0;
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ushort ToUInt16(this string value)
        {
            if (ushort.TryParse(value, out ushort result))
            {
                return result;
            }
            return 0;
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="value"></param>
        /// <param name="style"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static ushort ToUInt16(this string value, NumberStyles style, IFormatProvider provider)
        {
            if (ushort.TryParse(value, style, provider, out ushort result))
            {
                return result;
            }
            return 0;
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static short ToInt16(this string value)
        {
            if (short.TryParse(value, out short result))
            {
                return result;
            }
            return 0;
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="value"></param>
        /// <param name="style"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static short ToInt16(this string value, NumberStyles style, IFormatProvider provider)
        {
            if (short.TryParse(value, style, provider, out short result))
            {
                return result;
            }
            return 0;
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte ToByte(this string value)
        {
            if (byte.TryParse(value, out byte result))
            {
                return result;
            }
            return 0;
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="value"></param>
        /// <param name="style"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static byte ToByte(this string value, NumberStyles style, IFormatProvider provider)
        {
            if (byte.TryParse(value, style, provider, out byte result))
            {
                return result;
            }
            return 0;
        }
        /// <summary>
        /// 将数字字符串转换为64位无符号整数
        /// </summary>
        /// <param name="value"></param>
        /// <param name="radix">字符串中数字的基数，必须为2 ~ 36</param>
        /// <returns></returns>
        public static ulong ToUInt64(this string value, int radix)
        {
            ulong num = 0uL;
            foreach (char c in value)
            {
                int num2;
                if (c >= '0' && c <= '9')
                {
                    num2 = c - 48;
                }
                else if (c >= 'a' && c <= 'z')
                {
                    num2 = 10 + c - 97;
                }
                else
                {
                    if (c < 'A' || c > 'Z')
                    {
                        return 0;
                    }
                    num2 = 10 + c - 65;
                }
                if (num2 >= radix)
                {
                    return 0;
                }
                num = (ulong)((long)num * (long)radix);
                num = (ulong)((long)num + (long)num2);
            }
            return num;
        }
        /// <summary>
        /// 将数字字符串转换为64位有符号整数
        /// </summary>
        /// <param name="value"></param>
        /// <param name="radix"></param>
        /// <returns></returns>
        public static long ToInt64(this string value, int radix)
        {
            return (long)value.ToUInt64(radix);
        }
        /// <summary>
        /// 将数字字符串转换为32位无符号整数
        /// </summary>
        /// <param name="value"></param>
        /// <param name="radix">字符串中数字的基数，必须为2 ~ 36</param>
        /// <returns></returns>
        public static uint ToUInt32(this string value, int radix)
        {
            return (uint)value.ToUInt64(radix);
        }
        /// <summary>
        /// 将数字字符串转换为32位有符号整数
        /// </summary>
        /// <param name="value"></param>
        /// <param name="radix">字符串中数字的基数，必须为2 ~ 36</param>
        /// <returns></returns>
        public static int ToInt32(this string value, int radix)
        {
            return (int)value.ToUInt64(radix);
        }
        /// <summary>
        /// 将数字字符串转换为16位无符号整数
        /// </summary>
        /// <param name="value"></param>
        /// <param name="radix">字符串中数字的基数，必须为2 ~ 36</param>
        /// <returns></returns>
        public static ushort ToUInt16(this string value, int radix)
        {
            return (ushort)value.ToUInt64(radix);
        }
        /// <summary>
        /// 将数字字符串转换为16位有符号整数
        /// </summary>
        /// <param name="value"></param>
        /// <param name="radix">字符串中数字的基数，必须为2 ~ 36</param>
        /// <returns></returns>
        public static short ToInt16(this string value, int radix)
        {
            return (short)value.ToUInt64(radix);
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="value"></param>
        /// <param name="radix"></param>
        /// <returns></returns>
        public static byte ToByte(this string value, int radix)
        {
            return (byte)value.ToUInt64(radix);
        }
        /// <summary>
        /// 将指定进制字符串转换为等效字节数组
        /// </summary>
        /// <param name="value"></param>
        /// <param name="radix">字符串中数字的基数，必须为2 ~ 36</param>
        /// <param name="width">每个字节占用的字符长度</param>
        /// <returns></returns>
        public static byte[] ToByteArray(this string value, int radix, int width)
        {
            List<byte> list = new List<byte>();
            for (int i = 0; i < (value?.Length ?? 0); i += width)
            {
                byte? b = (i + width > value.Length) ? value.Substring(i, value.Length - i).ToByte(radix) : value.Substring(i, width).ToByte(radix);
                if (!b.HasValue)
                {
                    return null;
                }
                list.Add(b.Value);
            }
            return list.ToArray();
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="value"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static string[] Split(this string value, params string[] separator)
        {
            return value.Split(separator, StringSplitOptions.None);
        }
        /// <summary>
        /// 分割
        /// </summary>
        /// <param name="value"></param>
        /// <param name="count"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static string[] Split(this string value, string[] separator, int count)
        {
            return value.Split(separator, count, StringSplitOptions.None);
        }
        /// <summary>
        /// URL编码
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string UrlEncode(this string value)
        {
            return HttpUtility.UrlEncode(value);
        }
        /// <summary>
        /// URL解码
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string UrlDecode(this string value)
        {
            return HttpUtility.UrlDecode(value);
        }
        /// <summary>
        /// 异或计算
        /// </summary>
        /// <param name="data"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Xor(this string data, byte value)
        {
            var result = new MemoryStream();
            var bytes = data.ToBytes();
            foreach (var v in bytes) { result.WriteByte((byte)(v ^ value)); }
            return result.ToArray().ToString(Encoding.UTF8);
        }
        /// <summary>
        /// 微信支付WCPaySign字段签名
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string WXPaySign(this string data)
        {
            var md5 = data.ToBytes().MD5();
            var key = "3ECA2F6FFA6D4952ABBACA5A7B067D23".ToByteArray(16, 2);
            var bcd_to_ascii = new byte[32];
            for (int i = 0; i < md5.Length; i++)
            {
                bcd_to_ascii[2 * i] = (byte)(md5[i] >> 4);
                bcd_to_ascii[2 * i + 1] = (byte)(md5[i] & 0xF);
            }
            var result = bcd_to_ascii.DES3Encrypt(key, CipherMode.ECB, PaddingMode.None);
            return result.ToString(16, 2);
        }

        public static bool IsImage(this string fileName)
        {
            bool isImage = false;
            string[] exts = { ".bmp", ".dib", ".jpg", ".jpeg", ".jpe", ".jfif", ".png", ".gif", ".tif", ".tiff" };
            if (exts.Contains(fileName.ToLower()))
            {
                isImage = true;
            }
            return isImage;
        }

        public static bool IsVideo(this string fileName)
        {
            bool isVideo = false;
            string[] exts = { "wmv", ".asf", ".asx", ".rm", ".rmvb", ".mp4 ", ".3gp", ".mov", ".m4v", ".avi", ".dat", ".mkv", ".flv", ".vob" };
            if (exts.Contains(fileName.ToLower()))
            {
                isVideo = true;
            }
            return isVideo;
        }

        public static bool IsVoice(this string fileName)
        {
            bool isVoice = false;
            string[] exts = { ".wav", ".aif", ".aiff", ".au", ".mp3", ".ra", ".rm", ".ram", ".wma", ".mmf", ".amr", ".aac", ".flac", ".snd" };
            if (exts.Contains(fileName.ToLower()))
            {
                isVoice = true;
            }
            return isVoice;
        }

        public static bool IsWxId(this string username)
        {
            bool isWxId = false;
            string[] exts = { "+", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            try
            {
                if (!exts.Contains(username?.Substring(0, 1)))
                {
                    isWxId = true;
                }
            }
            catch { isWxId = false; }
            return isWxId;
        }

        public static Dictionary<string, object> GetQueryParams(this string url)
        {
            var result = default(Dictionary<string, object>);
            var uri = new Uri(url);
            var querys = uri.Query?.Replace("?", "")?.Split('&');
            if (querys != null && querys.Length > 0)
            {
                result = new Dictionary<string, object>();
                foreach (var item in querys)
                {
                    var index = item?.IndexOf('=') ?? 0;
                    if (index > 0)
                    {
                        result.Add(item.Substring(0, index), item.Substring(index + 1));
                    }
                }
            }
            return result;
        }
    }
}
