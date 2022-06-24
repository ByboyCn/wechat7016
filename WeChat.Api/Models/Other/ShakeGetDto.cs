using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Other
{
    /// <summary>
    /// 摇一摇获取结果DTO
    /// </summary>
    public class ShakeGetDto : BaseDto
    {
        /// <summary>
        /// 上下文内容BASE64
        /// </summary>
        public string ContextBase64 { get; set; }
    }
}
