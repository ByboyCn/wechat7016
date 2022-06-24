using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Sns
{
    /// <summary>
    /// 好友朋友圈动态DTO
    /// </summary>
    public class SnsUserPageDto : BaseDto
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 上页MD5
        /// </summary>
        public string FirstPageMd5 { get; set; }
        /// <summary>
        /// 上一次最大动态id
        /// </summary>
        public string Maxid { get; set; }
    }
}
