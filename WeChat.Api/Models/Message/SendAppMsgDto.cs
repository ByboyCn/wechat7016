using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Message
{
    /// <summary>
    /// 发送APP消息DTO
    /// </summary>
    public class SendAppMsgDto : BaseDto
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// APP消息XML结构
        /// </summary>
        public string Content { get; set; }
    }
}
