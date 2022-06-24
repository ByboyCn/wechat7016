using System;
using System.Linq;

namespace WeChat.Core
{
    public static class WXContact
    {
        /// <summary>
        /// 系统联系人列表
        /// </summary>
        public static readonly string[] SYSTEM_CONTACTS = new[] { "exmail_tool", "weixin", "fmessage", "medianote", "floatbottle", "qmessage", "qqmail", "tmessage", "qqsync", "weibo", "mphelper", "tenpay", "filehelper", "mmpaynotify", "qqsafe", "Tencent-Games", "cll_qq", "mphelper", "fmessage", "newsapp", "filehelper", "weibo", "qqmail", "tmessage", "qmessage", "qqsync", "floatbottle", "lbsapp", "shakeapp", "medianote", "qqfriend", "readerapp", "blogapp", "facebookapp", "masssendapp", "meishiapp", "feedsapp", "voip", "blogappweixin", "weixin", "brandsessionholder", "weixinreminder", "wxid_novlwrv3lqwv11", "gh_22b87fa7cb3c", "officialaccounts", "notification_messages", "wxitil", "userexperience_alarm" };
        /// <summary>
        /// 是否是群
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static bool ISGroup(string username) => (username?.Contains("@") ?? false) && (username?.EndsWith("chatroom") ?? false);
        /// <summary>
        /// 是否是系统用户
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static bool ISSystemUser(string username) => SYSTEM_CONTACTS.Contains(username);
        /// <summary>
        /// 是否是公众号
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static bool ISBizAccount(string username) => username?.StartsWith("gh_") ?? false;
        /// <summary>
        /// 是否是用户
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static bool ISUser(string username) => !string.IsNullOrEmpty(username) && !ISGroup(username) && !ISBizAccount(username) && !ISSystemUser(username);
    }
}
