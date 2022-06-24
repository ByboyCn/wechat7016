using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.User
{
    /// <summary>
    /// 设置微信号DTO
    /// </summary>
    public class SetAlisaDto : BaseDto
    {
        /// <summary>
        /// 微信号
        /// </summary>
        public string Alisa { get; set; }
    }
}
