using System;
using System.Threading.Tasks;
using WeChat.Core.Protocol;
using WeChat.Core.Protocol.Protos;
using WeChat.Core.Protocol.Protos.V2;
using WeChat.Pb.Entites;
using XMS.WeChat.Core.Libraries.WCAes;
using XMS.WeChat.Core.Versions;

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
        /// 获取deviceToken
        /// </summary>
        /// <returns></returns>
        Task<TrustResp> WXGetDeviceToken();

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
        public virtual async Task<TrustResp> WXGetDeviceToken()
        {
                var data =CheckClientData.GetZTData(_Environment.WeChatDataId, _Environment.WeChatOsType, _Environment.Device.Model, _Environment.Device.CpuCore,
                _Environment.Device.IPhoneVersion, _Environment.DeviceName, _8026.PlistVersion, _Environment.WeChatOsType, _8026.PlistVersion,
               _8026.Md5OfMachoHeader, _8026.AppUUID, _8026.InstallTimes, _Environment.DeviceImei, _Cache.DeviceToken, _8026.StrVersion,
               _Cache.SoftConfig, _Cache.SoftData);
            var result = await Request<TrustResp>(new FPFresh()
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
                 ZTData = data
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_fpinit);
            _Cache.DeviceToken = result.TrustResponseData.DeviceToken;
            _Cache.SoftConfig = result.TrustResponseData.SoftData.SoftConfig;
            _Cache.SoftData = result.TrustResponseData.SoftData.SoftData;
            return result;
        }

    }
}
