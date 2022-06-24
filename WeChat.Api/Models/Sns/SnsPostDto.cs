using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Sns
{
    /// <summary>
    /// 发朋友圈DTO
    /// </summary>
    public class SnsPostDto : BaseDto
    {
        /// <summary>
        /// 朋友圈xml结构
        /// </summary>
        public string ContentXml { get; set; }
        /// <summary>
        /// 黑名单
        /// </summary>
        public string[] BlackList { get; set; }
        /// <summary>
        /// 提醒名单
        /// </summary>
        public string[] WithList { get; set; }
    }
}
