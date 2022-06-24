using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using WeChat.Api.Models;
using WeChat.Api.Models.UnBan;
using WeChat.Api.Models.Base;
using WeChat.Core;
using System.Net;

namespace WeChat.Api.Controllers
{
    /// <summary>
    /// 封号操作
    /// </summary>
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [ApiGroupSort(160)]


    public class UnBanController : BaseController

    {

        /// <summary>
        /// 配置器
        /// </summary>
            

        public IConfiguration Configuration { get; }
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="cache">缓存</param>
        /// <param name="configuration">配置器</param>
        public UnBanController(IDistributedCache cache, IConfiguration configuration)
            : base(cache)
        {
            Configuration = configuration;
        }
        #endregion





        /// <summary>
        /// 封号开启临时登录/强开
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXUnBanTempLogin))]
        public async Task<ActionResult<RestfulData<object>>> WXUnBanTempLogin([FromBody] TempLoginDto dto)
        {
            WXEnvironment environment;
            if ((bool)(dto.Data?.StartsWith("A")))
            {
                if (dto.Data.Length != 16)
                {
                    return new RestfulData<object>() { code = -1, flag = 0, message = "A16数据有误" };
                }
                environment = new WXEnvironment(Core.Protocol.WXTerminal.ANDROID, "", dto?.Data);
            }
            else
            {
                if (dto.Data.Length != 344)
                {
                    return new RestfulData<object>() { code = -1, flag = 0, message = "62数据有误" };
                }
                environment = new WXEnvironment(Core.Protocol.WXTerminal.IPAD, "Apple", dto?.Data);
            }
            return await CreateClient(environment, dto?.ProxyIP, async (client, result) =>
            {
                result.data = await client?.WXUnBanTempLogin(dto.UserName, dto.Password, dto.Force);
            });
        }
    }
}
