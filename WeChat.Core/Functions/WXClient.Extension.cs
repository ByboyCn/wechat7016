using System;
using System.Threading.Tasks;
using WeChat.Core.Protocol;
using WeChat.Core.Protocol.Protos;
using WeChat.Core.Protocol.Protos.V2;

namespace WeChat.Core
{
    public partial interface IWXApp
    {
        /// <summary>
        /// 好友(群聊)操作请求:删除/保存/拉黑/恢复/设置群昵称/设置好友备注名
        /// </summary>
        /// <param name="type">操作类型</param>
        /// <param name="data">修改后的对象</param>
        /// <returns></returns>
        Task<OpLogResponse> WXOpLog(SyncCmdID type, object data);
        /// <summary>
        /// 注册/登陆短信操作
        /// </summary>
        /// <param name="opcode">操作码，获取注册滑块-12，获取注册短信-14，发送注册短信-15，获取登陆验证码-16，发送登陆验证码-17</param>
        /// <param name="phone_number">手机号码，格式如：+8618012345678</param>
        /// <param name="verify_code">验证码</param>
        /// <param name="reg">是否注册,注册-1，登陆-0</param>
        /// <param name="regsessionid">注册会话id</param>
        /// <param name="authticket">滑块票据</param>
        /// <returns></returns>
        Task<BindOpMobileForRegResponse> WXBindOpMobileForReg(int opcode, string phone_number, string verify_code, uint reg, string regsessionid, string authticket);
        /// <summary>
        /// 获取个人或群二维码
        /// </summary>
        /// <param name="username">群id，为空则返回个人二维码</param>
        /// <returns></returns>
        Task<Protocol.Protos.GetQRCodeResponse> WXGetQrcode(string username = "");
        /// <summary>
        /// 单页获取通讯录（精准获取）
        /// </summary>
        /// <param name="current_wx_contact_seq">当前通讯录请求，第一次为0</param>
        /// <param name="current_chatroom_contact_seq">当前群聊请求，第一次为0</param>
        /// <returns></returns>
        Task<InitContactResponse> WXInitContact(int current_wx_contact_seq = 0, int current_chatroom_contact_seq = 0);

    }
    /// <summary>
    /// 微信客户端扩展
    /// </summary>
    public partial class WXApp
    {
        /// <summary>
        /// 好友(群聊)操作请求:删除/保存/拉黑/恢复/设置群昵称/设置好友备注名
        /// </summary>
        /// <param name="type">操作类型</param>
        /// <param name="data">修改后的对象</param>
        /// <returns></returns>
        public virtual async Task<OpLogResponse> WXOpLog(SyncCmdID type, object data)
        {
            var target = data.SerializeToProtoBuf();
            return await Request<OpLogResponse>(new OpLogRequest()
            {
                cmd = new Protocol.Protos.V2.CmdList
                {
                    count = 1,
                    list = new Protocol.Protos.V2.CmdItem[]
                    {
                        new Protocol.Protos.V2.CmdItem {  cmdid = type, cmdBuf = new Protocol.Protos.V2.CmdItem.DATA { data = target, len = target.Length } }
                    }
                }
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_oplog);
        }

        /// <summary>
        /// 注册/登陆短信操作
        /// </summary>
        /// <param name="opcode">操作码，获取注册滑块-12，获取注册短信-14，验证注册短信-15，获取登陆验证码-16，验证登陆验证码-17</param>
        /// <param name="phone_number">手机号码，格式如：+8618012345678</param>
        /// <param name="verify_code">验证码</param>
        /// <param name="reg">是否注册,注册-1，登陆-0</param>
        /// <param name="regsessionid">注册会话id</param>
        /// <param name="authticket">滑块票据</param>
        /// <returns></returns>
        public virtual async Task<BindOpMobileForRegResponse> WXBindOpMobileForReg(int opcode, string phone_number, string verify_code, uint reg, string regsessionid, string authticket)
        {
            //var retry = 3;
            //var result = default(BindOpMobileForRegResponse);
            var request = new BindOpMobileForRegRequest()
            {
                BaseRequest = new Protocol.Protos.BaseRequest
                {
                    ClientVersion = _Environment.Terminal.GetWeChatVersion(),
                    DeviceID = _Environment.WeChatDataId.ToByteArray(16, 2),
                    DeviceType = _Environment.WeChatOsType.ToBytes(),
                    SessionKey = _Cache.SessionKey,
                    Scene = 0,
                    Uin = 0
                },
                Mobile = phone_number,
                Opcode = opcode,
                Verifycode = verify_code,
                SafeDeviceName = _Cache.Terminal == WXTerminal.ANDROID ? "Android" : "iPhone",
                SafeDeviceType = _Cache.Terminal == WXTerminal.ANDROID ? "Android" : "iPhone",
                RandomEncryKey = new SKBuiltinBuffer_t() { Buffer = _Cache.SessionKey, iLen = (uint)(_Cache.SessionKey.Length), },
                Language = "zh_CN",
                InputMobileRetrys = 0,
                AdjustRet = 0,
                ClientSeqID = _Environment.DeviceImei + "-" + ((int)DateTime.Now.ToTimeStamp()).ToString(),
                MobileCheckType = (uint)(phone_number.StartsWith("+86") ? 1 : 0), // 0国外，1国内
                regSessionId = regsessionid,
                DialFlag = 0,        //0:短信验证码1:语音验证码
                DialLang = "",       //如果为语音验证码，则设置电话语言
                ForceReg = reg,
                AuthTicket = authticket
            }.SerializeToProtoBuf();
            return await Request<BindOpMobileForRegResponse>(request, WXCGIUrl.micromsg_bin_bindopmobileforreg);
            //do
            //{
            //    result = await Request<BindOpMobileForRegResponse>(request, WXCGIUrl.micromsg_bin_bindopmobileforreg);
            //    Thread.Sleep(1000 * 2);
            //} while (result?.BaseResponse?.Ret == (int)RetConst.MM_ERR_IDC_REDIRECT && --retry > 0);
            //return result;
        }

        /// <summary>
        /// 获取个人或群二维码
        /// </summary>
        /// <param name="username">群id，为空则返回个人二维码</param>
        /// <returns></returns>
        public virtual async Task<Protocol.Protos.GetQRCodeResponse> WXGetQrcode(string username = "")
        {
            return await Request<Protocol.Protos.GetQRCodeResponse>(new Protocol.Protos.V2.GetQRCodeRequest()
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
                opcode = 0,
                style = 0,
                userName = new SKBuiltinString[] { new SKBuiltinString { @string = username.IsEmpty() ? _Profile.UserName : username } }
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_getqrcode);
        }

        /// <summary>
        /// 单页获取通讯录（精准获取）
        /// </summary>
        /// <param name="current_wx_contact_seq">当前通讯录请求，第一次为0,-1停用</param>
        /// <param name="current_chatroom_contact_seq">当前群聊请求，第一次为0,-1停用</param>
        /// <returns></returns>
        public virtual async Task<InitContactResponse> WXInitContact(int current_wx_contact_seq = 0, int current_chatroom_contact_seq = 0)
        {
            return await Request<InitContactResponse>(new InitContactRequest()
            {
                currentChatRoomContactSeq = current_chatroom_contact_seq,
                currentWxcontactSeq = current_wx_contact_seq,
                username = _Profile.UserName
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_initcontact);
        }
    }
}
