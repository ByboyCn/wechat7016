using System;
using System.Threading.Tasks;
using WeChat.Core.Protocol;
using WeChat.Core.Protocol.Protos;

namespace WeChat.Core
{
    public partial interface IWXApp
    {
        /// <summary>
        /// 获取注册滑块
        /// </summary>
        /// <param name="phone_number">手机号码,格式+8613666666666</param>
        /// <returns></returns>
        Task<BindOpMobileForRegResponse> WXSlideRegisterVerifyCode(string phone_number);
        /// <summary>
        /// 获取注册验证码
        /// </summary>
        /// <param name="phone_number">手机号码,格式+8613666666666</param>
        /// <param name="authticket">滑块票据</param>
        /// <returns></returns>
        Task<BindOpMobileForRegResponse> WXGetRegisterVerifyCode(string phone_number, string authticket);
        /// <summary>
        /// 校验注册验证码
        /// </summary>
        /// <param name="phone_number">手机号码,格式+8613666666666</param>
        /// <param name="verify_code">验证码</param>
        /// <param name="regsessionid">会话id</param>
        /// <param name="authticket">滑块票据</param>
        /// <returns></returns>
        Task<BindOpMobileForRegResponse> WXCheckRegisterVerifyCode(string phone_number, string verify_code, string regsessionid, string authticket);
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="phone_number">手机号码,格式+8613666666666</param>
        /// <param name="nick_name">昵称</param>
        /// <param name="password">密码明文</param>
        /// <param name="ticket">票据，由<see cref="WXSendRegisterVerifyCode(string, string, string, string)"/>返回</param>
        /// <returns></returns>
        Task<NewRegResponse> WXRegister(string phone_number, string nick_name, string password, string ticket);
    }
    public partial class WXApp
    {
        /// <summary>
        /// 获取注册滑块
        /// </summary>
        /// <param name="phone_number">手机号码,格式+8613666666666</param>
        /// <returns></returns>
        public virtual async Task<BindOpMobileForRegResponse> WXSlideRegisterVerifyCode(string phone_number)
        {
            return await WXBindOpMobileForReg(12, phone_number, "", 1, "", "");
        }

        /// <summary>
        /// 获取注册验证码
        /// </summary>
        /// <param name="phone_number">手机号码,格式+8613666666666</param>
        /// <param name="authticket">滑块票据</param>
        /// <returns></returns>
        public virtual async Task<BindOpMobileForRegResponse> WXGetRegisterVerifyCode(string phone_number, string authticket)
        {
            return await WXBindOpMobileForReg(14, phone_number, "", 1, "", authticket);
        }

        /// <summary>
        /// 校验注册验证码
        /// </summary>
        /// <param name="phone_number">手机号码,格式+8613666666666</param>
        /// <param name="verify_code">验证码</param>
        /// <param name="regsessionid">会话id</param>
        /// <param name="authticket">滑块票据</param>
        /// <returns></returns>
        public virtual async Task<BindOpMobileForRegResponse> WXCheckRegisterVerifyCode(string phone_number, string verify_code, string regsessionid, string authticket)
        {
            return await WXBindOpMobileForReg(15, phone_number, verify_code, 1, regsessionid, authticket);
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="phone_number">手机号码,格式+8613666666666</param>
        /// <param name="nick_name">昵称</param>
        /// <param name="password">密码明文</param>
        /// <param name="ticket">票据，由<see cref="WXSendRegisterVerifyCode(string, string, string, string)"/>返回</param>
        /// <returns></returns>
        public virtual async Task<NewRegResponse> WXRegister(string phone_number, string nick_name, string password, string ticket)
        {
            var ecdh = new ECKeyPair(Curve.SecP224r1);
            return await Request<NewRegResponse>(new NewRegRequest()
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
                RandomEncryKey = new SKBuiltinBuffer_t { Buffer = _Cache.SessionKey, iLen = (uint)(_Cache.SessionKey.Length) },
                CliPubECDHKey = new ECDHKey { Key = new SKBuiltinBuffer_t { Buffer = ecdh.PublicKey, iLen = (uint)ecdh.PublicKey.Length }, Nid = 713 },
                ClientSeqID = _Environment.DeviceImei + "-" + ((int)DateTime.Now.ToTimeStamp()).ToString(),
                ClientFingerprint = _Environment.WeChatXmlInfo,
                BundleID = _Environment.WeChatBundleId,
                AndroidID = _Environment.DeviceImei,
                MacAddr = _Environment.DeviceMac,
                BindMobile = phone_number,
                Ticket = ticket,
                NickName = nick_name,
                Pwd = password.MD5(),
                Language = "zh_CN",
                ForceReg = 1,
                UserName = "",
                BindUin = 0,
                GoogleAid = "",
                DLSrc = 0,
                BuiltinIPSeq = 0,
                BindEmail = "",
                RegMode = 1,
                TimeZone = "8.00",
                AndroidInstallRef = "",
                Alias = "",
                RealCountry = "CN",
                VerifyContent = "",
                VerifySignature = "",
                HasHeadImg = 0,
                SuggestRet = 0
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_newreg);
        }
    }
}
