using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Message
{
    /// <summary>
    /// 下载消息文件DTO
    /// </summary>
    public class DownloadMsgFileDto : BaseDto
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// AppID
        /// </summary>
        public string AppID { get; set; }
        /// <summary>
        /// 附件ID
        /// </summary>
        public string AttachID { get; set; }
        /// <summary>
        /// 获取大小
        /// </summary>
        public uint Length { get; set; }
        /// <summary>
        /// 偏移
        /// </summary>
        public uint Offset { get; set; }
    }
}
