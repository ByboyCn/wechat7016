using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using WeChat.Api.Models;
using WeChat.Api.Models.Contact;
using WeChat.Api.Models.Other;

namespace WeChat.Api.Controllers
{
    /// <summary>
    /// 其它操作
    /// </summary>
     //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [ApiGroupSort(10)]
    public class OtherController : BaseController
    {
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="cache">缓存</param>
        public OtherController(IDistributedCache cache)
            : base(cache)
        {
        }
        #endregion

        /// <summary>
        /// 摇一摇获取内容
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXShakeReport))]
        public async Task<ActionResult<RestfulData<object>>> WXShakeReport([FromBody] LocationDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXShakeReport(dto.Latitude, dto.Longitude);
            });
        }

        /// <summary>
        /// 摇一摇获取结果
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXShakeGet))]
        public async Task<ActionResult<RestfulData<object>>> WXShakeGet([FromBody] ShakeGetDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXShakeGet(dto.ContextBase64.Base64Decode());
            });
        }

        /// <summary>
        /// 查看附近人
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXGetPeopleNearby))]
        public async Task<ActionResult<RestfulData<object>>> WXGetPeopleNearby([FromBody] LocationDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXGetPeopleNearby(dto.Latitude, dto.Longitude);
            });
        }

        /// <summary>
        /// 搜索硬件设备
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXSearchHardDevice))]
        public async Task<ActionResult<RestfulData<object>>> WXSearchHardDevice([FromBody] SearchHardDeviceDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXSearchHardDevice(dto.Qrcode);
            });
        }

        /// <summary>
        /// 上传设备步数
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXUploadDeviceStep))]
        public async Task<ActionResult<RestfulData<object>>> WXUploadDeviceStep([FromBody] UploadDeviceStepDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXUploadDeviceStep(dto.Count);
            });
        }

        /// <summary>
        /// 添加V3
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXaddv3))]
        public async Task<ActionResult<RestfulData<object>>> WXaddv3([FromBody] ContactDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                String[] UserName = new string[] { dto.UserName };
                var modUserInfo = await client?.WXGetContact(UserName);
                modUserInfo.contactList[0].bitVal = 8;
                modUserInfo.contactList[0].bitMask = 4294967295;
                var res = await client?.WXSetContactBlack2(modUserInfo.contactList[0]);
                if (res != null || res.ret == 0)
                {
                    string str = System.Text.Encoding.Default.GetString(res.oplogRet.ret);
                    if (str == "\u0000")
                    {
                        Thread.Sleep(1500);
                        modUserInfo.contactList[0].bitVal = 0;
                        res = await client?.WXSetContactBlack2(modUserInfo.contactList[0]);
                    }
                    else
                    {
                        result.data = res;
                        result.code = 501;
                        result.message = "失败-A1";
                        return;
                    }
                }
                else
                {
                    result.data = res;
                    result.code = 501;
                    result.message = "失败-B1";
                    return;
                }
                if (res != null || res.ret == 0)
                {
                    string str = System.Text.Encoding.Default.GetString(res.oplogRet.ret);
                    if (str == "\u0000")
                    {
                        Thread.Sleep(1500);
                        result.data = await client?.WXVerifyUser(2, dto.UserName, "", 6, "", "");
                    }
                    else
                    {
                        result.data = res;
                        result.code = 501;
                        result.message = "失败-A2";
                        return;
                    }
                }
                else
                {
                    result.data = res;
                    result.code = 501;
                    result.message = "失败-B2";
                    return;
                }
            });
        }
    }
}
