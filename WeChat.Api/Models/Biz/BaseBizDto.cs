using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Biz
{
    /// <summary>
    /// 公众号基础DTO
    /// </summary>
    public class BaseBizDto : BaseDto
    {
        /// <summary>
        /// 公众号名称
        /// 例如"weixin"
        /// </summary>
        public string BizUserName { get; set; }
    }
}
