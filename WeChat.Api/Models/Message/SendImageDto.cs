using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Message
{
    /// <summary>
    /// 发送图片消息DTO
    /// </summary>
    public class SendImageDto : BaseDto
    {
        /// <summary>
        /// 图片BASE64
        /// </summary>
        public string Base64Image { get; set; }

        /// <summary>
        /// 对方用户id/群id
        /// </summary>
        public string UserName { get; set; }
    }
}
