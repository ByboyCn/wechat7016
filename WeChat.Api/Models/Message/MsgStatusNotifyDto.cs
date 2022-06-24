using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Message
{
    /// <summary>
    /// 消息状态通知DTO
    /// </summary>
    public class MsgStatusNotifyDto : BaseDto
    {
        /// <summary>
        /// 消息Id
        /// </summary>
        public uint MsgId { get; set; }
    }
}
