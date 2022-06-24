using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Chatroom
{
    /// <summary>
    /// 设置群昵称DTO
    /// </summary>
    public class SetChatroomNameDto : BaseDto
    {
        /// <summary>
        /// 群id
        /// </summary>
        public string Chatroom { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }
    }
}
