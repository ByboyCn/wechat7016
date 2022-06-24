using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Auth
{
    /// <summary>
    /// 扫描二维码DTO
    /// </summary>
    public class ScanQrcodeDto : BaseDto
    {
        /// <summary>
        /// 二维码链接
        /// </summary>
        public string Url { get; set; }
    }
}
