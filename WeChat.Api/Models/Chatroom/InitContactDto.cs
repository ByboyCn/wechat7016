using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Chatroom
{
    /// <summary>
    ///  初始化通讯录DTO
    /// </summary>
    public class InitContactDto : BaseDto
    {
        /// <summary>
        /// 当前群聊联系人请求号,第一次为0
        /// </summary>
        public int CurrentChatroomContactSeq { get; set; }

        /// <summary>
        /// 是否获取详情
        /// 建议群少时使用
        /// </summary>
        public bool IsDetail { get; set; } = false;
    }
}
