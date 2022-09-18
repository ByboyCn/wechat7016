using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using WeChat.Core.Protocol;
using WeChat.Core.Protocol.Protos;
using WeChat.Core.Protocol.Protos.V2;
using Sodao.FastSocket.SocketBase;
using System.Buffers;
using System.ServiceModel.Channels;

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
        protected WXServer _Server = new WXServer();
        /// <summary>
        /// 微信会话
        /// </summary>
        protected WXSession _Session = new WXSession();
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
        public WXProxy Proxy { get; set; } = new WXProxy();
        #endregion

        #region 构造函数
        /// <summary>
        /// 构建短链接
        /// </summary>
        public WXShortLinker()
        {
            _Server.ShortServerPort = 80;
            _Server.ShortServerAddress = GetDnsServers("short.weixin.qq.com")?.FirstOrDefault() ?? "short.weixin.qq.com";
        }
        /// <summary>
        /// 构建短链接
        /// </summary>
        /// <param name="terminal">微信终端</param>
        public WXShortLinker(WXTerminal? terminal)
        {
            _Server.ShortServerPort = 80;
            if (terminal == WXTerminal.ANDROID)
            {
                _Server.ShortServerAddress = "extshort.weixin.qq.com";
            }
            else
            {
                _Server.ShortServerAddress = "short.weixin.qq.com";
            }
        }
        /// <summary>
        /// 构建短链接
        /// </summary>
        /// <param name="url">微信业务地址：short.weixin.qq.com</param>
        public WXShortLinker(string url)
        {
            _Server.ShortServerPort = 80;
            _Server.ShortServerAddress = GetDnsServers(url)?.FirstOrDefault() ?? "short.weixin.qq.com";
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
        HttpClient httpClient = new HttpClient();
        /// <summary>
        /// 发送请求HttpHelper
        /// </summary>
        /// <param name="data"></param>
        /// <param name="route"></param>
        /// <returns></returns>
        protected virtual async Task<byte[]> RequestByHttpHelper(byte[] data, string route, bool proxy = false)
        {
            try
            {
                Debug.WriteLine($"http://{_Server.ShortServerAddress}:{_Server.ShortServerPort}{route}");
                using var request = new ByteArrayContent(data);

                //这里没有host么   UserAgent 需要校验么
                request.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                request.Headers.Add("UserAgent", "MicroMessenger Client");
                request.Headers.Add("CacheControl", "no-cache");
                var message = await httpClient.PostAsync($"http://{_Server.ShortServerAddress}:{_Server.ShortServerPort}{route}", request);
                if (message.StatusCode == HttpStatusCode.OK)
                {
                    var response = await message.Content.ReadAsByteArrayAsync();

                    return response;
                }
                else
                {
                    Console.WriteLine("请求出错了");
                }
            }
            catch (Exception ex)
            {

                throw;
            }
           
            return null;
        }

        #endregion

        #region 接口
        /// <summary>
        /// 初始化Mmtls会话
        /// </summary>
        /// <returns></returns>
        public virtual async Task<bool> InitSession()
        {
            var request = await RequestByHttpHelper(_Session.BuildRequest(_Session.PskKey,out var ecdh, out var hash), $"/mmtls/{DateTime.UtcNow.ToTimeStamp()}");
            _Session.Initialize(WXSession.Parse(request).Item2, ecdh, hash);
            return _Session.Initialized;
        }
        /// <summary>
        /// 重定向
        /// </summary>
        /// <param name="network"></param>
        /// <returns></returns>
        public virtual async Task Redirect(Protocol.Protos.V2.NetworkSectResp network)
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
