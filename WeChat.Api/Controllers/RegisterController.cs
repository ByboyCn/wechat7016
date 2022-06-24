using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using WeChat.Api.Models;
using WeChat.Api.Models.Register;

namespace WeChat.Api.Controllers
{
    /// <summary>
    /// 注册操作
    /// </summary>
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [ApiGroupSort(50)]
    public class RegisterController : BaseController
    {
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="cache">缓存</param>
        public RegisterController(IDistributedCache cache)
            : base(cache)
        {
        }
        #endregion

        /// <summary>
        /// 获取注册滑块
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXSlideRegisterVerifyCode))]
        public async Task<ActionResult<RestfulData<object>>> WXSlideRegisterVerifyCode([FromBody] BaseVerifyCodeDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXSlideRegisterVerifyCode(dto.PhoneNumber);
            });
        }

        /// <summary>
        /// 获取注册验证码
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXGetRegisterVerifyCode))]
        public async Task<ActionResult<RestfulData<object>>> WXGetRegisterVerifyCode([FromBody] GetRegisterCodeDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXGetRegisterVerifyCode(dto.PhoneNumber, dto.AuthTicket);
            });
        }

        /// <summary>
        /// 效验注册验证码
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXCheckRegisterVerifyCode))]
        public async Task<ActionResult<RestfulData<object>>> WXCheckRegisterVerifyCode([FromBody] CheckRegisterCodeDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXCheckRegisterVerifyCode(dto.PhoneNumber, dto.VerifyCode, dto.SessionId, dto.AuthTicket);
            });
        }

        /// <summary>
        /// 注册账号
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXRegister))]
        public async Task<ActionResult<RestfulData<object>>> WXRegister([FromBody] RegisterDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXRegister(dto.PhoneNumber, dto.NickName, dto.Password, dto.Ticket);
            });
        }
    }
}