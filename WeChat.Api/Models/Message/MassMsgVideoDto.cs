using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Message
{
    /// <summary>
    /// 群发视频消息DTO
    /// </summary>
    public class MassMsgVideoDto : BaseDto
    {
        /// <summary>
        /// 用户列表
        /// </summary>
        public string[] Users { get; set; }
        /// <summary>
        /// 媒体文件BASE64
        /// </summary>
        public string MediaFileBase64 { get; set; }
        /// <summary>
        /// 媒体缩略图文件BASE64
        /// </summary>
        public string ThumbImageFileBase64 { get; set; }
        /// <summary>
        /// 媒体时长（单位：秒）
        /// </summary>
        public uint MediaTime { get; set; }
    }
}
