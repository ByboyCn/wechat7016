using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Label
{
    /// <summary>
    /// 删除标签DTO
    /// </summary>
    public class DelContactLabelDto : BaseDto
    {
        /// <summary>
        /// 标签Id
        /// </summary>
        public string Id { get; set; }
    }
}
