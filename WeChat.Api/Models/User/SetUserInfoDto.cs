using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.User
{
    /// <summary>
    /// 设置用户信息DTO
    /// </summary>
    public class SetUserInfoDto : BaseDto
    {
        /// <summary>
        /// 昵称(为null则不修改)
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        /// 性别：0：未知，1：男，2：女
        /// </summary>
        public int Sex { get; set; }
        /// <summary>
        /// 签名(为null则不修改)
        /// </summary>
        public string Signature { get; set; }
        /// <summary>
        /// 国家，国家简写字母，如：CN(为null则不修改)
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// 省份，省份拼音，如：zhejiang(为null则不修改)
        /// </summary>
        public string Province { get; set; }
        /// <summary>
        /// 城市，城市拼音，如：hangzhou(为null则不修改)
        /// </summary>
        public string City { get; set; }
    }
}
