using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml;
using WeChat.Core.Protocol;
using WeChat.Core.Protocol.Protos.V2;

namespace WeChat.Core
{
    /// <summary>
    /// 微信短链接
    /// </summary>
    public class WXShortLinker : IWXLinker
    {
        #region 字段
        /// <summary>
        /// 微信服务器
        /// </summary>
        protected WXServer _Server;
        /// <summary>
        /// 微信会话
        /// </summary>
        protected WXSession _Session;
        #endregion

        #region 属性
        /// <summary>
        /// 微信服务器
        /// </summary>
        public WXServer Server => _Server;
        /// <summary>
        /// 微信会话
        /// </summary>
        public WXSession Session => _Session;
        /// <summary>
        /// 获取或设置代理
        /// </summary>
        public WXProxy Proxy { get; set; }
        #endregion

        #region 构造函数
        /// <summary>
        /// 构建短链接
        /// </summary>
        public WXShortLinker()
        {
            _Server.ShortServerPort = 80;
            _Server.ShortServerAddress = GetDnsServers("sgshort.wechat.com")?.FirstOrDefault() ?? "short.weixin.qq.com";
        }
        /// <summary>
        /// 构建短链接
        /// </summary>
        /// <param name="terminal">微信终端</param>
        public WXShortLinker(WXTerminal terminal)
        {
            _Server.ShortServerPort = 80;
            if (terminal == WXTerminal.ANDROID)
            {
                //_Server.ShortServerAddress = GetDnsServers("szextshort.weixin.qq.com")?.FirstOrDefault() ?? "short.weixin.qq.com";
                _Server.ShortServerAddress = "szextshort.weixin.qq.com";
            }
            else
            {
                //_Server.ShortServerAddress = GetDnsServers("sgshort.wechat.com")?.FirstOrDefault() ?? "short.weixin.qq.com";
                _Server.ShortServerAddress = "sgshort.wechat.com";
            }
        }
        /// <summary>
        /// 构建短链接
        /// </summary>
        /// <param name="url">微信业务地址：short.weixin.qq.com</param>
        public WXShortLinker(string url)
        {
            _Server.ShortServerPort = 80;
            _Server.ShortServerAddress = GetDnsServers(url)?.FirstOrDefault() ?? "sgshort.wechat.com";
        }
        /// <summary>
        /// 构建短链接
        /// </summary>
        /// <param name="server">服务器</param>
        /// <param name="session">微信会话</param>
        public WXShortLinker(WXServer server, WXSession session)
        {
            _Server = server;
            _Session = session;
        }
        #endregion

