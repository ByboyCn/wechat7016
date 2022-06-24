using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Payment
{
    /// <summary>
    /// 确认转账DTO
    /// </summary>
    public class ConfirmPreTransferDto : BaseDto
    {
        /// <summary>
        /// 银行类型
        /// </summary>
        public string BankType { get; set; }
        /// <summary>
        /// 绑定卡号的Id
        /// </summary>
        public string BindSerial { get; set; }
        /// <summary>
        /// 请求的Key
        /// </summary>
        public string ReqKey { get; set; }
        /// <summary>
        /// 支付密码
        /// </summary>
        public string PayPassword { get; set; }
    }
}
