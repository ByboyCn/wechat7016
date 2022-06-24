using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Threading.Tasks;
using WeChat.Api.Models;
using WeChat.Api.Models.Base;
using WeChat.Core;

namespace WeChat.Api.Controllers
{
    /// <summary>
    /// 微信实例操作
    /// </summary>
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [ApiGroupSort(170)]
    public class ClientController : BaseController
    {
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="cache">缓存</param>
        public ClientController(IDistributedCache cache)
            : base(cache)
        {
        }
        #endregion

        /// <summary>
        /// 创建微信实例（A16登录/62登录/扫码登录）
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXCreate))]
        public async Task<ActionResult<RestfulData<BaseDto>>> WXCreate([FromBody] CreateDto dto)
        {
            if (!string.IsNullOrEmpty(dto.WxData))
            {
                if (dto.Terminal == 0 && dto.WxData.Length != 16)
                {
                    return new RestfulData<BaseDto>() { code = -1, flag = 0, message = "A16数据有误" };
                }
                else if (dto.Terminal == 1 && dto.WxData.Length != 344)
                {
                    return new RestfulData<BaseDto>() { code = -1, flag = 0, message = "62数据有误" };
                }
            }
          //  if (dto.Terminal != 0)
           // {
          //      dto.Brand = "Apple";
          //      dto.Terminal = 2;
        //    }
            var envir = new WXEnvironment((Core.Protocol.WXTerminal)(dto.Terminal), dto.Brand, dto.WxData, "", dto.Name, dto.Imei, dto.Mac, "");
            return await CreateClient(dto, "", envir, async (client, result) =>
             {
                 await _Cache.SetAsync(result.data.Guid, client.Serialization.SerializeToBinary(), new DistributedCacheEntryOptions { SlidingExpiration = TimeSpan.FromDays(1) });
                 result.remark = "GUID将作为后续所有操作的帐号标识";
             });
        }

        /// <summary>
        /// 尝试创建微信实例（A16登录/62登录/扫码登录）
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXTryCreate))]
        public async Task<ActionResult<RestfulData<BaseDto>>> WXTryCreate([FromBody] TryCreateDto dto)
        {
            var client = await GetClient(dto.Guid);
            if (client == null || !client.Linker.Session.Initialized || client.Status.Code != 1)
            {
                if (!string.IsNullOrEmpty(dto.WxData))
                {
                    if (dto.Terminal == 0 && dto.WxData.Length != 16)
                    {
                        return new RestfulData<BaseDto>() { code = -1, flag = 0, message = "A16数据有误" };
                    }
                    else if (dto.Terminal == 1 && dto.WxData.Length != 344)
                    {
                        return new RestfulData<BaseDto>() { code = -1, flag = 0, message = "62数据有误" };
                    }
                }
                if (dto.Terminal != 0)
                {
                    dto.Terminal = 2;
                }
                var envir = new WXEnvironment((Core.Protocol.WXTerminal)(dto.Terminal), "", dto.WxData);
                return await CreateClient(new CreateDto() { Proxy = dto.Proxy }, dto.Guid, envir, async (client, result) =>
                {
                    await _Cache.SetAsync(result.data.Guid, client.Serialization.SerializeToBinary(), new DistributedCacheEntryOptions { SlidingExpiration = TimeSpan.FromHours(2) });
                    result.remark = "GUID将作为后续所有操作的帐号标识";
                });
            }
            var heart = default(Core.Protocol.Protos.HeartBeatResponse);
            try
            {
                heart = await client.WXHeartBeat();
            }
            catch { }
            if (heart?.BaseResponse?.Ret != 0 || heart?.NextTime <= 0 || heart?.Selector <= 0)
            {
                if (!string.IsNullOrEmpty(dto.WxData))
                {
                    if (dto.Terminal == 0 && dto.WxData.Length != 16)
                    {
                        return new RestfulData<BaseDto>() { code = -1, flag = 0, message = "A16数据有误" };
                    }
                    else if (dto.Terminal == 1 && dto.WxData.Length != 344)
                    {
                        return new RestfulData<BaseDto>() { code = -1, flag = 0, message = "62数据有误" };
                    }
                }
                if (dto.Terminal != 0)
                {
                    dto.Terminal = 2;
                }
                var envir = new WXEnvironment((Core.Protocol.WXTerminal)(dto.Terminal), "", dto.WxData);
                return await CreateClient(new CreateDto() { Proxy = dto.Proxy }, dto.Guid, envir, async (client, result) =>
                {
                    await _Cache.SetAsync(result.data.Guid, client.Serialization.SerializeToBinary(), new DistributedCacheEntryOptions { SlidingExpiration = TimeSpan.FromHours(2) });
                    result.remark = "GUID将作为后续所有操作的帐号标识";
                });
            }
            return new RestfulData<BaseDto>() { code = 0, flag = 0, data = new BaseDto { Guid = dto.Guid }, message = "success", remark = client.Status.ToJson() };
        }

        /// <summary>
        /// 恢复微信实例
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXRecovery))]
        public async Task<ActionResult<RestfulData<BaseDto>>> WXRecovery([FromBody] RecoveryDto dto)
        {
            var serialization = dto.Serialization.ToByteArray(16, 2).DeserializeFromBinary<WXSerialization>();
            return await CreateClient(dto, serialization, null);
        }

        /// <summary>
        /// 释放微信实例
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXRelease))]
        public async Task<ActionResult<RestfulData<object>>> WXRelease([FromBody] BaseDto dto)
        {
            return await ReleaseClient<object>(dto, null);
        }

        /// <summary>
        /// 序列化微信实例
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXSerialization))]
        public async Task<ActionResult<RestfulData<string>>> WXSerialization([FromBody] BaseDto dto)
        {
            return await Business<string>(dto, async (client, result) =>
            {
                result.data = client.Serialization.SerializeToBinary().ToString(16, 2);
                await Task.CompletedTask;
            });
        }

        /// <summary>
        /// 设置/修改实例代理
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXSetProxy))]
        public async Task<ActionResult<RestfulData<object>>> WXSetProxy([FromBody] SetProxyDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                client.Linker.Proxy = new WXProxy()
                {
                    Enable = dto.Enable,
                    Address = dto.Address,
                    Port = dto.Port,
                    UserName = dto.UserName,
                    Password = dto.Password
                };
                await UpdateClient(dto.Guid, client);
                result.flag = 1;
                result.data = client.Linker.Proxy;
            });
        }

        /// <summary>
        /// 获取微信实例数据（A16/62数据）
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXGetWechatData))]
        public async Task<ActionResult<RestfulData<object>>> WXGetWechatData([FromBody] BaseDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = client?.Environment.WeChatData;
                await Task.CompletedTask;
            });
        }
    }
}