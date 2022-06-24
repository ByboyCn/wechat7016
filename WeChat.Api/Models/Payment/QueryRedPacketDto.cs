using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Payment
{
    /// <summary>
    /// 查询红包DTO
    /// </summary>
    public class QueryRedPacketDto : BaseDto
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
        /// 单页记录数,默认11
        /// </summary>
        public uint Limit { get; set; }
        /// <summary>
        /// 翻页偏移，第一页：0，第二页：11，第三页：22
        /// </summary>
        public uint Offset { get; set; }
    }
}
