using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.UnBan
{
   
    /// <summary>
    /// 封号操作DTO
    /// </summary>
    public class UnBanNoGuidDto
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; } = "";
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; } = "";
        /// <summary>
        /// 代理IP
        /// </summary>
        public string ProxyIP { get; set; } = "";
    }

    /// <summary>
    /// 临时登录DTO
    /// </summary>
    public class TempLoginDto: UnBanNoGuidDto
    {
        /// <summary>
        /// 数据
        /// </summary>
        public string Data { get; set; } = "";

        /// <summary>
        /// 是否强开
        /// </summary>
        public bool Force { get; set; } = false;
    }

    
}
