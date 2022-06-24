using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Message
{
    /// <summary>
    /// 发送文本消息DTO
    /// </summary>
    public class SendMsgDto : BaseDto
    {
        /// <summary>
        /// 对方用户id/群id
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 消息文本内容
        /// </summary>
        public string Content { get; set; }
    }
}
