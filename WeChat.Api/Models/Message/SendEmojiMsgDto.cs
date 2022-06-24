using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Message
{
    /// <summary>
    /// 发送Emoji消息DTO
    /// </summary>
    public class SendEmojiMsgDto : BaseDto
    {
        /// <summary>
        /// 对方用户id/群id
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 表情MD5
        /// 当Type≠0时忽略本参数
        /// </summary>
        public string Md5 { get; set; }
        /// <summary>
        /// 表情类型 0普通表情,1石头剪刀布,2骰子
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 1-3代表剪刀、石头、布,4-9代表骰子1-6点
        /// 当Type=0时忽略本参数
        /// </summary>
        public string Content { get; set; }
    }
}
