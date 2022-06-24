using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.User
{
    /// <summary>
    /// 获取二维码DTO
    /// </summary>
    public class GetQrcodeDto : BaseDto
    {
        /// <summary>
        /// 个人或群id
        /// </summary>
        public string UserName { get; set; }
    }
}
