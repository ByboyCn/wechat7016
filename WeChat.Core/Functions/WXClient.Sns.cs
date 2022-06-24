using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WeChat.Core.Protocol;
using WeChat.Core.Protocol.Protos;
using WeChat.Core.Protocol.Protos.V2;

namespace WeChat.Core
{
    public partial interface IWXApp
    {
        /// <summary>
        /// 设置朋友圈权限
        /// 允许朋友查看朋友圈的范围：7297，值（全部4294967295/最近半年4320/最近一个月720/最近三天72）
        /// 允许陌生人查看十条朋友圈：开启（7296，72）/关闭（7297，72）
        /// </summary>
        /// <param name="function"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        Task<OpLogResponse> WXSnsSwitch(uint function, uint value);
        /// <summary>
        /// 获取朋友圈动态
        /// </summary>
        /// <param name="first_page_md5">/首页为空，次页附带md5</param>
        /// <param name="maxid">首页为0 次页朋友圈消息id 的最小值</param>
        /// <returns></returns>
        Task<Protocol.Protos.V2.SnsTimeLineResponse> WXSnsTimeLine(string first_page_md5 = "", ulong maxid = 0);
        /// <summary>
        /// 获取指定人最早朋友圈
        /// </summary>
        /// <returns></returns>
        Task<Protocol.Protos.V2.SnsObject> WXGetOriginalSns(string username);
        /// <summary>
        /// 获取指定好友朋友圈信息
        /// </summary>
        /// <param name="username">对方用户名</param>
        /// <param name="first_page_md5">/首页为空, 次页附带md5</param>
        /// <param name="maxid">首页为0, 次页朋友圈消息id的最小值</param>
        /// <returns></returns>
        Task<Protocol.Protos.V2.SnsUserPageResponse> WXSnsUserPage(string username, string first_page_md5, ulong maxid = 0);
        /// <summary>
        /// 朋友圈操作（删圈/隐私/公开/删评/取赞）
        /// </summary>
        /// <param name="id">朋友圈消息id</param>
        /// <param name="type">//1删除朋友圈，2设为隐私，3设为公开，4删除评论，5取消点赞</param>
        /// <param name="ext">扩展id</param>
        /// <returns></returns>
        Task<Protocol.Protos.V2.SnsObjectOpResponse> WXSnsObjectOperate(ulong id, int type, uint ext);
        /// <summary>
        /// 发送朋友圈
        /// </summary>
        /// <param name="content">朋友圈结构内容</param>
        /// <param name="black_list">黑名单用户id列表</param>
        /// <param name="with_user_list">提醒用户id列表</param>
        /// <returns></returns>
        Task<Protocol.Protos.V2.SnsPostResponse> WXSnsPost(string content, string[] black_list, string[] with_user_list);
        /// <summary>
        /// 获取朋友圈消息详情
        /// </summary>
        /// <param name="id">消息id</param>
        /// <returns></returns>
        Task<Protocol.Protos.V2.SnsObjectDetailResponse> WXSnsObjectDetail(ulong id);
        /// <summary>
        /// 同步朋友圈
        /// </summary>
        /// <returns></returns>
        Task<Protocol.Protos.SnsSyncResponse> WXSnsSync();
        /// <summary>
        /// 上传朋友圈图片
        /// </summary>
        /// <param name="data">图片文件数据</param>
        /// <returns></returns>
        Task<Protocol.Protos.SnsUploadResponse> WXSnsUpload(byte[] data);
        /// <summary>
        /// 朋友圈消息回复（点赞/文本/消息/with/陌生人点赞）
        /// </summary>
        /// <param name="id">朋友圈消息Id</param>
        /// <param name="username">对方用户名</param>
        /// <param name="reply_id">回复的id</param>
        /// <param name="content">评论内容</param>
        /// <param name="type">1:点赞, 2:文本, 3:消息, 4:with, 5:陌生人点赞</param>
        /// <returns></returns>
        Task<Protocol.Protos.SnsCommentResponse> WXSnsComment(ulong id, string username, int reply_id, string content, int type);
    }
    public partial class WXApp
    {
        /// <summary>
        /// 设置朋友圈权限
        /// 允许朋友查看朋友圈的范围：7297，值（全部4294967295/最近半年4320/最近一个月720/最近三天72）
        /// 允许陌生人查看十条朋友圈：开启（7296，72）/关闭（7297，72）
        /// </summary>
        /// <param name="function"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual async Task<OpLogResponse> WXSnsSwitch(uint function, uint value = 0)
        {
            var result = default(OpLogResponse);
            var profile = await WXGetProfile();
            profile?.CallWhen(profile?.baseResponse?.ret == RetConst.MM_OK, async _ =>
            {
                var userinfo = profile.userInfoExt.snsUserInfo;
                userinfo.snsFlag = 1;
                userinfo.snsFlagEx = function;
                userinfo.snsPrivacyRecent = value;
                result = await WXOpLog(SyncCmdID.MM_SYNCCMD_MODSNSUSERINFO, userinfo);
            });
            return result;
        }
        /// <summary>
        /// 获取朋友圈动态
        /// </summary>
        /// <param name="first_page_md5">/首页为空，次页附带md5</param>
        /// <param name="maxid">首页为0 次页朋友圈消息id 的最小值</param>
        /// <returns></returns>
        public virtual async Task<Protocol.Protos.V2.SnsTimeLineResponse> WXSnsTimeLine(string first_page_md5 = "", ulong maxid = 0)
        {
            return await Request<Protocol.Protos.V2.SnsTimeLineResponse>(new Protocol.Protos.V2.SnsTimeLineRequest()
            {
                baseRequest = new Protocol.Protos.V2.BaseRequest
                {
                    clientVersion = (int)(_Environment.Terminal.GetWeChatVersion() & 0xF0000000 | 0x06070228),
                    devicelId = _Environment.WeChatDataId.ToByteArray(16, 2),
                    osType = _Environment.WeChatOsType,
                    sessionKey = _Cache.SessionKey,
                    scene = _Cache.Scene,
                    uin = _Cache.Uin
                },
                clientLastestId = 0,
                firstPageMd5 = first_page_md5,
                lastRequestTime = 0,
                maxId = maxid,
                minFilterId = 0,
                networkType = 1,
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_mmsnstimeline);
        }

        /// <summary>
        /// 获取指定人最早朋友圈
        /// </summary>
        /// <returns></returns>
        public virtual async Task<Protocol.Protos.V2.SnsObject> WXGetOriginalSns(string username)
        {
            ulong max = 0; var md5 = "";
            //var r = default(Core.Protocol.Protos.V2.SnsTimeLineResponse);
            var r = default(Core.Protocol.Protos.V2.SnsUserPageResponse);
            var ret = default(Core.Protocol.Protos.V2.SnsObject);
            do
            {
                //r = await WXSnsTimeLine(md5, max);
                r = await WXSnsUserPage(username, md5, max);
                if (r?.baseResponse?.ret != Core.Protocol.Protos.V2.RetConst.MM_OK) { break; }
                ret = r?.objectList?.OrderBy(o => o.createTime)?.FirstOrDefault() ?? ret;
                max = ret?.id ?? 0;
                md5 = r?.fristPageMd5 ?? "";
            } while ((r?.objectCount ?? 0) > 0);
            return ret;
        }

        /// <summary>
        /// 获取指定好友朋友圈信息
        /// </summary>
        /// <param name="username">对方用户名</param>
        /// <param name="first_page_md5">/首页为空, 次页附带md5</param>
        /// <param name="maxid">首页为0, 次页朋友圈消息id的最小值</param>
        /// <returns></returns>
        public virtual async Task<Protocol.Protos.V2.SnsUserPageResponse> WXSnsUserPage(string username, string first_page_md5, ulong maxid = 0)
        {
            return await Request<Protocol.Protos.V2.SnsUserPageResponse>(new Protocol.Protos.V2.SnsUserPageRequest()
            {
                baseRequest = new Protocol.Protos.V2.BaseRequest
                {
                    clientVersion = (int)(_Environment.Terminal.GetWeChatVersion() & 0xF0000000 | 0x06070228),
                    devicelId = _Environment.WeChatDataId.ToByteArray(16, 2),
                    osType = _Environment.WeChatOsType,
                    sessionKey = _Cache.SessionKey,
                    scene = _Cache.Scene,
                    uin = _Cache.Uin
                },
                fristPageMd5 = first_page_md5,
                username = username,
                maxid = maxid,
                source = 0,
                minFilterId = 0,
                lastRequestTime = 0
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_mmsnsuserpage);
        }

        /// <summary>
        /// 朋友圈操作（删圈/隐私/公开/删评/取赞）
        /// </summary>
        /// <param name="id">朋友圈消息id</param>
        /// <param name="type">//1删除朋友圈，2设为隐私，3设为公开，4删除评论，5取消点赞</param>
        /// <param name="ext">扩展id</param>
        /// <returns></returns>
        public virtual async Task<Protocol.Protos.V2.SnsObjectOpResponse> WXSnsObjectOperate(ulong id, int type, uint ext)
        {
            var extinfo = new SnsObjectOpExt() { id = ext }.SerializeToProtoBuf();
            return await Request<Protocol.Protos.V2.SnsObjectOpResponse>(new Protocol.Protos.V2.SnsObjectOpRequest()
            {
                baseRequest = new Protocol.Protos.V2.BaseRequest
                {
                    clientVersion = _Environment.Terminal.GetWeChatVersion(),
                    devicelId = _Environment.WeChatDataId.ToByteArray(16, 2),
                    osType = _Environment.WeChatOsType,
                    sessionKey = _Cache.SessionKey,
                    scene = _Cache.Scene,
                    uin = _Cache.Uin
                },
                opCount = 1,
                opList = new Protocol.Protos.V2.SnsObjectOp
                {
                    id = id,
                    opType = (SnsObjectOpType)type,
                    ext = new SKBuiltinString_ { buffer = extinfo, iLen = (uint)extinfo.Length }
                }
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_mmsnsobjectop);
        }

        /// <summary>
        /// 发送朋友圈
        /// </summary>
        /// <param name="content">朋友圈结构内容</param>
        /// <param name="black_list">黑名单用户id列表</param>
        /// <param name="with_user_list">提醒用户id列表</param>
        /// <returns></returns>
        public virtual async Task<Protocol.Protos.V2.SnsPostResponse> WXSnsPost(string content, string[] black_list, string[] with_user_list)
        {
            return await Request<Protocol.Protos.V2.SnsPostResponse>(new Protocol.Protos.V2.SnsPostRequest()
            {
                baseRequest = new Protocol.Protos.V2.BaseRequest
                {
                    clientVersion = _Environment.Terminal.GetWeChatVersion(),
                    devicelId = _Environment.WeChatDataId.ToByteArray(16, 2),
                    osType = _Environment.WeChatOsType,
                    sessionKey = _Cache.SessionKey,
                    scene = _Cache.Scene,
                    uin = _Cache.Uin
                },
                objectDesc = new SKBuiltinString_S { buffer = content, iLen = (uint)(content?.Length ?? 0) },
                withUserListNum = (uint)(with_user_list?.Length ?? 0),
                withUserList = with_user_list?.Select(u => new SKBuiltinString { @string = u })?.ToArray(),
                clientId = $"sns_post_{_Profile.UserName}_{DateTime.UtcNow.ToTimeStamp()}_0",
                postBGImgType = 1,
                blackListNum = (uint)(black_list?.Length ?? 0),
                blackList = black_list?.Select(u => new SKBuiltinString { @string = u })?.ToArray(),
                snsPostOperationFields = new SnsPostOperationFields(),
                poiInfo = new SKBuiltinString_()
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_mmsnspost);
        }

        /// <summary>
        /// 获取朋友圈消息详情
        /// </summary>
        /// <param name="id">消息id</param>
        /// <returns></returns>
        public virtual async Task<Protocol.Protos.V2.SnsObjectDetailResponse> WXSnsObjectDetail(ulong id)
        {
            return await Request<Protocol.Protos.V2.SnsObjectDetailResponse>(new Protocol.Protos.SnsObjectDetailRequest()
            {
                BaseRequest = new Protocol.Protos.BaseRequest
                {
                    ClientVersion = (int)(_Environment.Terminal.GetWeChatVersion() & 0xF0000000 | 0x06070228),
                    DeviceID = _Environment.WeChatDataId.ToByteArray(16, 2),
                    DeviceType = _Environment.WeChatOsType.ToBytes(),
                    SessionKey = _Cache.SessionKey,
                    Scene = (uint)(_Cache.Scene),
                    Uin = _Cache.Uin
                },
                Id = id
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_mmsnsobjectdetail);
        }

        /// <summary>
        /// 同步朋友圈
        /// </summary>
        /// <returns></returns>
        public virtual async Task<Protocol.Protos.SnsSyncResponse> WXSnsSync()
        {
            var result = await Request<Protocol.Protos.SnsSyncResponse>(new Protocol.Protos.SnsSyncRequest()
            {
                BaseRequest = new Protocol.Protos.BaseRequest
                {
                    ClientVersion = (int)(_Environment.Terminal.GetWeChatVersion() & 0xF0000000 | 0x06070228),
                    DeviceID = _Environment.WeChatDataId.ToByteArray(16, 2),
                    DeviceType = _Environment.WeChatOsType.ToBytes(),
                    SessionKey = _Cache.SessionKey,
                    Scene = (uint)(_Cache.Scene),
                    Uin = _Cache.Uin
                },
                KeyBuf = new SKBuiltinBuffer_t { Buffer = _Cache.SyncKey, iLen = (uint)(_Cache.SyncKey.Length) },
                Selector = 509,
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_mmsnssync);
            return result;
        }

        /// <summary>
        /// 上传朋友圈图片
        /// </summary>
        /// <param name="data">图片文件数据</param>
        /// <returns></returns>
        public virtual async Task<Protocol.Protos.SnsUploadResponse> WXSnsUpload(byte[] data)
        {
            var result = default(Protocol.Protos.SnsUploadResponse);
            if ((data?.Length ?? 0) <= 0) { return result; }
            var hash = data.MD5().ToString(16, 2);
            var offset = 0; var stream = new MemoryStream(data);
            do
            {
                var count = Math.Min(50000, data.Length - offset);
                var content = new byte[count];
                stream.Seek(offset, SeekOrigin.Begin);
                stream.Read(content, 0, count);
                result = await Request<Protocol.Protos.SnsUploadResponse>(new Protocol.Protos.SnsUploadRequest()
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
                    Type = 2,
                    MD5 = hash,
                    Buffer = new SKBuiltinBuffer_t { Buffer = content, iLen = (uint)count },
                    TotalLen = (uint)data.Length,
                    StartPos = (uint)offset
                }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_mmsnsupload);
                offset += count;
            } while (result?.BaseResponse?.Ret == (int)(RetConst.MM_OK) && offset < data.Length);
            return result;
        }

        /// <summary>
        /// 朋友圈消息回复（点赞/文本/消息/with/陌生人点赞）
        /// </summary>
        /// <param name="id">朋友圈消息Id</param>
        /// <param name="username">对方用户名</param>
        /// <param name="reply_id">回复的id</param>
        /// <param name="content">评论内容</param>
        /// <param name="type">1:点赞, 2:文本, 3:消息, 4:with, 5:陌生人点赞</param>
        /// <returns></returns>
        public virtual async Task<Protocol.Protos.SnsCommentResponse> WXSnsComment(ulong id, string username, int reply_id, string content, int type)
        {
            var timestamp = (uint)DateTime.UtcNow.ToTimeStamp();
            return await Request<Protocol.Protos.SnsCommentResponse>(new Protocol.Protos.SnsCommentRequest()
            {
                BaseRequest = new Protocol.Protos.BaseRequest
                {
                    ClientVersion = _Environment.Terminal.GetWeChatVersion(),
                    DeviceID = _Environment.WeChatDataId.ToByteArray(16, 2),
                    DeviceType = _Environment.WeChatOsType.ToBytes(),
                    SessionKey = _Cache.SessionKey,
                    Scene = (uint)_Cache.Scene,
                    Uin = _Cache.Uin
                },
                Action = new Protocol.Protos.SnsActionGroup()
                {
                    Id = id,
                    CurrentAction = new Protocol.Protos.SnsAction()
                    {
                        FromUsername = _Profile.UserName,
                        ToUsername = username,
                        FromNickname = _Profile.NickName,
                        ToNickname = username,
                        Type = (uint)type,
                        Source = 0,
                        CreateTime = timestamp,
                        Content = content ?? "",
                        ReplyCommentId = reply_id,
                        ReplyCommentId2 = 0
                    }
                },
                ClientId = $"wcc:{_Profile.UserName}-{timestamp}-0"
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_mmsnscomment);
        }
    }
}
