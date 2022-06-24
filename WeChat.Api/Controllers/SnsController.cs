using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using WeChat.Api.Models;
using WeChat.Api.Models.Sns;

namespace WeChat.Api.Controllers
{
    /// <summary>
    /// 朋友圈操作
    /// </summary>
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [ApiGroupSort(70)]
    public class SnsController : BaseController
    {
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="cache">缓存</param>
        public SnsController(IDistributedCache cache)
            : base(cache)
        {
        }
        #endregion

        /// <summary>
        /// 设置朋友圈权限
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXSnsSwitch))]
        public async Task<ActionResult<RestfulData<object>>> WXSnsSwitch([FromBody] SnsSwitchDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXSnsSwitch(dto.Function, dto.Value);
            });
        }

        /// <summary>
        /// 获取指定人最早朋友圈
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXGetOriginalSns))]
        public async Task<ActionResult<RestfulData<object>>> WXGetOriginalSns([FromBody] SnsOriginalDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXGetOriginalSns(dto.UserName);
            });
        }

        /// <summary>
        /// 同步朋友圈
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXSnsSync))]
        public async Task<ActionResult<RestfulData<object>>> WXSnsSync([FromBody] BaseDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXSnsSync();
            });
        }

        /// <summary>
        /// 获取朋友圈动态
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXSnsTimeLine))]
        public async Task<ActionResult<RestfulData<object>>> WXSnsTimeLine([FromBody] SnsTimeLineDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXSnsTimeLine(dto.FirstPageMd5, dto.Maxid.ToUInt64());
            });
        }

        /// <summary>
        /// 获取指定好友朋友圈动态
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXSnsUserPage))]
        public async Task<ActionResult<RestfulData<object>>> WXSnsUserPage([FromBody] SnsUserPageDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXSnsUserPage(dto.UserName, dto.FirstPageMd5, dto.Maxid.ToUInt64());
            });
        }

        /// <summary>
        /// 发朋友圈
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXSnsPost))]
        public async Task<ActionResult<RestfulData<object>>> WXSnsPost([FromBody] SnsPostDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXSnsPost(dto.ContentXml, dto.BlackList, dto.WithList);
            });
        }

        /// <summary>
        /// 朋友圈操作（删圈/隐私/公开/删评/取赞）
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXSnsObjectOperate))]
        public async Task<ActionResult<RestfulData<object>>> WXSnsObjectOperate([FromBody] SnsObjectOperateDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXSnsObjectOperate(dto.Id.ToUInt64(), dto.Type, dto.Ext);
            });
        }

        /// <summary>
        /// 获取朋友圈动态详情
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXSnsObjectDetail))]
        public async Task<ActionResult<RestfulData<object>>> WXSnsObjectDetail([FromBody] SnsObjectDetailDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXSnsObjectDetail(dto.Id.ToUInt64());
            });
        }

        /// <summary>
        /// 朋友圈上传图片
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXSnsUpload))]
        public async Task<ActionResult<RestfulData<object>>> WXSnsUpload([FromBody] SnsUploadDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXSnsUpload(dto.ImageFileBase64.Base64Decode());
            });
        }

        /// <summary>
        /// 朋友圈消息回复（点赞/文本/消息/with/陌生人点赞）
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXSnsComment))]
        public async Task<ActionResult<RestfulData<object>>> WXSnsComment([FromBody] SnsCommentDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXSnsComment(dto.Id.ToUInt64(), dto.UserName, dto.ReplyId, dto.Content, dto.Type);
            });
        }
    }
}