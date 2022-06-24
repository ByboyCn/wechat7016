using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Payment
{
    /// <summary>
    /// 打开红包DTO
    /// </summary>
    public class OpenRedPacketDto : BaseDto
    {
        /// <summary>
        /// 通道Id
        /// </summary>
        public string ChannelId { get; set; }
        /// <summary>
        /// 消息类型
        /// </summary>
        public int MsgType { get; set; }
        /// <summary>
        /// NativeUrl
        /// </summary>
        public string NativeUrl { get; set; }
        /// <summary>
        /// 发送Id
        /// </summary>
        public string SendId { get; set; }
        /// <summary>
        /// 版本
        /// </summary>
        public string Ver { get; set; }
        /// <summary>
        /// 发送用户id
        /// </summary>
        public string SendUserName { get; set; }
        /// <summary>
        /// 定时标识
        /// </summary>
        public string TimingIdentifier { get; set; }
    }
}
