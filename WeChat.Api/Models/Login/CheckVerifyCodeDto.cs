using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Login
{
    /// <summary>
    /// 效验登录验证码DTO
    /// </summary>
    public class CheckVerifyCodeDto : GetVerifyCodeDto
    {
        /// <summary>
        /// 验证码
        /// </summary>
        public string VerifyCode { get; set; }
    }
}
