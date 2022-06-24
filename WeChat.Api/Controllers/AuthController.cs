using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using WeChat.Api.Models;
using WeChat.Api.Models.Auth;

namespace WeChat.Api.Controllers
{
    /// <summary>
    /// 授权操作
    /// </summary>
     //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [ApiGroupSort(120)]
    public class AuthController : BaseController
    {
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="cache">缓存</param>
        public AuthController(IDistributedCache cache)
            : base(cache)
        {
        }
        #endregion

        /// <summary>
        /// 扫描并授权第三方登陆(二维码链接格式：https://open.weixin.qq.com/connect/confirm?uuid=xxxxx）
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXScanAndAuthLoginQrcode))]
        public async Task<ActionResult<RestfulData<object>>> WXScanAndAuthLoginQrcode([FromBody] ScanQrcodeDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXScanAndAuthLoginQrcode(dto.Url);
            });
        }

        /// <summary>
        /// 获取url访问授权pass_ticket
        /// 可实现扫码入群 自动加群 公众号阅读Key的获取
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(WXGetA8Key))]
        public async Task<ActionResult<RestfulData<object>>> WXGetA8Key([FromBody] URLDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXGetA8Key(dto.Url);
            });
        }

        /// <summary>
        /// 获取url授权
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(WXGetMpA8Key))]
        public async Task<ActionResult<RestfulData<object>>> WXGetMpA8Key([FromBody] URLDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXGetMpA8Key(dto.Url);
            });
        }

        /// <summary>
        /// 小程序授权，获取code
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXJSLogin))]
        public async Task<ActionResult<RestfulData<object>>> WXJSLogin([FromBody] JSDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXJSLogin(dto.AppId);
            });
        }

        /// <summary>
        /// 获取小程序授权信息（encryptedData,iv等）
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXJSOperateWxData))]
        public async Task<ActionResult<RestfulData<object>>> WXJSOperateWxData([FromBody] JSDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                var js_data = await client?.WXJSOperateWxData(dto.AppId);
                if (js_data?.data?.Length > 0)
                {
                    result.code = 0;
                    result.data = System.Text.Encoding.UTF8.GetString(js_data.data);
                }
                else
                {
                    result.data = js_data;
                }
            });
        }

        /// <summary>
        /// OAuth授权（公众号授权）
        /// 格式：<![CDATA[https://open.weixin.qq.com/connect/oauth2/authorize?appid=xx&redirect_uri=xx&response_type=code&scope=snsapi_userinfo&connect_redirect=1#wechat_redirect]]>
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(WXOAuthAuthorize))]
        public async Task<ActionResult<RestfulData<object>>> WXOAuthAuthorize([FromBody] URLDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXOAuthAuthorize(dto.Url);
            });
        }

        /// <summary>
        /// APP授权登录
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(WXSdkOAuthAuthorizeConfirm))]
        public async Task<ActionResult<RestfulData<object>>> WXSdkOAuthAuthorizeConfirm([FromBody] SdkOAuthAuthorizeConfirmDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXSdkOAuthAuthorizeConfirm(dto.AppId, dto.AppName, dto.AppNamePack);
            });
        }
    }
}
