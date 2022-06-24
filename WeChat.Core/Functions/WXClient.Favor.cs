using System;
using System.Linq;
using System.Threading.Tasks;
using WeChat.Core.Protocol;
using WeChat.Core.Protocol.Protos;

namespace WeChat.Core
{
    public partial interface IWXApp
    {
        /// <summary>
        /// 同步收藏夹
        /// </summary>
        /// <param name="key">第一次为空，后续为上一次的KeyBuf</param>
        /// <returns></returns>
        Task<Protocol.Protos.FavSyncResponse> WXFavSync(byte[] key = null);
        /// <summary>
        /// 获取最早收藏
        /// </summary>
        /// <returns></returns>
        Task<Protocol.Protos.AddFavItem> WXGetOriginalFav();
        /// <summary>
        /// 添加收藏
        /// </summary>
        /// <param name="content">xml格式收藏内容</param>
        /// <param name="sourceid">源id</param>
        /// <returns></returns>
        Task<Protocol.Protos.AddFavItemResponse> WXAddFavItem(string content, string sourceid = "");
        /// <summary>
        ///批量获取收藏夹信息
        /// </summary>
        /// <param name="favids">收藏id列表</param>
        /// <returns></returns>
        Task<Protocol.Protos.BatchGetFavItemResponse> WXBatchGetFavItem(uint[] favids);
        /// <summary>
        /// 批量删除收藏
        /// </summary>
        /// <param name="favids">收藏id列表</param>
        /// <returns></returns>
        Task<BatchDelFavItemResponse> WXDelFavItem(uint[] favids);
    }
    public partial class WXApp
    {
        /// <summary>
        /// 同步收藏夹
        /// </summary>
        /// <param name="key">第一次为空，后续为上一次的KeyBuf</param>
        /// <returns></returns>
        public virtual async Task<Protocol.Protos.FavSyncResponse> WXFavSync(byte[] key = null)
        {
            return await Request<Protocol.Protos.FavSyncResponse>(new Protocol.Protos.FavSyncRequest()
            {
                KeyBuf = new SKBuiltinBuffer_t { Buffer = key, iLen = (uint)(key?.Length ?? 0) },
                Selector = 1
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_favsync);
        }

        /// <summary>
        /// 获取最早收藏
        /// </summary>
        /// <returns></returns>
        public virtual async Task<Protocol.Protos.AddFavItem> WXGetOriginalFav()
        {
            var key = default(byte[]);
            var data = default(Core.Protocol.Protos.AddFavItem);
            var response = default(Core.Protocol.Protos.FavSyncResponse);
            do
            {
                response = await WXFavSync(key);
                if (response?.Ret != 0) { break; }
                data = response?.GetFavItems()?.OrderByDescending(o => o.FavId)?.FirstOrDefault() ?? data;
                key = response?.KeyBuf?.Buffer;
            } while ((response?.ContinueFlag ?? 0) > 0);
            return data;
        }

        /// <summary>
        /// 添加收藏
        /// </summary>
        /// <param name="content">xml格式收藏内容</param>
        /// <param name="sourceid">源id</param>
        /// <returns></returns>
        public virtual async Task<Protocol.Protos.AddFavItemResponse> WXAddFavItem(string content, string sourceid = "")
        {
            return await Request<Protocol.Protos.AddFavItemResponse>(new Protocol.Protos.AddFavItemRequest()
            {
                BaseRequest = new Protocol.Protos.BaseRequest
                {
                    ClientVersion = _Environment.Terminal.GetWeChatVersion(),
                    DeviceID = _Environment.WeChatDataId.ToByteArray(16, 2),
                    DeviceType = _Environment.WeChatOsType.ToBytes(),
                    SessionKey = _Cache.SessionKey,
                    Scene = (uint)(_Cache.Scene),
                    Uin = _Cache.Uin
                },
                ClientId = DateTime.Now.ToTimeStamp().ToString(),
                Object = content,
                Type = 1,
                SourceId = sourceid,
                SourceType = 2
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_addfavitem);
        }

        /// <summary>
        ///批量获取收藏夹信息
        /// </summary>
        /// <param name="favids">收藏id列表</param>
        /// <returns></returns>
        public virtual async Task<Protocol.Protos.BatchGetFavItemResponse> WXBatchGetFavItem(uint[] favids)
        {
            var result = default(Protocol.Protos.BatchGetFavItemResponse);
            if ((favids?.Length ?? 0) <= 0) { return result; }
            return await Request<Protocol.Protos.BatchGetFavItemResponse>(new Protocol.Protos.BatchGetFavItemRequest()
            {
                BaseRequest = new Protocol.Protos.BaseRequest
                {
                    ClientVersion = _Environment.Terminal.GetWeChatVersion(),
                    DeviceID = _Environment.WeChatDataId.ToByteArray(16, 2),
                    DeviceType = _Environment.WeChatOsType.ToBytes(),
                    SessionKey = _Cache.SessionKey,
                    Scene = (uint)(_Cache.Scene),
                    Uin = _Cache.Uin
                },
                Count = (uint)(favids?.Length ?? 0)
            }.CallWhen(true, _ => _.FavIdList.AddRange(favids)).SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_batchgetfavitem);
        }

        /// <summary>
        /// 批量删除收藏
        /// </summary>
        /// <param name="favids">收藏id列表</param>
        /// <returns></returns>
        public virtual async Task<BatchDelFavItemResponse> WXDelFavItem(uint[] favids)
        {
            var result = default(BatchDelFavItemResponse);
            if ((favids?.Length ?? 0) <= 0) { return result; }
            return await Request<BatchDelFavItemResponse>(new BatchDelFavItemRequest()
            {
                BaseRequest = new Protocol.Protos.BaseRequest
                {
                    ClientVersion = _Environment.Terminal.GetWeChatVersion(),
                    DeviceID = _Environment.WeChatDataId.ToByteArray(16, 2),
                    DeviceType = _Environment.WeChatOsType.ToBytes(),
                    SessionKey = _Cache.SessionKey,
                    Scene = (uint)(_Cache.Scene),
                    Uin = _Cache.Uin
                },
                Count = (uint)(favids?.Length ?? 0)
            }.CallWhen(true, _ => _.FavIdList.AddRange(favids)).SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_batchdelfavitem);
        }
    }
    /// <summary>
    /// 同步收藏扩展
    /// </summary>
    public static partial class FavSyncResponseExtensions
    {
        /// <summary>
        /// 获取收藏项
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public static AddFavItem[] GetFavItems(this Protocol.Protos.FavSyncResponse response)
        {
            return response?.CmdList?.List?.Select(item => item.CmdBuf.Buffer.DeserializeFromProtoBuf<AddFavItem>())?.ToArray();
        }
    }
}
