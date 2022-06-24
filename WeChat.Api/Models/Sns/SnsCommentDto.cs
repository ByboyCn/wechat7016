using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Sns
{
    /// <summary>
    /// 朋友圈回复DTO
    /// </summary>
    public class SnsCommentDto : BaseDto
    {
        /// <summary>
        /// 类型(1:点赞, 2:文本, 3:消息, 4:with, 5:陌生人点赞)
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 动态Id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 对方用户id
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 回复id
        /// </summary>
        public int ReplyId { get; set; }
        /// <summary>
        /// 回复内容
        /// </summary>
        public string Content { get; set; }
    }
}
