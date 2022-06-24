using System;

namespace WeChat.Core
{
    /// <summary>
    /// 微信加密类型
    /// </summary>
    public enum WXEncode
    {
        /// <summary>
        /// 无
        /// </summary>
        None = 0,
        /// <summary>
        /// RSA
        /// </summary>
        RSA = 7,
        /// <summary>
        /// AES
        /// </summary>
        AES = 5,
        /// <summary>
        /// HyBridEcdh-12
        /// </summary>
        HYBRID_ECDH = 12,
        /// <summary>
        /// AESGCM-13
        /// </summary>
        AESGCM = 13
    }
    /// <summary>
    /// 微信编码特性标记
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class WXEncodeAttribute : Attribute
    {
        /// <summary>
        /// 编码
        /// </summary>
        public WXEncode Encode { get; }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="encode"></param>
        public WXEncodeAttribute(WXEncode encode) { Encode = encode; }
    }
}
