using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Message
{
    /// <summary>
    /// 发送CDN视频消息DTO
    /// </summary>
    public class SendVideoByCDNDto : BaseDto
    {
        /// <summary>
        /// 对方用户id/群id
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// CDN视频地址
        /// </summary>
        public string CdnVideoUrl { get; set; }

        /// <summary>
        /// 原视频大小
        /// </summary>
        public int VideoSize { get; set; }

        /// <summary>
        /// CDN视频大小
        /// </summary>
        public int CdnVideoSize { get; set; }

        /// <summary>
        /// CDN视频缩略大小
        /// </summary>
        public int CdnThumbVideoSize { get; set; }

        /// <summary>
        /// CDN视频加密KEY
        /// </summary>
        public string CdnVideoAesKey { get; set; }
    }
}
