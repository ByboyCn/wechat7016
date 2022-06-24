using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Biz
{
    /// <summary>
    /// 公众号基础DTO
    /// </summary>
    public class BizUrlDto : BaseDto
    {
        /// <summary>
        /// 地址
        /// </summary>
        public string Url { get; set; }
    }
}
