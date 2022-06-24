using System.Collections.Generic;

namespace WeChat.Core
{
    /// <summary>
    /// 消息同步结果
    /// </summary>
    public partial class WXMessage
    {
        public IList<Protocol.Protos.ModUserInfo> ModUserInfos { get; set; } = new List<Protocol.Protos.ModUserInfo>();
        public IList<Protocol.Protos.ModContact> ModContacts { get; set; } = new List<Protocol.Protos.ModContact>();
        public IList<Protocol.Protos.DelContact> DelContacts { get; set; } = new List<Protocol.Protos.DelContact>();
        public IList<Protocol.Protos.AddMsg> AddMsgs { get; set; } = new List<Protocol.Protos.AddMsg>();
        public IList<Protocol.Protos.ModMsgStatus> ModMsgStatuss { get; set; } = new List<Protocol.Protos.ModMsgStatus>();
        public IList<Protocol.Protos.DelChatContact> DelChatContacts { get; set; } = new List<Protocol.Protos.DelChatContact>();
        public IList<Protocol.Protos.DelContactMsg> DelContactMsgs { get; set; } = new List<Protocol.Protos.DelContactMsg>();
        public IList<Protocol.Protos.DelMsg> DelMsgs { get; set; } = new List<Protocol.Protos.DelMsg>();
        public IList<Protocol.Protos.Report> Reports { get; set; } = new List<Protocol.Protos.Report>();
        public IList<Protocol.Protos.OpenQQMicroBlog> OpenQQMicroBlogs { get; set; } = new List<Protocol.Protos.OpenQQMicroBlog>();
        public IList<Protocol.Protos.CloseMicroBlog> CloseMicroBlogs { get; set; } = new List<Protocol.Protos.CloseMicroBlog>();
        public IList<Protocol.Protos.InviteFriendOpen> InviteFriendOpens { get; set; } = new List<Protocol.Protos.InviteFriendOpen>();
        public IList<Protocol.Protos.ModMicroBlogInfo> ModMicroBlogInfos { get; set; } = new List<Protocol.Protos.ModMicroBlogInfo>();
        public IList<Protocol.Protos.ModNotifyStatus> ModNotifyStatuss { get; set; } = new List<Protocol.Protos.ModNotifyStatus>();
        public IList<Protocol.Protos.ModChatRoomMember> ModChatRoomMembers { get; set; } = new List<Protocol.Protos.ModChatRoomMember>();
        public IList<Protocol.Protos.QuitChatRoom> QuitChatRooms { get; set; } = new List<Protocol.Protos.QuitChatRoom>();
        public IList<Protocol.Protos.ModUserDomainEmail> ModUserDomainEmails { get; set; } = new List<Protocol.Protos.ModUserDomainEmail>();
        public IList<Protocol.Protos.DelUserDomainEmail> DelUserDomainEmails { get; set; } = new List<Protocol.Protos.DelUserDomainEmail>();
        public IList<Protocol.Protos.ModChatRoomNotify> ModChatRoomNotifys { get; set; } = new List<Protocol.Protos.ModChatRoomNotify>();
        public IList<Protocol.Protos.PossibleFriend> PossibleFriends { get; set; } = new List<Protocol.Protos.PossibleFriend>();
        public IList<Protocol.Protos.FunctionSwitch> FunctionSwitchs { get; set; } = new List<Protocol.Protos.FunctionSwitch>();
        public IList<Protocol.Protos.QContact> QContacts { get; set; } = new List<Protocol.Protos.QContact>();
        public IList<Protocol.Protos.TContact> TContacts { get; set; } = new List<Protocol.Protos.TContact>();
        public IList<Protocol.Protos.PSMStat> PSMStats { get; set; } = new List<Protocol.Protos.PSMStat>();
        public IList<Protocol.Protos.ModChatRoomTopic> ModChatRoomTopics { get; set; } = new List<Protocol.Protos.ModChatRoomTopic>();
        public IList<Protocol.Protos.UpdateStatOpLog> UpdateStatOpLogs { get; set; } = new List<Protocol.Protos.UpdateStatOpLog>();
        public IList<Protocol.Protos.ModDisturbSetting> ModDisturbSettings { get; set; } = new List<Protocol.Protos.ModDisturbSetting>();
        public IList<Protocol.Protos.ModBottleContact> ModBottleContacts { get; set; } = new List<Protocol.Protos.ModBottleContact>();
        public IList<Protocol.Protos.DelBottleContact> DelBottleContacts { get; set; } = new List<Protocol.Protos.DelBottleContact>();
        public IList<Protocol.Protos.ModUserImg> ModUserImgs { get; set; } = new List<Protocol.Protos.ModUserImg>();
        public IList<Protocol.Protos.KVStatItem> KVStatItems { get; set; } = new List<Protocol.Protos.KVStatItem>();
        public IList<Protocol.Protos.ThemeOpLog> ThemeOpLogs { get; set; } = new List<Protocol.Protos.ThemeOpLog>();
        public IList<Protocol.Protos.UserInfoExt> UserInfoExts { get; set; } = new List<Protocol.Protos.UserInfoExt>();
        public IList<Protocol.Protos.SnsObject> SnsObjects { get; set; } = new List<Protocol.Protos.SnsObject>();
        public IList<Protocol.Protos.SnsActionGroup> SnsActionGroups { get; set; } = new List<Protocol.Protos.SnsActionGroup>();
        public IList<Protocol.Protos.ModBrandSetting> ModBrandSettings { get; set; } = new List<Protocol.Protos.ModBrandSetting>();
        public IList<Protocol.Protos.ModChatRoomMemberDisplayName> ModChatRoomMemberDisplayNames { get; set; } = new List<Protocol.Protos.ModChatRoomMemberDisplayName>();
        public IList<Protocol.Protos.ModChatRoomMemberFlag> ModChatRoomMemberFlags { get; set; } = new List<Protocol.Protos.ModChatRoomMemberFlag>();
        public IList<Protocol.Protos.WebWxFunctionSwitch> WebWxFunctionSwitchs { get; set; } = new List<Protocol.Protos.WebWxFunctionSwitch>();
        public IList<Protocol.Protos.ModSnsBlackList> ModSnsBlackLists { get; set; } = new List<Protocol.Protos.ModSnsBlackList>();
        public IList<Protocol.Protos.NewDelMsg> NewDelMsgs { get; set; } = new List<Protocol.Protos.NewDelMsg>();
        public IList<Protocol.Protos.ModDescription> ModDescriptions { get; set; } = new List<Protocol.Protos.ModDescription>();
        public IList<Protocol.Protos.KVCmd> KVCmds { get; set; } = new List<Protocol.Protos.KVCmd>();
        public IList<Protocol.Protos.DeleteSnsOldGroup> DeleteSnsOldGroups { get; set; } = new List<Protocol.Protos.DeleteSnsOldGroup>();
    }
}
