using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Message
{
    /// <summary>
    /// 分享收藏DTO
    /// </summary>
    public class ShareFavDto : BaseDto
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 收藏Id列表
        /// </summary>
        public uint[] Ids { get; set; }
    }
}
