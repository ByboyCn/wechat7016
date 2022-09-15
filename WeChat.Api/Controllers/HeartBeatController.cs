using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using WeChat.Api.Models;
using WeChat.Pb.Entites;

namespace WeChat.Api.Controllers
{
    /// <summary>
    /// 心跳操作
    /// </summary>
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [ApiGroupSort(140)]
    public class HeartbeatController : BaseController
    {
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="cache">缓存</param>
        public HeartbeatController(IDistributedCache cache)
            : base(cache)
        {
        }
        #endregion

        /// <summary>
        /// 心跳
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXHeartBeat))]
        public async Task<ActionResult<RestfulData<object>>> WXHeartBeat([FromBody] BaseDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                var heart = default(Core.Protocol.Protos.HeartBeatResponse);
                try
                {
                    heart = await client.WXHeartBeat();
                }
                catch { }
                if (heart?.BaseResponse?.Ret == 0 && heart?.NextTime > 0 && heart?.Selector > 0)
                {
                    result.code = 0;
                    result.data = "心跳成功";
                    result.message = "success";
                    result.remark = client.Status.ToJson();
                }
                else
                {
                    result.code = -1;
                    result.data = "心跳失败";
                    result.message = "success";
                    result.remark = heart.ToJson();
                }
            });
        }

        /// <summary>
        /// 获取devicetoken
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXHeartBeat))]
        public async Task<ActionResult<RestfulData<object>>> GetDeviceToken([FromBody] BaseDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                var heart = default(TrustResp);
                try
                {
                    heart = await client.WXGetDeviceToken();
                }
                catch { }
                
            });
        }

    }
}