        #region 虚函数
        /// <summary>
        /// 获取DNS服务器IP
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        protected virtual List<string> GetDnsServers(string name)
        {
            var ips = new List<string>();
            var doc = new XmlDocument();
            var web = new WXWebClient();
            web?.CallWhen(Proxy.Enable, _ => _.Proxy = Proxy.ToWebProxy());
            doc.LoadXml(web.DownloadString("http://dns.weixin.qq.com/cgi-bin/micromsg-bin/newgetdns"));
            var domainlist = doc.SelectSingleNode("/dns/domainlist");
            foreach (XmlNode node in domainlist.ChildNodes)
            {
                if (node.Attributes["name"].Value == name) { foreach (XmlNode ip in node.ChildNodes) { ips.Add(ip.InnerText); } }
            }
            return ips;
        }
        /// <summary>
        /// 发送请求WebClient
        /// </summary>
        /// <param name="data"></param>
        /// <param name="route"></param>
        /// <returns></returns>
        protected virtual async Task<byte[]> RequestByWebClient(byte[] data, string route)
        {
            var client = new WXWebClient();
            client?.CallWhen(Proxy.Enable, _ => _.Proxy = Proxy.ToWebProxy());
            return await client.UploadDataTaskAsync($"http://{_Server.ShortServerAddress}:{_Server.ShortServerPort}{route}", data);
        }
        /// <summary>
        /// 发送请求HttpWebRequest
        /// </summary>
        /// <param name="data"></param>
        /// <param name="route"></param>
        /// <returns></returns>
        protected virtual async Task<byte[]> RequestByHttpWebRequest(byte[] data, string route)
        {
            var response = default(WebResponse);
            var request = default(HttpWebRequest);
            byte[] result = default;
            try
            {
                request = WebRequest.Create($"http://{_Server.ShortServerAddress}:{_Server.ShortServerPort}{route}") as HttpWebRequest;
                request.Method = "POST";
                request.Headers.Clear();
                request.Headers.Add(HttpRequestHeader.Accept, "*/*");
                request.Headers.Add(HttpRequestHeader.CacheControl, "no-cache");
                request.Headers.Add(HttpRequestHeader.ContentType, "application/octet-stream");
                request.Headers.Add(HttpRequestHeader.UserAgent, "MicroMessenger Client");
                if (Session.Initialized)
                {
                    request.Headers.Add(HttpRequestHeader.Upgrade, "mmtls");
                }
                request.KeepAlive = true;
                request.AllowAutoRedirect = false;
                request.Proxy = Proxy.ToWebProxy();
                request.ServicePoint.Expect100Continue = false;
                request.ServicePoint.ConnectionLimit = 1024;
                request.GetRequestStream().Write(data ?? new byte[0], 0, data?.Length ?? 0);
                response = await request?.GetResponseAsync();
            }
            catch (Exception ex)
            {
                //System.Diagnostics.Debug.WriteLine($"{ex.Message}\r\n{ex.StackTrace}");
                Debug.WriteLine($"{ex.Message}");
                return result;
            }
            finally
            {
                request?.Abort();
            }
            using (MemoryStream _stream = new MemoryStream())
            {
                //开始读取流并设置编码方式
                response?.GetResponseStream()?.CopyTo(_stream, 1024);
                //获取Byte
                result = _stream?.ToArray();
            }
            response?.Close();
            response?.Dispose();
            return result;
        }
        /// <summary>
        /// 发送请求HttpHelper
        /// </summary>
        /// <param name="data"></param>
        /// <param name="route"></param>
        /// <returns></returns>
        protected virtual async Task<byte[]> RequestByHttpHelper(byte[] data, string route, bool proxy = false)
        {
            Debug.WriteLine($"http://{_Server.ShortServerAddress}:{_Server.ShortServerPort}{route}");
            HttpResult result = new HttpResult();
            HttpHelper http = new HttpHelper();
            HttpItem item = new HttpItem()
            {
                URL = $"http://{_Server.ShortServerAddress}:{_Server.ShortServerPort}{route}",
                Method = "POST",
                Accept = "*/*",
                ContentType = "application/octet-stream",
                UserAgent = "MicroMessenger Client",
                KeepAlive = false,
                PostDataType = PostDataType.Byte,
                ResultType = ResultType.Byte,
                PostdataByte = data,
                Timeout = 1000 * 200
            };
            item.Header.Add(HttpRequestHeader.CacheControl, "no-cache");
            if (Session.Initialized)
            {
                item.Header.Add(HttpRequestHeader.Upgrade, "mmtls");
            }
            if (Proxy.Enable == true && proxy == true)
            {
                item.ProxyIp = Proxy.ToStrProxy();
            }
            result = http.GetHtml(item);
            await Task.CompletedTask;
            return result?.ResultByte ?? new byte[1] { 1 };
        }

        #endregion

