using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Sns
{
    /// <summary>
    /// 设置朋友圈权限DTO
    /// </summary>
    public class SnsSwitchDto : BaseDto
    {
        /// <summary>
        /// 允许朋友查看朋友圈的范围：7297，值（全部：4294967295，最近半年：4320，最近一个月：720，最近3天：72）
        /// 允许陌生人查看十条朋友圈：开启（7296，值：72），关闭（7297，值：72）
        /// </summary>
        public uint Function { get; set; }
        /// <summary>
        /// 开关
        /// </summary>
        public uint Value { get; set; }
    }
}
