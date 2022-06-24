using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Message
{
    /// <summary>
    /// 发送分享消息DTO
    /// </summary>
    public class SendShareDto : BaseDto
    {
        /// <summary>
        /// 对方用户id/群id
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// app类型 3：音乐  4：小app  5：大app
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 链接地址
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 数据链接地址
        /// </summary>
        public string DataUrl { get; set; }

        /// <summary>
        /// 缩略图链接地址
        /// </summary>
        public string ThumbUrl { get; set; }
    }
}
