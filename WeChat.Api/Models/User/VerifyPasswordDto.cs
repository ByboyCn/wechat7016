using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.User
{
    /// <summary>
    /// 验证密码DTO
    /// </summary>
    public class VerifyPasswordDto : BaseDto
    {
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
    }
}
