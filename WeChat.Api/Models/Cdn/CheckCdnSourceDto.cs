using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Cdn
{
    /// <summary>
    /// 校验CDN资源DTO
    /// </summary>
    public class CheckCdnSourceDto : BaseDto
    {
        /// <summary>
        /// 
        /// </summary>
        public uint data_source_type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string data_source_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string dataid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string fullmd5 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string head256md5 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public uint fullsize { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public uint isthumb { get; set; }
    }
}
