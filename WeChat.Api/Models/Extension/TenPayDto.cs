using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Extension
{
    /// <summary>
    /// 腾讯支付DTO
    /// </summary>
    public class TenPayDto : BaseDto
    {
        /// <summary>
        /// 操作类型
        /// </summary>
        public Core.Protocol.Protos.V2.enMMTenPayCgiCmd Type { get; set; }
        /// <summary>
        /// ReqText
        /// </summary>
        public string ReqText { get; set; }
        /// <summary>
        /// ReqTextWx
        /// </summary>
        public string ReqTextWx { get; set; }
    }
}
