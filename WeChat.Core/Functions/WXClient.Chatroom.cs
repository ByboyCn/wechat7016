using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeChat.Core.Protocol;
using WeChat.Core.Protocol.Protos;
using WeChat.Core.Protocol.Protos.V2;

namespace WeChat.Core
{
    public partial interface IWXApp
    {
        /// <summary>
        /// 分页获取通讯录群聊(详情)
        /// </summary>
        /// <param name="current_chatroom_contact_seq">当前群聊请求，第一次为0</param>
        /// <param name="detail">是否获取详情，建议群少时使用</param>
        /// <returns></returns>
        Task<InitContactResponse> WXGetChatroomPage(int current_chatroom_contact_seq = 0, bool detail = false);
        /// <summary>
        /// 获取全部通讯录群聊(ID)
        /// </summary>
        /// <returns></returns>
        Task<List<string>> WXGetChatroomAll();
        /// <summary>
        /// 扫描群二维码
        /// </summary>
        /// <param name="url">二维码url，格式如：https://weixin.qq.com/g/xxxxxx </param>
        /// <returns></returns>
        Task<string> WXScanChatroomQrcode(string url);
        /// <summary>
        /// 获取群二维码
        /// </summary>
        /// <param name="chatroom">群id</param>
        /// <returns></returns>
        Task<Protocol.Protos.GetQRCodeResponse> WXGetChatroomQrcode(string chatroom);
        /// <summary>
        /// 创建群
        /// </summary>
        /// <param name="users">要邀请的联系人id列表,第一个必须是自己的wxid</param>
        /// <param name="nickname">群昵称</param>
        /// <returns></returns>
        Task<CreateChatRoomResponese> WXCreateChatroom(string[] users, string nickname = "");
        /// <summary>
        /// 面对面创群
        /// </summary>
        /// <param name="password">密码</param>
        /// <param name="latitude">纬度</param>
        /// <param name="longitude">经度</param>
        /// <returns></returns>
        Task<FacingCreateChatRoomRequest> WXCreateFaceChatroom(string password, float latitude, float longitude);
        /// <summary>
        /// 退出群
        /// </summary>
        /// <param name="chatroom">群id</param>
        /// <returns></returns>
        Task<OpLogResponse> WXQuitChatroom(string chatroom);
        /// <summary>
        /// 设置群名称
        /// </summary>
        /// <param name="chatroom">群id</param>
        /// <param name="nickname">名称</param>
        /// <returns></returns>
        Task<OpLogResponse> WXSetChatroomName(string chatroom, string nickname);
        /// <summary>
        /// 设置我在本群昵称
        /// </summary>
        /// <param name="chatroom">群id</param>
        /// <param name="nickname">昵称</param>
        /// <returns></returns>
        Task<OpLogResponse> WXSetChatroomNameDisplyName(string chatroom, string nickname);
        /// <summary>
        /// 显示群成员昵称
        /// </summary>
        /// <param name="chatroom">群id</param>
        /// <param name="value">1开/2关</param>
        /// <returns></returns>
        Task<OpLogResponse> WXShowChatroomMemberDisplyName(string chatroom, uint value);
        /// <summary>
        /// 保存到通讯录
        /// </summary>
        /// <param name="chatroom">群id</param>
        /// <param name="value">1开/2关</param>
        /// <returns></returns>
        Task<OpLogResponse> WXSaveChatroomToContact(string chatroom, uint value);
        /// <summary>
        /// 设置群聊邀请验证
        /// </summary>
        /// <param name="chatroom">群id</param>
        /// <param name="status">关闭：0，打开：2</param>
        /// <returns></returns>
        Task<OpLogResponse> WXSetChatroomAccessVerify(string chatroom, uint status);
        /// <summary>
        /// 转让群主
        /// </summary>
        /// <param name="chatroom">新群id</param>
        /// <param name="user">新群主用户名</param>
        /// <returns></returns>
        Task<TransferChatRoomOwnerResponse> WXTransferChatroomOwner(string chatroom, string user);
        /// <summary>
        /// 获取群公告
        /// </summary>
        /// <param name="chatroom">群id</param>
        /// <returns></returns>
        Task<GetChatRoomAnnouncementResponse> WXGetChatroomAnnouncement(string chatroom);
        /// <summary>
        /// 邀请群成员（40人以上）
        /// </summary>
        /// <param name="chatroom">群id</param>
        /// <param name="users">对方用户名列表</param>
        /// <returns></returns>
        Task<InviteChatRoomMemberResponse> WXInviteChatroomMember(string chatroom, string[] users);
        /// <summary>
        /// 添加群管理
        /// </summary>
        /// <param name="chatroom">群id</param>
        /// <param name="users">对方用户名列表</param>
        /// <returns></returns>
        Task<AddChatRoomAdminResponse> WXAddChatroomAdmin(string chatroom, string[] users);
        /// <summary>
        /// 删除群管理
        /// </summary>
        /// <param name="chatroom">群id</param>
        /// <param name="users">对方用户名列表</param>
        /// <returns></returns>
        Task<DelChatRoomAdminResponse> WXDelChatroomAdmin(string chatroom, string[] users);
        /// <summary>
        /// 添加群成员（40人以内）
        /// </summary>
        /// <param name="chatroom">群id</param>
        /// <param name="users">对方用户名列表</param>
        /// <returns></returns>
        Task<Protocol.Protos.V2.AddChatRoomMemberResponse> WXAddChatroomMember(string chatroom, string[] users);
        /// <summary>
        /// 删除群成员
        /// </summary>
        /// <param name="chatroom">群id</param>
        /// <param name="users">对方用户名列表</param>
        /// <returns></returns>
        Task<Protocol.Protos.V2.DelChatRoomMemberResponse> WXDelChatroomMember(string chatroom, string[] users);
        /// <summary>
        /// 获取群成员详情
        /// </summary>
        /// <param name="chatroom">群id</param>
        /// <returns></returns>
        Task<Protocol.Protos.V2.GetChatroomMemberDetailResponse> WXGetChatroomMemberDetail(string chatroom);
        /// <summary>
        /// 获取群信息
        /// </summary>
        /// <param name="chatrooms">群ids</param>
        /// <returns></returns>
        Task<ChatRoomProfile[]> WXGetChatroomInfoDetail(string[] chatrooms);
        /// <summary>
        /// 设置群公告
        /// </summary>
        /// <param name="chatroom">群id</param>
        /// <param name="context">公告内容</param>
        /// <returns></returns>
        Task<Protocol.Protos.SetChatRoomAnnouncementResponse> WXSetChatroomAnnouncement(string chatroom, string context);
    }
    public partial class WXApp
    {
        /// <summary>
        /// 分页获取通讯录群聊(详情)
        /// </summary>
        /// <param name="current_chatroom_contact_seq">当前群聊请求，第一次为0</param>
        /// <param name="detail">是否获取详情，建议群少时使用</param>
        /// <returns></returns>
        public virtual async Task<InitContactResponse> WXGetChatroomPage(int current_chatroom_contact_seq = 0, bool detail = false)
        {
            var response = await WXInitContact(-1, current_chatroom_contact_seq);
            if (detail)
            {
                response.contactUserInfoList = await WXGetChatroomInfoDetail(response?.contactUsernameList);
            }
            return response;
        }

