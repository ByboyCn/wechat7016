using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Register
{
    /// <summary>
    /// 注册账号基础DTO
    /// </summary>
    public class BaseVerifyCodeDto : BaseDto
    {
        /// <summary>
        /// 手机号码,格式+8613666666666
        /// </summary>
        public string PhoneNumber { get; set; }
    }
}
