using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Chatroom
{
    /// <summary>
    /// 群及成员DTO
    /// </summary>
    public class ChatroomMemberDto : BaseDto
    {
        /// <summary>
        /// 用户列表
        /// </summary>
        public string[] Users { get; set; }
        /// <summary>
        /// 群id
        /// </summary>
        public string Chatroom { get; set; }
    }
}
