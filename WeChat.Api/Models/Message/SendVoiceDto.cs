using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Message
{
    /// <summary>
    /// 发送语音消息DTO
    /// </summary>
    public class SendVoiceDto : BaseDto
    {
        /// <summary>
        /// 音频格式：AMR = 0,SPEEX = 1,MP3 = 2,WAVE = 3,SILK = 4
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 音频文件BASE64
        /// </summary>
        public string DataFileBase64 { get; set; }
        /// <summary>
        /// 音频时长，单位毫秒
        /// </summary>
        public int VoiceTime { get; set; }
    }
}
