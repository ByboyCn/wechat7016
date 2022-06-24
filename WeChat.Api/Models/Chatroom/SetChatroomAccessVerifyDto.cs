using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Chatroom
{
    /// <summary>
    /// 设置群公告DTO
    /// </summary>
    public class SetChatroomAccessVerifyDto : BaseDto
    {
        /// <summary>
        /// 群id
        /// </summary>
        public string Chatroom { get; set; }
        /// <summary>
        /// 邀请验证开关
        /// </summary>
        public bool Enable { get; set; }
    }
}
