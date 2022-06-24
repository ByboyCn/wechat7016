using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.User
{
    /// <summary>
    /// 绑定邮箱DTO
    /// </summary>
    public class BindEmailDto : BaseDto
    {
        /// <summary>
        /// 操作码(1:绑定，2:解绑)
        /// </summary>
        public uint OpCode { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }
    }
}
