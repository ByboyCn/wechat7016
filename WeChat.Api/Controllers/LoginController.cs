using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using WeChat.Api.Models;
using WeChat.Api.Models.Login;

namespace WeChat.Api.Controllers
{
    /// <summary>
    /// 登录操作
    /// </summary>
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [ApiGroupSort(150)] //排序
    public class LoginController : BaseController
    {
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="cache">缓存</param>
        public LoginController(IDistributedCache cache)
            : base(cache)
        {
        }
        #endregion

        /// <summary>
        /// 获取登录二维码
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXGetLoginQrcode))]
        public async Task<ActionResult<RestfulData<object>>> WXGetLoginQrcode([FromBody] BaseDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                var response = await client?.WXGetLoginQrcode();
                var data = new { response?.uuid, qrcode = "data:img/jpg;base64," + response?.qRCode.src.Base64Encode(), response.expiredTime, response.checkTime };
                await UpdateClient(dto.Guid, client);
                result.data = data;
                result.flag = 1;
            });
        }

        /// <summary>
        /// 获取登录二维码状态
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXCheckLoginQrcode))]
        public async Task<ActionResult<RestfulData<object>>> WXCheckLoginQrcode([FromBody] CheckLoginQrcodeDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                var response = await client?.WXCheckLoginQrcode(dto.Uuid);
                result.data = await client?.WXCheckLoginQrcodeDetail(response);
                await UpdateClient(dto.Guid, client);
                result.flag = 1;
            });
        }

        /// <summary>
        /// 扫码二次登录（唤醒登录）
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXTwiceLoginQrcode))]
        public async Task<ActionResult<RestfulData<object>>> WXTwiceLoginQrcode([FromBody] BaseDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXTwiceLoginQrcode();
                await UpdateClient(dto.Guid, client);
                result.flag = 1;
            });
        }

        /// <summary>
        /// 获取登录验证码
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXGetLoginVerifyCode))]
        public async Task<ActionResult<RestfulData<object>>> WXGetLoginVerifyCode([FromBody] GetVerifyCodeDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXGetLoginVerifyCode(dto.PhoneNumber);
                await UpdateClient(dto.Guid, client);
                result.flag = 1;
            });
        }

        /// <summary>
        /// 效验登录验证码
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXCheckLoginVerifyCode))]
        public async Task<ActionResult<RestfulData<object>>> WXCheckLoginVerifyCode([FromBody] CheckVerifyCodeDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXCheckLoginVerifyCode(dto.PhoneNumber, dto.VerifyCode);
                await UpdateClient(dto.Guid, client);
                result.flag = 1;
            });
        }



        /// <summary>
        /// 人工安全登录（24PB）
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXSecLoginManual))]
        public async Task<ActionResult<RestfulData<object>>> WXSecLoginManual([FromBody] LoginDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                var auth = await client?.WXSecManualAuth((Core.WXLoginChannel)dto.Channel, dto.UserName, dto.Password, dto.Slider);
                //result.data = auth;
                result.data = client?.Status;
                if (client?.Status.Code == 1)
                {
                    if (dto.Init)
                    {
                        await client?.WXNewInit();
                        result.remark = "自动初始化新设备成功";
                    }
                    await UpdateClient(dto.Guid, client);
                    result.flag = 1;
                    return;
                }
                else if (client?.Status.Code == 3)
                {
                    await ReleaseClient<object>(new BaseDto() { Guid = dto.Guid }, null);
                    result.remark = "实例已释放";
                    return;
                }
                else
                {
                    await UpdateClient(dto.Guid, client);
                    result.flag = 1;
                }
            });
        }

        /// <summary>
        /// 安全自动登录/二次登录（24PB）
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXSecLoginAuto))]
        public async Task<ActionResult<RestfulData<object>>> WXSecLoginAuto([FromBody] BaseDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                var auth = await client?.WXSecAutoAuth();
                //result.data = auth;
                result.data = client?.Status;
                if (client?.Status.Code == 1)
                {
                    await client?.WXNewInit();
                    result.remark = "自动初始化新设备成功";
                    await UpdateClient(dto.Guid, client);
                    result.flag = 1;
                    return;
                }
                else if (client?.Status.Code == 3)
                {
                    await ReleaseClient<object>(new BaseDto() { Guid = dto.Guid }, null);
                    result.remark = "实例已释放";
                    return;
                }
                else
                {
                    await UpdateClient(dto.Guid, client);
                    result.flag = 1;
                }
            });
        }

        /// <summary>
        /// 新设备登录成功初始化
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXNewInit))]
        public async Task<ActionResult<RestfulData<object>>> WXNewInit([FromBody] BaseDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXNewInit();
                await UpdateClient(dto.Guid, client);
                result.flag = 1;
            });
        }

        /// <summary>
        /// 注销登录
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXLogout))]
        public async Task<ActionResult<RestfulData<object>>> WXLogout([FromBody] BaseDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXLogout();
                await UpdateClient(dto.Guid, client);
                result.flag = 1;
            });
        }

        /// <summary>
        /// 获取登录令牌（用于自动登录或扫码二次登录）
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXGetLoginToken))]
        public async Task<ActionResult<RestfulData<object>>> WXGetLoginToken([FromBody] BaseDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = client?.Cache.AutoAuthToken;
                await Task.CompletedTask;
            });
        }

        /// <summary>
        /// 外部设备登陆扫码
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(WXExtDeviceLoginConfirmGet))]
        public async Task<ActionResult<RestfulData<object>>> WXExtDeviceLoginConfirmGet([FromBody] URLDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXExtDeviceLoginConfirmGet(dto.Url);
            });
        }

        /// <summary>
        /// 外部设备登陆确认
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXExtDeviceLoginConfirmOK))]
        public async Task<ActionResult<RestfulData<object>>> WXExtDeviceLoginConfirmOK([FromBody] URLDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXExtDeviceLoginConfirmOK(dto.Url);
            });
        }

        /// <summary>
        /// 辅助登录新设备,格式：https://login.weixin.qq.com/q/xxxxx
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(WXHelpDeviceLogin))]
        public async Task<ActionResult<RestfulData<object>>> WXHelpDeviceLogin([FromBody] URLDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXHelpDeviceLogin(dto.Url);
            });
        }

        /// <summary>
        /// 重提数据A16/62
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(WXExtractData))]
        public async Task<ActionResult<RestfulData<object>>> WXExtractData([FromBody] DataDto dto)
        {
            if (dto.Terminal != 0)
            {
                dto.Terminal = 2;
            }
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXExtractData((Core.Protocol.WXTerminal)(dto.Terminal));
            });
        }
    }
}