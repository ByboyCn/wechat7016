using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Message
{
    /// <summary>
    /// 校验大文件下载DTO
    /// </summary>
    public class CheckFileDownloadDto : BaseDto
    {
        /// <summary>
        /// aeskey
        /// </summary>
        public string aeskey { get; set; }
        /// <summary>
        /// type
        /// </summary>
        public uint type { get; set; }
        /// <summary>
        /// name
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// ext
        /// </summary>
        public string ext { get; set; }
        /// <summary>
        /// md5
        /// </summary>
        public string md5 { get; set; }
        /// <summary>
        /// size
        /// </summary>
        public ulong size { get; set; }
        /// <summary>
        /// fromuser
        /// </summary>
        public string fromuser { get; set; }
        /// <summary>
        /// touser
        /// </summary>
        public string touser { get; set; }
    }
}
