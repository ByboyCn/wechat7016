using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WeChat.Core.Protocol;

namespace WeChat.Core
{
    /// <summary>
    /// 微信App接口
    /// </summary>
    public partial interface IWXApp : IWXCore
    {
        /// <summary>
        /// 状态
        /// </summary>
        WXStatus Status { get; }
        /// <summary>
        /// 个人信息
        /// </summary>
        WXProfile Profile { get; }
        /// <summary>
        /// 环境信息
        /// </summary>
        WXEnvironment Environment { get; }
        /// <summary>
        /// 序列化信息
        /// </summary>
        WXSerialization Serialization { get; }
        /// <summary>
        /// HTTP GET 请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="header"></param>
        /// <param name="option"></param>
        /// <returns></returns>
        Task<HttpWebResponse> WXHttpGet(string url, IDictionary<string, string> header = null, Action<HttpWebRequest> option = null);
        /// <summary>
        /// HTTP POST 请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <param name="header"></param>
        /// <param name="option"></param>
        /// <returns></returns>
        Task<HttpWebResponse> WXHttpPost(string url, byte[] data = null, IDictionary<string, string> header = null, Action<HttpWebRequest> option = null);
        /// <summary>
        /// 验证代理IP
        /// </summary>
        /// <returns></returns>
        bool TestProxy(WXCGIUrl cgi);
    }
    /// <summary>
    /// 微信APP
    /// </summary>
    public partial class WXApp : WXCore, IWXApp
    {
        #region 字段
        /// <summary>
        /// 状态信息
        /// </summary>
        protected WXStatus _Status;
        /// <summary>
        /// 用户信息
        /// </summary>
        protected WXProfile _Profile = new WXProfile();
        /// <summary>
        /// 环境信息
        /// </summary>
        protected WXEnvironment _Environment;
        #endregion

        #region 构造函数
        /// <summary>
        /// 构建微信App
        /// </summary>
        /// <param name="linker">连接器</param>
        /// <param name="environment">环境信息</param>
        public WXApp(IWXLinker linker, WXEnvironment environment)
            : base(environment.Terminal, linker)
        {
            _Environment = environment;
        }
        /// <summary>
        /// 构建微信App
        /// </summary>
        /// <param name="linker">连接器</param>
        /// <param name="environment">环境信息</param>
        /// <param name="cache">缓存</param>
        /// <param name="profile">个人信息</param>
        public WXApp(IWXLinker linker, WXEnvironment environment, WXCache cache, WXProfile profile)
            : base(linker, cache)
        {
            _Environment = environment;
            _Profile = profile;
        }
        /// <summary>
        /// 构建微信App
        /// </summary>
        /// <param name="linker">连接器</param>
        /// <param name="environment">环境信息</param>
        /// <param name="cache">缓存</param>
        /// <param name="profile">个人信息</param>
        /// <param name="status">状态</param>
        public WXApp(IWXLinker linker, WXEnvironment environment, WXCache cache, WXProfile profile, WXStatus status)
            : base(linker, cache)
        {
            _Environment = environment;
            _Profile = profile;
            _Status = status;
        }
        #endregion

        #region 属性
        /// <summary>
        /// 获取状态
        /// </summary>
        public WXStatus Status => _Status;
        /// <summary>
        /// 获取用户概要信息
        /// </summary>
        public WXProfile Profile => _Profile;
        /// <summary>
        /// 获取环境信息
        /// </summary>
        public WXEnvironment Environment => _Environment;
        /// <summary>
        /// 获取序列化信息
        /// </summary>
        public WXSerialization Serialization => new WXSerialization
        {
            Cache = Cache,
            Status = Status,
            Profile = Profile,
            Environment = Environment,
            Proxy = Linker.Proxy,
            Server = Linker.Server,
            Session = Linker.Session
        };
        #endregion

        #region Http请求
        /// <summary>
        /// 构建GET请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="header"></param>
        /// <param name="option"></param>
        /// <returns></returns>
        public virtual async Task<HttpWebResponse> WXHttpGet(string url, IDictionary<string, string> header = null, Action<HttpWebRequest> option = null)
        {
            var response = default(WebResponse);
            var request = default(HttpWebRequest);
            try
            {
                request = WebRequest.Create(url) as HttpWebRequest;
                header?.Keys?.ToList()?.ForEach(k => request.Headers.Add(k, header[k]));
                request.Headers.Add("Keep-Alive", "115");
                request.Headers.Add("Upgrade-Insecure-Requests", "1");
                request.Headers["Accept-Language"] = "zh-CN,en-US;q=0.8";
                request.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                request.UserAgent = _Environment.WeChatUserAgent;
                request.Method = "GET";
                request.AllowAutoRedirect = false;
                request.Accept = "*/*";
                request.KeepAlive = true;
                request.Proxy = _Linker.Proxy.ToWebProxy();
                //request.Timeout = 1000 * 10;
                request.ServicePoint.ConnectionLimit = int.MaxValue;
                option?.Invoke(request);
                response = await request.GetResponseAsync();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"{ex.Message}\r\n{ex.StackTrace}");
            }
            finally
            {
                request?.Abort();
            }
            return response as HttpWebResponse;
        }

        /// <summary>
        /// 构建POST请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <param name="header"></param>
        /// <param name="option"></param>
        /// <returns></returns>
        public virtual async Task<HttpWebResponse> WXHttpPost(string url, byte[] data = null, IDictionary<string, string> header = null, Action<HttpWebRequest> option = null)
        {
            var response = default(WebResponse);
            var request = default(HttpWebRequest);
            try
            {
                request = WebRequest.Create(url) as HttpWebRequest;
                header?.Keys?.ToList()?.ForEach(k => request.Headers.Add(k, header[k]));
                request.Headers.Add("Keep-Alive", "115");
                request.Headers.Add("Upgrade-Insecure-Requests", "1");
                request.Headers["Accept-Language"] = "zh-CN,en-US;q=0.8";
                request.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                request.UserAgent = _Environment.WeChatUserAgent;
                request.Method = "POST";
                request.AllowAutoRedirect = false;
                request.Accept = "*/*";
                request.KeepAlive = true;
                request.Proxy = _Linker.Proxy.ToWebProxy();
                request.ServicePoint.Expect100Continue = false;
                request.ServicePoint.ConnectionLimit = int.MaxValue;
                option?.Invoke(request);
                request.GetRequestStream().Write(data ?? new byte[0], 0, data?.Length ?? 0);
                response = await request.GetResponseAsync();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"{ex.Message}\r\n{ex.StackTrace}");
            }
            finally
            {
                request?.Abort();
            }
            return response as HttpWebResponse;
        }

        /// <summary>
        /// 验证代理有效性
        /// </summary>
        /// <returns></returns>
        public bool TestProxy(WXCGIUrl cgi)
        {
            if (!Linker.Proxy.Enable || !cgi.GetProxy())
            {
                return true;
            }
            HttpHelper http = new HttpHelper();
            HttpItem item = new HttpItem()
            {
                URL = "https://weixin110.qq.com/security/readtemplate?t=security_center_website/index&",
                Method = "GET",
                Timeout = 5000,
                ProxyIp = Linker.Proxy.ToStrProxy()
            };
            if (http.GetHtml(item)?.Html?.Contains("微信安全中心") ?? false)
            {
                return true;
            }
            return false;
        }

        #endregion
    }
}
