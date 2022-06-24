using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Payment
{
    /// <summary>
    /// 创建红包DTO
    /// </summary>
    public class CreateRedPacketDto : BaseDto
    {
        /// <summary>
        /// 红包类型：0普通红包，1拼手气红包
        /// </summary>
        public uint Type { get; set; }
        /// <summary>
        /// 好友或群id
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 0个人红包，1群红包，3分享红包
        /// </summary>
        public uint From { get; set; }
        /// <summary>
        /// 红包个数，必须大于等于1
        /// </summary>
        public uint Count { get; set; }
        /// <summary>
        /// 红包金额，必须大于等于1，单位：分
        /// </summary>
        public uint Amount { get; set; }
        /// <summary>
        /// 红包语 如: 恭喜发财，大吉大利
        /// </summary>
        public string Content { get; set; }
    }
}
