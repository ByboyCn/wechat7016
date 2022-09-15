using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeChat.Core.Protocol;
using WeChat.Core.Protocol.Protos;
using WeChat.Core.Protocol.Protos.V2;
using XMS.WeChat.Core.Libraries.WCAes;
using XMS.WeChat.Core.Versions;

namespace WeChat.Core
{
    public partial interface IWXApp
    {
        /// <summary>
        /// 好友验证(打招呼/添加好友/拒绝添加好友)
        /// </summary>
        /// <param name="type">类型，1添加好友/公众号，2打招呼验证，3同意好友添加请求，4拒绝</param>
        /// <param name="stranger_v1">对方stranger_v1字符串,公众号时则为公众号APPID</param>
        /// <param name="stranger_v2">对方stranger_v2字符串,公众号时忽略</param>
        /// <param name="scene">添加好友来源类型，1QQ，2邮箱，3微信号，14群聊，15手机号，18附近的人，25漂流瓶，29摇一摇，30二维码，13通讯录</param>
        /// <param name="verify">添加好友时的验证信息(可为空，WX自己默认首次验证就是为空，若需要验证消息则再次发送填写该参数)</param>
        /// <param name="ticket">接受好友请求的ticket,若添加好友来源为群，则指定群用户名，可为空)</param>
        /// <returns></returns>
        Task<VerifyUserResponese> WXVerifyUser(int type, string stranger_v1, string stranger_v2, byte scene, string verify, string ticket);
        /// <summary>
        /// 批量好友验证（接口版）
        /// </summary>
        /// <param name="type">类型，1添加好友/公众号，2打招呼验证，3同意好友添加请求，4拒绝</param>
        /// <param name="users">好友信息</param>
        /// <param name="scene">添加好友来源类型，1QQ，2邮箱，3微信号，14群聊，15手机号，18附近的人，25漂流瓶，29摇一摇，30二维码，13通讯录</param>
        /// <param name="verify">添加好友时的验证信息(可为空，WX自己默认首次验证就是为空，若需要验证消息则再次发送填写该参数)</param>
        /// <returns></returns>
        Task<VerifyUserResponese> WXBatchVerifyUser(int type, Protocol.Protos.V2.VerifyUser[] users, byte scene, string verify);
        /// <summary>
        /// 分页获取通讯录好友（精准获取）
        /// </summary>
        /// <param name="current_wx_contact_seq">当前通讯录请求，第一次为0</param>
        /// <returns></returns>
        Task<InitContactResponse> WXInitContactPage(int current_wx_contact_seq = 0);
        /// <summary>
        /// 获取全部通讯录好友（精准获取）
        /// </summary>
        /// <returns></returns>
        Task<List<string>> WXInitContactAll();
        /// <summary>
        /// 修改联系人标志
        /// </summary>
        /// <param name="username">联系人username</param>
        /// <param name="flag">标志：3：黑名单，6：标星，0：通讯录，9：消息免打扰，11：置顶聊天</param>
        /// <param name="enable">开关（是否启用）</param>
        /// <returns></returns>
        Task<OpLogResponse> WXSetContactFlag(string username, ushort flag, bool enable);
        /// <summary>
        /// 删除好友
        /// </summary>
        /// <param name="username">对方用户名</param>
        /// <returns></returns>
        Task<OpLogResponse> WXDeleteContact(string username);
        /// <summary>
        /// 批量删除好友
        /// </summary>
        /// <param name="username">用户名数组</param>
        /// <returns></returns>
        Task<BatchDelContact> WXBatchDeleteContact(string[] usernames);
        /// <summary>
        /// 设置用户备注
        /// </summary>
        /// <param name="username">用户id</param>
        /// <param name="remark">备注</param>
        /// <param name="description">描述</param>
        /// <returns></returns>
        Task<OpLogResponse> WXSetContactRemark(string username, string remark, string description);

        /// <summary>
        /// 拉黑联系人2
        /// </summary>
        /// <param name="ModContacts">联系人ModContacts</param>
        /// <returns></returns>
        Task<OpLogResponse> WXSetContactBlack2(Protocol.Protos.V2.ModContact ModContacts);

