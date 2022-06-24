using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Contact
{
    /// <summary>
    /// 获取联系人DTO
    /// </summary>
    public class GetContactDto : BaseDto
    {
        /// <summary>
        /// 联系人列表
        /// </summary>
        public string[] Users { get; set; }
    }
}
