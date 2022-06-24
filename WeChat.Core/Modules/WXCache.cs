using System;
using WeChat.Core.Protocol;

namespace WeChat.Core
{
    /// <summary>
    /// 微信缓存
    /// </summary>
    [Serializable]
    public struct WXCache
    {
        /// <summary>
        /// 终端
        /// </summary>
        public WXTerminal Terminal;
        /// <summary>
        /// 上报CCD上下文值
        /// </summary>
        public int ReportCcdContext;
        /// <summary>
        /// 场景
        /// </summary>
        public int Scene;
        /// <summary>
        /// 用户编号
        /// </summary>
        public uint Uin;
        /// <summary>
        /// 会话Cookie
        /// </summary>
        public string Cookie;
        /// <summary>
        /// ECDH共享密钥
        /// </summary>
        public byte[] EcdhKey;
        /// <summary>
        /// Hybrid ECDH 公钥
        /// </summary>
        public byte[] HybridEcdhPubKey;
        /// <summary>
        /// Hybrid ECDH 私钥
        /// </summary>
        public byte[] HybridEcdhPriKey;
        /// <summary>
        /// 同步密钥
        /// </summary>
        public byte[] SyncKey;
        /// <summary>
        /// 会话密钥
        /// </summary>
        public byte[] SessionKey;
        /// <summary>
        /// 客户端会话密钥
        /// </summary>
        public byte[] ClientSessionKey;
        /// <summary>
        /// 服务端会话密钥
        /// </summary>
        public byte[] ServerSessionKey;
        /// <summary>
        /// 自动登陆Token
        /// </summary>
        public byte[] AutoAuthToken;
        /// <summary>
        /// 自动登陆票据
        /// </summary>
        public string AutoAuthTicket;
    }
}
