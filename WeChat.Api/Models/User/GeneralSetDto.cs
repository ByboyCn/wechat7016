using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.User
{
    /// <summary>
    /// 通用设置DTO
    /// </summary>
    public class GeneralSetDto : BaseDto
    {
        /// <summary>
        /// 类型（1：设置微信号）
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        public string Value { get; set; }
    }
}
