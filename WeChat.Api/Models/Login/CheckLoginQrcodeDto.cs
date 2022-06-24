using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Login
{
    /// <summary>
    /// 获取登陆二维码状态DTO
    /// </summary>
    public class CheckLoginQrcodeDto : BaseDto
    {
        /// <summary>
        /// 二维码Uuid
        /// </summary>
        public string Uuid { get; set; }
    }
}
