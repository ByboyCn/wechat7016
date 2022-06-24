using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Contact
{
    /// <summary>
    /// 上传通讯录DTO
    /// </summary>
    public class UploadMContactDto : BaseDto
    {
        /// <summary>
        /// 自己手机号码
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 手机号码列表（建议大小为15）
        /// </summary>
        public string[] PhoneNumberList { get; set; }
    }
}
