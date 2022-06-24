using System;
using System.IO;
using System.Threading.Tasks;
using WeChat.Core.Protocol;
using WeChat.Core.Protocol.Protos;
using WeChat.Core.Protocol.Protos.V2;

namespace WeChat.Core
{
    public partial interface IWXApp
    {
        /// <summary>
        /// 绑定/解绑手机号
        /// </summary>
        /// <param name="opcode">操作码,1：获取验证码，2：绑定手机号，3：解绑手机号</param>
        /// <param name="phone_number">手机号码</param>
        /// <param name="verify_code">验证码</param>
        /// <returns></returns>
        Task<BindOpMobileResponse> WXBindMobile(int opcode, string phone_number, string verify_code = "");
        /// <summary>
        /// 绑定/解绑邮箱
        /// </summary>
        /// <param name="opcode">操作码，绑定：1，解绑：2</param>
        /// <param name="email">邮箱账号</param>
        /// <returns></returns>
        Task<BindEmailResponse> WXBindEmail(uint opcode, string email);
        /// <summary>
        /// 验证密码
        /// </summary>
        /// <param name="password">密码明文</param>
        /// <returns></returns>
        Task<NewVerifyPasswdResponse> WXVerifyPassword(string password);
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="password">密码</param>
        /// <param name="ticket">票据，由<see cref="WXVerifyPassword"/>返回</param>
        /// <returns></returns>
        Task<NewSetPasswdResponse> WXSetPassword(string password, string ticket);
        /// <summary>
        /// 一键修改密码
        /// </summary>
        /// <param name="oldpassword">旧密码</param>
        /// <param name="newpassword">新密码</param>
        /// <returns></returns>
        Task<NewSetPasswdResponse> WXOnceSetPassword(string oldpassword, string newpassword);
        /// <summary>
        /// 上传头像
        /// </summary>
        /// <param name="data">图片文件数据</param>
        /// <returns></returns>
        Task<UploadHDHeadImgResponse> WXUploadHeadImage(byte[] data);
        /// <summary>
        /// 删除安全设备
        /// </summary>
        /// <param name="uuid">安全设备UUID</param>
        /// <returns></returns>
        Task<DelSafeDeviceResponse> WXDelSafeDevice(string uuid);
        /// <summary>
        /// 好友验证方式
        /// 4：加我为朋友是需要验证(1开启，2关闭)
        /// 7：向我推荐通讯录朋友（1关闭，2开启）
        /// 8：允许手机号找到我（1关闭，2开启）
        /// 25：允许微信号找到我（1关闭，2开启）
        /// 38：允许群聊添加我（1关闭，2开启）
        /// 39：允许我的二维码添加我（1关闭，2开启）
        /// 40：允许名片添加我（1关闭，2开启）
        /// </summary>
        /// <param name="function"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        Task<OpLogResponse> WXFunctionSwitch(uint function, uint value);
        /// <summary>
        /// 设置用户信息
        /// </summary>
        /// <param name="nickname">昵称</param>
        /// <param name="sex">性别</param>
        /// <param name="signature">签名</param>
        /// <param name="country">国家</param>
        /// <param name="province">省份</param>
        /// <param name="city">城市</param>
        /// <returns></returns>
        Task<OpLogResponse> WXSetUserInfo(string nickname, int sex, string signature, string country, string province, string city);
        /// <summary>
        /// 通用设置
        /// </summary>
        /// <param name="type">1：设置微信号</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        Task<GeneralSetResponse> WXGeneralSet(int type, string value);
        /// <summary>
        /// 获取个人二维码
        /// </summary>
        /// <returns></returns>
        Task<Protocol.Protos.GetQRCodeResponse> WXGetUserQrcode();
        /// <summary>
        /// 获取个人资料
        /// </summary>
        /// <returns></returns>
        Task<Protocol.Protos.V2.GetProfileResponse> WXGetProfile();
        /// <summary>
        /// 个人信息验证（身份证）
        /// </summary>
        /// <param name="realname">真实姓名</param>
        /// <param name="cardtype">证件类型</param>
        /// <param name="cardnumber">证件号码</param>
        /// <returns></returns>
        Task<VerifyPersonalInfoResp> WXVerifyPersonalInfo(string realname, uint cardtype, string cardnumber);
        /// <summary>
        /// 获取安全设备信息
        /// </summary>
        /// <returns></returns>
        Task<GetSafetyInfoRespsonse> WXGetSafetyInfo();
        /// <summary>
        /// 修改安全设备信息
        /// </summary>
        /// <returns></returns>
        Task<UpdateSafeDeviceResponse> WXUpdateSafeDevice();
    }
    public partial class WXApp
    {
        /// <summary>
        /// 绑定/解绑手机号
        /// </summary>
        /// <param name="opcode">操作码,1：获取验证码，2：绑定手机号，3：解绑手机号</param>
        /// <param name="phone_number">手机号码,国外号请带上完整前缀（如+1）</param>
        /// <param name="verify_code">验证码</param>
        /// <returns></returns>
        public virtual async Task<BindOpMobileResponse> WXBindMobile(int opcode, string phone_number, string verify_code = "")
        {
            return await Request<BindOpMobileResponse>(new BindOpMobileRequest()
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
                UserName = _Profile.UserName,
                Mobile = phone_number,
                Opcode = opcode,
                Verifycode = (opcode == 1 ? "" : verify_code),
                SafeDeviceName = "iPad",
                SafeDeviceType = "iPad",
                DialFlag = 0,
                ClientSeqID = _Environment.DeviceImei + "-" + (DateTime.Now.ToTimeStamp()).ToString(),
                Language = "zh_CN",
                RandomEncryKey = new SKBuiltinBuffer_t() { Buffer = new Random().NextBytes(16), iLen = 16U }
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_bindopmobile);
        }

