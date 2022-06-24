using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Contact
{
    /// <summary>
    /// 获取通讯录朋友DTO
    /// </summary>
    public class GetMFriendDto : BaseDto
    {
        /// <summary>
        /// 上次同步的MD5,首次传空
        /// </summary>
        public string Md5 { get; set; }
    }
}
