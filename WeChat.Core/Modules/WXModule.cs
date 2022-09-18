using System;
using System.ComponentModel;
using System.Net;
using System.Threading.Tasks;
using WeChat.Core.Protocol;
using WeChat.Core.Protocol.Protos.V2;

namespace WeChat.Core
{
    /// <summary>
    /// 微信代理
    /// </summary>
    [Serializable]
    public class WXProxy
    {
        #region 属性
        /// <summary>
        /// 开关
        /// </summary>
        [DefaultValue(false)]
        public bool Enable;
        /// <summary>
        /// 地址
        /// </summary>
        public string Address;
        /// <summary>
        /// 端口
        /// </summary>
        public int Port;
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName;
        /// <summary>
        /// 密码
        /// </summary>
        public string Password;
        #endregion

        #region 接口
        /// <summary>
        /// 转换成WebProxy
        /// </summary>
        /// <returns></returns>
        public IWebProxy ToWebProxy()
        {
            var result = default(WebProxy);
            if (!Enable) { return null; }
            result = new WebProxy(Address, Port);
            if (!UserName.IsEmpty() || !Password.IsEmpty()) { result.Credentials = new NetworkCredential(UserName, Password); }
            return result;
        }

        /// <summary>
        /// 转换成ProxyIP:Port
        /// </summary>
        /// <returns></returns>
        public string ToStrProxy()
        {
            if (!Enable) { return ""; }
            return $"{Address}:{Port}";
        }
        #endregion
    }
    /// <summary>
    /// 微信服务器
    /// </summary>
    [Serializable]
    public class WXServer
    {
        /// <summary>
        /// 长链服务器地址
        /// </summary>
        public string LongServerAddress;
        /// <summary>
        /// 长链服务器端口
        /// </summary>
        public int LongServerPort;
        /// <summary>
        /// 短链服务器地址
        /// </summary>
        public string ShortServerAddress;
        /// <summary>
        /// 短链服务器端口
        /// </summary>
        public int ShortServerPort;
    }
    /// <summary>
    /// 微信包
    /// </summary>
    public struct WXPacket
    {
        /// <summary>
        /// 包头
        /// </summary>
        public WXPacketHead Head;
        /// <summary>
        /// 包体
        /// </summary>
        public byte[] Body;
    }
    /// <summary>
    /// 微信包头
    /// </summary>
    public struct WXPacketHead
    {
        /// <summary>
        /// CGI
        /// </summary>
        public int CGI;
        /// <summary>
        /// 是否压缩
        /// </summary>
        public bool Ziped;
        /// <summary>
        /// 解密类型(RSA:7,AES:5)
        /// </summary>
        public int Decrypt;
        /// <summary>
        /// Uin
        /// </summary>
        public uint Uin;
        /// <summary>
        /// Cookie
        /// </summary>
        public string Cookie;
        /// <summary>
        /// 版本
        /// </summary>
        public int Version;
    }
    /// <summary>
    /// 微信连接接口
    /// </summary>
    public interface IWXLinker
    {
        /// <summary>
        /// 微信服务器
        /// </summary>
        WXServer Server { get; }
        /// <summary>
        /// 微信会话
        /// </summary>
        WXSession Session { get; }
        /// <summary>
        /// 微信代理
        /// </summary>
        WXProxy Proxy { get; set; }

        /// <summary>
        /// 初始化会话
        /// </summary>
        /// <returns></returns>
        Task<bool> InitSession();
        /// <summary>
        /// 重定向
        /// </summary>
        /// <param name="network"></param>
        /// <returns></returns>
        Task Redirect(NetworkSectResp network);
        /// <summary>
        /// 请求
        /// </summary>
        /// <param name="data"></param>
        /// <param name="cgi"></param>
        /// <returns></returns>
        Task<byte[]> Request(byte[] data, WXCGIUrl cgi);
    }
}
