using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Contact
{
    /// <summary>
    ///  初始化通讯录DTO
    /// </summary>
    public class InitContactDto : BaseDto
    {
        /// <summary>
        /// 当前好友联系人请求号,第一次为0
        /// </summary>
        public int CurrentWxContactSeq { get; set; }
    }
}
