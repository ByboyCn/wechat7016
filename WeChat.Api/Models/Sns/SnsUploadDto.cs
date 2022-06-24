using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Sns
{
    /// <summary>
    /// 朋友圈上传图片DTO
    /// </summary>
    public class SnsUploadDto : BaseDto
    {
        /// <summary>
        /// 图片文件BASE64
        /// </summary>
        public string ImageFileBase64 { get; set; }
    }
}
