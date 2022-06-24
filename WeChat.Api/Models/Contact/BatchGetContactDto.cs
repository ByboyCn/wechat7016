using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Contact
{
    /// <summary>
    /// 批量获取好友简介DTO
    /// </summary>
    public class BatchGetContactDto : BaseDto
    {
        /// <summary>
        /// 好友列表
        /// </summary>
        public string[] Users { get; set; }
    }
}
