using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Login
{
    /// <summary>
    /// 获取DTO
    /// </summary>
    public class LoginDto : BaseDto
    {
        /// <summary>
        /// 登录通道(0：用户密码，1：二维码，2：手机)
        /// </summary>
        public int Channel { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; } = "";
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; } = "";
        /// <summary>
        /// 过滑块
        /// </summary>
        public bool Slider { get; set; } = true;
        /// <summary>
        /// 新设备初始化
        /// 消息相关功能需要先初始化
        /// </summary>
        public bool Init { get; set; } = false;
    }
}
