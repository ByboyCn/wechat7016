using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Payment
{
    /// <summary>
    /// 检测支付密码DTO
    /// </summary>
    public class CheckPayPasswordDto : BaseDto
    {
        /// <summary>
        /// 支付密码
        /// </summary>
        public string Password { get; set; }
    }
}