        /// <summary>
        /// 绑定/解绑邮箱
        /// </summary>
        /// <param name="opcode">操作码，绑定：1，解绑：2</param>
        /// <param name="email">邮箱账号</param>
        /// <returns></returns>
        public virtual async Task<BindEmailResponse> WXBindEmail(uint opcode, string email)
        {
            return await Request<BindEmailResponse>(new BindEmailRequest()
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
                Email = email,
                OpCode = opcode
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_bindemail);
        }

        /// <summary>
        /// 验证密码
        /// </summary>
        /// <param name="password">密码明文</param>
        /// <returns></returns>
        public virtual async Task<NewVerifyPasswdResponse> WXVerifyPassword(string password)
        {
            return await Request<NewVerifyPasswdResponse>(new NewVerifyPasswdRequest()
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
                Pwd1 = password.MD5(),
                Pwd2 = password.MD5(),
                OpCode = 1
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_newverifypasswd);
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="password">密码</param>
        /// <param name="ticket">票据，由<see cref="WXVerifyPassword"/>返回</param>
        /// <returns></returns>
        public virtual async Task<NewSetPasswdResponse> WXSetPassword(string password, string ticket)
        {
            var result = await Request<NewSetPasswdResponse>(new SetPwdRequest()
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
                AutoAuthKey = new SKBuiltinBuffer_t { Buffer = _Cache.AutoAuthToken, iLen = (uint)(_Cache.AutoAuthToken.Length) },
                Password = password.MD5(),
                Ticket = ticket
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_newsetpasswd);
            result?.CallWhen(result?.BaseResponse?.Ret == (int)(RetConst.MM_OK), _ =>
            {
                _Profile.Password = password;
                _Profile.PasswordMd5 = password.MD5();
            });
            return result;
        }

        /// <summary>
        /// 一键修改密码
        /// </summary>
        /// <param name="oldpassword">旧密码</param>
        /// <param name="newpassword">新密码</param>
        /// <returns></returns>
        public virtual async Task<NewSetPasswdResponse> WXOnceSetPassword(string oldpassword, string newpassword)
        {
            if (!TestProxy(WXCGIUrl.micromsg_bin_newverifypasswd))
            {
                return new NewSetPasswdResponse() { BaseResponse = new Protocol.Protos.BaseResponse() { Ret = 408, ErrMsg = new SKBuiltinString_t() { String = "代理超时" } } };
            }
            var verify = await WXVerifyPassword(oldpassword);
            if (verify?.BaseResponse?.Ret != (int)RetConst.MM_OK || (verify?.Ticket?.Length ?? 0) <= 0)
            {
                string errMsg = "验证密码失败";
                if (!string.IsNullOrEmpty(verify?.BaseResponse?.ErrMsg?.String))
                {
                    errMsg = verify.BaseResponse.ErrMsg.String.Between("<Content><![CDATA[", "]]></Content>");
                }
                return new NewSetPasswdResponse() { BaseResponse = new Protocol.Protos.BaseResponse() { Ret = verify?.BaseResponse?.Ret ?? -1, ErrMsg = new SKBuiltinString_t() { String = errMsg } } };
            }
            var set = await WXSetPassword(newpassword, verify?.Ticket);
            if (set?.BaseResponse?.Ret != (int)RetConst.MM_OK || (set?.AutoAuthKey?.iLen ?? 0) <= 0)
            {
                string errMsg = "修改密码失败";
                if (!string.IsNullOrEmpty(set?.BaseResponse?.ErrMsg?.String))
                {
                    errMsg = verify.BaseResponse.ErrMsg.String.Between("<Content><![CDATA[", "]]></Content>");
                }
                set = new NewSetPasswdResponse() { BaseResponse = new Protocol.Protos.BaseResponse() { Ret = set?.BaseResponse?.Ret ?? -2, ErrMsg = new SKBuiltinString_t() { String = errMsg } } };
            }
            return set;
        }

        /// <summary>
        /// 上传头像
        /// </summary>
        /// <param name="data">图片文件数据</param>
        /// <returns></returns>
        public virtual async Task<UploadHDHeadImgResponse> WXUploadHeadImage(byte[] data)
        {
            var result = default(UploadHDHeadImgResponse);
            if ((data?.Length ?? 0) <= 0) { return result; }
            var hash = data.MD5().ToString(16, 2);
            var offset = 0; var stream = new MemoryStream(data);
            do
            {
                var count = Math.Min(50000, data.Length - offset);
                var content = new byte[count];
                stream.Seek(offset, SeekOrigin.Begin);
                stream.Read(content, 0, count);
                result = await Request<UploadHDHeadImgResponse>(new UploadHDHeadImgRequest()
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
                    HeadImgType = 1,
                    ImgHash = hash,
                    Data = new SKBuiltinBuffer_t { Buffer = content, iLen = (uint)content.Length },
                    UserName = _Profile.UserName,
                    TotalLen = (uint)data.Length,
                    StartPos = (uint)offset
                }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_uploadhdheadimg);
                offset += count;
            } while (result?.BaseResponse?.Ret == (int)(RetConst.MM_OK) && offset < data.Length);
            return result;
        }

