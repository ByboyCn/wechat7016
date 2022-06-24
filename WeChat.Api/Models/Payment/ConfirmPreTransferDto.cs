using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Payment
{
    /// <summary>
    /// 创建转账DTO
    /// </summary>
    public class CreatePreTransferDto : BaseDto
    {
        /// <summary>
        /// 对方用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public uint Fee { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Description { get; set; }
    }
}