        /// <summary>
        /// 设置用户标签
        /// </summary>
        /// <param name="username">用户id</param>
        /// <param name="labels">标签id数组,删除标签则传入null</param>
        /// <returns></returns>
        Task<OpLogResponse> WXSetContactLabel(string username, int[] labels);
        /// <summary>
        /// 批量获取好友简介
        /// </summary>
        /// <param name="users">好友用户名列表</param>
        /// <returns></returns>
        Task<ContactProfile[]> WXBatchGetContactProfile(string[] users);
        /// <summary>
        /// 搜索联系人
        /// </summary>
        /// <param name="username">手机号，微信号，QQ号</param>
        /// <returns></returns>
        Task<Protocol.Protos.V2.SearchContactResponse> WXSearchContact(string username);
        /// <summary>
        /// 获取邀请朋友
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        Task<Protocol.Protos.V2.NewGetInviteFriendResponse> WXGetInviteFriend(uint type = 0);
        /// <summary>
        /// 获取联系人详情
        /// </summary>
        /// <param name="users">用户列表</param>
        /// <returns></returns>
        Task<Protocol.Protos.V2.GetContactResponse> WXGetContact(string[] users);
        /// <summary>
        /// 获取联系人状态[僵尸粉]
        /// -1未知,0好基友,1非好友,2删对方(对方还有自己),3被删除,4相互删,5被拉黑,6被封号
        /// </summary>
        /// <param name="users">用户列表</param>
        /// <returns></returns>
        Task<Dictionary<string, int>> WXGetContactStatus(string[] users);
        /// <summary>
        /// 批量获取用户头像
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        Task<Protocol.Protos.BatchGetHeadImgResponse> WXBatchGetContactHeadImage(string[] users);
        /// <summary>
        /// 获取手机朋友列表
        /// </summary>
        /// <param name="md5">上一次同步的md5值，首次传空</param>
        /// <param name="optype">操作类型</param>
        /// <returns></returns>
        Task<Protocol.Protos.GetMFriendResponse> WXGetMFriend(string md5 = "", uint optype = 0);
        /// <summary>
        /// 上传手机联系人
        /// </summary>
        /// <param name="mobile">当前手机号码</param>
        /// <param name="phones">通讯录手机号列表</param>
        /// <returns></returns>
        Task<Protocol.Protos.UploadMContactResponse> WXUploadMContact(string mobile, string[] phones);
    }
    public partial class WXApp
    {
        /// <summary>
        /// 好友验证(打招呼/添加好友/关注公众号/拒绝添加好友)
        /// </summary>
        /// <param name="type">类型，1添加好友/公众号，2打招呼验证，3同意好友添加请求，4拒绝</param>
        /// <param name="stranger_v1">对方stranger_v1字符串,公众号时则为公众号APPID</param>
        /// <param name="stranger_v2">对方stranger_v2字符串,公众号时忽略</param>
        /// <param name="scene">添加好友来源类型，1QQ，2邮箱，3微信号，14群聊，15手机号，18附近的人，25漂流瓶，29摇一摇，30二维码，13通讯录</param>
        /// <param name="verify">添加好友时的验证信息(可为空，WX自己默认首次验证就是为空，若需要验证消息则再次发送填写该参数)</param>
        /// <param name="ticket">接受好友请求的ticket,若添加好友来源为群，则指定群用户名，可为空)</param>
        /// <returns></returns>
        public virtual async Task<VerifyUserResponese> WXVerifyUser(int type, string stranger_v1, string stranger_v2, byte scene, string verify, string ticket)
        {
            var ccd = CheckClientData.GetNewSpamData(_Environment.WeChatDataId, _Environment.WeChatOsType, _Environment.Device.Model, _Environment.Device.CpuCore,
                _Environment.Device.IPhoneVersion, _Environment.DeviceName, _8026.PlistVersion, _Environment.WeChatOsType, _8026.PlistVersion,
               _8026.Md5OfMachoHeader, _8026.AppUUID, _8026.InstallTimes, _Environment.DeviceImei, _Cache.DeviceToken, _8026.StrVersion,
               _Cache.SoftConfig, _Cache.SoftData);
            var extspam = new WCExtInfo
            {
                CcData = new SKBuiltinString_ { buffer = ccd, iLen = (uint)(ccd.Length) }
            }.SerializeToProtoBuf();
            return await Request<VerifyUserResponese>(new Protocol.Protos.V2.VerifyUserRequest()
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
                opcode = (VerifyUserOpCode)type,
                sceneList = new byte[] { scene },
                SceneListNumFieldNumber = 1,
                verifyContent = verify,
                verifyUserListSize = 1,
                verifyUserList = new Protocol.Protos.V2.VerifyUser[]
                {
                    new Protocol.Protos.V2.VerifyUser
                    {
                         value = stranger_v1,
                         antispamTicket = stranger_v2,
                         friendFlag = 0,
                         scanQrcodeFromScene = 0,
                         verifyUserTicket = stranger_v2,
                         chatRoomUserName = ticket
                    }
                },
                extSpamInfo = new SKBuiltinString_ { buffer = extspam, iLen = (uint)(extspam.Length) },
                needConfirm = 1
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_verifyuser);
        }