        /// <summary>
        /// 好友验证方式
        /// 4：加我为朋友是需要验证(1开启，2关闭)
        /// 7：向我推荐通讯录朋友（1关闭，2开启）
        /// 8：允许手机号找到我（1关闭，2开启）
        /// 25：允许微信号找到我（1关闭，2开启）
        /// 38：允许群聊添加我（1关闭，2开启）
        /// 39：允许我的二维码添加我（1关闭，2开启）
        /// 40：允许名片添加我（1关闭，2开启）
        /// </summary>
        /// <param name="function"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual async Task<OpLogResponse> WXFunctionSwitch(uint function, uint value)
        {
            return await WXOpLog(SyncCmdID.CmdIdFunctionSwitch, new Protocol.Protos.V2.FunctionSwitch() { functionId = function, switchValue = value });
        }

        /// <summary>
        /// 设置用户信息
        /// </summary>
        /// <param name="nickname">昵称</param>
        /// <param name="sex">性别</param>
        /// <param name="signature">签名</param>
        /// <param name="country">国家</param>
        /// <param name="province">省份</param>
        /// <param name="city">城市</param>
        /// <returns></returns>
        public virtual async Task<OpLogResponse> WXSetUserInfo(string nickname, int sex, string signature, string country, string province, string city)
        {
            var result = default(OpLogResponse);
            var profile = await WXGetProfile();
            profile?.CallWhen(profile?.baseResponse?.ret == RetConst.MM_OK, async _ =>
            {
                var user = profile.userInfo;
                user.sex = sex;
                user?.CallWhen(nickname != null, _ => _.nickName = new SKBuiltinString { @string = nickname });
                user?.CallWhen(signature != null, _ => _.signature = signature);
                user?.CallWhen(country != null, _ => _.country = country);
                user?.CallWhen(province != null, _ => _.province = province);
                user?.CallWhen(city != null, _ => _.city = city);
                result = await WXOpLog(SyncCmdID.CmdIdModUserInfo, user);
            });
            return result;
        }

