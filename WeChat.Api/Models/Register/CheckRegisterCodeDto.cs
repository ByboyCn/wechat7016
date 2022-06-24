using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Register
{
    /// <summary>
    /// 效验注册验证码DTO
    /// </summary>
    public class CheckRegisterCodeDto : GetRegisterCodeDto
    {
        /// <summary>
        /// 验证码
        /// </summary>
        public string VerifyCode { get; set; }
        /// <summary>
        /// 会话id
        /// </summary>
        public string SessionId { get; set; }
    }
}
