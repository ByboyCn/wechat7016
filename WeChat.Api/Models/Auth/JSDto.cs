using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Auth
{
    /// <summary>
    /// JS Dto
    /// </summary>
    public class JSDto : BaseDto
    {
        /// <summary>
        /// 小程序Appid
        /// </summary>
        public string AppId { get; set; }
    }
}
