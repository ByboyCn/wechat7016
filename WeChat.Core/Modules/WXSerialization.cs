using System;

namespace WeChat.Core
{
    /// <summary>
    /// 微信序列化信息
    /// </summary>
    [Serializable]
    public class WXSerialization
    {
        /// <summary>
        /// 代理
        /// </summary>
        public WXProxy? Proxy { get; set; }
        /// <summary>
        /// 服务器
        /// </summary>
        public WXServer? Server { get; set; }
        /// <summary>
        /// 会话
        /// </summary>
        public WXSession? Session { get; set; }
        /// <summary>
        /// 缓存
        /// </summary>
        public WXCache? Cache { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public WXStatus? Status { get; set; }
        /// <summary>
        /// 个人信息
        /// </summary>
        public WXProfile? Profile { get; set; }
        /// <summary>
        /// 环境信息
        /// </summary>
        public WXEnvironment? Environment { get; set; }
    }
}
