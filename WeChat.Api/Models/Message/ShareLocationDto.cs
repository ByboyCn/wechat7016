using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Message
{
    /// <summary>
    /// 分享位置DTO
    /// </summary>
    public class ShareLocationDto : BaseDto
    {
        /// <summary>
        /// 对方用户id
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title{ get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        public float Latitude { get; set; }
        /// <summary>
        /// 纬度
        /// </summary>
        public float Longitude { get; set; }
    }
}
