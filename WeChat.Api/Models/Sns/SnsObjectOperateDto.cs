using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Sns
{
    /// <summary>
    /// 朋友圈操作DTO
    /// </summary>
    public class SnsObjectOperateDto : BaseDto
    {
        /// <summary>
        /// 朋友圈动态Id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 1删除朋友圈，2设为隐私，3设为公开，4删除评论，5取消点赞
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 扩展id
        /// </summary>
        public uint Ext { get; set; }
    }
}
