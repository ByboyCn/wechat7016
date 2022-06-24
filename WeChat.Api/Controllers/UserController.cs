using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using WeChat.Api.Models;
using WeChat.Api.Models.User;
using WeChat.Core.Protocol.Protos.V2;

namespace WeChat.Api.Controllers
{
    /// <summary>
    /// 用户操作
    /// </summary>
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [ApiGroupSort(130)]
    public class UserController : BaseController
    {
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="cache">缓存</param>
        public UserController(IDistributedCache cache)
            : base(cache)
        {
        }
        #endregion

        /// <summary>
        /// 上传头像
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXUploadHeadImage))]
        public async Task<ActionResult<RestfulData<object>>> WXUploadHeadImage([FromBody] UploadHeadImageDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXUploadHeadImage(dto.Base64Image.Base64Decode());
            });
        }

        /// <summary>
        /// 获取账号详情
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXGetProfile))]
        public async Task<ActionResult<RestfulData<object>>> WXGetProfile([FromBody] BaseDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXGetProfile();
            });
        }

        /// <summary>
        /// 设置用户信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXSetUserInfo))]
        public async Task<ActionResult<RestfulData<object>>> WXSetUserInfo([FromBody] SetUserInfoDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXSetUserInfo(dto.NickName, dto.Sex, dto.Signature, dto.Country, dto.Province, dto.City);
            });
        }

        /// <summary>
        /// 设置微信号
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXSetAlisa))]
        public async Task<ActionResult<RestfulData<object>>> WXSetAlisa([FromBody] SetAlisaDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXGeneralSet(1, dto.Alisa);
            });
        }

        /// <summary>
        /// 获取个人二维码
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXGetUserQrcode))]
        public async Task<ActionResult<RestfulData<object>>> WXGetUserQrcode([FromBody] BaseDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXGetQrcode();
                result.remark = "data:img/jpg;base64,";
            });
        }

        /// <summary>
        /// 验证密码
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXVerifyPassword))]
        public async Task<ActionResult<RestfulData<object>>> WXVerifyPassword([FromBody] VerifyPasswordDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXVerifyPassword(dto.Password);
            });
        }

        /// <summary>
        /// 设置密码(需要先验证密码)
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXSetPassword))]
        public async Task<ActionResult<RestfulData<object>>> WXSetPassword([FromBody] SetPasswordDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXSetPassword(dto.Password, dto.Ticket);
                await UpdateClient(dto.Guid, client);
                result.flag = 1;
            });
        }

        /// <summary>
        /// 一键修改密码
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXOnceSetPassword))]
        public async Task<ActionResult<RestfulData<object>>> WXOnceSetPassword([FromBody] OncePasswordDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXOnceSetPassword(dto.OldPassword, dto.NewPassword);
                await UpdateClient(dto.Guid, client);
                result.flag = 1;
            });
        }

        /// <summary>
        /// 绑定/解绑手机号
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXBindMobile))]
        public async Task<ActionResult<RestfulData<object>>> WXBindMobile([FromBody] BindMobileDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXBindMobile(dto.OpCode, dto.PhoneNumber, dto.VerifyCode);
            });
        }

        /// <summary>
        /// 绑定/解绑邮箱
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXBindEmail))]
        public async Task<ActionResult<RestfulData<object>>> WXBindEmail([FromBody] BindEmailDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXBindEmail(dto.OpCode, dto.Email);
            });
        }

        /// <summary>
        /// 获取安全设备信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXGetSafetyInfo))]
        public async Task<ActionResult<RestfulData<object>>> WXGetSafetyInfo([FromBody] BaseDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXGetSafetyInfo();
            });
        }

        /// <summary>
        /// 删除安全设备
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXDelSafeDevice))]
        public async Task<ActionResult<RestfulData<object>>> WXDelSafeDevice([FromBody] DelSafeDeviceDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXDelSafeDevice(dto.Uuid);
            });
        }

        /// <summary>
        /// 修改安全设备信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXUpdateSafeDevice))]
        public async Task<ActionResult<RestfulData<object>>> WXUpdateSafeDevice([FromBody] BaseDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXUpdateSafeDevice();
            });
        }

        /// <summary>
        /// 好友验证功能切换
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXFunctionSwitch))]
        public async Task<ActionResult<RestfulData<object>>> WXFunctionSwitch([FromBody] FunctionSwitchDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXFunctionSwitch(dto.Function, dto.Value);
            });
        }

        /// <summary>
        /// 验证个人信息(身份证)
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXVerifyPersonalInfo))]
        public async Task<ActionResult<RestfulData<object>>> WXVerifyPersonalInfo([FromBody] VerifyPersonalInfoDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXVerifyPersonalInfo(dto.RealName, dto.CardType, dto.CardNumber);
            });
        }
    }
}