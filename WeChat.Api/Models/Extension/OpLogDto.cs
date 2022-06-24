using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Extension
{
    /// <summary>
    /// 好友(群聊)操作请求DTO
    /// </summary>
    public class OpLogDto:BaseDto
    {
        /// <summary>
        /// 操作类型
        /// </summary>
        public Core.Protocol.Protos.V2.SyncCmdID Type { get; set; }
        /// <summary>
        /// 修改后的对象
        /// </summary>
        public object Data { get; set; }
    }
}
