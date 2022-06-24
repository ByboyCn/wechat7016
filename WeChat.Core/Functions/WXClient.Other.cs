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
        ///摇一摇，上报位置
        /// </summary>
        /// <param name="latitude">经度</param>
        /// <param name="longitude">纬度</param>
        /// <returns></returns>
        Task<ShakeReportResponse> WXShakeReport(float latitude, float longitude);
        /// <summary>
        /// 摇一摇，获取结果
        /// </summary>
        /// <param name="context">内容，由<see cref="WXShakeReport(float, float)"/>返回</param>
        /// <returns></returns>
        Task<ShakeGetResponse> WXShakeGet(byte[] context);
        /// <summary>
        /// 查看附近人
        /// </summary>
        /// <param name="longitude">经度</param>
        /// <param name="latitude">纬度</param>
        /// <returns></returns>
        Task<Protocol.Protos.LbsResponse> WXGetPeopleNearby(float longitude, float latitude);
        /// <summary>
        /// 查询硬件设备
        /// </summary>
        /// <param name="qrcode">设备二维码</param>
        /// <returns></returns>
        Task<SearchHardDeviceResponse> WXSearchHardDevice(string qrcode);
        /// <summary>
        /// 上传设备步数
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        Task<UploadDeviceStepResp> WXUploadDeviceStep(uint count);
    }

    public partial class WXApp
    {
        /// <summary>
        ///摇一摇,上报位置
        /// </summary>
        /// <param name="latitude">经度</param>
        /// <param name="longitude">纬度</param>
        /// <returns></returns>
        public virtual async Task<ShakeReportResponse> WXShakeReport(float latitude, float longitude)
        {
            return await Request<ShakeReportResponse>(new ShakeReportRequest()
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
                GPSSource = 0,
                ImgId = 0,
                Latitude = latitude,
                Longitude = longitude,
                OpCode = 0,
                Precision = 0,
                Times = 1
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_shakereport);
        }

        /// <summary>
        /// 摇一摇，获取结果
        /// </summary>
        /// <param name="context">内容，由<see cref="WXShakeReport(float, float)"/>返回</param>
        /// <returns></returns>
        public virtual async Task<ShakeGetResponse> WXShakeGet(byte[] context)
        {
            return await Request<ShakeGetResponse>(new ShakeGetRequest()
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
                Buffer = new SKBuiltinBuffer_t { Buffer = context, iLen = (uint)(context?.Length ?? 0) }
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_shakeget);
        }

        /// <summary>
        /// 查询硬件设备
        /// </summary>
        /// <param name="qrcode">设备二维码</param>
        /// <returns></returns>
        public virtual async Task<SearchHardDeviceResponse> WXSearchHardDevice(string qrcode)
        {
            return await Request<SearchHardDeviceResponse>(new SearchHardDeviceRequest()
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
                HardDeviceQRCode = qrcode
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_searchharddevice);
        }

        /// <summary>
        /// 查看附近人
        /// </summary>
        /// <param name="longitude">经度</param>
        /// <param name="latitude">纬度</param>
        /// <returns></returns>
        public virtual async Task<Protocol.Protos.LbsResponse> WXGetPeopleNearby(float longitude, float latitude)
        {
            return await Request<Protocol.Protos.LbsResponse>(new Protocol.Protos.LbsRequest()
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
                GPSSource = 0,
                Latitude = latitude,
                Longitude = longitude,
                OpCode = 1,// 1/3/4
                Precision = 65
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_lbsfind);
        }

        /// <summary>
        /// 上报设备步数
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public virtual async Task<UploadDeviceStepResp> WXUploadDeviceStep(uint count)
        {
            var now = DateTime.UtcNow.ToTimeStamp();
            return await Request<UploadDeviceStepResp>(new UploadDeviceStepReq
            {
                BaseRequest = new Protocol.Protos.V2.BaseRequest
                {
                    clientVersion = _Environment.Terminal.GetWeChatVersion(),
                    devicelId = _Environment.WeChatDataId.ToByteArray(16, 2),
                    osType = _Environment.WeChatOsType,
                    sessionKey = _Cache.SessionKey,
                    scene = _Cache.Scene,
                    uin = _Cache.Uin
                },
                DeviceType = "gh_43f2581f6fd6",
                FromTime = (uint)now,
                ToTime = (uint)(now - 36000),
                StepCount = count,
                SystemZone = "8"
            }.SerializeToProtoBuf(), WXCGIUrl.mmoc_bin_hardware_uploaddevicestep);
        }
    }
}
