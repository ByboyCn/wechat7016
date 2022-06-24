using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Message
{
    /// <summary>
    /// 获取语音消息DTO
    /// </summary>
    public class GetMsgVoiceDto : GetMsgMediaDto
    {
        /// <summary>
        /// ClientMsgId
        /// </summary>
        public string ClientMsgId { get; set; }
        /// <summary>
        /// 消息Id
        /// </summary>
        public string MsgId { get; set; }
        /// <summary>
        /// bufId
        /// </summary>
        public string bufid { get; set; }
        /// <summary>
        /// chatroom
        /// 好友时忽略
        /// </summary>
        public string chatroom { get; set; }
    }
}
