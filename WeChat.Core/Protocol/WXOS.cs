using System;

namespace WeChat.Core.Protocol
{
    /// <summary>
    /// 微信系统
    /// </summary>
    public enum WXOS
    {
        /// <summary>
        /// Android系统
        /// </summary>
        [WXOS("A", "\0")]
        ANDROID,
        /// <summary>
        /// IOS系统
        /// </summary>
        [WXOS("62706c6973743030d4010203040506090a582476657273696f6e58246f626a65637473592461726368697665725424746f7012000186a0a2070855246e756c6c5f1020", "5f100f4e534b657965644172636869766572d10b0c54726f6f74800108111a232d32373a406375787d0000000000000101000000000000000d0000000000000000000000000000007f")]
        IOS,
        /// <summary>
        /// IMAC系统
        /// </summary>
        [WXOS("", "")]
        IMAC,
        /// <summary>
        /// WINDOWS系统
        /// </summary>
        [WXOS("", "")]
        WINDOWS
    }
    /// <summary>
    /// 微信系统特性标记
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class WXOSAttribute : Attribute
    {
        /// <summary>
        /// 微信数据前缀
        /// </summary>
        public string WXDataPrefix { get; }
        /// <summary>
        /// 微信数据后缀
        /// </summary>
        public string WXDataSuffix { get; }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="wx_data_prefix"></param>
        /// <param name="wx_data_suffix"></param>
        public WXOSAttribute(string wx_data_prefix, string wx_data_suffix)
        {
            WXDataPrefix = wx_data_prefix;
            WXDataSuffix = wx_data_suffix;
        }
    }
    /// <summary>
    /// 微信系统扩展
    /// </summary>
    public static class WXOSExtensions
    {
        /// <summary>
        /// 获取微信数据前缀
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static string GetWXDataPrefix(this WXOS target)
        {
            var result = default(string);
            var attris = target.GetType().GetField(target.ToString()).GetCustomAttributes(typeof(WXOSAttribute), true);
            if (attris != null && attris.Length > 0)
            {
                WXOSAttribute coAttrs = attris[0] as WXOSAttribute;
                result = coAttrs.WXDataPrefix;
            }
            return result;
        }
        /// <summary>
        /// 获取微信数据后缀
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static string GetWXDataSuffix(this WXOS target)
        {
            var result = default(string);
            var attris = target.GetType().GetField(target.ToString()).GetCustomAttributes(typeof(WXOSAttribute), true);
            if (attris != null && attris.Length > 0)
            {
                WXOSAttribute coAttrs = attris[0] as WXOSAttribute;
                result = coAttrs.WXDataSuffix;
            }
            return result;
        }
    }
}
