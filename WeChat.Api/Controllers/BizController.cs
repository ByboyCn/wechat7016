using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using WeChat.Api.Models;
using WeChat.Api.Models.Biz;

namespace WeChat.Api.Controllers
{
    /// <summary>
    /// 公众号操作
    /// </summary>
     //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [ApiGroupSort(110)]
    public class BizController : BaseController
    {
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="cache">缓存</param>
        public BizController(IDistributedCache cache)
            : base(cache)
        {
        }
        #endregion

        /// <summary>
        /// 搜索公众号
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXSearchBiz))]
        public async Task<ActionResult<RestfulData<object>>> WXSearchBiz([FromBody] BaseBizDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXSearchBiz(dto.BizUserName);
            });
        }

        /// <summary>
        /// 关注公众号
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXForkBizAccount))]
        public async Task<ActionResult<RestfulData<object>>> WXForkBizAccount([FromBody] BaseBizDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXForkBizAccount(dto.BizUserName);
            });
        }

        /// <summary>
        /// 操作公众号菜单
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXClickBizMenu))]
        public async Task<ActionResult<RestfulData<object>>> WXClickBizMenu([FromBody] ClickCommandDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXClickBizMenu(dto.BizUserName, dto.MenuID, dto.MenuKey);
            });
        }

        /// <summary>
        /// 阅读公众号文章（链接格式：https://mp.weixin.qq.com/s/xxxxx）
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXReadBizArticle))]
        public async Task<ActionResult<RestfulData<object>>> WXReadBizArticle([FromBody] BizUrlDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXReadBizArticle(dto.Url);
            });
        }

        /// <summary>
        /// 点赞公众号文章（链接格式：https://mp.weixin.qq.com/s/xxxxx）
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXLikeBizArticle))]
        public async Task<ActionResult<RestfulData<object>>> WXLikeBizArticle([FromBody] BizUrlDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXLikeBizArticle(dto.Url);
            });
        }
    }
}
