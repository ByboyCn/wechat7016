using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Login
{
    /// <summary>
    /// URL Dto
    /// </summary>
    public class URLDto : BaseDto
    {
        /// <summary>
        /// Url链接
        /// </summary>
        public string Url { get; set; }
    }

    /// <summary>
    /// 重提数据Dto
    /// </summary>
    public class DataDto : BaseDto
    {
        /// <summary>
        /// 0：安卓/1：iPad
        /// </summary>
        public int Terminal { get; set; }
    }
}
