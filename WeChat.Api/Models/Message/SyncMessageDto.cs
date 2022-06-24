using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeChat.Core;

namespace WeChat.Api.Models.Message
{
    /// <summary>
    /// 同步消息DTO
    /// </summary>
    public class SyncMessageDto
    {
        /// <summary>
        /// 继续同步标志
        /// </summary>
        public int Continueflag { get; set; }
        /// <summary>
        /// 返回值
        /// </summary>
        public int Ret { get; set; }
        /// <summary>
        /// 结果
        /// </summary>
        public WXMessage Result { get; set; }
    }
}
