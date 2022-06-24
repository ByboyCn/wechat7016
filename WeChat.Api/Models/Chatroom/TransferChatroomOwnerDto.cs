using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Chatroom
{
    /// <summary>
    /// 转让群主DTO
    /// </summary>
    public class TransferChatroomOwnerDto : BaseDto
    {
        /// <summary>
        /// 群id
        /// </summary>
        public string Chatroom { get; set; }
        /// <summary>
        /// 新群主id
        /// </summary>
        public string UserName { get; set; }
    }
}
