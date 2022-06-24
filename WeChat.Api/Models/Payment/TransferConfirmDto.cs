using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Payment
{
    /// <summary>
    /// 确认转账DTO
    /// </summary>
    public class TransferConfirmDto : BaseDto
    {
        /// <summary>
        /// 银行类型
        /// </summary>
        public string BankType { get; set; }
        /// <summary>
        /// 卡号绑定的序列号
        /// </summary>
        public string BindSerial { get; set; }
        /// <summary>
        /// 请求key
        /// </summary>
        public string ReqKey { get; set; }
        /// <summary>
        /// 支付密码
        /// </summary>
        public string Password { get; set; }
    }
}
