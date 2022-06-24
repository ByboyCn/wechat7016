using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Contact
{
    /// <summary>
    /// 联系人DTO
    /// </summary>
    public class ContactDto : BaseDto
    {
        /// <summary>
        /// 删除：用户ID
        /// 搜索：手机号/微信号/QQ号
        /// </summary>
        public string UserName { get; set; }
    }
}
