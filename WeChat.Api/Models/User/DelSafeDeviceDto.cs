using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.User
{
    /// <summary>
    /// 删除安全设备DTO
    /// </summary>
    public class DelSafeDeviceDto : BaseDto
    {
        /// <summary>
        /// 设备uuid
        /// </summary>
        public string Uuid { get; set; }
    }
}