        /// <summary>
        /// 通用设置
        /// </summary>
        /// <param name="type">1：设置微信号</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public virtual async Task<GeneralSetResponse> WXGeneralSet(int type, string value)
        {
            return await Request<GeneralSetResponse>(new GeneralSetRequest()
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
                SetType = type,
                SetValue = value
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_generalset);
        }

        /// <summary>
        /// 获取个人二维码
        /// </summary>
        /// <param name="username">群id，为空则返回个人二维码</param>
        /// <returns></returns>
        public virtual async Task<Protocol.Protos.GetQRCodeResponse> WXGetUserQrcode()
        {
            return await WXGetQrcode(Profile.UserName);
        }

        /// <summary>
        /// 获取个人资料
        /// </summary>
        /// <returns></returns>
        public virtual async Task<Protocol.Protos.V2.GetProfileResponse> WXGetProfile()
        {
            return await Request<Protocol.Protos.V2.GetProfileResponse>(new Protocol.Protos.V2.GetProfileRequest()
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
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_getprofile);
        }

        /// <summary>
        /// 个人信息验证（身份证）
        /// </summary>
        /// <param name="realname">真实姓名</param>
        /// <param name="cardtype">证件类型</param>
        /// <param name="cardnumber">证件号码</param>
        /// <returns></returns>
        public virtual async Task<VerifyPersonalInfoResp> WXVerifyPersonalInfo(string realname, uint cardtype, string cardnumber)
        {
            return await Request<VerifyPersonalInfoResp>(new VerifyPersonalInfoReq()
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
                UserRealName = realname,
                UserIDCardType = cardtype,
                UserIDCardNum = cardnumber
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_verifypersonalinfo);
        }

        /// <summary>
        /// 获取安全设备信息
        /// </summary>
        /// <returns></returns>
        public virtual async Task<GetSafetyInfoRespsonse> WXGetSafetyInfo()
        {
            return await Request<GetSafetyInfoRespsonse>(new GetSafetyInfoRequest()
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
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_getsafetyinfo);
        }

        /// <summary>
        /// 删除安全设备
        /// </summary>
        /// <param name="uuid">安全设备UUID</param>
        /// <returns></returns>
        public virtual async Task<DelSafeDeviceResponse> WXDelSafeDevice(string uuid)
        {
            return await Request<DelSafeDeviceResponse>(new DelSafeDeviceRequest()
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
                Uuid = uuid
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_delsafedevice);
        }

        /// <summary>
        /// 修改安全设备
        /// </summary>
        /// <returns></returns>
        public virtual async Task<UpdateSafeDeviceResponse> WXUpdateSafeDevice()
        {
            return await Request<UpdateSafeDeviceResponse>(new UpdateSafeDeviceRequest()
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
                Uuid = _Environment.DeviceName,
                DeviceType = _Environment.WeChatOsType,
                Name = _Environment.WeChatVendorId.Replace("-", "")
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_delsafedevice);
        }
    }
}
