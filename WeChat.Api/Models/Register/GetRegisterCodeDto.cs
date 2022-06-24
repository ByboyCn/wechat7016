using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Register
{
    /// <summary>
    /// 获取注册验证码DTO
    /// </summary>
    public class GetRegisterCodeDto : BaseVerifyCodeDto
    {
        /// <summary>
        /// 票据
        /// </summary>
        public string AuthTicket { get; set; }
    }
}
