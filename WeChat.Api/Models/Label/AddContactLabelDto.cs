using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Label
{
    /// <summary>
    /// 添加标签DTO
    /// </summary>
    public class AddContactLabelDto : BaseDto
    {
        /// <summary>
        /// 标签名称
        /// </summary>
        public string Name { get; set; }
    }
}