        /// <summary>
        /// 拉黑联系人2
        /// </summary>
        /// <param name="username">联系人username</param>
        /// <param name="flag">标志：3：黑名单，6：标星，0：通讯录，9：消息免打扰，11：置顶聊天</param>
        /// <param name="enable">开关（是否启用）</param>
        /// <returns></returns>
        public virtual async Task<OpLogResponse> WXSetContactBlack2(Protocol.Protos.V2.ModContact ModContacts)
        {
            var result = await WXOpLog(SyncCmdID.CmdIdModContact, ModContacts);
            return result;
        }

        /// <summary>
        /// 批量好友验证（接口版）
        /// </summary>
        /// <param name="type">类型，1添加好友/公众号，2打招呼验证，3同意好友添加请求，4拒绝</param>
        /// <param name="users">好友信息</param>
        /// <param name="scene">添加好友来源类型，1QQ，2邮箱，3微信号，14群聊，15手机号，18附近的人，25漂流瓶，29摇一摇，30二维码，13通讯录</param>
        /// <param name="verify">添加好友时的验证信息(可为空，WX自己默认首次验证就是为空，若需要验证消息则再次发送填写该参数)</param>
        /// <returns></returns>
        public virtual async Task<VerifyUserResponese> WXBatchVerifyUser(int type, Protocol.Protos.V2.VerifyUser[] users, byte scene, string verify)
        {
            var result = default(VerifyUserResponese);
            if (users == null || users.Length <= 0) { return result; }
            return await Request<VerifyUserResponese>(new Protocol.Protos.V2.VerifyUserRequest()
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
                opcode = (VerifyUserOpCode)type,
                sceneList = new byte[] { scene },
                SceneListNumFieldNumber = 1,
                verifyContent = verify,
                verifyUserList = users,
                verifyUserListSize = (uint)(users?.Length ?? 0)
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_verifyuser);
        }

        /// <summary>
        /// 分页获取通讯录好友（精准获取）
        /// </summary>
        /// <param name="current_wx_contact_seq">当前通讯录请求，第一次为0</param>
        /// <returns></returns>
        public virtual async Task<InitContactResponse> WXInitContactPage(int current_wx_contact_seq = 0)
        {
            var response = await WXInitContact(current_wx_contact_seq, -1);
            var result = new List<string>();
            //筛选用户
            foreach (var item in response?.contactUsernameList)
            {
                if (WXContact.ISUser(item))
                {
                    result.Add(item);
                }
            }
            if (response?.contactUsernameList != null)
            {
                response.contactUsernameList = result.ToArray();
            }
            return response;
        }

