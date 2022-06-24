using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.User
{
    /// <summary>
    /// 验证个人信息DTO
    /// </summary>
    public class VerifyPersonalInfoDto : BaseDto
    {
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { get; set; }
        /// <summary>
        /// 卡类型
        /// </summary>
        public uint CardType { get; set; }
        /// <summary>
        /// 卡号
        /// </summary>
        public string CardNumber { get; set; }
    }
}