        /// <summary>
        /// 获取全部通讯录群聊(ID)
        /// </summary>
        /// <returns></returns>
        public virtual async Task<List<string>> WXGetChatroomAll()
        {
            int current_chatroom_contact_seq = 0;
            var result = new List<string>();
            while (true)
            {
                var response = await WXInitContact(-1, current_chatroom_contact_seq);
                if (response == null || response.baseResponse.ret != RetConst.MM_OK)
                {
                    break;
                }
                if (response?.contactUsernameList?.Length > 0)
                {
                    result.AddRange(response.contactUsernameList);
                    if (response?.contactUsernameList?.Length < 100 || current_chatroom_contact_seq == response.currentChatRoomContactSeq)
                    {
                        break;
                    }
                    current_chatroom_contact_seq = response.currentChatRoomContactSeq;
                }
                else
                {
                    break;
                }
            }
            return result.Distinct().ToList();
        }

        /// <summary>
        /// 扫描群二维码
        /// </summary>
        /// <param name="url">二维码url，格式如：https://weixin.qq.com/g/xxxxx </param>
        /// <returns></returns>
        public virtual async Task<string> WXScanChatroomQrcode(string url)
        {
            var result = default(string);
            var a8key = await WXGetA8Key(url);
            var full = a8key?.FullURL;
            if (full?.StartsWith("weixin://jump/mainframe/") ?? false)
            {
                result = full.Replace("weixin://jump/mainframe/", "");
                return result;
            }
            if ((full?.IsEmpty() ?? true))
            {
                return "A8Key授权失败";
            }
            HttpHelper http = new HttpHelper();
            HttpItem item = new HttpItem()
            {
                URL = full,
                Method = "POST"
            };
            return http.GetHtml(item)?.Header["Location"]?.Replace("weixin://jump/mainframe/", "");
        }

