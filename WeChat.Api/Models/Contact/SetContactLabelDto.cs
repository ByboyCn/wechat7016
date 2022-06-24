using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Contact
{
    /// <summary>
    /// 设置用户标签DTO
    /// </summary>
    public class SetContactLabelDto : BaseDto
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 标签id列表
        /// </summary>
        public int[] Labels { get; set; }
    }
}
