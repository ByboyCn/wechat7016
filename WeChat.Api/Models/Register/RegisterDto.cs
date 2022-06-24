using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Register
{
    /// <summary>
    /// 注册账号DTO
    /// </summary>
    public class RegisterDto : BaseVerifyCodeDto
    {
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 注册票据
        /// </summary>
        public string Ticket { get; set; }
    }
}
