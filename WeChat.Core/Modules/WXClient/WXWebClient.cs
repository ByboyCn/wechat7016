using System;
using System.Net;

namespace WeChat.Core
{
    /// <summary>
    /// 微信HTTP客户端
    /// </summary>
    public class WXWebClient : WebClient
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public WXWebClient()
        {
            Headers.Clear();
            Headers.Add(HttpRequestHeader.Accept, "*/*");
            Headers.Add(HttpRequestHeader.CacheControl, "no-cache");
            Headers.Add(HttpRequestHeader.ContentType, "application/octet-stream");
            Headers.Add(HttpRequestHeader.UserAgent, "MicroMessenger Client");
            Headers.Add(HttpRequestHeader.Upgrade, "mmtls");
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="webHeader">请求头部</param>
        public WXWebClient(WebHeaderCollection webHeader)
        {
            Headers = webHeader;
        }

        /// <summary>
        /// 重载获取请求,以支持自动解压
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        protected override WebRequest GetWebRequest(Uri address)
        {
            HttpWebRequest request = base.GetWebRequest(address) as HttpWebRequest;
            request.Timeout = 3000;
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
            return request;
        }
    }
}
