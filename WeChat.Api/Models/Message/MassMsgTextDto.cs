using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Message
{
    /// <summary>
    /// 群发文本消息DTO
    /// </summary>
    public class MassMsgTextDto : BaseDto
    {
        /// <summary>
        /// 用户id列表
        /// </summary>
        public string[] Users { get; set; }
        /// <summary>
        /// 文本内容
        /// </summary>
        public string Content { get; set; }
    }
}