        /// <summary>
        /// 获取全部通讯录好友（精准获取）
        /// </summary>
        /// <returns></returns>
        public virtual async Task<List<string>> WXInitContactAll()
        {
            int current_wx_contact_seq = 0;
            var tmep = new List<string>();
            var result = new List<string>();
            while (true)
            {
                var response = await WXInitContact(current_wx_contact_seq, -1);
                if (response == null || response.baseResponse.ret != RetConst.MM_OK)
                {
                    break;
                }
                if (response?.contactUsernameList?.Length > 0)
                {
                    tmep.AddRange(response.contactUsernameList);
                    if (response?.contactUsernameList?.Length < 100 || current_wx_contact_seq == response.currentWxcontactSeq)
                    {
                        break;
                    }
                    current_wx_contact_seq = response.currentWxcontactSeq;
                }
                else
                {
                    break;
                }
            }
            //筛选用户
            foreach (var item in tmep)
            {
                if (WXContact.ISUser(item))
                {
                    result.Add(item);
                }
            }
            return result.Distinct().ToList();
        }

        /// <summary>
        /// 修改联系人标志
        /// </summary>
        /// <param name="username">联系人username</param>
        /// <param name="flag">标志：3：黑名单，6：标星，0：通讯录，9：消息免打扰，11：置顶聊天</param>
        /// <param name="enable">开关（是否启用）</param>
        /// <returns></returns>
        public virtual async Task<OpLogResponse> WXSetContactFlag(string username, ushort flag, bool enable)
        {
            var result = default(OpLogResponse);
            var response = await WXGetContact(new string[] { username });
            response?.CallWhen(response?.baseResponse?.ret == RetConst.MM_OK, async _ =>
            {
                var contact = response.contactList[0];
                if (flag == 3)
                {
                    if (enable)
                    {
                        contact.bitVal = 8;
                        contact.bitMask = 4294967295;
                    }
                    else
                    {
                        contact.bitVal = 0;
                    }
                }
                else
                {
                    if (enable) { contact.bitVal |= (uint)(1 << flag); } else { contact.bitVal &= ~(uint)(1 << flag); }
                }
                result = await WXOpLog(SyncCmdID.CmdIdModContact, contact);
            });
            return result;
        }

        /// <summary>
        /// 删除好友
        /// </summary>
        /// <param name="username">对方用户名</param>
        /// <returns></returns>
        public virtual async Task<OpLogResponse> WXDeleteContact(string username)
        {
            return await WXOpLog(SyncCmdID.CmdIdDelContact, new Protocol.Protos.V2.DelContact() { deleteContactScene = 0, userName = new SKBuiltinString { @string = username } });
        }

        /// <summary>
        /// 批量删除好友
        /// </summary>
        /// <param name="username">用户名数组</param>
        /// <returns></returns>
        public virtual async Task<BatchDelContact> WXBatchDeleteContact(string[] usernames)
        {
            List<string> success = new List<string>();
            List<string> error = new List<string>();
            foreach (var username in usernames)
            {
                var response = await WXOpLog(SyncCmdID.CmdIdDelContact, new Protocol.Protos.V2.DelContact() { deleteContactScene = 0, userName = new SKBuiltinString { @string = username } });
                if (response == null || response.ret != 0 || response.oplogRet.count != 1)
                {
                    error.Add(username);
                }
                else
                {
                    success.Add(username);
                }
            }
            return new BatchDelContact()
            {
                successCount = success.Count,
                errorCount = error.Count,
                successList = success.ToArray(),
                errorList = error.ToArray()
            };
        }

        /// <summary>
        /// 设置用户备注
        /// </summary>
        /// <param name="username">用户id</param>
        /// <param name="remark">备注</param>
        /// <param name="description">描述</param>
        /// <returns></returns>
        public virtual async Task<OpLogResponse> WXSetContactRemark(string username, string remark, string description)
        {
            var result = default(OpLogResponse);
            var response = await WXGetContact(new string[] { username });
            response?.CallWhen(response?.baseResponse?.ret == RetConst.MM_OK, async _ =>
            {
                var contact = response.contactList[0];
                contact.description = description;
                contact.remark = new SKBuiltinString { @string = remark };
                result = await WXOpLog(SyncCmdID.CmdIdModContact, contact);
            });
            return result;
        }

