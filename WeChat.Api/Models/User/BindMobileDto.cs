using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.User
{
    /// <summary>
    /// 绑定手机号DTO
    /// </summary>
    public class BindMobileDto : BaseDto
    {
        /// <summary>
        /// 1：获取验证码，2：绑定手机号，3：解绑手机号
        /// </summary>
        public int OpCode { get; set; }
        /// <summary>
        /// 手机号码
        /// 国外号请带上完整前缀（如+1）
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// 验证码
        /// </summary>
        public string VerifyCode { get; set; }
    }
}