        /// <summary>
        /// 获取群二维码
        /// </summary>
        /// <param name="chatroom">群id</param>
        /// <returns></returns>
        public virtual async Task<Protocol.Protos.GetQRCodeResponse> WXGetChatroomQrcode(string chatroom)
        {
            return await WXGetQrcode(chatroom);
        }

        /// <summary>
        /// 创建群
        /// </summary>
        /// <param name="users">要邀请的联系人id列表,第一个必须是自己的wxid</param>
        /// <param name="nickname">群名称</param>
        /// <returns></returns>
        public virtual async Task<CreateChatRoomResponese> WXCreateChatroom(string[] users, string nickname = "")
        {
            return await Request<CreateChatRoomResponese>(new Protocol.Protos.V2.CreateChatRoomRequest()
            {
                baseRequest = new Protocol.Protos.V2.BaseRequest
                {
                    clientVersion = _Environment.Terminal.GetWeChatVersion(),
                    devicelId = _Environment.WeChatDataId.ToByteArray(16, 2),
                    osType = _Environment.WeChatOsType,
                    sessionKey = _Cache.SessionKey,
                    scene = _Cache.Scene,
                    uin = _Cache.Uin
                },
                scene = 0,
                topic = new SKBuiltinString { @string = nickname },
                memberCount = (uint)(users?.Length ?? 0),
                memberList = users?.Select(u => new Protocol.Protos.V2.MemberReq { member = new SKBuiltinString { @string = u } })?.ToArray()
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_createchatroom);
        }

        /// <summary>
        /// 面对面创群
        /// </summary>
        /// <param name="password">密码</param>
        /// <param name="latitude">纬度</param>
        /// <param name="longitude">经度</param>
        /// <returns></returns>
        public virtual async Task<FacingCreateChatRoomRequest> WXCreateFaceChatroom(string password, float latitude, float longitude)
        {
            return await Request<FacingCreateChatRoomRequest>(new FacingCreateChatRoomRequest()
            {
                BaseRequest = new Protocol.Protos.BaseRequest
                {
                    SessionKey = _Cache.SessionKey,
                    Uin = _Cache.Uin,
                    DeviceID = _Environment.WeChatDataId.ToByteArray(16, 2),
                    ClientVersion = _Environment.Terminal.GetWeChatVersion(),
                    DeviceType = Encoding.UTF8.GetBytes(_Environment.WeChatOsType),
                    Scene = (uint)_Cache.Scene,
                },
                GPSSource = 0,
                Latitude = latitude,
                Longitude = longitude,
                Precision = 65,
                OpCode = (uint)0,
                PassWord = password
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_mmfacingcreatechatroom);
        }

        /// <summary>
        /// 退出群
        /// </summary>
        /// <param name="chatroom">群id</param>
        /// <returns></returns>
        public virtual async Task<OpLogResponse> WXQuitChatroom(string chatroom)
        {
            return await WXOpLog(SyncCmdID.CmdIdQuitChatRoom, new Protocol.Protos.V2.QuitChatRoom()
            {
                userName = new SKBuiltinString { @string = _Profile.UserName },
                chatRoomName = new SKBuiltinString { @string = chatroom }
            });
        }

        /// <summary>
        /// 设置群名称
        /// </summary>
        /// <param name="chatroom">群id</param>
        /// <param name="nickname">名称</param>
        /// <returns></returns>
        public virtual async Task<OpLogResponse> WXSetChatroomName(string chatroom, string nickname)
        {
            var result = default(OpLogResponse);
            var r = await WXGetContact(new string[] { chatroom });
            if (r?.baseResponse?.ret != (int)RetConst.MM_OK) { return result; }
            var contact = r.contactList[0];
            contact.nickName = new SKBuiltinString { @string = nickname };
            return await WXOpLog(SyncCmdID.CmdIdModContact, contact);
        }

        /// <summary>
        /// 设置我在本群昵称
        /// </summary>
        /// <param name="chatroom">群id</param>
        /// <param name="nickname">昵称</param>
        /// <returns></returns>
        public virtual async Task<OpLogResponse> WXSetChatroomNameDisplyName(string chatroom, string nickname)
        {
            return await WXOpLog(SyncCmdID.MM_SYNCCMD_MODCHATROOMMEMBERDISPLAYNAME, new ModChatRoomMemberDisplayName()
            {
                ChatRoomName = chatroom,
                DisplayName = nickname,
                UserName = Profile.UserName
            });
        }

        /// <summary>
        /// 显示群成员昵称
        /// </summary>
        /// <param name="chatroom">群id</param>
        /// <param name="value">1开/2关</param>
        /// <returns></returns>
        public virtual async Task<OpLogResponse> WXShowChatroomMemberDisplyName(string chatroom, uint value)
        {
            return await WXOpLog(SyncCmdID.MM_SYNCCMD_MODCHATROOMMEMBERFLAG, new ModChatRoomMemberFlag()
            {
                ChatRoomName = chatroom,
                UserName = Profile.UserName,
                FlagSwitch = 3,
                Value = value
            });
        }

        /// <summary>
        /// 保存到通讯录
        /// </summary>
        /// <param name="chatroom">群id</param>
        /// <param name="value">1开/2关</param>
        /// <returns></returns>
        public virtual async Task<OpLogResponse> WXSaveChatroomToContact(string chatroom, uint value)
        {
            return await WXOpLog(SyncCmdID.MM_SYNCCMD_MODCHATROOMMEMBERFLAG, new ModChatRoomMemberFlag()
            {
                ChatRoomName = chatroom,
                UserName = Profile.UserName,
                FlagSwitch = 8,
                Value = value
            });
        }

        /// <summary>
        /// 设置群聊邀请验证
        /// </summary>
        /// <param name="chatroom">群id</param>
        /// <param name="status">关闭：0，打开：2</param>
        /// <returns></returns>
        public virtual async Task<OpLogResponse> WXSetChatroomAccessVerify(string chatroom, uint status)
        {
            return await WXOpLog(SyncCmdID.CmdIdModChatRoomAccessVerify, new ModChatRoomAccessVerify()
            {
                chatRoomName = chatroom,
                status = status
            });
        }

        /// <summary>
        /// 转让群主
        /// </summary>
        /// <param name="chatroom">群id</param>
        /// <param name="user">新群主用户名</param>
        /// <returns></returns>
        public virtual async Task<TransferChatRoomOwnerResponse> WXTransferChatroomOwner(string chatroom, string user)
        {
            return await Request<TransferChatRoomOwnerResponse>(new TransferChatRoomOwnerRequest()
            {
                BaseRequest = new Protocol.Protos.BaseRequest
                {
                    ClientVersion = _Environment.Terminal.GetWeChatVersion(),
                    DeviceID = _Environment.WeChatDataId.ToByteArray(16, 2),
                    DeviceType = _Environment.WeChatOsType.ToBytes(),
                    SessionKey = _Cache.SessionKey,
                    Scene = (uint)(_Cache.Scene),
                    Uin = _Cache.Uin
                },
                ChatRoomName = chatroom,
                NewOwnerUserName = user
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_transferchatroomowner);
        }

        /// <summary>
        /// 获取群公告
        /// </summary>
        /// <param name="chatroom">群id</param>
        /// <returns></returns>
        public virtual async Task<GetChatRoomAnnouncementResponse> WXGetChatroomAnnouncement(string chatroom)
        {
            return await Request<GetChatRoomAnnouncementResponse>(new GetChatRoomAnnouncementRequest()
            {
                BaseRequest = new Protocol.Protos.BaseRequest
                {
                    ClientVersion = _Environment.Terminal.GetWeChatVersion(),
                    DeviceID = _Environment.WeChatDataId.ToByteArray(16, 2),
                    DeviceType = _Environment.WeChatOsType.ToBytes(),
                    SessionKey = _Cache.SessionKey,
                    Scene = (uint)(_Cache.Scene),
                    Uin = _Cache.Uin
                },
                ChatRoomName = chatroom
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_getchatroomannouncement);
        }

        /// <summary>
        /// 邀请群成员（40人以上）
        /// </summary>
        /// <param name="chatroom">群id</param>
        /// <param name="users">对方用户名列表</param>
        /// <returns></returns>
        public virtual async Task<InviteChatRoomMemberResponse> WXInviteChatroomMember(string chatroom, string[] users)
        {
            var members = users?.Select(item => new Protocol.Protos.MemberReq() { MemberName = new SKBuiltinString_t { String = item } })?.ToList();
            return await Request<InviteChatRoomMemberResponse>(new InviteChatRoomMemberRequest()
            {
                BaseRequest = new Protocol.Protos.BaseRequest
                {
                    ClientVersion = _Environment.Terminal.GetWeChatVersion(),
                    DeviceID = _Environment.WeChatDataId.ToByteArray(16, 2),
                    DeviceType = _Environment.WeChatOsType.ToBytes(),
                    SessionKey = _Cache.SessionKey,
                    Scene = (uint)(_Cache.Scene),
                    Uin = _Cache.Uin
                },
                ChatRoomName = new SKBuiltinString_t { String = chatroom },
                MemberCount = (uint)(members?.Count ?? 0)
            }?.CallWhen(members != null, _ => _.MemberList.AddRange(members)).SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_invitechatroommember);
        }

        /// <summary>
        /// 添加群管理
        /// </summary>
        /// <param name="chatroom">群id</param>
        /// <param name="users">对方用户名列表</param>
        /// <returns></returns>
        public virtual async Task<AddChatRoomAdminResponse> WXAddChatroomAdmin(string chatroom, string[] users)
        {
            return await Request<AddChatRoomAdminResponse>(new AddChatRoomAdminRequest()
            {
                baseRequest = new Protocol.Protos.V2.BaseRequest
                {
                    clientVersion = _Environment.Terminal.GetWeChatVersion(),
                    devicelId = _Environment.WeChatDataId.ToByteArray(16, 2),
                    osType = _Environment.WeChatOsType,
                    sessionKey = _Cache.SessionKey,
                    scene = _Cache.Scene,
                    uin = _Cache.Uin
                },
                chatRoomName = chatroom,
                userNameList = users
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_addchatroomadmin);
        }

        /// <summary>
        /// 删除群管理
        /// </summary>
        /// <param name="chatroom">群id</param>
        /// <param name="users">对方用户名列表</param>
        /// <returns></returns>
        public virtual async Task<DelChatRoomAdminResponse> WXDelChatroomAdmin(string chatroom, string[] users)
        {
            return await Request<DelChatRoomAdminResponse>(new DelChatRoomAdminRequest()
            {
                baseRequest = new Protocol.Protos.V2.BaseRequest
                {
                    clientVersion = _Environment.Terminal.GetWeChatVersion(),
                    devicelId = _Environment.WeChatDataId.ToByteArray(16, 2),
                    osType = _Environment.WeChatOsType,
                    sessionKey = _Cache.SessionKey,
                    scene = _Cache.Scene,
                    uin = _Cache.Uin
                },
                chatRoomName = chatroom,
                userNameList = users
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_delchatroomadmin);
        }

        /// <summary>
        /// 添加群成员（40人以内）
        /// </summary>
        /// <param name="chatroom">群id</param>
        /// <param name="users">对方用户名列表</param>
        /// <returns></returns>
        public virtual async Task<Protocol.Protos.V2.AddChatRoomMemberResponse> WXAddChatroomMember(string chatroom, string[] users)
        {
            return await Request<Protocol.Protos.V2.AddChatRoomMemberResponse>(new Protocol.Protos.V2.AddChatRoomMemberRequest()
            {
                baseRequest = new Protocol.Protos.V2.BaseRequest
                {
                    clientVersion = _Environment.Terminal.GetWeChatVersion(),
                    devicelId = _Environment.WeChatDataId.ToByteArray(16, 2),
                    osType = _Environment.WeChatOsType,
                    sessionKey = _Cache.SessionKey,
                    scene = _Cache.Scene,
                    uin = _Cache.Uin
                },
                chatRoomName = new SKBuiltinString { @string = chatroom },
                memberCount = (uint)(users?.Length ?? 0),
                memberList = users?.Select(u => new Protocol.Protos.V2.MemberReq { member = new SKBuiltinString { @string = u } })?.ToArray()
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_addchatroommember);
        }

        /// <summary>
        /// 删除群成员
        /// </summary>
        /// <param name="chatroom">群id</param>
        /// <param name="users">对方用户名列表</param>
        /// <returns></returns>
        public virtual async Task<Protocol.Protos.V2.DelChatRoomMemberResponse> WXDelChatroomMember(string chatroom, string[] users)
        {
            return await Request<Protocol.Protos.V2.DelChatRoomMemberResponse>(new Protocol.Protos.V2.DelChatRoomMemberRequest()
            {
                baseRequest = new Protocol.Protos.V2.BaseRequest
                {
                    clientVersion = _Environment.Terminal.GetWeChatVersion(),
                    devicelId = _Environment.WeChatDataId.ToByteArray(16, 2),
                    osType = _Environment.WeChatOsType,
                    sessionKey = _Cache.SessionKey,
                    scene = _Cache.Scene,
                    uin = _Cache.Uin
                },
                chatRoomName = chatroom,
                memberCount = (uint)(users?.Length ?? 0),
                memberList = users?.Select(u => new Protocol.Protos.V2.DelMemberReq { memberName = new SKBuiltinString { @string = u } })?.ToArray()
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_delchatroommember);
        }

        /// <summary>
        /// 获取群成员详细
        /// </summary>
        /// <param name="chatroom">群id</param>
        /// <returns></returns>
        public virtual async Task<Protocol.Protos.V2.GetChatroomMemberDetailResponse> WXGetChatroomMemberDetail(string chatroom)
        {
            return await Request<Protocol.Protos.V2.GetChatroomMemberDetailResponse>(new Protocol.Protos.V2.GetChatroomMemberDetailRequest()
            {
                baseRequest = new Protocol.Protos.V2.BaseRequest
                {
                    clientVersion = _Environment.Terminal.GetWeChatVersion(),
                    devicelId = _Environment.WeChatDataId.ToByteArray(16, 2),
                    osType = _Environment.WeChatOsType,
                    sessionKey = _Cache.SessionKey,
                    scene = _Cache.Scene,
                    uin = _Cache.Uin
                },
                clientVersion = 0,
                chatroomUserName = chatroom
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_getchatroommemberdetail);
        }

        /// <summary>
        /// 获取群信息
        /// </summary>
        /// <param name="chatroom"></param>
        /// <returns></returns>
        public virtual async Task<ChatRoomProfile[]> WXGetChatroomInfoDetail(string[] chatrooms)
        {
            #region 和谐方法
            //return await Request<Protocol.Protos.V2.GetChatRoomInfoDetailResponse>(new Protocol.Protos.V2.GetChatRoomInfoDetailRequest()
            //{
            //    baseRequest = new Protocol.Protos.V2.BaseRequest
            //    {
            //        clientVersion = _Environment.Terminal.GetWeChatVersion(),
            //        devicelId = _Environment.WeChatDataId.ToByteArray(16, 2),
            //        osType = _Environment.WeChatOsType,
            //        sessionKey = _Cache.SessionKey,
            //        scene = _Cache.Scene,
            //        uin = _Cache.Uin
            //    },
            //    chatRoomName = chatroom
            //}.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_getchatroominfodetail);
            #endregion

            var result = default(ChatRoomProfile[]);
            if ((chatrooms?.Length ?? 0) <= 0) { return null; }
            var response = await Request<BatchGetContactProfileResponse>(new BatchGetContactProfileRequest()
            {
                BaseRequest = new Protocol.Protos.BaseRequest
                {
                    ClientVersion = _Environment.Terminal.GetWeChatVersion(),
                    DeviceID = _Environment.WeChatDataId.ToByteArray(16, 2),
                    DeviceType = _Environment.WeChatOsType.ToBytes(),
                    SessionKey = _Cache.SessionKey,
                    Scene = (uint)(_Cache.Scene),
                    Uin = _Cache.Uin
                },
                Mode = 0,
                Count = (uint)(chatrooms?.Length ?? 0)
            }.CallWhen(true, _ => _.UserNameList.AddRange(chatrooms.Select(u => new SKBuiltinString_t { String = u }))).SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_batchgetcontactprofile);
            response?.CallWhen(response?.BaseResponse?.Ret == (int)(RetConst.MM_OK), _ =>
            {
                result = response?.ContactProfileBufList?.Select(item => item.Buffer.DeserializeFromProtoBuf<ChatRoomProfile>())?.ToArray();
            });
            return result;
        }

        /// <summary>
        /// 设置群公告
        /// </summary>
        /// <param name="chatroom">群id</param>
        /// <param name="context">公告内容</param>
        /// <returns></returns>
        public virtual async Task<Protocol.Protos.SetChatRoomAnnouncementResponse> WXSetChatroomAnnouncement(string chatroom, string context)
        {
            return await Request<Protocol.Protos.SetChatRoomAnnouncementResponse>(new Protocol.Protos.SetChatRoomAnnouncementRequest()
            {
                BaseRequest = new Protocol.Protos.BaseRequest
                {
                    ClientVersion = _Environment.Terminal.GetWeChatVersion(),
                    DeviceID = _Environment.WeChatDataId.ToByteArray(16, 2),
                    DeviceType = _Environment.WeChatOsType.ToBytes(),
                    SessionKey = _Cache.SessionKey,
                    Scene = (uint)(_Cache.Scene),
                    Uin = _Cache.Uin
                },
                Announcement = context,
                ChatRoomName = chatroom
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_setchatroomannouncement);
        }
    }
}
