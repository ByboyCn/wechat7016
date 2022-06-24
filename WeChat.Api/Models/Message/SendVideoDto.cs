using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Message
{
    /// <summary>
    /// 发送视频消息DTO
    /// </summary>
    public class SendVideoDto :BaseDto
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 视频文件BASE64
        /// </summary>
        public string VideoFileBase64 { get; set; }
        /// <summary>
        /// 缩略图文件BASE64
        /// </summary>
        public string ImageFileBase64 { get; set; }
        /// <summary>
        /// 视频时长
        /// 单位秒
        /// </summary>
        public uint VideoTime { get; set; }
    }
}
