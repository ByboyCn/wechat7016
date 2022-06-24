using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Sns
{
    /// <summary>
    /// 最早朋友圈DTO
    /// </summary>
    public class SnsOriginalDto : BaseDto
    {
        /// <summary>
        /// 用户名（可自己）
        /// </summary>
        public string UserName { get; set; }
    }
}
