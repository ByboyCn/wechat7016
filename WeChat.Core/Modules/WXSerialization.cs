using System;

namespace WeChat.Core
{
    /// <summary>
    /// 微信序列化信息
    /// </summary>
    [Serializable]
    public struct WXSerialization
    {
        /// <summary>
        /// 代理
        /// </summary>
        public WXProxy Proxy;
        /// <summary>
        /// 服务器
        /// </summary>
        public WXServer Server;
        /// <summary>
        /// 会话
        /// </summary>
        public WXSession Session;
        /// <summary>
        /// 缓存
        /// </summary>
        public WXCache Cache;
        /// <summary>
        /// 状态
        /// </summary>
        public WXStatus Status;
        /// <summary>
        /// 个人信息
        /// </summary>
        public WXProfile Profile;
        /// <summary>
        /// 环境信息
        /// </summary>
        public WXEnvironment Environment;
    }
}
