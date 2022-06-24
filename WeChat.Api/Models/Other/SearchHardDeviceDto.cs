using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Other
{
    /// <summary>
    /// 搜索硬件设备DTO
    /// </summary>
    public class SearchHardDeviceDto : BaseDto
    {
        /// <summary>
        /// 二维码
        /// </summary>
        public string Qrcode { get; set; }
    }
}
