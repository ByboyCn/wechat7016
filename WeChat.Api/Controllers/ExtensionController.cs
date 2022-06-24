using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using WeChat.Api.Models;
using WeChat.Api.Models.Extension;
using WeChat.Core;

namespace WeChat.Api.Controllers
{
    /// <summary>
    /// 扩展功能
    /// </summary>
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [ApiGroupSort(20)]
    public class ExtensionController : BaseController
    {
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="cache">缓存</param>
        public ExtensionController(IDistributedCache cache)
            : base(cache)
        {
        }
        #endregion

        /// <summary>
        /// 短信操作
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(WXBindOpMobileForReg))]
        public async Task<ActionResult<RestfulData<object>>> WXBindOpMobileForReg([FromBody] BindOpMobileForRegDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXBindOpMobileForReg(dto.OpCode, dto.PhoneNumber, dto.VerifyCode, dto.Reg, dto.RegsessionId, dto.Authticket);
            });
        }

        /// <summary>
        /// 好友(群聊)操作请求
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(WXOpLog))]
        public async Task<ActionResult<RestfulData<object>>> WXOpLog([FromBody] OpLogDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXOpLog(dto.Type, dto.Data);
            });
        }

        /// <summary>
        /// 腾讯支付
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(WXTenPay))]
        public async Task<ActionResult<RestfulData<object>>> WXTenPay([FromBody] TenPayDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXTenPay(dto.Type, dto.ReqText, dto.ReqTextWx);
            });
        }
    }
}
