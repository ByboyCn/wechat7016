using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Message
{
    /// <summary>
    /// 分享名片DTO
    /// </summary>
    public class ShareCardDto : BaseDto
    {
        /// <summary>
        /// 对方用户id/群id
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 名片联系人id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        /// 别名
        /// </summary>
        public string Alias { get; set; }
    }
}
