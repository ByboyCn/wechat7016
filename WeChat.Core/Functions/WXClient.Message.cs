using System;
using System.IO;
using System.Threading.Tasks;
using WeChat.Core.Protocol;
using WeChat.Core.Protocol.Protos;
using WeChat.Core.Protocol.Protos.V2;

namespace WeChat.Core
{
    public partial interface IWXApp
    {
        /// <summary>
        /// 发送文字消息
        /// </summary>
        /// <param name="username"></param>
        /// <param name="content"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        Task<NewSendMsgRespone> WXSendMsg(string username, string content, int type = 1);
        /// <summary>
        /// 发送Emoji消息
        /// </summary>
        /// <param name="username">接收人</param>
        /// <param name="emoji_md5">表情MD5,石头:da1c289d4e363f3ce1ff36538903b92f/骰子:9e3f303561566dc9342a3ea41e6552a6</param>
        /// <param name="game_type">表情类型 0普通表情,1石头剪刀布,2骰子</param>
        /// <param name="content">当Type=0时忽略本参数 1-3代表剪刀、石头、布,4-9代表骰子1-6点</param>
        /// <returns></returns>
        Task<UploadEmojiResponse> WXSendEmojiMsg(string username, string emoji_md5, int game_type, string content);
        /// <summary>
        /// 分享名片
        /// </summary>
        /// <param name="username">对方用户名</param>
        /// <param name="id">名片微信id</param>
        /// <param name="nickname">昵称</param>
        /// <param name="alias">别名</param>
        /// <returns></returns>
        Task<NewSendMsgRespone> WXShareCard(string username, string id, string nickname, string alias);
        /// <summary>
        /// 分享位置
        /// </summary>
        /// <param name="username">对方用户名</param>
        /// <param name="title">名称</param>
        /// <param name="latitude">经度</param>
        /// <param name="longitude">纬度</param>
        /// <returns></returns>
        Task<NewSendMsgRespone> WXShareLocation(string username, string title, float latitude, float longitude);
        /// <summary>
        /// 分享收藏
        /// </summary>
        /// <param name="username">对方用户名</param>
        /// <param name="ids">收藏id列表</param>
        /// <returns></returns>
        Task<ShareFavResponse> WXShareFav(string username, uint[] ids);
        /// <summary>
        /// 发送语音消息
        /// </summary>
        /// <param name="username">对方用户名</param>
        /// <param name="data">音频数据</param>
        /// <param name="voice_time">音频长度 10为一秒</param>
        /// <param name="type">音频格式：AMR = 0, MP3 = 2, SILK = 4, SPEEX = 1, WAVE = 3</param>
        /// <returns></returns>
        Task<UploadVoiceResponse> WXSendVoice(string username, byte[] data, int voice_time, int type);
        /// <summary>
        /// 撤回消息
        /// </summary>
        /// <param name="username">对方用户名</param>
        /// <param name="new_msg_id">新消息id</param>
        /// <returns></returns>
        Task<RevokeMsgResponse> WXRevokeMsg(string username, ulong new_msg_id);
        /// <summary>
        /// 获取消息视频（支持大视频）
        /// 大视频：length超过61440的字节流
        /// </summary>
        /// <param name="username">对方用户名</param>
        /// <param name="new_msg_id">新消息Id</param>
        /// <param name="total_length">文件总大小</param>
        /// <param name="offset">偏移</param>
        /// <returns></returns>
        Task<DownloadVideoResponse> WXGetMsgVideo(string username, ulong new_msg_id, uint total_length, uint offset = 0);
        /// <summary>
        /// 获取消息语音（支持长语音）
        /// 长语音：length超过61440的字节流
        /// </summary>
        /// <param name="client_msgid"></param>
        /// <param name="msgid"></param>
        /// <param name="new_msgid"></param>
        /// <param name="bufid"></param>
        /// <param name="total_length"></param>
        /// <param name="offset"></param>
        /// <param name="chatroom"></param>
        /// <returns></returns>
        /// <returns></returns>
        Task<Protocol.Protos.V2.DownloadVoiceResponse> WXGetMsgVoice(string client_msgid, uint msgid, ulong new_msgid, ulong bufid, uint total_length, uint offset = 0, string chatroom = "");
        /// <summary>
        /// 获取消息图片（支持高清大图）
        /// 大图：length超过65536的字节流
        /// 高清：xml中有hdlength字段值
        /// </summary>
        /// <param name="username">对方用户名</param>
        /// <param name="new_msg_id">新消息id</param>
        /// <param name="total_length">获取大小 xml中hdlength或length值</param>
        /// <param name="offset">偏移</param>
        /// <param name="CompressType">压缩类型（0压缩 1高清）</param>
        Task<Protocol.Protos.V2.GetMsgImgResponse> WXGetMsgImage(string username, ulong new_msg_id, uint total_length, uint offset = 0, uint CompressType = 0);
        /// <summary>
        /// 消息状态通知
        /// </summary>
        /// <param name="msgid">消息id</param>
        /// <returns></returns>
        Task<Protocol.Protos.V2.StatusNotifyResponse> WXMsgStatusNotify(uint msgid);
        /// <summary>
        /// 发送图片消息
        /// </summary>
        /// <param name="username"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<Protocol.Protos.V2.UploadMsgImgResponse> WXSendImage(string username, byte[] data);
        /// <summary>
        /// 发送视频消息
        /// </summary>
        /// <param name="username"></param>
        /// <param name="video">视频</param>
        /// <param name="image">封面图</param>
        /// <param name="video_time">单位秒</param>
        /// <returns></returns>
        Task<Protocol.Protos.V2.UploadVideoResponse> WXSendVideo(string username, byte[] video, byte[] image, uint video_time);
        /// <summary>
        /// 发送CDN图片消息
        /// </summary>
        /// <param name="username"></param>
        /// <param name="cdnImgUrl"></param>
        /// <param name="cdnImgSize"></param>
        /// <param name="cdnThumbImgSize"></param>
        /// <param name="cdnImgAesKey"></param>
        /// <returns></returns>
        Task<Protocol.Protos.V2.UploadMsgImgResponse> WXSendImageByCDN(string username, string cdnImgUrl, int cdnImgSize, int cdnThumbImgSize, string cdnImgAesKey);
        /// <summary>
        /// 发送CDN高清图片消息
        /// </summary>
        /// <param name="username"></param>
        /// <param name="cdnImgUrl"></param>
        /// <param name="cdnImgSize"></param>
        /// <param name="cdnHDImgSize"></param>
        /// <param name="cdnThumbImgSize"></param>
        /// <param name="cdnImgAesKey"></param>
        /// <returns></returns>
        Task<Protocol.Protos.V2.UploadMsgImgResponse> WXSendHDImageByCDN(string username, string cdnImgUrl, int cdnImgSize, int cdnHDImgSize, int cdnThumbImgSize, string cdnImgAesKey);
        /// <summary>
        /// 发送CDN视频消息
        /// </summary>
        /// <param name="username"></param>
        /// <param name="cdnVideoUrl"></param>
        /// <param name="VideoSize"></param>
        /// <param name="cdnVideoSize"></param>
        /// <param name="cdnThumbVideoSize"></param>
        /// <param name="cdnVideoAesKey"></param>
        /// <returns></returns>
        Task<Protocol.Protos.V2.UploadVideoResponse> WXSendVideoByCDN(string username, string cdnVideoUrl, int VideoSize, int cdnVideoSize, int cdnThumbVideoSize, string cdnVideoAesKey);
        /// <summary>
        /// 同步消息
        /// </summary>
        /// <param name="selector">3同步新消息，5同步通讯录，262151新消息和通讯录一起同步</param>
        /// <returns></returns>
        Task<Protocol.Protos.V2.NewSyncResponse> WXSyncMsg(int selector = 262151);
        /// <summary>
        /// 群发消息（文本）
        /// </summary>
        /// <param name="users">用户名列表</param>
        /// <param name="content">消息内容</param>
        /// <returns></returns>
        Task<Protocol.Protos.V2.MassSendResponse> WXMassMsg(string[] users, string content);
        /// <summary>
        /// 群发消息（图片）
        /// </summary>
        /// <param name="users">用户名列表</param>
        /// <param name="image_data">图片压缩数据</param>
        /// <returns></returns>
        Task<Protocol.Protos.V2.MassSendResponse> WXMassMsg(string[] users, byte[] image_data);
        /// <summary>
        /// 群发消息（视频）
        /// </summary>
        /// <param name="users">用户名列表</param>
        /// <param name="media_data">视频数据</param>
        /// <param name="thumb_image_data">视频缩略图数据</param>
        /// <param name="media_time">视频长度，单位秒</param>
        /// <returns></returns>
        Task<Protocol.Protos.V2.MassSendResponse> WXMassMsg(string[] users, byte[] media_data, byte[] thumb_image_data, uint media_time);
        /// <summary>
        /// 群发消息（语音）
        /// </summary>
        /// <param name="users">用户名列表</param>
        /// <param name="media_data">语音数据</param>
        /// <param name="media_time">语音长度，单位秒</param>
        /// <param name="type">语音格式：AMR = 0, MP3 = 2, SILK = 4, SPEEX = 1, WAVE = 3</param>
        /// <returns></returns>
        Task<Protocol.Protos.V2.MassSendResponse> WXMassMsg(string[] users, byte[] media_data, uint media_time, uint type);
        /// <summary>
        /// 发送app信息
        /// </summary>
        /// <param name="username">对方用户名</param>
        /// <param name="content">消息上下文</param>
        /// <param name="type">类型</param>
        /// <returns></returns>
        Task<Protocol.Protos.SendAppMsgResponse> WXSendAppMsg(string username, string content, uint type = 8);
        /// <summary>
        /// 发送app消息
        /// </summary>
        /// <param name="username">对方用户名</param>
        /// <param name="appid">AppId</param>
        /// <param name="title">标题</param>
        /// <param name="description">描述</param>
        /// <param name="type">app类型 3：音乐  4：小app  5：大app</param>
        /// <param name="url">链接地址</param>
        /// <param name="data_url">数据链接地址</param>
        /// <param name="thumb_url">缩略图链接地址</param>
        /// <returns></returns>
        Task<Protocol.Protos.SendAppMsgResponse> WXSendAppMsg(string username, string appid, string title, string description, int type, string url, string data_url, string thumb_url);
        /// <summary>
        /// 发送分享
        /// </summary>
        /// <param name="username"></param>
        /// <param name="title">标题</param>
        /// <param name="description">描述</param>
        /// <param name="type">app类型 3：音乐  4：小app  5：大app</param>
        /// <param name="url">链接地址</param>
        /// <param name="data_url">数据链接地址</param>
        /// <param name="thumb_url">缩略图链接地址</param>
        /// <returns></returns>
        Task<Protocol.Protos.SendAppMsgResponse> WXSendShare(string username, string title, string description, int type, string url, string data_url, string thumb_url);
        /// <summary>
        /// 发送文件消息
        /// </summary>
        /// <param name="username">对方用户名</param>
        /// <param name="attachid">附件id</param>
        /// <param name="title">标题</param>
        /// <param name="length">文件长度</param>
        /// <param name="extension">文件扩展名</param>
        /// <returns></returns>
        Task<Protocol.Protos.SendAppMsgResponse> WXSendMsgFile(string username, string attachid, string title, long length, string extension);
        /// <summary>
        /// 上传消息文件
        /// </summary>
        /// <param name="data">数据</param>
        /// <returns></returns>
        Task<UploadAppAttachResponse> WXUploadMsgFile(byte[] data);
        /// <summary>
        /// 下载消息文件（支持大文件）
        /// 大文件：length超过50000的字节流
        /// </summary>
        /// <param name="username">对方用户名</param>
        /// <param name="appid">AppId</param>
        /// <param name="attachid">MediaId</param>
        /// <param name="total_length">获取大小</param>
        /// <param name="offset">偏移</param>
        /// <returns></returns>
        Task<DownloadAppAttachResponse> WXDownloadMsgFile(string username, string appid, string attachid, uint total_length, uint offset = 0);
        /// <summary>
        /// 校验大文件下载
        /// </summary>
        /// <param name="aeskey"></param>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <param name="ext"></param>
        /// <param name="md5"></param>
        /// <param name="size"></param>
        /// <param name="fromuser"></param>
        /// <param name="touser"></param>
        /// <returns></returns>
        Task<CheckBigFileDownloadResponse> WXCheckFileDownload(string aeskey, uint type, string name, string ext, string md5, ulong size, string fromuser, string touser);
    }
    public partial class WXApp
    {
        /// <summary>
        /// 同步消息
        /// </summary>
        /// <param name="selector">3同步新消息，5同步通讯录，262151新消息和通讯录一起同步</param>
        /// <returns></returns>
        public virtual async Task<Protocol.Protos.V2.NewSyncResponse> WXSyncMsg(int selector = 262151)
        {
            var result = await Request<Protocol.Protos.V2.NewSyncResponse>(new Protocol.Protos.V2.NewSyncRequest()
            {
                continueflag = new FLAG() { flag = 0 },
                device = _Environment.WeChatOsType,
                scene = 4,
                selector = selector,
                syncmsgdigest = 1,
                tagmsgkey = _Cache.SyncKey.DeserializeFromProtoBuf<syncMsgKey>()
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_newsync);
            return result;
        }

        /// <summary>
        /// 发送文字消息
        /// </summary>
        /// <param name="username"></param>
        /// <param name="content"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public virtual async Task<NewSendMsgRespone> WXSendMsg(string username, string content, int type = 1)
        {
            return await Request<NewSendMsgRespone>(new NewSendMsgRequest()
            {
                info = new ChatInfo
                {
                    clientMsgId = (ulong)(DateTime.UtcNow.ToTimeStamp()),
                    toid = new SKBuiltinString { @string = username },
                    content = content,
                    utc = DateTime.UtcNow.ToTimeStamp(),
                    type = type,
                    msgSource = string.Empty
                },
                cnt = 1
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_newsendmsg);
        }

        /// <summary>
        /// 发送Emoji消息
        /// </summary>
        /// <param name="username">接收人</param>
        /// <param name="emoji_md5">表情MD5,石头:da1c289d4e363f3ce1ff36538903b92f/骰子:9e3f303561566dc9342a3ea41e6552a6</param>
        /// <param name="game_type">表情类型 0普通表情,1石头剪刀布,2骰子</param>
        /// <param name="content">当Type=0时忽略本参数 1-3代表剪刀、石头、布,4-9代表骰子1-6点</param>
        /// <returns></returns>
        /// <returns></returns>
        public virtual async Task<UploadEmojiResponse> WXSendEmojiMsg(string username, string emoji_md5, int game_type, string content)
        {
            var time = DateTime.Now.ToTimeStamp();
            var request = new Protocol.Protos.UploadEmojiRequest()
            {
                BaseRequest = new Protocol.Protos.BaseRequest
                {
                    ClientVersion = _Environment.Terminal.GetWeChatVersion(),
                    DeviceID = _Environment.WeChatDataId.ToByteArray(16, 2),
                    DeviceType = _Environment.WeChatOsType.ToBytes(),
                    SessionKey = _Cache.SessionKey,
                    Uin = _Cache.Uin,
                    Scene = (uint)_Cache.Scene
                },
                ReqTime = (uint)time,
                EmojiItemCount = 1
            };
            request.EmojiItem.Add(new EmojiUploadInfoReq()
            {
                Type = 1,
                ClientMsgID = time.ToString(),
                ToUserName = username,
                MD5 = emoji_md5,
                EmojiBuffer = new SKBuiltinBuffer_t()
                {
                    Buffer = new byte[0],
                    iLen = 0
                },
                StartPos = 0,
                TotalLen = 1,
                ExternXML = String.Format("<gameext type=\"{0}\" content=\"{1}\" ></gameext>", game_type, content)
            });
            return await Request<UploadEmojiResponse>(request.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_sendemoji);
        }

        /// <summary>
        /// 发送图片消息
        /// </summary>
        /// <param name="username"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public virtual async Task<Protocol.Protos.V2.UploadMsgImgResponse> WXSendImage(string username, byte[] data)
        {
            var result = default(Protocol.Protos.V2.UploadMsgImgResponse);
            if ((data?.Length ?? 0) <= 0) { return result; }
            var msgtime = (uint)DateTime.UtcNow.ToTimeStamp();
            var clientimgid = new SKBuiltinString { @string = $"{username}_{msgtime}" };
            var offset = 0; var stream = new MemoryStream(data);
            do
            {
                var count = Math.Min(50000, data.Length - offset);
                var content = new byte[count];
                stream.Seek(offset, SeekOrigin.Begin);
                stream.Read(content, 0, count);
                result = await Request<Protocol.Protos.V2.UploadMsgImgResponse>(new Protocol.Protos.V2.UploadMsgImgRequest()
                {
                    BaseRequest = new Protocol.Protos.V2.BaseRequest
                    {
                        clientVersion = _Environment.Terminal.GetWeChatVersion(),
                        devicelId = _Environment.WeChatDataId.ToByteArray(16, 2),
                        osType = _Environment.WeChatOsType,
                        sessionKey = _Cache.SessionKey,
                        scene = _Cache.Scene,
                        uin = _Cache.Uin
                    },
                    clientImgId = clientimgid,
                    data = new SKBuiltinString_ { buffer = content, iLen = (uint)content.Length },
                    dataLen = (uint)content.Length,
                    totalLen = (uint)(data?.Length ?? 0),
                    to = new SKBuiltinString { @string = username },
                    msgType = (uint)3,
                    from = new SKBuiltinString { @string = _Profile.UserName },
                    startPos = (uint)offset,
                    messageExt = "png",
                    reqTime = Convert.ToUInt32(msgtime),
                    encryVer = 0,
                    uICreateTime = msgtime,
                }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_uploadmsgimg);
                offset += count;
            } while (result?.baseResponse?.ret == RetConst.MM_OK && offset < data.Length);
            return result;
        }

        /// <summary>
        /// 发送视频消息
        /// </summary>
        /// <param name="username"></param>
        /// <param name="video">视频</param>
        /// <param name="image">封面图</param>
        /// <param name="video_time">单位秒</param>
        /// <returns></returns>
        public virtual async Task<Protocol.Protos.V2.UploadVideoResponse> WXSendVideo(string username, byte[] video, byte[] image, uint video_time)
        {
            var result = default(Protocol.Protos.V2.UploadVideoResponse);
            var clientid = DateTime.Now.ToTimeStamp().ToString();
            var offset = 0; var stream = new MemoryStream(image);
            var BaseRequest = new Protocol.Protos.V2.BaseRequest
            {
                clientVersion = _Environment.Terminal.GetWeChatVersion(),
                devicelId = _Environment.WeChatDataId.ToByteArray(16, 2),
                osType = _Environment.WeChatOsType,
                sessionKey = _Cache.SessionKey,
                scene = _Cache.Scene,
                uin = _Cache.Uin
            };
            var videoData = new SKBuiltinString_ { buffer = new byte[0], iLen = 0 };
            do
            {
                var count = Math.Min(50000, image.Length - offset);
                var content = new byte[count];
                stream.Seek(offset, SeekOrigin.Begin);
                stream.Read(content, 0, count);
                result = await Request<Protocol.Protos.V2.UploadVideoResponse>(new Protocol.Protos.V2.UploadVideoRequest()
                {
                    BaseRequest = BaseRequest,
                    clientMsgId = clientid,
                    videoData = videoData,
                    videoTotalLen = video.Length,
                    playLength = video_time,
                    videoStartPos = 0,
                    funcFlag = 2,
                    cameraType = 2,
                    videoFrom = 0,
                    from = _Profile.UserName,
                    to = username,
                    networkEnv = 1,
                    reqTime = Convert.ToUInt32(DateTime.Now.ToTimeStamp()),
                    encryVer = 0,
                    thumbStartPos = (uint)offset,
                    thumbTotalLen = image.Length,
                    thumbData = new SKBuiltinString_ { buffer = content, iLen = (uint)content.Length }
                }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_uploadvideo);
                offset += count;
            } while (result?.baseResponse?.ret == RetConst.MM_OK && offset < stream.Length);
            if (result?.baseResponse?.ret != RetConst.MM_OK) { return result; } else { offset = 0; stream.Close(); stream = new MemoryStream(video); }
            var thumbData = new SKBuiltinString_ { buffer = new byte[0], iLen = 0 };
            do
            {
                var count = Math.Min(50000, video.Length - offset);
                var content = new byte[count];
                stream.Seek(offset, SeekOrigin.Begin);
                stream.Read(content, 0, count);
                result = await Request<Protocol.Protos.V2.UploadVideoResponse>(new Protocol.Protos.V2.UploadVideoRequest()
                {
                    BaseRequest = BaseRequest,
                    clientMsgId = clientid,
                    videoData = new SKBuiltinString_ { buffer = content, iLen = (uint)content.Length },
                    videoTotalLen = video.Length,
                    playLength = video_time,
                    videoStartPos = (uint)offset,
                    funcFlag = 2,
                    cameraType = 2,
                    videoFrom = 0,
                    from = _Profile.UserName,
                    to = username,
                    networkEnv = 1,
                    reqTime = Convert.ToUInt32(DateTime.Now.ToTimeStamp()),
                    encryVer = 0,
                    thumbStartPos = (uint)image.Length,
                    thumbTotalLen = image.Length,
                    thumbData = thumbData
                }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_uploadvideo);
                offset += count;
            } while (result?.baseResponse?.ret == RetConst.MM_OK && offset < stream.Length);
            return result;
        }

        /// <summary>
        /// 发送语音消息
        /// </summary>
        /// <param name="username">对方用户名</param>
        /// <param name="data">音频数据</param>
        /// <param name="voice_time">音频长度 10为一秒</param>
        /// <param name="type">音频格式：AMR = 0, MP3 = 2, SILK = 4, SPEEX = 1, WAVE = 3</param>
        /// <returns></returns>
        public virtual async Task<UploadVoiceResponse> WXSendVoice(string username, byte[] data, int voice_time, int type)
        {
            var result = default(UploadVoiceResponse);
            var clientid = DateTime.Now.ToTimeStamp().ToString();
            var offset = 0; var stream = new MemoryStream(data);
            do
            {
                var count = Math.Min(50000, data.Length - offset);
                var content = new byte[count];
                stream.Seek(offset, SeekOrigin.Begin);
                stream.Read(content, 0, count);
                result = await Request<UploadVoiceResponse>(new UploadVoiceRequest()
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
                    from = _Profile.UserName,
                    to = username,
                    clientMsgId = clientid,
                    voiceFormat = (VoiceFormat)type,
                    voiceLen = voice_time,
                    length = data.Length,
                    data = new SKBuiltinString_ { buffer = content, iLen = (uint)(content?.Length ?? 0) },
                    offset = offset,
                    endFlag = (content?.Length ?? 0) < 50000 ? 1 : 0,
                    msgsource = "",
                    reqTime = DateTime.Now.ToTimeStamp(),
                }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_uploadvoice);
                offset += count;
                System.Diagnostics.Debug.WriteLine($"{data.Length}/{offset}/{content?.Length}");
            } while (result?.baseResponse?.ret == RetConst.MM_OK && offset < stream.Length);
            return result;
            //return await Request<UploadVoiceResponse>(new UploadVoiceRequest()
            //{
            //    baseRequest = new Protocol.Protos.V2.BaseRequest
            //    {
            //        clientVersion = _Environment.Terminal.GetWeChatVersion(),
            //        devicelId = _Environment.WeChatDataId.ToByteArray(16, 2),
            //        osType = _Environment.WeChatOsType,
            //        sessionKey = _Cache.SessionKey,
            //        scene = _Cache.Scene,
            //        uin = _Cache.Uin
            //    },
            //    from = _Profile.UserName,
            //    to = username,
            //    clientMsgId = DateTime.Now.ToTimeStamp().ToString(),
            //    voiceFormat = (VoiceFormat)type,
            //    voiceLen = voice_time,
            //    length = data.Length,
            //    data = new SKBuiltinString_ { buffer = data, iLen = (uint)(data?.Length ?? 0) },
            //    offset = 0,
            //    endFlag = 1,
            //    msgsource = ""
            //}.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_uploadvoice);
        }

        /// <summary>
        /// 发送CDN图片消息
        /// </summary>
        /// <param name="username"></param>
        /// <param name="cdnImgUrl"></param>
        /// <param name="cdnImgSize"></param>
        /// <param name="cdnThumbImgSize"></param>
        /// <param name="cdnImgAesKey"></param>
        /// <returns></returns>
        public virtual async Task<Protocol.Protos.V2.UploadMsgImgResponse> WXSendImageByCDN(string username, string cdnImgUrl, int cdnImgSize, int cdnThumbImgSize, string cdnImgAesKey)
        {
            return await Request<Protocol.Protos.V2.UploadMsgImgResponse>(new Protocol.Protos.V2.UploadMsgImgRequest()
            {
                BaseRequest = new Protocol.Protos.V2.BaseRequest
                {
                    clientVersion = _Environment.Terminal.GetWeChatVersion(),
                    devicelId = _Environment.WeChatDataId.ToByteArray(16, 2),
                    osType = _Environment.WeChatOsType,
                    sessionKey = _Cache.SessionKey,
                    scene = _Cache.Scene,
                    uin = _Cache.Uin
                },
                clientImgId = new SKBuiltinString { @string = $"{username}_{(uint)DateTime.UtcNow.ToTimeStamp()}" },
                data = new SKBuiltinString_ { buffer = new byte[0], iLen = 0 },
                dataLen = (uint)cdnImgSize,
                totalLen = (uint)cdnImgSize,
                to = new SKBuiltinString { @string = username },
                msgType = (uint)3,
                from = new SKBuiltinString { @string = _Profile.UserName },
                startPos = 0,
                aESKey = cdnImgAesKey,
                cDNThumbAESKey = cdnImgAesKey,
                cDNMidImgSize = cdnImgSize,
                cDNThumbImgSize = cdnThumbImgSize,
                cDNMidImgUrl = cdnImgUrl,
                cDNThumbImgUrl = cdnImgUrl,
                reqTime = Convert.ToUInt32((uint)DateTime.UtcNow.ToTimeStamp()),
                encryVer = 1
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_uploadmsgimg);
        }

        /// <summary>
        /// 发送CDN高清图片消息
        /// </summary>
        /// <param name="username"></param>
        /// <param name="cdnImgUrl"></param>
        /// <param name="cdnImgSize"></param>
        /// <param name="cdnHDImgSize"></param>
        /// <param name="cdnThumbImgSize"></param>
        /// <param name="cdnImgAesKey"></param>
        /// <returns></returns>
        public virtual async Task<Protocol.Protos.V2.UploadMsgImgResponse> WXSendHDImageByCDN(string username, string cdnImgUrl, int cdnImgSize, int cdnHDImgSize, int cdnThumbImgSize, string cdnImgAesKey)
        {
            return await Request<Protocol.Protos.V2.UploadMsgImgResponse>(new Protocol.Protos.V2.UploadMsgImgRequest()
            {
                BaseRequest = new Protocol.Protos.V2.BaseRequest
                {
                    clientVersion = _Environment.Terminal.GetWeChatVersion(),
                    devicelId = _Environment.WeChatDataId.ToByteArray(16, 2),
                    osType = _Environment.WeChatOsType,
                    sessionKey = _Cache.SessionKey,
                    scene = _Cache.Scene,
                    uin = _Cache.Uin
                },
                clientImgId = new SKBuiltinString { @string = $"{username}_{(uint)DateTime.UtcNow.ToTimeStamp()}" },
                data = new SKBuiltinString_ { buffer = new byte[0], iLen = 0 },
                dataLen = (uint)cdnImgSize,
                totalLen = (uint)cdnImgSize,
                to = new SKBuiltinString { @string = username },
                msgType = (uint)3,
                from = new SKBuiltinString { @string = _Profile.UserName },
                startPos = 0,
                aESKey = cdnImgAesKey,
                cDNThumbAESKey = cdnImgAesKey,
                cDNMidImgSize = cdnImgSize,
                cDNBigImgSize = cdnHDImgSize,
                cDNThumbImgSize = cdnThumbImgSize,
                cDNMidImgUrl = cdnImgUrl,
                cDNBigImgUrl = cdnImgUrl,
                cDNThumbImgUrl = cdnImgUrl,
                reqTime = Convert.ToUInt32((uint)DateTime.UtcNow.ToTimeStamp()),
                encryVer = 1
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_uploadmsgimg);
        }

        /// <summary>
        /// 发送CDN视频消息
        /// </summary>
        /// <param name="username"></param>
        /// <param name="cdnVideoUrl"></param>
        /// <param name="VideoSize"></param>
        /// <param name="cdnVideoSize"></param>
        /// <param name="cdnThumbVideoSize"></param>
        /// <param name="cdnVideoAesKey"></param>
        /// <returns></returns>
        public virtual async Task<Protocol.Protos.V2.UploadVideoResponse> WXSendVideoByCDN(string username, string cdnVideoUrl, int VideoSize, int cdnVideoSize, int cdnThumbVideoSize, string cdnVideoAesKey)
        {
            return await Request<Protocol.Protos.V2.UploadVideoResponse>(new Protocol.Protos.V2.UploadVideoRequest()
            {
                BaseRequest = new Protocol.Protos.V2.BaseRequest
                {
                    clientVersion = _Environment.Terminal.GetWeChatVersion(),
                    devicelId = _Environment.WeChatDataId.ToByteArray(16, 2),
                    osType = _Environment.WeChatOsType,
                    sessionKey = _Cache.SessionKey,
                    scene = _Cache.Scene,
                    uin = _Cache.Uin
                },
                clientMsgId = $"{username}_{(uint)DateTime.UtcNow.ToTimeStamp()}",
                videoData = new SKBuiltinString_ { buffer = new byte[0], iLen = 0 },
                videoTotalLen = cdnVideoSize,
                playLength = (uint)cdnVideoSize,
                videoStartPos = 0,
                funcFlag = (uint)2,
                cameraType = 2,
                videoFrom = 0,
                to = username,
                from = _Profile.UserName,
                networkEnv = 1,
                reqTime = Convert.ToUInt32((uint)DateTime.UtcNow.ToTimeStamp()),
                encryVer = 0,
                cDNVideoUrl = cdnVideoUrl,
                aESKey = cdnVideoAesKey,
                cDNThumbUrl = cdnVideoUrl,
                cDNThumbImgSize = cdnThumbVideoSize,
                cDNThumbAESKey = cdnVideoAesKey,
                thumbStartPos = 0,
                thumbTotalLen = 50000,
                thumbData = new SKBuiltinString_() { iLen = (uint)0, buffer = new byte[0] }
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_uploadvideo);
        }

        /// <summary>
        /// 分享名片
        /// </summary>
        /// <param name="username">对方用户名</param>
        /// <param name="id">名片微信id</param>
        /// <param name="nickname">昵称</param>
        /// <param name="alias">别名</param>
        /// <returns></returns>
        public virtual async Task<NewSendMsgRespone> WXShareCard(string username, string id, string nickname, string alias)
        {
            nickname = string.IsNullOrEmpty(nickname) ? id : nickname;
            var content = $"<?xml version=\"1.0\"?>\n<msg bigheadimgurl=\"\" smallheadimgurl=\"\" username=\"{id}\" nickname=\"{nickname}\" fullpy=\"\" shortpy=\"\" alias=\"{alias}\" imagestatus=\"0\" scene=\"17\" province=\"\" city=\"\" sign=\"\" sex=\"2\" certflag=\"0\" certinfo=\"\" brandIconUrl=\"\" brandHomeUrl=\"\" brandSubscriptConfigUrl=\"\" brandFlags=\"0\" regionCode=\"CN\" />\n";
            return await WXSendMsg(username, content, 42);
        }

        /// <summary>
        /// 分享位置
        /// </summary>
        /// <param name="username">对方用户名</param>
        /// <param name="title">名称</param>
        /// <param name="latitude">经度</param>
        /// <param name="longitude">纬度</param>
        /// <returns></returns>
        public virtual async Task<NewSendMsgRespone> WXShareLocation(string username, string title, float latitude, float longitude)
        {
            var content = $"<?xml version=\"1.0\"?>\n<msg>\n\t<location x=\"{latitude}\" y=\"{longitude}\" scale=\"16\" label=\"{title}\" maptype=\"0\" poiname=\"[位置]{title}\" poiid=\"\" />\n</msg>";
            return await WXSendMsg(username, content, 48);
        }

        /// <summary>
        /// 分享收藏
        /// </summary>
        /// <param name="username">对方用户名</param>
        /// <param name="ids">收藏id列表</param>
        /// <returns></returns>
        public virtual async Task<ShareFavResponse> WXShareFav(string username, uint[] ids)
        {
            var result = default(ShareFavResponse);
            if ((ids?.Length ?? 0) <= 0) { return result; }
            return await Request<ShareFavResponse>(new ShareFavRequest()
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
                ToUser = username,
                Scene = 0,
                Count = (uint)(ids?.Length)
            }.CallWhen(true, _ => _.FavIdList.AddRange(ids)).SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_sharefav);
        }

        /// <summary>
        /// 撤回消息
        /// </summary>
        /// <param name="username">对方用户名</param>
        /// <param name="new_msg_id">新消息id</param>
        /// <returns></returns>
        public virtual async Task<RevokeMsgResponse> WXRevokeMsg(string username, ulong new_msg_id)
        {
            return await Request<RevokeMsgResponse>(new RevokeMsgRequest()
            {
                BaseRequest = new Protocol.Protos.BaseRequest
                {
                    ClientVersion = _Environment.Terminal.GetWeChatVersion(),
                    DeviceID = _Environment.WeChatDataId.ToByteArray(16, 2),
                    DeviceType = _Environment.WeChatOsType.ToBytes(),
                    SessionKey = _Cache.SessionKey,
                    Uin = _Cache.Uin,
                    Scene = 0
                },
                ClientMsgId = $"{DateTime.Now.ToTimeStamp()}_{new_msg_id}",
                NewClientMsgId = 26,
                CreateTime = (uint)(DateTime.Now.ToTimeStamp()),
                FromUserName = _Profile.UserName,
                ToUserName = username,
                SvrNewMsgId = new_msg_id,
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_revokemsg);
        }

        /// <summary>
        /// 获取消息视频（支持大视频）
        /// 大视频：length超过61440的字节流
        /// </summary>
        /// <param name="username">对方用户名</param>
        /// <param name="new_msg_id">新消息Id</param>
        /// <param name="total_length">文件总大小</param>
        /// <param name="offset">偏移</param>
        /// <returns></returns>
        public virtual async Task<DownloadVideoResponse> WXGetMsgVideo(string username, ulong new_msg_id, uint total_length, uint offset = 0)
        {
            return await Request<DownloadVideoResponse>(new DownloadVideoRequest()
            {
                BaseRequest = new Protocol.Protos.BaseRequest
                {
                    ClientVersion = _Environment.Terminal.GetWeChatVersion(),
                    DeviceID = _Environment.WeChatDataId.ToByteArray(16, 2),
                    DeviceType = _Environment.WeChatOsType.ToBytes(),
                    SessionKey = _Cache.SessionKey,
                    Uin = _Cache.Uin,
                    Scene = 0
                },
                NewMsgId = new_msg_id,
                StartPos = offset,
                NetworkEnv = 1,
                TotalLen = Math.Min(total_length - offset, 61440),
                MxPackSize = total_length
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_downloadvideo);
        }

        /// <summary>
        /// 获取消息语音（支持长语音）
        /// 长语音：length超过61440的字节流
        /// </summary>
        /// <param name="client_msgid"></param>
        /// <param name="msgid"></param>
        /// <param name="new_msgid"></param>
        /// <param name="bufid"></param>
        /// <param name="total_length"></param>
        /// <param name="offset"></param>
        /// <param name="chatroom"></param>
        /// <returns></returns>
        public virtual async Task<Protocol.Protos.V2.DownloadVoiceResponse> WXGetMsgVoice(string client_msgid, uint msgid, ulong new_msgid, ulong bufid, uint total_length, uint offset = 0, string chatroom = "")
        {
            return await Request<Protocol.Protos.V2.DownloadVoiceResponse>(new Protocol.Protos.V2.DownloadVoiceRequest()
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
                msgId = msgid,
                offset = offset,
                length = Math.Min(total_length - offset, 61440),
                Newmsgid = new_msgid,
                clientMsgId = client_msgid,
                MasterbufId = bufid,
                Chatroomname = chatroom
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_downloadvoice);
        }

        /// <summary>
        /// 获取消息图片（支持高清大图）
        /// 大图：length超过65536的字节流
        /// 高清：xml中有hdlength字段值
        /// </summary>
        /// <param name="username">对方用户名</param>
        /// <param name="new_msg_id">新消息id</param>
        /// <param name="total_length">获取大小 xml中hdlength或length值</param>
        /// <param name="offset">偏移</param>
        /// <param name="CompressType">压缩类型（0压缩 1高清）</param>
        /// <returns></returns>
        public virtual async Task<Protocol.Protos.V2.GetMsgImgResponse> WXGetMsgImage(string username, ulong new_msg_id, uint total_length, uint offset = 0, uint CompressType = 0)
        {
            return await Request<Protocol.Protos.V2.GetMsgImgResponse>(new Protocol.Protos.V2.GetMsgImgRequest()
            {
                baseRequest = new Protocol.Protos.V2.BaseRequest
                {
                    clientVersion = _Environment.Terminal.GetWeChatVersion(),
                    devicelId = _Environment.WeChatDataId.ToByteArray(16, 2),
                    osType = _Environment.WeChatOsType,
                    sessionKey = _Cache.SessionKey,
                    uin = _Cache.Uin,
                    scene = 0
                },
                newMsgId = new_msg_id,
                compressType = CompressType,
                dataLen = Math.Min(total_length - offset, 65536),
                startPos = offset,
                totalLen = total_length,
                from = new SKBuiltinString { @string = username },
                to = new SKBuiltinString { @string = _Profile.UserName }
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_getmsgimg);
        }

        /// <summary>
        /// 消息状态通知
        /// </summary>
        /// <param name="msgid">消息id</param>
        /// <returns></returns>
        public virtual async Task<Protocol.Protos.V2.StatusNotifyResponse> WXMsgStatusNotify(uint msgid)
        {
            return await Request<Protocol.Protos.V2.StatusNotifyResponse>(new Protocol.Protos.V2.StatusNotifyRequest()
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
                clientMsgId = msgid.ToString(),
                code = 1
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_statusnotify);
        }

        /// <summary>
        /// 群发消息（文本）
        /// </summary>
        /// <param name="users">用户名列表</param>
        /// <param name="content">消息内容</param>
        /// <returns></returns>
        public virtual async Task<Protocol.Protos.V2.MassSendResponse> WXMassMsg(string[] users, string content)
        {
            var result = default(Protocol.Protos.V2.MassSendResponse);
            if ((users?.Length ?? 0) <= 0) { return result; }
            var tolist = string.Join(';', users);
            var tolistmd5 = tolist.MD5().ToLower();
            var data = content.ToBytes();
            return await Request<Protocol.Protos.V2.MassSendResponse>(new Protocol.Protos.V2.MassSendRequest()
            {
                baseRequest = new Protocol.Protos.V2.BaseRequest
                {
                    clientVersion = _Environment.Terminal.GetWeChatVersion(),
                    devicelId = _Environment.WeChatDataId.ToByteArray(16, 2),
                    osType = _Environment.WeChatOsType,
                    sessionKey = _Cache.SessionKey,
                    uin = _Cache.Uin,
                    scene = 0
                },
                toList = tolist,
                toListMd5 = tolistmd5,
                clientId = $"{DateTime.Now.ToTimeStamp()}_{tolistmd5}",
                msgType = 1,
                mediaTime = 0,
                dataBuffer = new SKBuiltinString_ { buffer = data, iLen = (uint)data.Length },
                dataStartPos = 0,
                dataTotalLen = (uint)data.Length,
                thumbTotalLen = 0,
                thumbStartPos = 0,
                thumbData = new SKBuiltinString_(),
                cameraType = 2,
                videoSource = 0,
                toListCount = (uint)(users?.Length ?? 0),
                isSendAgain = 1,
                compressType = 0,
                voiceFormat = 0
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_masssend);
        }

        /// <summary>
        /// 群发消息（图片）
        /// </summary>
        /// <param name="users">用户名列表</param>
        /// <param name="image_data">图片压缩数据</param>
        /// <returns></returns>
        public virtual async Task<Protocol.Protos.V2.MassSendResponse> WXMassMsg(string[] users, byte[] image_data)
        {
            var result = default(Protocol.Protos.V2.MassSendResponse);
            if ((users?.Length ?? 0) <= 0 || (image_data?.Length ?? 0) <= 0) { return result; }
            var tolist = string.Join(';', users);
            var tolistmd5 = tolist.MD5().ToLower();
            var tolistcount = (uint)(users?.Length ?? 0);
            var clientid = $"{DateTime.Now.ToTimeStamp()}_{tolistmd5}";
            var offset = 0;
            do
            {
                var count = Math.Min(1024 * 8, image_data.Length - offset);
                var data = image_data.Copy(offset, count);
                result = await Request<Protocol.Protos.V2.MassSendResponse>(new Protocol.Protos.V2.MassSendRequest()
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
                    toList = tolist,
                    toListMd5 = tolistmd5,
                    clientId = clientid,
                    msgType = 3,
                    mediaTime = 0,
                    dataBuffer = new SKBuiltinString_ { buffer = data, iLen = (uint)data.Length },
                    dataStartPos = (uint)offset,
                    dataTotalLen = (uint)image_data.Length,
                    thumbTotalLen = 0,
                    thumbStartPos = 0,
                    thumbData = new SKBuiltinString_(),
                    cameraType = 2,
                    videoSource = 0,
                    toListCount = tolistcount,
                    isSendAgain = 1,
                    compressType = 1,
                    voiceFormat = 0
                }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_masssend);
                offset += count;
            } while (result?.baseResponse?.ret == RetConst.MM_OK && offset < image_data.Length);
            return result;
        }

        /// <summary>
        /// 群发消息（视频）
        /// </summary>
        /// <param name="users">用户名列表</param>
        /// <param name="media_data">视频数据</param>
        /// <param name="thumb_image_data">视频缩略图数据</param>
        /// <param name="media_time">视频长度，单位秒</param>
        /// <returns></returns>
        public virtual async Task<Protocol.Protos.V2.MassSendResponse> WXMassMsg(string[] users, byte[] media_data, byte[] thumb_image_data, uint media_time)
        {
            var result = default(Protocol.Protos.V2.MassSendResponse);
            if ((users?.Length ?? 0) <= 0) { return result; }
            var tolist = string.Join(';', users);
            var tolist_md5 = tolist.MD5().ToLower();
            var tolist_count = (uint)(users?.Length ?? 0);
            var clientid = $"{DateTime.Now.ToTimeStamp()}_{tolist_md5}";
            var offset = 0;
            do
            {
                var count = Math.Min(1024 * 32, media_data.Length - offset);
                var data = media_data.Copy(offset, count);
                result = await Request<Protocol.Protos.V2.MassSendResponse>(new Protocol.Protos.V2.MassSendRequest()
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
                    toList = tolist,
                    toListMd5 = tolist_md5,
                    clientId = clientid,
                    msgType = 43,
                    mediaTime = media_time,
                    dataBuffer = new SKBuiltinString_ { buffer = data, iLen = (uint)data.Length },
                    dataStartPos = (uint)offset,
                    dataTotalLen = (uint)media_data.Length,
                    thumbTotalLen = (uint)thumb_image_data.Length,
                    thumbStartPos = 0,
                    thumbData = new SKBuiltinString_(),
                    cameraType = 2,
                    videoSource = 2,
                    toListCount = tolist_count,
                    isSendAgain = 1,
                    compressType = 0,
                    voiceFormat = 0
                }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_masssend);
                offset += count;
            } while (result?.baseResponse?.ret == RetConst.MM_OK && offset < media_data.Length);
            if (result?.baseResponse?.ret == RetConst.MM_OK)
            {
                result = await Request<Protocol.Protos.V2.MassSendResponse>(new Protocol.Protos.V2.MassSendRequest()
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
                    toList = tolist,
                    toListMd5 = tolist_md5,
                    clientId = clientid,
                    msgType = 43,
                    mediaTime = media_time,
                    dataBuffer = new SKBuiltinString_(),
                    dataStartPos = (uint)offset,
                    dataTotalLen = (uint)media_data.Length,
                    thumbTotalLen = (uint)thumb_image_data.Length,
                    thumbStartPos = 0,
                    thumbData = new SKBuiltinString_() { buffer = thumb_image_data, iLen = (uint)thumb_image_data.Length },
                    cameraType = 2,
                    videoSource = 2,
                    toListCount = tolist_count,
                    isSendAgain = 1,
                    compressType = 0,
                    voiceFormat = 0
                }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_masssend);
            }
            return result;
        }

        /// <summary>
        /// 群发消息（语音）
        /// </summary>
        /// <param name="users">用户名列表</param>
        /// <param name="media_data">语音数据</param>
        /// <param name="media_time">语音长度，单位毫秒</param>
        /// <param name="type">语音格式：AMR = 0, MP3 = 2, SILK = 4, SPEEX = 1, WAVE = 3</param>
        /// <returns></returns>
        public virtual async Task<Protocol.Protos.V2.MassSendResponse> WXMassMsg(string[] users, byte[] media_data, uint media_time, uint type)
        {
            var result = default(Protocol.Protos.V2.MassSendResponse);
            if ((users?.Length ?? 0) <= 0) { return result; }
            var tolist = string.Join(';', users);
            var tolistmd5 = tolist.MD5().ToLower();
            var tolist_count = (uint)(users?.Length ?? 0);
            var clientid = $"{DateTime.Now.ToTimeStamp()}_{tolistmd5}";
            var offset = 0;
            do
            {
                var count = Math.Min(1024 * 8, media_data.Length - offset);
                var data = media_data.Copy(offset, count);
                result = await Request<Protocol.Protos.V2.MassSendResponse>(new Protocol.Protos.V2.MassSendRequest()
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
                    toList = tolist,
                    toListMd5 = tolistmd5,
                    clientId = clientid,
                    msgType = 34,
                    mediaTime = media_time,
                    dataBuffer = new SKBuiltinString_ { buffer = data, iLen = (uint)data.Length },
                    dataStartPos = (uint)offset,
                    dataTotalLen = (uint)media_data.Length,
                    thumbTotalLen = 0,
                    thumbStartPos = 0,
                    cameraType = 2,
                    videoSource = 0,
                    toListCount = tolist_count,
                    isSendAgain = 1,
                    compressType = 0,
                    voiceFormat = type
                }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_masssend);
                offset += count;
            } while (result?.baseResponse?.ret == RetConst.MM_OK && offset < media_data.Length);
            return result;
        }

        /// <summary>
        /// 发送app信息
        /// </summary>
        /// <param name="username">对方用户名</param>
        /// <param name="content">消息上下文</param>
        /// <param name="type">类型</param>
        /// <returns></returns>
        public virtual async Task<Protocol.Protos.SendAppMsgResponse> WXSendAppMsg(string username, string content, uint type = 8)
        {
            return await Request<Protocol.Protos.SendAppMsgResponse>(new Protocol.Protos.SendAppMsgRequest()
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
                Msg = new Protocol.Protos.AppMsg
                {
                    ClientMsgId = DateTime.Now.ToTimeStamp().ToString(),
                    ToUserName = username,
                    Content = content,
                    FromUserName = _Profile.UserName,
                    Type = type
                }
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_sendappmsg);
        }

        /// <summary>
        /// 发送app消息
        /// </summary>
        /// <param name="username">对方用户名</param>
        /// <param name="appid">AppId</param>
        /// <param name="title">标题</param>
        /// <param name="description">描述</param>
        /// <param name="type">app类型 3：音乐  4：小app  5：大app</param>
        /// <param name="url">链接地址</param>
        /// <param name="data_url">数据链接地址</param>
        /// <param name="thumb_url">缩略图链接地址</param>
        /// <returns></returns>
        public virtual async Task<Protocol.Protos.SendAppMsgResponse> WXSendAppMsg(string username, string appid, string title, string description, int type, string url, string data_url, string thumb_url)
        {
            data_url = string.IsNullOrEmpty(data_url) ? url : data_url;
            var content = $"<appmsg appid=\"{appid}\" sdkver=\"0\"><title>{title}</title><des>{description}</des><type>{type}</type><showtype>0</showtype><soundtype>0</soundtype><contentattr>0</contentattr><url>{url}</url><lowurl>{url}</lowurl><dataurl>{data_url}</dataurl><lowdataurl>{data_url}</lowdataurl> <thumburl>{thumb_url}</thumburl></appmsg>";
            return await Request<Protocol.Protos.SendAppMsgResponse>(new Protocol.Protos.SendAppMsgRequest()
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
                Msg = new Protocol.Protos.AppMsg
                {
                    ClientMsgId = DateTime.Now.ToTimeStamp().ToString(),
                    ToUserName = username,
                    Content = content,
                    FromUserName = _Profile.UserName,
                    Type = (uint)type,
                    AppId = appid,
                    CreateTime = (uint)(DateTime.Now.ToTimeStamp())
                }
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_sendappmsg);
        }

        /// <summary>
        /// 发送分享
        /// </summary>
        /// <param name="username"></param>
        /// <param name="title">标题</param>
        /// <param name="description">描述</param>
        /// <param name="type">app类型 3：音乐  4：小app  5：大app</param>
        /// <param name="url">链接地址</param>
        /// <param name="data_url">数据链接地址</param>
        /// <param name="thumb_url">缩略图链接地址</param>
        /// <returns></returns>
        public virtual async Task<Protocol.Protos.SendAppMsgResponse> WXSendShare(string username, string title, string description, int type, string url, string data_url, string thumb_url)
        {
            data_url = string.IsNullOrEmpty(data_url) ? url : data_url;
            var content = $"<appmsg  sdkver=\"0\"><title>{title}</title><des>{description}</des><type>{type}</type><showtype>0</showtype><soundtype>0</soundtype><contentattr>0</contentattr><url>{url}</url><lowurl>{url}</lowurl><dataurl>{data_url}</dataurl><lowdataurl>{data_url}</lowdataurl> <thumburl>{thumb_url}</thumburl></appmsg>";
            return await WXSendAppMsg(username, content);
        }

        /// <summary>
        /// 发送文件消息
        /// </summary>
        /// <param name="username">对方用户名</param>
        /// <param name="attachid">附件id</param>
        /// <param name="title">标题</param>
        /// <param name="length">文件长度</param>
        /// <param name="extension">文件扩展名</param>
        /// <returns></returns>
        public virtual async Task<Protocol.Protos.SendAppMsgResponse> WXSendMsgFile(string username, string attachid, string title, long length, string extension)
        {
            var content = $"<?xml version=\"1.0\"?>\n<appmsg appid='' sdkver=''><title>{title}</title><des></des><action></action><type>6</type><content></content><url></url><lowurl></lowurl><appattach><totallen>{length}</totallen><attachid>{attachid}</attachid><fileext>{extension}</fileext></appattach><extinfo></extinfo></appmsg>";
            return await WXSendAppMsg(username, content, 6);
        }

        /// <summary>
        /// 上传消息文件
        /// </summary>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public virtual async Task<UploadAppAttachResponse> WXUploadMsgFile(byte[] data)
        {
            var result = default(UploadAppAttachResponse);
            if (data == null) { return result; }
            var offset = 0; var stream = new MemoryStream(data);
            do
            {
                var count = Math.Min(50000, data.Length - offset);
                var content = new byte[count];
                stream.Seek(offset, SeekOrigin.Begin);
                stream.Read(content, 0, count);
                result = await Request<UploadAppAttachResponse>(new UploadAppAttachRequest()
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
                    ClientAppDataId = DateTime.Now.ToTimeStamp().ToString(),
                    Data = new SKBuiltinBuffer_t { Buffer = content, iLen = (uint)content.Length },
                    UserName = _Profile.UserName,
                    DataLen = (uint)content.Length,
                    TotalLen = (uint)(data?.Length ?? 0),
                    Type = 4,
                    StartPos = (uint)offset
                }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_uploadappattach);
                offset += count;
            } while (result?.BaseResponse?.Ret == (int)(RetConst.MM_OK) && offset < data.Length);
            return result;
        }

        /// <summary>
        /// 下载消息文件（支持大文件）
        /// 大文件：length超过50000的字节流
        /// </summary>
        /// <param name="username">对方用户名</param>
        /// <param name="appid">AppId</param>
        /// <param name="attachid">MediaId</param>
        /// <param name="total_length">获取大小</param>
        /// <param name="offset">偏移</param>
        /// <returns></returns>
        public virtual async Task<DownloadAppAttachResponse> WXDownloadMsgFile(string username, string appid, string attachid, uint total_length, uint offset = 0)
        {
            return await Request<DownloadAppAttachResponse>(new DownloadAppAttachRequest()
            {
                BaseRequest = new Protocol.Protos.BaseRequest
                {
                    ClientVersion = _Environment.Terminal.GetWeChatVersion(),
                    DeviceID = _Environment.WeChatDataId.ToByteArray(16, 2),
                    DeviceType = _Environment.WeChatOsType.ToBytes(),
                    SessionKey = _Cache.SessionKey,
                    Uin = _Cache.Uin,
                    Scene = 0
                },
                AppId = appid,
                MediaId = attachid,
                UserName = username,
                TotalLen = total_length,
                StartPos = offset,
                DataLen = 0,
                OutFmt = "",
                Rotation = 0,
                Type = 0,
                CDNType = 0,
                SdkVersion = 0,
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_downloadappattach);
        }

        /// <summary>
        /// 校验大文件下载
        /// </summary>
        /// <param name="aeskey"></param>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <param name="ext"></param>
        /// <param name="md5"></param>
        /// <param name="size"></param>
        /// <param name="fromuser"></param>
        /// <param name="touser"></param>
        /// <returns></returns>
        public virtual async Task<CheckBigFileDownloadResponse> WXCheckFileDownload(string aeskey, uint type, string name, string ext, string md5, ulong size, string fromuser, string touser)
        {
            return await Request<CheckBigFileDownloadResponse>(new CheckBigFileDownloadRequest()
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
                AESKey = aeskey,
                FileExt = ext,
                FileMd5 = md5,
                FileName = name,
                FileType = type,
                FileSize = size,
                ToUserName = touser,
                FromUserName = fromuser
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_checkbigfiledownload);
        }

    }
    /// <summary>
    /// 同步消息扩展
    /// </summary>
    public static partial class NewSyncResponseExtensions
    {
        /// <summary>
        /// 保存同步结果
        /// </summary>
        /// <param name="response"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static Protocol.Protos.V2.NewSyncResponse SaveSyncResult(this Protocol.Protos.V2.NewSyncResponse response, ref WXMessage result)
        {
            if (result != null && response?.cmdList?.list != null)
            {
                foreach (var r in response.cmdList.list)
                {
                    switch (r.cmdid)
                    {
                        case SyncCmdID.CmdInvalid: break;
                        case SyncCmdID.CmdIdModContactDomainEmail: break;
                        case SyncCmdID.CmdIdModUserInfo: result.ModUserInfos?.Add(r.cmdBuf.data.DeserializeFromProtoBuf<Protocol.Protos.ModUserInfo>()); break;
                        case SyncCmdID.CmdIdModContact: result.ModContacts?.Add(r.cmdBuf.data.DeserializeFromProtoBuf<Protocol.Protos.ModContact>()); break;
                        case SyncCmdID.CmdIdDelContact: result.DelContacts?.Add(r.cmdBuf.data.DeserializeFromProtoBuf<Protocol.Protos.DelContact>()); break;
                        case SyncCmdID.CmdIdAddMsg: result.AddMsgs?.Add(r.cmdBuf.data.DeserializeFromProtoBuf<Protocol.Protos.AddMsg>()); break;
                        case SyncCmdID.CmdIdModMsgStatus: result.ModMsgStatuss?.Add(r.cmdBuf.data.DeserializeFromProtoBuf<Protocol.Protos.ModMsgStatus>()); break;
                        case SyncCmdID.CmdIdDelChatContact: result.DelChatContacts?.Add(r.cmdBuf.data.DeserializeFromProtoBuf<Protocol.Protos.DelChatContact>()); break;
                        case SyncCmdID.CmdIdDelContactMsg: result.DelContactMsgs?.Add(r.cmdBuf.data.DeserializeFromProtoBuf<Protocol.Protos.DelContactMsg>()); break;
                        case SyncCmdID.CmdIdDelMsg: result.DelMsgs?.Add(r.cmdBuf.data.DeserializeFromProtoBuf<Protocol.Protos.DelMsg>()); break;
                        case SyncCmdID.CmdIdReport: result.Reports?.Add(r.cmdBuf.data.DeserializeFromProtoBuf<Protocol.Protos.Report>()); break;
                        case SyncCmdID.CmdIdOpenQQMicroBlog: result.OpenQQMicroBlogs?.Add(r.cmdBuf.data.DeserializeFromProtoBuf<Protocol.Protos.OpenQQMicroBlog>()); break;
                        case SyncCmdID.CmdIdCloseMicroBlog: result.CloseMicroBlogs?.Add(r.cmdBuf.data.DeserializeFromProtoBuf<Protocol.Protos.CloseMicroBlog>()); break;
                        case SyncCmdID.CmdIdModMicroBlog: result.ModMicroBlogInfos?.Add(r.cmdBuf.data.DeserializeFromProtoBuf<Protocol.Protos.ModMicroBlogInfo>()); break;
                        case SyncCmdID.CmdIdModNotifyStatus: result.ModNotifyStatuss?.Add(r.cmdBuf.data.DeserializeFromProtoBuf<Protocol.Protos.ModNotifyStatus>()); break;
                        case SyncCmdID.CmdIdModChatRoomMember: result.ModChatRoomMembers?.Add(r.cmdBuf.data.DeserializeFromProtoBuf<Protocol.Protos.ModChatRoomMember>()); break;
                        case SyncCmdID.CmdIdQuitChatRoom: result.QuitChatRooms?.Add(r.cmdBuf.data.DeserializeFromProtoBuf<Protocol.Protos.QuitChatRoom>()); break;
                        case SyncCmdID.CmdIdModUserDomainEmail: result.ModUserDomainEmails?.Add(r.cmdBuf.data.DeserializeFromProtoBuf<Protocol.Protos.ModUserDomainEmail>()); break;
                        case SyncCmdID.CmdIdDelUserDomainEmail: result.DelUserDomainEmails?.Add(r.cmdBuf.data.DeserializeFromProtoBuf<Protocol.Protos.DelUserDomainEmail>()); break;
                        case SyncCmdID.CmdIdModChatRoomNotify: result.ModChatRoomNotifys?.Add(r.cmdBuf.data.DeserializeFromProtoBuf<Protocol.Protos.ModChatRoomNotify>()); break;
                        case SyncCmdID.CmdIdPossibleFriend: result.PossibleFriends?.Add(r.cmdBuf.data.DeserializeFromProtoBuf<Protocol.Protos.PossibleFriend>()); break;
                        case SyncCmdID.CmdIdInviteFriendOpen: result.InviteFriendOpens?.Add(r.cmdBuf.data.DeserializeFromProtoBuf<Protocol.Protos.InviteFriendOpen>()); break;
                        case SyncCmdID.CmdIdFunctionSwitch: result.FunctionSwitchs?.Add(r.cmdBuf.data.DeserializeFromProtoBuf<Protocol.Protos.FunctionSwitch>()); break;
                        case SyncCmdID.CmdIdModQContact: result.QContacts?.Add(r.cmdBuf.data.DeserializeFromProtoBuf<Protocol.Protos.QContact>()); break;
                        case SyncCmdID.CmdIdModTContact: result.TContacts?.Add(r.cmdBuf.data.DeserializeFromProtoBuf<Protocol.Protos.TContact>()); break;
                        case SyncCmdID.CmdIdPsmStat: result.PSMStats?.Add(r.cmdBuf.data.DeserializeFromProtoBuf<Protocol.Protos.PSMStat>()); break;
                        case SyncCmdID.CmdIdModChatRoomTopic: result.ModChatRoomTopics?.Add(r.cmdBuf.data.DeserializeFromProtoBuf<Protocol.Protos.ModChatRoomTopic>()); break;
                        case SyncCmdID.MM_SYNCCMD_UPDATESTAT: result.UpdateStatOpLogs?.Add(r.cmdBuf.data.DeserializeFromProtoBuf<Protocol.Protos.UpdateStatOpLog>()); break;
                        case SyncCmdID.MM_SYNCCMD_MODDISTURBSETTING: result.ModDisturbSettings?.Add(r.cmdBuf.data.DeserializeFromProtoBuf<Protocol.Protos.ModDisturbSetting>()); break;
                        case SyncCmdID.MM_SYNCCMD_MODBOTTLECONTACT: result.ModBottleContacts?.Add(r.cmdBuf.data.DeserializeFromProtoBuf<Protocol.Protos.ModBottleContact>()); break;
                        case SyncCmdID.MM_SYNCCMD_DELBOTTLECONTACT: result.DelBottleContacts?.Add(r.cmdBuf.data.DeserializeFromProtoBuf<Protocol.Protos.DelBottleContact>()); break;
                        case SyncCmdID.MM_SYNCCMD_MODUSERIMG: result.ModUserImgs?.Add(r.cmdBuf.data.DeserializeFromProtoBuf<Protocol.Protos.ModUserImg>()); break;
                        case SyncCmdID.MM_SYNCCMD_KVSTAT: result.KVStatItems?.Add(r.cmdBuf.data.DeserializeFromProtoBuf<Protocol.Protos.KVStatItem>()); break;
                        case SyncCmdID.NN_SYNCCMD_THEMESTAT: result.ThemeOpLogs?.Add(r.cmdBuf.data.DeserializeFromProtoBuf<Protocol.Protos.ThemeOpLog>()); break;
                        case SyncCmdID.MM_SYNCCMD_USERINFOEXT: result.UserInfoExts?.Add(r.cmdBuf.data.DeserializeFromProtoBuf<Protocol.Protos.UserInfoExt>()); break;
                        case SyncCmdID.MM_SNS_SYNCCMD_OBJECT: result.SnsObjects?.Add(r.cmdBuf.data.DeserializeFromProtoBuf<Protocol.Protos.SnsObject>()); break;
                        case SyncCmdID.MM_SNS_SYNCCMD_ACTION: result.SnsActionGroups?.Add(r.cmdBuf.data.DeserializeFromProtoBuf<Protocol.Protos.SnsActionGroup>()); break;
                        case SyncCmdID.MM_SYNCCMD_BRAND_SETTING: result.ModBrandSettings?.Add(r.cmdBuf.data.DeserializeFromProtoBuf<Protocol.Protos.ModBrandSetting>()); break;
                        case SyncCmdID.MM_SYNCCMD_MODCHATROOMMEMBERDISPLAYNAME: result.ModChatRoomMemberDisplayNames?.Add(r.cmdBuf.data.DeserializeFromProtoBuf<Protocol.Protos.ModChatRoomMemberDisplayName>()); break;
                        case SyncCmdID.MM_SYNCCMD_MODCHATROOMMEMBERFLAG: result.ModChatRoomMemberFlags?.Add(r.cmdBuf.data.DeserializeFromProtoBuf<Protocol.Protos.ModChatRoomMemberFlag>()); break;
                        case SyncCmdID.MM_SYNCCMD_WEBWXFUNCTIONSWITCH: result.WebWxFunctionSwitchs?.Add(r.cmdBuf.data.DeserializeFromProtoBuf<Protocol.Protos.WebWxFunctionSwitch>()); break;
                        case SyncCmdID.MM_SYNCCMD_MODSNSBLACKLIST: result.ModSnsBlackLists?.Add(r.cmdBuf.data.DeserializeFromProtoBuf<Protocol.Protos.ModSnsBlackList>()); break;
                        case SyncCmdID.MM_SYNCCMD_NEWDELMSG: result.NewDelMsgs?.Add(r.cmdBuf.data.DeserializeFromProtoBuf<Protocol.Protos.NewDelMsg>()); break;
                        case SyncCmdID.MM_SYNCCMD_MODDESCRIPTION: result.ModDescriptions?.Add(r.cmdBuf.data.DeserializeFromProtoBuf<Protocol.Protos.ModDescription>()); break;
                        case SyncCmdID.MM_SYNCCMD_KVCMD: result.KVCmds?.Add(r.cmdBuf.data.DeserializeFromProtoBuf<Protocol.Protos.KVCmd>()); break;
                        case SyncCmdID.MM_SYNCCMD_DELETE_SNS_OLDGROUP: result.DeleteSnsOldGroups?.Add(r.cmdBuf.data.DeserializeFromProtoBuf<Protocol.Protos.DeleteSnsOldGroup>()); break;
                        case SyncCmdID.MM_SYNCCMD_MODSNSUSERINFO: break;
                        case SyncCmdID.MM_SYNCCMD_DELETEBOTTLE: break;
                        case SyncCmdID.MM_FAV_SYNCCMD_ADDITEM: break;
                        case SyncCmdID.CmdIdMax: break;
                    }
                }
            }
            return response;
        }
    }
}
