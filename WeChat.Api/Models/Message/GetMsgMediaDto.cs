using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Message
{
    /// <summary>
    /// 获取消息媒体DTO
    /// </summary>
    public class GetMsgMediaDto : BaseDto
    {
        /// <summary>
        /// 对方用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 新消息Id
        /// </summary>
        public string NewMsgId { get; set; }
        /// <summary>
        /// 总长度或单次获取长度
        /// 音视频总长度大于61440时属于大文件，请分次获取
        /// 图片总长度大于65536时属于大文件，请分次获取
        /// </summary>
        public uint TotalLength { get; set; }
        /// <summary>
        /// 偏移，第一次为0
        /// </summary>
        public uint Offset { get; set; }
    }
}
