using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Contact
{
    /// <summary>
    /// 设置联系人标志DTO
    /// </summary>
    public class SetContactFlagDto : BaseDto
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 标志（3：黑名单，6：标星，0：通讯录，9：消息免打扰，11：置顶聊天）
        /// </summary>
        public ushort Flag { get; set; }
        /// <summary>
        /// 状态（启用：true，禁用：false）
        /// </summary>
        public bool Status { get; set; }
    }
}
