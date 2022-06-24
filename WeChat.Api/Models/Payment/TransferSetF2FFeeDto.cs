using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Payment
{
    /// <summary>
    /// 获取自定义金额收款二维码DTO
    /// </summary>
    public class TransferSetF2FFeeDto : BaseDto
    {
        /// <summary>
        /// 金额，单位分，比如一元就是100
        /// </summary>
        public uint Fee { get; set; }
        /// <summary>
        /// 收款备注
        /// </summary>
        public string Description { get; set; }
    }
}
