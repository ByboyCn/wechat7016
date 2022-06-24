using System;
using System.Threading.Tasks;
using WeChat.Core.Protocol;
using WeChat.Core.Protocol.Protos;
using WeChat.Core.Protocol.Protos.V2;

namespace WeChat.Core
{
    public partial interface IWXApp
    {
        /// <summary>
        /// 心跳
        /// </summary>
        /// <returns></returns>
        Task<Protocol.Protos.HeartBeatResponse> WXHeartBeat();
        /// <summary>
        /// 上报客户端校验（扫码登陆后 1-2 分钟上报一次）
        /// 23XML
        /// </summary>
        /// <returns></returns>
        Task<ReportClientCheckResponse> WXReportClientCheck();
        /// <summary>
        /// 安全上报客户端校验（扫码登陆后 1-2 分钟上报一次）
        /// 24PB
        /// </summary>
        /// <returns></returns>
        Task<ReportClientCheckResponse> WXSecReportClientCheck();
    }

    public partial class WXApp
    {
        /// <summary>
        /// 心跳
        /// </summary>
        /// <returns></returns>
        public virtual async Task<Protocol.Protos.HeartBeatResponse> WXHeartBeat()
        {
            return await Request<Protocol.Protos.HeartBeatResponse>(new Protocol.Protos.HeartBeatRequest()
            {
                BaseRequest = new Protocol.Protos.BaseRequest
                {
                    ClientVersion = _Environment.Terminal.GetWeChatVersion(),
                    DeviceID = _Environment.WeChatDataId.ToByteArray(16, 2),
                    DeviceType = _Environment.WeChatOsType.ToBytes(),
                    SessionKey = _Cache.SessionKey,
                    Scene = (uint)(_Cache.Scene),
                    Uin = _Cache.Uin
                },
                TimeStamp = (uint)DateTime.Now.ToTimeStamp(),
                KeyBuf = new SKBuiltinBuffer_t() { Buffer = _Cache.SyncKey, iLen = (uint)(_Cache.SyncKey.Length) },
                BlueToothBroadCastContent = new SKBuiltinBuffer_t() { Buffer = new byte[0], iLen = 0 },
                Scene = 0
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_heartbeat);
        }

        /// <summary>
        /// 上报客户端校验（扫码登陆后 1-2 分钟上报一次）
        /// 23XML
        /// </summary>
        /// <returns></returns>
        public virtual async Task<ReportClientCheckResponse> WXReportClientCheck()
        {
            if (_Cache.ReportCcdContext == 0) { return null; }
            return await Request<ReportClientCheckResponse>(new ReportClientCheckRequest()
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
                clientCheckData = new DeviceRunningInfo23
                {
                    Version = "00000003",
                    Encrypted = 1,
                    Data = WCAES03.BuildClientCheckData(_Environment.BuildClientCheckDataXml())
                }.SerializeToProtoBuf(),
                context = _Cache.ReportCcdContext
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_reportclientcheck);
        }

        /// <summary>
        /// 安全上报客户端校验（扫码登陆后 1-2 分钟上报一次）
        /// 24PB
        /// </summary>
        /// <returns></returns>
        public virtual async Task<ReportClientCheckResponse> WXSecReportClientCheck()
        {
            if (_Cache.ReportCcdContext == 0) { return null; }
            return await Request<ReportClientCheckResponse>(new ReportClientCheckRequest()
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
                clientCheckData = new DeviceRunningInfo24
                {
                    Version = "00000003",
                    Encrypted = 1,
                    Data = WCAES03.BuildClientCheckData(_Environment.BuildClientCheckDataPB()),
                    Timestamp = (uint)DateTime.UtcNow.ToTimeStamp(),
                    Optype = 5,
                    Uin = 0
                }.SerializeToProtoBuf(),
                context = _Cache.ReportCcdContext
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_reportclientcheck);
        }
    }
}
