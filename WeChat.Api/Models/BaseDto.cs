using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models
{
    /// <summary>
    /// 基本DTO
    /// </summary>
    public class BaseDto
    {
        /// <summary>
        /// 微信实例唯一ID
        /// </summary>
        public string Guid { get; set; }
    }
}
