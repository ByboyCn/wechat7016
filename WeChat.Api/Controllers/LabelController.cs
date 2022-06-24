using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using WeChat.Api.Models;
using WeChat.Api.Models.Label;

namespace WeChat.Api.Controllers
{
    /// <summary>
    /// 标签操作
    /// </summary>
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [ApiGroupSort(30)]
    public class LabelController : BaseController
    {
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="cache">缓存</param>
        public LabelController(IDistributedCache cache)
            : base(cache)
        {
        }
        #endregion

        /// <summary>
        /// 获取标签列表
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXGetContactLabelList))]
        public async Task<ActionResult<RestfulData<object>>> WXGetContactLabelList([FromBody] BaseDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXGetContactLabelList();
            });
        }

        /// <summary>
        /// 添加标签
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXAddContactLabel))]
        public async Task<ActionResult<RestfulData<object>>> WXAddContactLabel([FromBody] AddContactLabelDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXAddContactLabel(dto.Name);
            });
        }

        /// <summary>
        /// 修改标签列表
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXModifyContactLabelList))]
        public async Task<ActionResult<RestfulData<object>>> WXModifyContactLabelList([FromBody] ModifyContactLabelListDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXModifyContactLabelList(dto.userLabelInfos);
            });
        }

        /// <summary>
        /// 删除标签
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(WXDelContactLabel))]
        public async Task<ActionResult<RestfulData<object>>> WXDelContactLabel([FromBody] DelContactLabelDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXDelContactLabel(dto.Id);
            });
        }
    }
}