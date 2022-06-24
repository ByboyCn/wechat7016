using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Payment
{
    /// <summary>
    /// 收款操作DTO
    /// </summary>
    public class TransferOperateDto : BaseDto
    {
        /// <summary>
        /// 有效时间
        /// </summary>
        public string InvalidTime { get; set; }
        /// <summary>
        /// 转账Id
        /// </summary>
        public string TransId { get; set; }
        /// <summary>
        /// 交易Id
        /// </summary>
        public string TransactionId { get; set; }
    }
}
