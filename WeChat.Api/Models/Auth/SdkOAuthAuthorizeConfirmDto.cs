using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Auth
{
    /// <summary>
    /// APP授权登录Dto
    /// </summary>
    public class SdkOAuthAuthorizeConfirmDto : BaseDto
    {
        /// <summary>
        /// 应用Appid
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 应用名称
        /// </summary>
        public string AppName { get; set; }

        /// <summary>
        /// 应用包名
        /// </summary>
        public string AppNamePack { get; set; }

    }
}
