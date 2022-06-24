using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Message
{
    /// <summary>
    /// 发送文件消息DTO
    /// </summary>
    public class SendMsgFileDto : BaseDto
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 附件ID
        /// 附件上传时返回或从消息同步里获取
        /// </summary>
        public string AttachId { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 文件长度
        /// </summary>
        public long Length { get; set; }
        /// <summary>
        /// 文件扩展名
        /// </summary>
        public string Extension { get; set; }
    }
}
