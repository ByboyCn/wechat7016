using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Chatroom
{
    /// <summary>
    /// 群操作DTO
    /// </summary>
    public class OpLogChatroomDto : BaseDto
    {
        /// <summary>
        /// 群id
        /// </summary>
        public string Chatroom { get; set; }
        /// <summary>
        /// 开关
        /// 1开/2关
        /// </summary>
        public uint Value { get; set; }
    }
}
