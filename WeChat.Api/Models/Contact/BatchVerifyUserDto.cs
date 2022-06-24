using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Contact
{
    /// <summary>
    ///  批量好友验证DTO
    /// </summary>
    public class BatchVerifyUserDto : BaseDto
    {
        /// <summary>
        /// 类型，1添加好友/公众号，2打招呼验证，3同意好友添加请求，4拒绝
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 好友信息
        /// </summary>
        public Core.Protocol.Protos.V2.VerifyUser[] Users { get; set; }

        /// <summary>
        /// 添加好友来源类型，1QQ，2邮箱，3微信号，13通讯录，14群聊，15手机号，18附近的人，25漂流瓶，29摇一摇，30二维码
        /// </summary>
        public byte Scene { get; set; }
        /// <summary>
        /// 添加好友时的验证信息(可为空，WX自己默认首次验证就是为空，若需要验证消息则再次发送填写该参数)
        /// </summary>
        public string Verify { get; set; }
    }
}
