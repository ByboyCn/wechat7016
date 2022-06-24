using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Extension
{
    /// <summary>
    ///  短信操作DTO
    /// </summary>
    public class BindOpMobileForRegDto : BaseDto
    {
        /// <summary>
        /// 操作码
        /// </summary>
        public int OpCode { get; set; }
        /// <summary>
        /// 手机号码，格式如：+8618012345678
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// 验证码
        /// </summary>
        public string VerifyCode { get; set; }
        /// <summary>
        /// 是否注册,0:登陆,1:注册
        /// </summary>
        public uint Reg { get; set; }
        /// <summary>
        /// 会话ID
        /// </summary>
        public string RegsessionId { get; set; }
        /// <summary>
        /// 票据
        /// </summary>
        public string Authticket { get; set; }
    }
}
