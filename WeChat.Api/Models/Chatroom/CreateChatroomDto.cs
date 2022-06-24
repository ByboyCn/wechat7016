using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Chatroom
{
    /// <summary>
    /// 创建群聊DTO
    /// </summary>
    public class CreateChatroomDto : BaseDto
    {
        /// <summary>
        /// 用户列表，至少三人，且第一个人为自己
        /// </summary>
        public string[] Users { get; set; }
        /// <summary>
        /// 群昵称
        /// </summary>
        public string NickName { get; set; }
    }
}
