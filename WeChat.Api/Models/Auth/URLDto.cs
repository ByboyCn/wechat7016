using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Auth
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
}
