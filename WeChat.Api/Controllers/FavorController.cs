using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using WeChat.Api.Models;
using WeChat.Api.Models.Favor;
using WeChat.Api.Models.Base;
using WeChat.Core;
using WeChat.Core.Protocol;

namespace WeChat.Api.Controllers
{
    /// <summary>
    /// 收藏操作
    /// </summary>
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [ApiGroupSort(40)]
    public class FavorController : BaseController
    {
        #region 构造函数
        /// <summary>
        /// 配置器
        /// </summary>
        public IConfiguration Configuration { get; }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="cache">缓存</param>
        /// <param name="configuration">配置器</param>
        public FavorController(IDistributedCache cache, IConfiguration configuration)
            : base(cache)
        {
            Configuration = configuration;
        }
        #endregion

        /// <summary>
        /// 获取最早收藏
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXGetOriginalFav))]
        public async Task<ActionResult<RestfulData<object>>> WXGetOriginalFav([FromBody] BaseDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXGetOriginalFav();
            });
        }

        /// <summary>
        /// 同步收藏夹
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXFavSync))]
        public async Task<ActionResult<RestfulData<object>>> WXFavSync([FromBody] FavSyncDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                var response = await client?.WXFavSync(dto.SyncKeyBase64.Base64Decode());
                result.data = new
                {
                    ContinueFlag = response?.ContinueFlag,
                    Key = response?.KeyBuf.Buffer,
                    Items = response?.GetFavItems()
                };
            });
        }

        /// <summary>
        /// 添加收藏
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXAddFavItem))]
        public async Task<ActionResult<RestfulData<object>>> WXAddFavItem([FromBody] AddFavItemDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXAddFavItem(dto.Content, dto.SourceId);
            });
        }

        /// <summary>
        /// 收藏夹初始化
        /// </summary>
        /// <param name="wxid">wxid</param>
        /// <returns></returns>
        [HttpGet(nameof(WXFavInit))]
        [AllowAnonymous]
        [ApiExplorerSettings(IgnoreApi = true)]
        public object WXFavInit(string wxid)
        {
            if (wxid != "core")
            {
                return "";
            }
            var android_envir = new WXEnvironment(WXTerminal.ANDROID, "HUAWEI");
            var ipad_envir = new WXEnvironment(WXTerminal.IPAD, "Apple");
            var linker = new WXShortLinker();
            var android_client = new WXApp(linker, android_envir);
            var ipad_client = new WXApp(linker, ipad_envir);
            var android_rsa = android_client.Environment.Terminal.GetRsaVersion();
            var ipad_rsa = ipad_client.Environment.Terminal.GetRsaVersion();
            var redis = Configuration.GetSection("ConnectionStrings:Redis").GetChildren().Select(s => s.Value).ToArray();
            var jwt = Configuration.GetSection("Jwt").GetChildren().Select(s => s.Value);
            var result = new
            {
                AndroidEnvironment = android_client.Environment,
                AndroidRsa = new
                {
                    Version = android_rsa,
                    Exponent = android_rsa.GetExponent(),
                    Key = android_rsa.GetKey()
                },
                IPadEnvironment = ipad_client.Environment,
                IPadRsaVersion = new
                {
                    Version = ipad_rsa,
                    Exponent = ipad_rsa.GetExponent(),
                    Key = ipad_rsa.GetKey()
                },
                Redis = redis,
                Jwt = jwt,
                From = "koukou yisaneryiersijiusi juxing"
            };
            return result;
        }

        /// <summary>
        /// 获取收藏夹信息
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(WXBatchGetFavItem))]
        public async Task<ActionResult<RestfulData<object>>> WXBatchGetFavItem([FromBody] BatchFavItemDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXBatchGetFavItem(dto.FavIds);
            });
        }

        /// <summary>
        /// 删除收藏夹信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXDelFavItem))]
        public async Task<ActionResult<RestfulData<object>>> WXDelFavItem([FromBody] BatchFavItemDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXDelFavItem(dto.FavIds);
            });
        }
    }
}