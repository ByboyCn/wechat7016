using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WeChat.Core.Protocol;
using WeChat.Core.Protocol.Protos;
using WeChat.Core.Protocol.Protos.V2;

namespace WeChat.Core
{
    public partial interface IWXApp
    {
        /// <summary>
        /// 小程序授权，获取code
        /// </summary>
        /// <param name="appid">小程序appid</param>
        /// <returns></returns>
        Task<JSLoginResponse> WXJSLogin(string appid);
        /// <summary>
        /// 获取小程序授权信息（encryptedData,iv等）
        /// </summary>
        /// <param name="appid">小程序appid</param>
        /// <returns></returns>
        Task<JSOperateWxDataResponse> WXJSOperateWxData(string appid);
    }

    public partial class WXApp
    {
        /// <summary>
        /// 小程序授权，获取code
        /// </summary>
        /// <param name="appid">小程序appid</param>
        /// <returns></returns>
        public virtual async Task<JSLoginResponse> WXJSLogin(string appid)
        {
            return await Request<JSLoginResponse>(new JSLoginRequest()
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
                appid = appid,
                loginType = 1,
                versionType = 0,
                extInfo = new WxaExternalInfo()
                {
                    scene = 1001,
                    sourceEnv = 1,
                }
            }.SerializeToProtoBuf(), WXCGIUrl.mmbiz_bin_js_login);
        }

        /// <summary>
        /// 获取小程序授权信息（encryptedData,iv等）
        /// </summary>
        /// <param name="appid">小程序appid</param>
        /// <returns></returns>
        public virtual async Task<JSOperateWxDataResponse> WXJSOperateWxData(string appid)
        {
            return await Request<JSOperateWxDataResponse>(new JSOperateWxDataRequest()
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
                appid = appid,
                data = "{\"with_credentials\":true,\"data\":{\"lang\":\"zh_CN\"},\"api_name\":\"webapi_getuserinfo\",\"from_component\":true}".ToBytes(),
                grantScope = "scope.userInfo",
                opt = 1,
                versionType = 0,
                extInfo = new WxaExternalInfo()
                {
                    hostAppid = "",
                    scene = 1008,
                    sourceEnv = 2,
                }
            }.SerializeToProtoBuf(), WXCGIUrl.mmbiz_bin_js_operatewxdata);
        }
    }
}
