using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Sns
{
    /// <summary>
    /// 朋友圈动态详情DTO
    /// </summary>
    public class SnsObjectDetailDto : BaseDto
    {
        /// <summary>
        /// 动态Id
        /// </summary>
        public string Id { get; set; }
    }
}
