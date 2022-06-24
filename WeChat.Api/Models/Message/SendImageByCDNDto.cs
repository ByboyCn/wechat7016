using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Message
{
    /// <summary>
    /// 发送CDN图片消息DTO
    /// </summary>
    public class SendImageByCDNDto : BaseDto
    {
        /// <summary>
        /// 对方用户id/群id
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// CDN图片地址
        /// </summary>
        public string CdnImgUrl { get; set; }

        /// <summary>
        /// CDN图片大小
        /// </summary>
        public int CdnImgSize { get; set; }

        /// <summary>
        /// CDN图片缩略图大小
        /// </summary>
        public int CdnThumbImgSize { get; set; }

        /// <summary>
        /// CDN图片加密KEY
        /// </summary>
        public string CdnImgAesKey { get; set; }
    }
}
