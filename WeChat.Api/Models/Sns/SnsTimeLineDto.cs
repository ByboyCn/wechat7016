using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Sns
{
    /// <summary>
    /// 获取朋友圈动态DTO
    /// </summary>
    public class SnsTimeLineDto : BaseDto
    {
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
