using System;
using System.Threading.Tasks;
using WeChat.Core.Protocol;
using WeChat.Core.Protocol.Protos;

namespace WeChat.Core
{
    public partial interface IWXApp
    {
        /// <summary>
        /// 校验CDN资源
        /// </summary>
        /// <param name="data_source_type"></param>
        /// <param name="data_source_id"></param>
        /// <param name="dataid"></param>
        /// <param name="fullmd5"></param>
        /// <param name="head256md5"></param>
        /// <param name="fullsize"></param>
        /// <param name="isthumb"></param>
        /// <returns></returns>
        Task<CheckCDNResponse> WXCheckCdnSource(uint data_source_type, string data_source_id, string dataid, string fullmd5, string head256md5, uint fullsize, uint isthumb);

        /// <summary>
        /// 获取CDN_DNS信息
        /// </summary>
        /// <param name="clientip">客户端ip</param>
        /// <returns></returns>
        Task<Protocol.Protos.V2.GetCDNDnsResponse> WXGetCdnDNS(string clientip);
    }

    public partial class WXApp
    {
        /// <summary>
        /// 校验CDN
        /// </summary>
        /// <param name="data_source_type"></param>
        /// <param name="data_source_id"></param>
        /// <param name="dataid"></param>
        /// <param name="fullmd5"></param>
        /// <param name="head256md5"></param>
        /// <param name="fullsize"></param>
        /// <param name="isthumb"></param>
        /// <returns></returns>
        public virtual async Task<CheckCDNResponse> WXCheckCdnSource(uint data_source_type, string data_source_id, string dataid, string fullmd5, string head256md5, uint fullsize, uint isthumb)
        {
            return await Request<CheckCDNResponse>(new CheckCDNRequest()
            {
                BaseRequest = new Protocol.Protos.BaseRequest
                {
                    ClientVersion = _Environment.Terminal.GetWeChatVersion(),
                    DeviceID = _Environment.WeChatDataId.ToByteArray(16, 2),
                    DeviceType = _Environment.WeChatOsType.ToBytes(),
                    SessionKey = _Cache.SessionKey,
                    Scene = (uint)(_Cache.Scene),
                    Uin = _Cache.Uin
                }
            }?.CallWhen(true, _ =>
            {
                _.Count = 1;
                _.List.Add(new CheckCDN { DataSourceType = data_source_type, DataSourceId = data_source_id, DataId = dataid, FullMd5 = fullmd5, Head256Md5 = head256md5, FullSize = fullsize, IsThumb = isthumb });
            }).SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_checkcdn);
        }

        /// <summary>
        /// 获取CDN_DNS信息
        /// </summary>
        /// <param name="clientip">客户端ip</param>
        /// <returns></returns>
        public virtual async Task<Protocol.Protos.V2.GetCDNDnsResponse> WXGetCdnDNS(string clientip)
        {
            clientip = clientip ?? "127.0.0.1";
            return await Request<Protocol.Protos.V2.GetCDNDnsResponse>(new Protocol.Protos.V2.GetCDNDnsRequest()
            {
                baseRequest = new Protocol.Protos.V2.BaseRequest
                {
                    clientVersion = _Environment.Terminal.GetWeChatVersion(),
                    devicelId = _Environment.WeChatDataId.ToByteArray(16, 2),
                    osType = _Environment.WeChatOsType,
                    sessionKey = _Cache.SessionKey,
                    scene = _Cache.Scene,
                    uin = _Cache.Uin
                },
                clientIP = clientip
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_getcdndns);
        }
    }
}
