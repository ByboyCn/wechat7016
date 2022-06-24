using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.User
{
    /// <summary>
    /// 好友验证功能切换
    /// </summary>
    public class FunctionSwitchDto : BaseDto
    {
        /// <summary>
        /// 4：加我为朋友是需要验证(1开启，2关闭)
        /// 7：向我推荐通讯录朋友（1关闭，2开启）
        /// 8：允许手机号找到我（1关闭，2开启）
        /// 25：允许微信号找到我（1关闭，2开启）
        /// 38：允许群聊添加我（1关闭，2开启）
        /// 39：允许我的二维码添加我（1关闭，2开启）
        /// 40：允许名片添加我（1关闭，2开启）
        /// </summary>
        public uint Function { get; set; }
        /// <summary>
        /// 开关
        /// </summary>
        public uint Value { get; set; }
    }
}
