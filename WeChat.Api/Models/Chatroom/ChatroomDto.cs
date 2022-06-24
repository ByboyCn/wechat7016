using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Chatroom
{
    /// <summary>
    /// 群DTO
    /// </summary>
    public class ChatroomDto : BaseDto
    {
        /// <summary>
        /// 群id
        /// </summary>
        public string Chatroom { get; set; }
    }

    /// <summary>
    /// 群DTO
    /// </summary>
    public class ChatroomsDto : BaseDto
    {
        /// <summary>
        /// 群id
        /// </summary>
        public string[] Chatroom { get; set; }
    }
}
