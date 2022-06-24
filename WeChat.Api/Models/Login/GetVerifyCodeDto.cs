using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Login
{
    /// <summary>
    /// 获取登录验证码DTO
    /// </summary>
    public class GetVerifyCodeDto : BaseDto
    {
        /// <summary>
        /// 手机号码,格式+8613666666666
        /// </summary>
        public string PhoneNumber { get; set; }
    }
}
