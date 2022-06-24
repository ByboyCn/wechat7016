using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Other
{
    /// <summary>
    /// 上传设备步数DTO
    /// </summary>
    public class UploadDeviceStepDto : BaseDto
    {
        /// <summary>
        /// 步数
        /// </summary>
        public uint Count { get; set; }
    }
}
