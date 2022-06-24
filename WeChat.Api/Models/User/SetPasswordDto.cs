using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.User
{
    /// <summary>
    /// 设置密码DTO
    /// </summary>
    public class SetPasswordDto : BaseDto
    {
        /// <summary>
        /// 验证密码票据
        /// </summary>
        public string Ticket { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
    }
}
