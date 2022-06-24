using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Message
{
    /// <summary>
    /// 群发语音消息DTO
    /// </summary>
    public class MassMsgVoiceDto : BaseDto
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
        /// 媒体时长（单位：毫秒）
        /// </summary>
        public uint MediaTime { get; set; }
        /// <summary>
        /// 音频格式：AMR = 0, MP3 = 2, SILK = 4, SPEEX = 1, WAVE = 3
        /// </summary>
        public uint Type { get; set; }
    }
}
