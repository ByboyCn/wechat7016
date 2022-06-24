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
        /// 扫码登陆第三方授权
        /// </summary>
        /// <param name="url">二维码url,格式：https://open.weixin.qq.com/connect/confirm?uuid=xxxxx</param>
        /// <returns></returns>
        Task<string> WXScanAndAuthLoginQrcode(string url);
        /// <summary>
        /// 获取url访问授权pass_ticket
        /// 可实现扫码入群 自动加群 公众号阅读Key的获取
        /// </summary>
        /// <param name="url">访问的链接</param>
        /// <param name="scene">2 来源好友或群 必须设置来源的id  3 历史阅读 4 二维码连接 7 来源公众号 必须设置公众号的id</param>
        /// <param name="username">公众号/用户名/群id</param>
        /// <returns></returns>
        Task<GetA8KeyResp> WXGetA8Key(string url, uint scene = 4, string username = "");
        /// <summary>
        /// 授权登陆
        /// </summary>
        /// <param name="url"></param>
        /// <param name="scene"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        Task<GetA8KeyResp> WXGetMpA8Key(string url, uint scene = 4, string username = "");
        /// <summary>
        /// OAuth授权(公众号授权)
        /// </summary>
        /// <param name="url">授权地址，格式：<![CDATA[https://open.weixin.qq.com/connect/oauth2/authorize?appid=wxxxxxx&redirect_uri=http%3a%2f%2fxx.com/xxx&response_type=code&scope=snsapi_userinfo&connect_redirect=1#wechat_redirect]]></param>
        /// <returns></returns>
        Task<OauthAuthorizeResp> WXOAuthAuthorize(string url);
        /// <summary>
        /// APP授权登录
        /// </summary>
        /// <param name="appid"></param>
        /// <param name="app_name"></param>
        /// <param name="app_name_pack"></param>
        /// <returns></returns>
        Task<SdkOauthAuthorizeConfirmResp> WXSdkOAuthAuthorizeConfirm(string appid, string app_name, string app_name_pack);
    }

    public partial class WXApp
    {
        /// <summary>
        /// 扫码登陆第三方授权
        /// </summary>
        /// <param name="url">二维码url,格式：https://open.weixin.qq.com/connect/confirm?uuid=xxxxx</param>
        /// <returns></returns>
        public virtual async Task<string> WXScanAndAuthLoginQrcode(string url)
        {
            var a8key = await WXGetA8Key(url);
            if (a8key?.FullURL?.IsEmpty() ?? true) { return "A8Key授权失败"; }
            HttpHelper http = new HttpHelper();
            HttpItem item = new HttpItem()
            {
                URL = a8key.FullURL,
                Method = "GET"
            };
            http.GetHtml(item);
            item = new HttpItem()
            {
                URL = "https://open.weixin.qq.com/connect/confirm_reply",
                Method = "POST",
                PostDataType = PostDataType.Byte,
                PostdataByte = (a8key.FullURL.Replace("https://open.weixin.qq.com/connect/confirm?", "") + "&snsapi_login=on&allow=allow").ToBytes(),
                Referer = a8key.FullURL
            };
            item.Header.Add("Origin", "https://open.weixin.qq.com");
            HttpResult result = http.GetHtml(item);
            return result.Html;
        }

        /// <summary>
        /// 获取url访问授权pass_ticket
        /// 可实现扫码入群 自动加群 公众号阅读Key的获取
        /// </summary>
        /// <param name="url">访问的链接</param>
        /// <param name="scene">2 来源好友或群 必须设置来源的id  3 历史阅读 4 二维码连接 7 来源公众号 必须设置公众号的id</param>
        /// <param name="username">公众号/用户名/群id</param>
        /// <returns></returns>
        public virtual async Task<GetA8KeyResp> WXGetA8Key(string url, uint scene = 4, string username = "")
        {
            return await Request<GetA8KeyResp>(new GetA8KeyRequest()
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
                codeType = 0,
                codeVersion = 0,
                flag = 0,
                fontScale = 100,
                netType = "WIFI",
                opCode = 2,
                userName = username,
                reqUrl = new SKBuiltinString() { @string = url },
                friendQQ = 0,
                scene = scene
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_geta8key);
        }

        /// <summary>
        /// 授权登陆
        /// </summary>
        /// <param name="url"></param>
        /// <param name="scene"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public virtual async Task<GetA8KeyResp> WXGetMpA8Key(string url, uint scene = 4, string username = "")
        {
            return await Request<GetA8KeyResp>(new GetA8KeyRequest()
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
                codeType = 0,
                codeVersion = 0,
                flag = 0,
                fontScale = 100,
                netType = "WIFI",
                opCode = 2,
                userName = username,
                reqUrl = new SKBuiltinString() { @string = url },
                friendQQ = 0,
                scene = scene
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_mp_geta8key);
        }

        /// <summary>
        /// OAuth授权(公众号授权)
        /// </summary>
        /// <param name="url">授权地址，格式：<![CDATA[https://open.weixin.qq.com/connect/oauth2/authorize?appid=wxxxxxx&redirect_uri=http%3a%2f%2fxx.com/xxx&response_type=code&scope=snsapi_userinfo&connect_redirect=1#wechat_redirect]]></param>
        /// <returns></returns>
        public virtual async Task<OauthAuthorizeResp> WXOAuthAuthorize(string url)
        {
            return await Request<OauthAuthorizeResp>(new OauthAuthorizeReq()
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
                OauthUrl = url,
                BizUsername = "",
                Scene = 1
            }.SerializeToProtoBuf(), WXCGIUrl.mmbiz_bin_oauth_authorize);
        }

        /// <summary>
        /// APP授权登录
        /// </summary>
        /// <param name="appid"></param>
        /// <param name="app_name"></param>
        /// <param name="app_name_pack"></param>
        /// <returns></returns>
        public virtual async Task<SdkOauthAuthorizeConfirmResp> WXSdkOAuthAuthorizeConfirm(string appid, string app_name, string app_name_pack)
        {
            return await Request<SdkOauthAuthorizeConfirmResp>(new SdkOauthAuthorizeConfirmReq()
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
                Opt = 1,
                Scope = new[] { "snsapi_userinfo" }.ToList(),
                Appid = appid,
                State = app_name,
                Bundleid = app_name_pack,
                AvatarId = 0,
                UniversalLink = "",
                OpensdkVersion = "",
                SdkToken = "",
                OpensdkBundleid = "",
                SdkTokenChk = 0
            }.SerializeToProtoBuf(), WXCGIUrl.mmbiz_bin_sdk_oauth_authorize_confirm);
        }

        //public virtual async Task<OauthRandomAvatarResp> WXOauthRandomAvatar()
        //{
        //    return await Request<OauthRandomAvatarResp>(new OauthRandomAvatarReq()
        //    {
        //        BaseRequest = new Protocol.Protos.V2.BaseRequest
        //        {
        //            clientVersion = _Environment.Terminal.GetWeChatVersion(),
        //            devicelId = _Environment.WeChatDataId.ToByteArray(16, 2),
        //            osType = _Environment.WeChatOsType,
        //            sessionKey = _Cache.SessionKey,
        //            scene = _Cache.Scene,
        //            uin = _Cache.Uin
        //        }
        //    }.SerializeToProtoBuf(), WXCGIUrl.mmbiz_bin_oauth_getrandomavatar);
        //}
    }
}
