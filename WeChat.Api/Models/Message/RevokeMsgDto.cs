using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Message
{
    /// <summary>
    /// 撤回消息DTO
    /// </summary>
    public class RevokeMsgDto : BaseDto
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 新消息Id
        /// </summary>
        public string NewMsgId { get; set; }
    }
}