        /// <summary>
        /// 设置用户标签
        /// </summary>
        /// <param name="username">用户id</param>
        /// <param name="labels">标签id数组,删除标签则传入null</param>
        /// <returns></returns>
        public virtual async Task<OpLogResponse> WXSetContactLabel(string username, int[] labels)
        {
            var result = default(OpLogResponse);
            var response = await WXGetContact(new string[] { username });
            response?.CallWhen(response?.baseResponse?.ret == RetConst.MM_OK, async _ =>
            {
                var contact = response.contactList[0];
                contact.labelIDList = ((labels?.Length ?? 0) > 0 ? string.Join(",", labels) : "");
                result = await WXOpLog(SyncCmdID.CmdIdModContact, contact);
            });
            return result;
        }

        /// <summary>
        /// 批量获取好友简介
        /// </summary>
        /// <param name="users">好友用户名列表</param>
        /// <returns></returns>
        public virtual async Task<ContactProfile[]> WXBatchGetContactProfile(string[] users)
        {
            var result = default(ContactProfile[]);
            if ((users?.Length ?? 0) <= 0) { return null; }
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
                Count = (uint)(users?.Length ?? 0)
            }.CallWhen(true, _ => _.UserNameList.AddRange(users.Select(u => new SKBuiltinString_t { String = u }))).SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_batchgetcontactprofile);
            response?.CallWhen(response?.BaseResponse?.Ret == (int)(RetConst.MM_OK), _ =>
            {
                result = response?.ContactProfileBufList?.Select(item => item.Buffer.DeserializeFromProtoBuf<ContactProfile>())?.ToArray();
            });
            return result;
        }

        /// <summary>
        /// 搜索联系人
        /// </summary>
        /// <param name="username">手机号，微信号，QQ号</param>
        /// <returns></returns>
        public virtual async Task<Protocol.Protos.V2.SearchContactResponse> WXSearchContact(string username)
        {
            return await Request<Protocol.Protos.V2.SearchContactResponse>(new Protocol.Protos.V2.SearchContactRequest()
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
                searchScene = 1,
                opCode = 0,
                fromScene = 1,
                userName = new SKBuiltinString { @string = username }
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_searchcontact);
        }

        /// <summary>
        /// 获取邀请朋友
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public virtual async Task<Protocol.Protos.V2.NewGetInviteFriendResponse> WXGetInviteFriend(uint type = 0)
        {
            return await Request<Protocol.Protos.V2.NewGetInviteFriendResponse>(new Protocol.Protos.V2.NewGetInviteFriendRequest()
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
                friendType = type
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_newgetinvitefriend);
        }

        /// <summary>
        /// 获取联系人详情
        /// </summary>
        /// <param name="users">用户列表</param>
        /// <returns></returns>
        public virtual async Task<Protocol.Protos.V2.GetContactResponse> WXGetContact(string[] users)
        {
            return await Request<Protocol.Protos.V2.GetContactResponse>(new Protocol.Protos.V2.GetContactRequest()
            {
                baseRequest = new Protocol.Protos.V2.BaseRequest
                {
                    clientVersion = _Environment.Terminal.GetWeChatVersion(),
                    devicelId = _Environment.WeChatDataId.ToByteArray(16, 2),
                    osType = _Environment.WeChatOsType,
                    sessionKey = _Cache.SessionKey,
                    scene = _Cache.Scene,
                    uin = _Cache.Uin
                }
            }.CallWhen((users?.Length ?? 0) > 0, _ =>
            {
                _.userNameList = users.Select(u => new SKBuiltinString { @string = u }).ToArray();
                _.userCount = (uint)(users?.Length ?? 0);
            }).SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_getcontact);
        }

        /// <summary>
        /// 获取联系人状态[僵尸粉]
        /// -1未知,0好基友,1非好友,2删对方(对方还有自己),3被删除,4相互删,5被拉黑,6被封号
        /// </summary>
        /// <param name="users">用户列表</param>
        /// <returns></returns>
        public virtual async Task<Dictionary<string, int>> WXGetContactStatus(string[] users)
        {
            var status = new Dictionary<string, int>();
            var response = await WXGetContact(users);
            if (response?.baseResponse?.ret == Core.Protocol.Protos.V2.RetConst.MM_OK)
            {
                for (int i = 0; i < response.contactCount; i++)
                {
                    if (!WXContact.ISUser(response.contactList[i].userName.@string))
                    {
                        continue;
                    }
                    int value = -1;
                    var user = response.contactList[i];
                    if (user.bitVal == 0)
                    {
                        value = 1;
                        if (user.bitMask != 0)
                        {
                            value = response.ticket[i].antispamticket.IsEmpty() ? 4 : 2;
                        }
                    }
                    else
                    {
                        value = 5;
                        if (!user.bigHeadImgUrl.IsEmpty())
                        {
                            if (response.ticket[i].antispamticket.IsEmpty())
                            {
                                value = 0;
                                var pay = await WXCreatePreTransfer(response.contactList[i].userName.@string, 1, "test");
                                if (pay != null && pay.baseResponse.ret == Core.Protocol.Protos.V2.RetConst.MM_OK && pay.tenpayErrMsg != null)
                                {
                                    if (pay.tenpayErrMsg.Contains("不是收款方好友"))
                                    {
                                        value = 1;
                                    }
                                    else if (pay.tenpayErrMsg.Contains("限制登录"))
                                    {
                                        value = 6;
                                    }
                                }
                            }
                            else
                            {
                                value = 3;
                            }
                        }
                    }
                    status.Add(response.contactList[i].userName.@string, value);
                }
            }
            return status;
        }

        /// <summary>
        /// 批量获取用户头像
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public virtual async Task<Protocol.Protos.BatchGetHeadImgResponse> WXBatchGetContactHeadImage(string[] users)
        {
            var result = default(Protocol.Protos.BatchGetHeadImgResponse);
            if ((users?.Length ?? 0) <= 0) { return result; }
            return await Request<Protocol.Protos.BatchGetHeadImgResponse>(new Protocol.Protos.BatchGetHeadImgRequest()
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
                Count = (uint)(users?.Length ?? 0)
            }.CallWhen(true, _ => _.UserNameList.AddRange(users?.Select(u => new SKBuiltinString_t { String = u }))).SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_batchgetheadimg);
        }

        /// <summary>
        /// 获取手机朋友列表
        /// </summary>
        /// <param name="md5">上一次同步的md5值，首次传空</param>
        /// <param name="optype">操作类型</param>
        /// <returns></returns>
        public virtual async Task<Protocol.Protos.GetMFriendResponse> WXGetMFriend(string md5 = "", uint optype = 0)
        {
            return await Request<Protocol.Protos.GetMFriendResponse>(new Protocol.Protos.GetMFriendRequest()
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
                OpType = optype,
                MD5 = md5 ?? ""
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_getmfriend);
        }

        /// <summary>
        /// 上传手机联系人
        /// </summary>
        /// <param name="mobile">当前手机号码</param>
        /// <param name="phones">通讯录手机号列表</param>
        /// <returns></returns>
        public virtual async Task<Protocol.Protos.UploadMContactResponse> WXUploadMContact(string mobile, string[] phones)
        {
            var mobiles = phones?.Select(m => new Protocol.Protos.Mobile() { v = m })?.ToArray();
            return await Request<Protocol.Protos.UploadMContactResponse>(new Protocol.Protos.UploadMContactRequest()
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
                Opcode = 1,
                UserName = _Profile.UserName,
                Mobile = mobile
            }.CallWhen((mobiles?.Length ?? 0) > 0, _ =>
            {
                _.MobileList.AddRange(mobiles);
                _.MobileListSize = mobiles.Length;
            }).SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_uploadmcontact);
        }
    }
}