        #region 接口
        /// <summary>
        /// 初始化Mmtls会话
        /// </summary>
        /// <returns></returns>
        public virtual async Task<bool> InitSession()
        {
            #region 测试mmtls初始化 2020-12-22
            //string log = "Build:{0}/{1}ms Request:{2}/{3}ms Init:{4}/{5}ms";
            //DateTime start, end;
            //TimeSpan ts;
            //start = DateTime.Now;
            //var build = _Session.BuildRequest(out var ecdh, out var hash);
            //end = DateTime.Now;
            //ts = end.Subtract(start);
            //log = log.Replace("{0}", $"{build?.Length}");
            //log = log.Replace("{1}", $"{ts.TotalMilliseconds}");
            //start = DateTime.Now;
            //var request = await RequestByHttpHelper(build, $"/mmtls/{DateTime.UtcNow.ToTimeStamp()}");
            //end = DateTime.Now;
            //ts = end.Subtract(start);
            //log = log.Replace("{2}", $"{request?.Length}");
            //log = log.Replace("{3}", $"{ts.TotalMilliseconds}");
            //start = DateTime.Now;
            //var session = _Session.Initialize(WXSession.Parse(request).Item2, ecdh, hash);
            //end = DateTime.Now;
            //ts = end.Subtract(start);
            //log = log.Replace("{4}", $"{session?.Length}");
            //log = log.Replace("{5}", $"{ts.TotalMilliseconds}");
            //Debug.WriteLine($"{log}");
            #endregion
            var request = await RequestByHttpHelper(_Session.BuildRequest(_Session.PskKey,out var ecdh, out var hash), $"/mmtls/{DateTime.UtcNow.ToTimeStamp()}");
            _Session.Initialize(WXSession.Parse(request).Item2, ecdh, hash);
            return _Session.Initialized;
        }
        /// <summary>
        /// 重定向
        /// </summary>
        /// <param name="network"></param>
        /// <returns></returns>
        public virtual async Task Redirect(NetworkSectResp network)
        {
            var dns = network?.newHostList?.list?.First(t => t.origin == "extshort.weixin.qq.com")?.substitute;
            var ips = network?.builtinIplist?.shortConnectIplist?.Where(t => t.domain.Replace("\0", "") == dns)?.ToArray();
            #region IP访问+连通性判断
            //var end = ips?.Select(t => new IPEndPoint(IPAddress.Parse(t.ip.Replace("\0", "")), (int)t.port))?.FirstOrDefault(t => t.IsReachable());
            //if (end != null)
            //{
            //    _Server.ShortServerAddress = end.Address.ToString();
            //    _Server.ShortServerPort = end.Port;
            //    Debug.WriteLine($"【短链重定向】地址:[{_Server.ShortServerAddress}:{_Server.ShortServerPort}]");
            //}
            #endregion

            #region 域名访问
            var end = ips?.FirstOrDefault();
            if (end != null)
            {
                _Server.ShortServerAddress = end.domain.Replace("\0", "");
                _Server.ShortServerPort = Convert.ToInt32(end.port);
                //Debug.WriteLine($"【短链重定向】地址:[{_Server.ShortServerAddress}:{_Server.ShortServerPort}]");
            }
            #endregion

            await Task.CompletedTask;
        }
        /// <summary>
        /// 发送请求
        /// </summary>
        /// <param name="data"></param>
        /// <param name="cgi"></param>
        /// <returns></returns>
        public virtual async Task<byte[]> Request(byte[] data, WXCGIUrl cgi)
        {
            var result = new byte[0];
            var route = cgi.GetUrl();
            var proxy = cgi.GetProxy();
            var hash = new byte[0];
            var mmtls = _Session.Initialized;
            _Session.CallWhen(mmtls, _ =>
            {
                //data = _Session.ShortLinkPack(_Session.ShortLinkHead("short.weixin.qq.com", route, data), out hash);
                data = _Session.ShortLinkPack(_Session.ShortLinkHead(_Server.ShortServerAddress, route, data), out hash);
                route = $"/mmtls/{DateTime.UtcNow.ToTimeStamp()}";
            });
            //Debug.WriteLine($"【短链接】地址:[{_Server.ShortServerAddress}:{_Server.ShortServerPort}] 路由:[{cgi.GetUrl()}] Mmtls:[{route}] 长度:[{data.Length}]");
            result = await RequestByHttpHelper(data, route, proxy);
            _Session.CallWhen(mmtls, _ =>
            {
                result = _Session.ShortLinkUnPack(result, hash);
            });
            return result;
        }
        #endregion
    }
}
