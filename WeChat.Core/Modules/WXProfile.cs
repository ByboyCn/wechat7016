using System;

namespace WeChat.Core
{
    /// <summary>
    /// 微信个人信息
    /// </summary>
    [Serializable]
    public struct WXProfile
    {
        /// <summary>
        /// 微信ID/用户名
        /// </summary>
        public string UserName;
        /// <summary>
        /// 密码
        /// </summary>
        public string Password;
        /// <summary>
        /// MD5密码
        /// </summary>
        public string PasswordMd5;
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName;
        /// <summary>
        /// 头像
        /// </summary>
        public string HeadImage;
        /// <summary>
        /// 绑定的邮箱
        /// </summary>
        public string BindEmail;
        /// <summary>
        /// 绑定的手机号
        /// </summary>
        public string BindMobile;
        /// <summary>
        /// 微信号
        /// </summary>
        public string Alias;
    }
}
