using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using WeChat.Api.Models;
using WeChat.Api.Models.Message;
using WeChat.Core;

namespace WeChat.Api.Controllers
{
    /// <summary>
    /// 消息操作
    /// </summary>
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [ApiGroupSort(80)]
    public class MessageController : BaseController
    {
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="cache">缓存</param>
        public MessageController(IDistributedCache cache)
            : base(cache)
        {
        }
        #endregion

        /// <summary>
        /// 同步消息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXSyncMsg))]
        public async Task<ActionResult<RestfulData<object>>> WXSyncMsg([FromBody] BaseDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                var message = new WXMessage();
                var response = await client?.WXSyncMsg();
                response?.SaveSyncResult(ref message);
                var data = new SyncMessageDto() { Ret = response?.ret ?? -1, Continueflag = response?.Continueflag ?? 0, Result = message };
                await UpdateClient(dto.Guid, client);
                result.flag = 1;
                result.data = data;
            });
        }

        /// <summary>
        /// 发送文本消息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXSendMsg))]
        public async Task<ActionResult<RestfulData<object>>> WXSendMsg([FromBody] SendMsgDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXSendMsg(dto.UserName, dto.Content);
            });
        }

        /// <summary>
        /// 发送Emoji消息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXSendEmojiMsg))]
        public async Task<ActionResult<RestfulData<object>>> WXSendEmojiMsg([FromBody] SendEmojiMsgDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                if (dto.Type == 1)
                {
                    dto.Md5 = "da1c289d4e363f3ce1ff36538903b92f";
                }
                else if (dto.Type == 2)
                {
                    dto.Md5 = "9e3f303561566dc9342a3ea41e6552a6";
                }
                result.data = await client?.WXSendEmojiMsg(dto.UserName, dto.Md5, dto.Type, dto.Content);
            });
        }

        /// <summary>
        /// 发送图片消息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXSendImage))]
        public async Task<ActionResult<RestfulData<object>>> WXSendImage([FromBody] SendImageDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXSendImage(dto.UserName, dto.Base64Image.Base64Decode());
            });
        }

        /// <summary>
        /// 发送语音消息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXSendVoice))]
        public async Task<ActionResult<RestfulData<object>>> WXSendVoice([FromBody] SendVoiceDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXSendVoice(dto.UserName, dto.DataFileBase64.Base64Decode(), dto.VoiceTime, dto.Type);
            });
        }

        /// <summary>
        /// 发送视频消息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXSendVideo))]
        public async Task<ActionResult<RestfulData<object>>> WXSendVideo([FromBody] SendVideoDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXSendVideo(dto.UserName, dto.VideoFileBase64.Base64Decode(), dto.ImageFileBase64.Base64Decode(), dto.VideoTime);
            });
        }

        /// <summary>
        /// 发送CDN图片消息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXSendImageByCDN))]
        public async Task<ActionResult<RestfulData<object>>> WXSendImageByCDN([FromBody] SendImageByCDNDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXSendImageByCDN(dto.UserName, dto.CdnImgUrl, dto.CdnImgSize, dto.CdnThumbImgSize, dto.CdnImgAesKey);
            });
        }

        /// <summary>
        /// 发送CDN高清图片消息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXSendHDImageByCDN))]
        public async Task<ActionResult<RestfulData<object>>> WXSendHDImageByCDN([FromBody] SendHDImageByCDNDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXSendHDImageByCDN(dto.UserName, dto.CdnImgUrl, dto.CdnImgSize, dto.CdnHDImgSize, dto.CdnThumbImgSize, dto.CdnImgAesKey);
            });
        }

        /// <summary>
        /// 发送CDN视频消息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXSendVideoByCDN))]
        public async Task<ActionResult<RestfulData<object>>> WXSendVideoByCDN([FromBody] SendVideoByCDNDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXSendVideoByCDN(dto.UserName, dto.CdnVideoUrl, dto.VideoSize, dto.CdnVideoSize, dto.CdnThumbVideoSize, dto.CdnVideoAesKey);
            });
        }

        /// <summary>
        /// 校验CDN资源
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXCheckCdnSource))]
        public async Task<ActionResult<RestfulData<object>>> WXCheckCdnSource([FromBody] Models.Cdn.CheckCdnSourceDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXCheckCdnSource(dto.data_source_type, dto.data_source_id, dto.dataid, dto.fullmd5, dto.head256md5, dto.fullsize, dto.isthumb);
            });
        }

        /// <summary>
        /// 发送APP消息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXSendAppMsg))]
        public async Task<ActionResult<RestfulData<object>>> WXSendAppMsg([FromBody] SendAppMsgDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXSendAppMsg(dto.UserName, dto.Content);
            });
        }

        /// <summary>
        /// 发送文件消息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXSendMsgFile))]
        public async Task<ActionResult<RestfulData<object>>> WXSendMsgFile([FromBody] SendMsgFileDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXSendMsgFile(dto.UserName, dto.AttachId, dto.Title, dto.Length, dto.Extension);
            });
        }

        /// <summary>
        /// 上传消息文件
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXUploadMsgFile))]
        public async Task<ActionResult<RestfulData<object>>> WXUploadMsgFile([FromBody] UploadMsgFileDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXUploadMsgFile(dto.Data.Base64Decode());
            });
        }

        /// <summary>
        /// 下载消息文件
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXDownloadMsgFile))]
        public async Task<ActionResult<RestfulData<object>>> WXDownloadMsgFile([FromBody] DownloadMsgFileDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXDownloadMsgFile(dto.UserName, dto.AppID, dto.AttachID, dto.Length, dto.Offset);
            });
        }

        /// <summary>
        /// 校验文件下载
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXCheckFileDownload))]
        public async Task<ActionResult<RestfulData<object>>> WXCheckFileDownload([FromBody] CheckFileDownloadDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXCheckFileDownload(dto.aeskey, dto.type, dto.name, dto.ext, dto.md5, dto.size, dto.fromuser, dto.touser);
            });
        }

        /// <summary>
        /// 群发文本消息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXMassMsgText))]
        public async Task<ActionResult<RestfulData<object>>> WXMassMsgText([FromBody] MassMsgTextDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXMassMsg(dto.Users, dto.Content);
            });
        }

        /// <summary>
        /// 群发图片消息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXMassMsgImage))]
        public async Task<ActionResult<RestfulData<object>>> WXMassMsgImage([FromBody] MassMsgImageDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXMassMsg(dto.Users, dto.ImageFileBase64.Base64Decode());
            });
        }

        /// <summary>
        /// 群发视频消息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXMassMsgVideo))]
        public async Task<ActionResult<RestfulData<object>>> WXMassMsgVideo([FromBody] MassMsgVideoDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXMassMsg(dto.Users, dto.MediaFileBase64.Base64Decode(), dto.ThumbImageFileBase64.Base64Decode(), dto.MediaTime);
            });
        }

        /// <summary>
        /// 群发语音消息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXMassMsgVoice))]
        public async Task<ActionResult<RestfulData<object>>> WXMassMsgVoice([FromBody] MassMsgVoiceDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXMassMsg(dto.Users, dto.MediaFileBase64.Base64Decode(), dto.MediaTime, dto.Type);
            });
        }

        /// <summary>
        /// 获取消息视频（支持大视频）
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXGetMsgVideo))]
        public async Task<ActionResult<RestfulData<object>>> WXGetMsgVideo([FromBody] GetMsgMediaDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXGetMsgVideo(dto.UserName, dto.NewMsgId.ToUInt64(), dto.TotalLength, dto.Offset);
            });
        }

        /// <summary>
        /// 获取消息语音（支持长语音）
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXGetMsgVoice))]
        public async Task<ActionResult<RestfulData<object>>> WXGetMsgVoice([FromBody] GetMsgVoiceDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXGetMsgVoice(dto.ClientMsgId, dto.MsgId.ToUInt32(), dto.NewMsgId.ToUInt64(), dto.bufid.ToUInt64(), dto.TotalLength, dto.Offset, dto.chatroom);
            });
        }

        /// <summary>
        /// 获取消息图片（支持高清大图）
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXGetMsgImage))]
        public async Task<ActionResult<RestfulData<object>>> WXGetMsgImage([FromBody] GetMsgImageDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXGetMsgImage(dto.UserName, dto.NewMsgId.ToUInt64(), dto.TotalLength, dto.Offset, dto.CompressType);
            });
        }

        /// <summary>
        /// 撤回消息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXRevokeMsg))]
        public async Task<ActionResult<RestfulData<object>>> WXRevokeMsg([FromBody] RevokeMsgDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXRevokeMsg(dto.UserName, dto.NewMsgId.ToUInt64());
            });
        }

        /// <summary>
        /// 消息状态通知
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXMsgStatusNotify))]
        public async Task<ActionResult<RestfulData<object>>> WXMsgStatusNotify([FromBody] MsgStatusNotifyDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXMsgStatusNotify(dto.MsgId);
            });
        }

        /// <summary>
        /// 发送分享消息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXSendShare))]
        public async Task<ActionResult<RestfulData<object>>> WXSendShare([FromBody] SendShareDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXSendShare(dto.UserName, dto.Title, dto.Description, dto.Type, dto.Url, dto.DataUrl, dto.ThumbUrl);
            });
        }

        /// <summary>
        /// 分享名片
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXShareCard))]
        public async Task<ActionResult<RestfulData<object>>> WXShareCard([FromBody] ShareCardDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXShareCard(dto.UserName, dto.Id, dto.NickName, dto.Alias);
            });
        }

        /// <summary>
        /// 分享位置
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXShareLocation))]
        public async Task<ActionResult<RestfulData<object>>> WXShareLocation([FromBody] ShareLocationDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXShareLocation(dto.UserName, dto.Title, dto.Latitude, dto.Longitude);
            });
        }

        /// <summary>
        /// 分享收藏
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXShareFav))]
        public async Task<ActionResult<RestfulData<object>>> WXShareFav([FromBody] ShareFavDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXShareFav(dto.UserName, dto.Ids);
            });
        }
    }
}