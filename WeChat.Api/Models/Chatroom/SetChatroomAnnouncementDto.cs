using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Chatroom
{
    /// <summary>
    /// 设置群公告DTO
    /// </summary>
    public class SetChatroomAnnouncementDto : BaseDto
    {
        /// <summary>
        /// 公告
        /// </summary>
        public string Announcement { get; set; }
        /// <summary>
        /// 群id
        /// </summary>
        public string Chatroom { get; set; }
    }
}
