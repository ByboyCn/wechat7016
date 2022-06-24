using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Message
{
    /// <summary>
    /// 群发图片消息DTO
    /// </summary>
    public class MassMsgImageDto : BaseDto
    {
        /// <summary>
        /// 用户列表
        /// </summary>
        public string[] Users { get; set; }
        /// <summary>
        /// 图片文件BASE64编码
        /// </summary>
        public string ImageFileBase64 { get; set; }
    }
}
