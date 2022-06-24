using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.User
{
    /// <summary>
    /// 上传头像DTO
    /// </summary>
    public class UploadHeadImageDto : BaseDto
    {
        /// <summary>
        /// 图片BASE64编码
        /// 不带base64头部声明
        /// </summary>
        public string Base64Image { get; set; }
    }
}
