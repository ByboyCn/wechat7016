using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Message
{
    /// <summary>
    /// 获取图片消息DTO
    /// </summary>
    public class GetMsgImageDto : GetMsgMediaDto
    {
        /// <summary>
        /// 压缩类型（0压缩 1高清）
        /// 当xml只中含有length 字段时 CompressType = 0 可以下载高清(有压缩情况)
        /// 当xml中含有hdlength 字段时 CompressType = 1 可以下载高清
        /// </summary>
        public uint CompressType { get; set; }
    }
}
