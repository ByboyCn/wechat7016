using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Favor
{
    /// <summary>
    /// 添加收藏DTO
    /// </summary>
    public class AddFavItemDto : BaseDto
    {
        /// <summary>
        /// 收藏xml内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 源id
        /// </summary>
        public string SourceId { get; set; }
    }
}
