using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using WeChat.Api.Models;
using WeChat.Api.Models.Contact;

namespace WeChat.Api.Controllers
{
    /// <summary>
    /// 联系人操作
    /// </summary>
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [ApiGroupSort(100)]
    public class ContactController : BaseController
    {
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="cache">缓存</param>
        public ContactController(IDistributedCache cache)
            : base(cache)
        {
        }
        #endregion

        /// <summary>
        /// 好友验证(打招呼/添加好友/拒绝添加好友)
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXVerifyUser))]
        public async Task<ActionResult<RestfulData<object>>> WXVerifyUser([FromBody] VerifyUserDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXVerifyUser(dto.Type, dto.Stranger_v1, dto.Stranger_v2, dto.Scene, dto.Verify, dto.Ticket);
            });
        }

        /// <summary>
        /// 批量好友验证（接口版）
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXBatchVerifyUser))]
        public async Task<ActionResult<RestfulData<object>>> WXBatchVerifyUser([FromBody] BatchVerifyUserDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXBatchVerifyUser(dto.Type, dto.Users, dto.Scene, dto.Verify);
            });
        }

        /// <summary>
        /// 分页获取通讯录好友（精准获取）
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXInitContactPage))]
        public async Task<ActionResult<RestfulData<object>>> WXInitContactPage([FromBody] InitContactDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                var list = await client?.WXInitContactPage(dto.CurrentWxContactSeq);
                result.data = list;
                result.remark = $"{list?.contactUsernameList?.Length}";
                await UpdateClient(dto.Guid, client);
                result.flag = 1;
            });
        }

        /// <summary>
        /// 获取全部通讯录好友（精准获取）
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXInitContactAll))]
        public async Task<ActionResult<RestfulData<object>>> WXInitContactAll([FromBody] BaseDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                var list = await client?.WXInitContactAll();
                result.data = list;
                result.remark = $"{list?.Count}";
                await UpdateClient(dto.Guid, client);
                result.flag = 1;
            });
        }

        /// <summary>
        /// 删除联系人
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXDeleteContact))]
        public async Task<ActionResult<RestfulData<object>>> WXDeleteContact([FromBody] ContactDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXDeleteContact(dto.UserName);
            });
        }

        /// <summary>
        /// 批量删除联系人
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXBatchDeleteContact))]
        public async Task<ActionResult<RestfulData<object>>> WXBatchDeleteContact([FromBody] GetContactDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXBatchDeleteContact(dto.Users);
            });
        }

        /// <summary>
        /// 设置联系人标志
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXSetContactFlag))]
        public async Task<ActionResult<RestfulData<object>>> WXSetContactFlag([FromBody] SetContactFlagDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXSetContactFlag(dto.UserName, dto.Flag, dto.Status);
            });
        }

        /// <summary>
        /// 设置用户备注
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXSetContactRemark))]
        public async Task<ActionResult<RestfulData<object>>> WXSetContactRemark([FromBody] SetContactRemarkDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXSetContactRemark(dto.UserName, dto.Remark, dto.Description);
            });
        }

        /// <summary>
        /// 设置用户标签
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXSetContactLabel))]
        public async Task<ActionResult<RestfulData<object>>> WXSetContactLabel([FromBody] SetContactLabelDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXSetContactLabel(dto.UserName, dto.Labels);
            });
        }

        /// <summary>
        /// 批量获取好友简介
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXBatchGetContactProfile))]
        public async Task<ActionResult<RestfulData<object>>> WXBatchGetContactProfile([FromBody] BatchGetContactDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXBatchGetContactProfile(dto.Users);
            });
        }

        /// <summary>
        /// 批量获取好友头像
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXBatchGetContactHeadImage))]
        public async Task<ActionResult<RestfulData<object>>> WXBatchGetContactHeadImage([FromBody] BatchGetContactDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXBatchGetContactHeadImage(dto.Users);
            });
        }

        /// <summary>
        /// 搜索联系人
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXSearchContact))]
        public async Task<ActionResult<RestfulData<object>>> WXSearchContact([FromBody] ContactDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXSearchContact(dto.UserName);
            });
        }

        /// <summary>
        /// 获取邀请朋友
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXGetInviteFriend))]
        public async Task<ActionResult<RestfulData<object>>> WXGetInviteFriend([FromBody] BaseDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXGetInviteFriend();
            });
        }

        /// <summary>
        /// 获取联系人详情
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXGetContact))]
        public async Task<ActionResult<RestfulData<object>>> WXGetContact([FromBody] GetContactDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXGetContact(dto.Users);
            });
        }

        /// <summary>
        /// 获取联系人状态[僵尸粉](单向好友/被拉黑/被封号)
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXGetContactStatus))]
        public async Task<ActionResult<RestfulData<object>>> WXGetContactStatus([FromBody] GetContactDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXGetContactStatus(dto.Users);
                result.remark = "-1未知,0好基友,1非好友,2删对方(对方还有自己),3被删除,4相互删,5被拉黑,6被封号";
            });
        }

        /// <summary>
        /// 上传通讯录
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXUploadMContact))]
        public async Task<ActionResult<RestfulData<object>>> WXUploadMContact([FromBody] UploadMContactDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXUploadMContact(dto.Mobile, dto.PhoneNumberList);
            });
        }

        /// <summary>
        /// 获取手机朋友列表
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXGetMFriend))]
        public async Task<ActionResult<RestfulData<object>>> WXGetMFriend([FromBody] GetMFriendDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXGetMFriend(dto.Md5);
            });
        }
    }
}