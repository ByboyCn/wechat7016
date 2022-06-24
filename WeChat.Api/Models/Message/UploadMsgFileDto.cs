using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Message
{
    /// <summary>
    /// 上传消息文件DTO
    /// </summary>
    public class UploadMsgFileDto : BaseDto
    {
        /// <summary>
        /// 文件Base64数据
        /// </summary>
        public string Data { get; set; }
    }
}
