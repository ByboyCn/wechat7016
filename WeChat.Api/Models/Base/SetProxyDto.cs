using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Base
{
    /// <summary>
    /// 设置代理DTO
    /// </summary>
    public class SetProxyDto : BaseDto
    {
        /// <summary>
        /// 开关
        /// </summary>
        public bool Enable { get; set; }
        /// <summary>
        /// IP地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 端口
        /// </summary>
        public int Port { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
    }
}
