using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using WeChat.Api.Models;
using WeChat.Api.Models.Chatroom;

namespace WeChat.Api.Controllers
{
    /// <summary>
    /// 群聊操作
    /// </summary>
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [ApiGroupSort(90)]
    public class ChatroomController : BaseController
    {
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="cache">缓存</param>
        public ChatroomController(IDistributedCache cache)
            : base(cache)
        {
        }
        #endregion

        /// <summary>
        /// 分页获取通讯录群聊（详情）
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXGetChatroomPage))]
        public async Task<ActionResult<RestfulData<object>>> WXGetChatroomPage([FromBody] InitContactDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                var list = await client?.WXGetChatroomPage(dto.CurrentChatroomContactSeq, dto.IsDetail);
                result.data = list;
                result.remark = $"{list?.contactUsernameList?.Length}";
                await UpdateClient(dto.Guid, client);
                result.flag = 1;
            });
        }

        /// <summary>
        /// 获取全部通讯录群聊（ID）
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXGetChatroomAll))]
        public async Task<ActionResult<RestfulData<object>>> WXGetChatroomAll([FromBody] BaseDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                var list = await client?.WXGetChatroomAll();
                result.data = list;
                result.remark = $"{list?.Count}";
                await UpdateClient(dto.Guid, client);
                result.flag = 1;
            });
        }

        /// <summary>
        /// 扫码进群（二维码链接格式：https://weixin.qq.com/g/xxxxx）
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXScanChatroomQrcode))]
        public async Task<ActionResult<RestfulData<object>>> WXScanChatroomQrcode([FromBody] ScanQrcodeDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXScanChatroomQrcode(dto.Url);
            });
        }

        /// <summary>
        /// 获取群二维码
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXGetChatroomQrcode))]
        public async Task<ActionResult<RestfulData<object>>> WXGetChatroomQrcode([FromBody] ChatroomDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXGetChatroomQrcode(dto.Chatroom);
                result.remark = "data:img/jpg;base64,";
            });
        }

        /// <summary>
        /// 创建群聊
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXCreateChatroom))]
        public async Task<ActionResult<RestfulData<object>>> WXCreateChatroom([FromBody] CreateChatroomDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXCreateChatroom(dto.Users, dto.NickName);
            });
        }

        /// <summary>
        /// 面对面创群
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXCreateFaceChatroom))]
        public async Task<ActionResult<RestfulData<object>>> WXCreateFaceChatroom([FromBody] CreateFaceChatroomDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXCreateFaceChatroom(dto.Password, dto.Latitude, dto.Longitude);
            });
        }

        /// <summary>
        /// 退出群聊
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXQuitChatroom))]
        public async Task<ActionResult<RestfulData<object>>> WXQuitChatroom([FromBody] ChatroomDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXQuitChatroom(dto.Chatroom);
            });
        }

        /// <summary>
        /// 设置群名称
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(WXSetChatroomName))]
        public async Task<ActionResult<RestfulData<object>>> WXSetChatroomName([FromBody] SetChatroomNameDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXSetChatroomName(dto.Chatroom, dto.NickName);
            });
        }

        /// <summary>
        /// 设置我在本群昵称
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(WXSetChatroomNameDisplyName))]
        public async Task<ActionResult<RestfulData<object>>> WXSetChatroomNameDisplyName([FromBody] SetChatroomNameDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXSetChatroomNameDisplyName(dto.Chatroom, dto.NickName);
            });
        }

        /// <summary>
        /// 显示群成员昵称
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(WXShowChatroomMemberDisplyName))]
        public async Task<ActionResult<RestfulData<object>>> WXShowChatroomMemberDisplyName([FromBody] OpLogChatroomDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXShowChatroomMemberDisplyName(dto.Chatroom, dto.Value);
            });
        }

        /// <summary>
        /// 保存到通讯录
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(WXSaveChatroomToContact))]
        public async Task<ActionResult<RestfulData<object>>> WXSaveChatroomToContact([FromBody] OpLogChatroomDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXSaveChatroomToContact(dto.Chatroom, dto.Value);
            });
        }

        /// <summary>
        /// 转让群主
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(WXTransferChatroomOwner))]
        public async Task<ActionResult<RestfulData<object>>> WXTransferChatroomOwner([FromBody] TransferChatroomOwnerDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXTransferChatroomOwner(dto.Chatroom, dto.UserName);
            });
        }

        /// <summary>
        /// 获取群公告
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(WXGetChatroomAnnouncement))]
        public async Task<ActionResult<RestfulData<object>>> WXGetChatroomAnnouncement([FromBody] ChatroomDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXGetChatroomAnnouncement(dto.Chatroom);
            });
        }

        /// <summary>
        /// 邀请群成员(40人以上)
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(WXInviteChatroomMember))]
        public async Task<ActionResult<RestfulData<object>>> WXInviteChatroomMember([FromBody] ChatroomMemberDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXInviteChatroomMember(dto.Chatroom, dto.Users);
            });
        }

        /// <summary>
        /// 添加群成员（40人以内）
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXAddChatroomMember))]
        public async Task<ActionResult<RestfulData<object>>> WXAddChatroomMember([FromBody] ChatroomMemberDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXAddChatroomMember(dto.Chatroom, dto.Users);
            });
        }

        /// <summary>
        /// 删除群成员
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXDelChatroomMember))]
        public async Task<ActionResult<RestfulData<object>>> WXDelChatroomMember([FromBody] ChatroomMemberDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXDelChatroomMember(dto.Chatroom, dto.Users);
            });
        }

        /// <summary>
        /// 添加群管理员
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXAddChatroomAdmin))]
        public async Task<ActionResult<RestfulData<object>>> WXAddChatroomAdmin([FromBody] ChatroomMemberDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXAddChatroomAdmin(dto.Chatroom, dto.Users);
            });
        }

        /// <summary>
        /// 删除群管理员
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXDelChatroomAdmin))]
        public async Task<ActionResult<RestfulData<object>>> WXDelChatroomAdmin([FromBody] ChatroomMemberDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXDelChatroomAdmin(dto.Chatroom, dto.Users);
            });
        }

        /// <summary>
        /// 获取群成员详情
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXGetChatroomMemberDetail))]
        public async Task<ActionResult<RestfulData<object>>> WXGetChatroomMemberDetail([FromBody] ChatroomDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXGetChatroomMemberDetail(dto.Chatroom);
            });
        }

        /// <summary>
        /// 获取群信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXGetChatroomInfoDetail))]
        public async Task<ActionResult<RestfulData<object>>> WXGetChatroomInfoDetail([FromBody] ChatroomsDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXGetChatroomInfoDetail(dto.Chatroom);
            });
        }

        /// <summary>
        /// 设置群公告
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXSetChatroomAnnouncement))]
        public async Task<ActionResult<RestfulData<object>>> WXSetChatroomAnnouncement([FromBody] SetChatroomAnnouncementDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXSetChatroomAnnouncement(dto.Chatroom, dto.Announcement);
            });
        }

        /// <summary>
        /// 设置群聊邀请验证
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXSetChatroomAccessVerify))]
        public async Task<ActionResult<RestfulData<object>>> WXSetChatroomAccessVerify([FromBody] SetChatroomAccessVerifyDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXSetChatroomAccessVerify(dto.Chatroom, (uint)(dto.Enable ? 2 : 0));
            });
        }
    }
}