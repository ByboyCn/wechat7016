using Microsoft.AspNetCore.Authorization;
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
    /// 微信控制器基类
    /// </summary>
    [Authorize]
    public abstract class BaseController : ControllerBase
    {
        #region 字段
        /// <summary>
        /// 缓存
        /// </summary>
        protected readonly IDistributedCache _Cache;
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="cache">缓存</param>
        protected BaseController(IDistributedCache cache)
        {
            _Cache = cache;
        }
        #endregion

        /// <summary>
        /// 更新微信实例
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="client"></param>
        /// <returns></returns>
        protected virtual async Task<byte[]> UpdateClient(string guid, IWXApp client)
        {
            if (client == null || guid.IsEmpty()) { return null; }
            //if (client.Serialization.Cache.HybridEcdhPubKey?.Length <= 0 || client.Serialization.Cache.HybridEcdhPriKey == null || client.Serialization.Cache.SessionKey?.Length <= 0)
            //{
            //    throw new Exception("UpdateClient Cache为空");
            //}
            var result = client.Serialization.SerializeToBinary();
            await _Cache.SetAsync(guid, result, new DistributedCacheEntryOptions { SlidingExpiration = TimeSpan.FromHours(2) });
            return result;
        }
        /// <summary>
        /// 获取微信实例
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        protected virtual async Task<IWXApp> GetClient(string guid)
        {
            if (guid.IsEmpty()) { return null; }
            var client = default(IWXApp);
            var data = await _Cache.GetAsync(guid);
            try
            {
                var serializetion = data.DeserializeFromBinary<WXSerialization>();
                //if (serializetion.Cache.HybridEcdhPubKey?.Length <= 0 || serializetion.Cache.HybridEcdhPriKey == null || serializetion.Cache.SessionKey?.Length <= 0)
                //{
                //    throw new Exception("GetClient Cache为空");
                //}
                var linker = new WXShortLinker(serializetion.Server, serializetion.Session) { Proxy = serializetion.Proxy };
                client = new WXApp(linker, serializetion.Environment, serializetion.Cache, serializetion.Profile, serializetion.Status);
            }
            catch
            {
                //throw ex;
            }
            return client;
        }
        /// <summary>
        /// 创建全新微信实例
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="guid"></param>
        /// <param name="environment">环境信息</param>
        /// <param name="action"></param>
        /// <returns></returns>
        protected virtual async Task<RestfulData<BaseDto>> CreateClient(CreateDto dto, string guid, WXEnvironment environment, Action<IWXApp, RestfulData<BaseDto>> action)
        {
            if (guid.IsEmpty()) { guid = Guid.NewGuid().ToString(); }
            var result = new RestfulData<BaseDto> { code = 0, flag = 1, message = "success" };
            var linker = new WXShortLinker(environment.Terminal);
            var mmtls = await linker.InitSession();
            if (!mmtls)
            {
                result.code = -1;
                result.message = "Mmtls握手失败";
                return result;
            }
            result.data = new BaseDto { Guid = guid };
            if (!string.IsNullOrEmpty(dto.Proxy))
            {
                string[] temp = dto.Proxy.Split(":");
                if (temp.Length == 2)
                {
                    linker.Proxy = new WXProxy()
                    {
                        Address = temp[0],
                        Enable = true,
                        Port = (int)temp[1].ToInt32()
                    };
                }
            }
            var client = new WXApp(linker, environment);
            action?.Invoke(client, result);
            return result;
        }
        /// <summary>
        /// 创建序列微信实例
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="serialization">客户端序列化信息</param>
        /// <param name="action"></param>
        /// <returns></returns>
        protected virtual async Task<RestfulData<BaseDto>> CreateClient(RecoveryDto dto, WXSerialization serialization, Action<IWXApp, RestfulData<BaseDto>> action)
        {
            var guid = Guid.NewGuid().ToString();
            var linker = new WXShortLinker(serialization.Server, serialization.Session) { Proxy = serialization.Proxy };
            var client = new WXApp(linker, serialization.Environment, serialization.Cache, serialization.Profile, serialization.Status);
            var result = new RestfulData<BaseDto> { code = 0, flag = 1, message = "success", data = new BaseDto { Guid = guid } };
            await _Cache.SetAsync(guid, client.Serialization.SerializeToBinary(), new DistributedCacheEntryOptions { SlidingExpiration = TimeSpan.FromDays(1) });
            action?.Invoke(client, result);
            return result;
        }
        /// <summary>
        /// 创建临时微信实例
        /// </summary>
        /// <param name="environment">环境</param>
        /// <param name="proxy">代理IP</param>
        /// <param name="action"></param>
        /// <returns></returns>
        protected virtual async Task<RestfulData<object>> CreateClient(WXEnvironment environment, string proxy, Func<IWXApp, RestfulData<object>, Task> action)
        {
            var result = new RestfulData<object> { code = 0, flag = 1, message = "success" };
            var linker = new WXShortLinker(environment.Terminal);
            var mmtls = await linker.InitSession();
            if (!mmtls)
            {
                result.code = -1;
                result.message = "Mmtls握手失败";
                return result;
            }
            if (!string.IsNullOrEmpty(proxy))
            {
                string[] temp = proxy.Split(":");
                if (temp.Length == 2)
                {
                    linker.Proxy = new WXProxy()
                    {
                        Address = temp[0],
                        Enable = true,
                        Port = (int)temp[1].ToInt32()
                    };
                }
            }
            var client = new WXApp(linker, environment);
            await action?.Invoke(client, result);
            return result;
        }
        /// <summary>
        /// 释放微信实例
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        protected virtual async Task<RestfulData<T>> ReleaseClient<T>(BaseDto dto, Action<RestfulData<T>> action)
        {
            var result = new RestfulData<T>() { code = 0, message = "success", flag = 1 };
            await _Cache.RemoveAsync(dto.Guid);
            action?.Invoke(result);
            return result;
        }
        /// <summary>
        /// 请求业务
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dto"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        protected virtual async Task<RestfulData<T>> Business<T>(BaseDto dto, Func<IWXApp, RestfulData<T>, Task> action)
        {
            var result = new RestfulData<T> { code = -1, message = "实例不存在" };
            var client = await GetClient(dto.Guid);
            if (client != null && client.Linker.Session.Initialized)
            {
                result.code = 0;
                result.message = "success";
                await action?.Invoke(client, result);
            }
            return result;
        }
    }
}