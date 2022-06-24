using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WeChat.Core.Protocol;
using WeChat.Core.Protocol.Protos.V2;

namespace WeChat.Core
{
    public partial interface IWXApp
    {
        #region 基础登录
        /// <summary>
        /// 新设备登录成功初始化
        /// </summary>
        /// <param name="current_sync_key"></param>
        /// <param name="max_sync_key"></param>
        /// <returns></returns>
        Task<Protocol.Protos.NewInitResponse> WXNewInit(byte[] current_sync_key = null, byte[] max_sync_key = null);
        /// <summary>
        /// 人工登录（23XML）
        /// </summary>
        /// <param name="channel">通道</param>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="slider">过滑块</param>
        /// <returns></returns>
        Task<UnifyAuthResponse> WXManualAuth(WXLoginChannel channel, string username, string password, bool slider = true);
        /// <summary>
        /// 安全人工登录（24PB）
        /// </summary>
        /// <param name="channel">通道</param>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="slider">过滑块</param>
        /// <returns></returns>
        Task<UnifyAuthResponse> WXSecManualAuth(WXLoginChannel channel, string username, string password, bool slider = true);
        /// <summary>
        /// 自动登录/二次登录（23XML）
        /// </summary>
        /// <returns></returns>
        Task<UnifyAuthResponse> WXAutoAuth();
        /// <summary>
        /// 安全自动登录/二次登录（24PB）
        /// </summary>
        /// <returns></returns>
        Task<UnifyAuthResponse> WXSecAutoAuth();
        /// <summary>
        /// 注销
        /// </summary>
        /// <returns></returns>
        Task<Protocol.Protos.LogOutResponse> WXLogout();
        #endregion

        #region 扫码登录
        /// <summary>
        /// 获取登陆二维码
        /// </summary>
        /// <returns></returns>
        Task<GetLoginQRCodeResponse> WXGetLoginQrcode();
        /// <summary>
        /// 发送扫码二次登陆请求（唤醒登录）
        /// </summary>
        /// <returns></returns>
        Task<PushLoginURLResponse> WXTwiceLoginQrcode();
        /// <summary>
        /// 获取登陆二维码扫码状态
        /// </summary>
        /// <param name="uuid">获取二维码时返回的uuid</param>
        /// <returns></returns>
        Task<CheckLoginQRCodeResponse> WXCheckLoginQrcode(string uuid);
        /// <summary>
        /// 获取登陆二维码扫码状态详情
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        Task<LoginQRCodeNotify> WXCheckLoginQrcodeDetail(CheckLoginQRCodeResponse response);
        #endregion

        #region 短信登录
        /// <summary>
        /// 获取登陆验证码
        /// </summary>
        /// <param name="phone_number">手机号码,格式+8613666666666</param>
        /// <returns></returns>
        Task<Protocol.Protos.BindOpMobileForRegResponse> WXGetLoginVerifyCode(string phone_number);
        /// <summary>
        /// 效验登陆验证码
        /// </summary>
        /// <param name="phone_number">手机号码,格式+8613666666666</param>
        /// <param name="verify_code">验证码</param>
        /// <returns></returns>
        Task<Protocol.Protos.BindOpMobileForRegResponse> WXCheckLoginVerifyCode(string phone_number, string verify_code);
        #endregion

        #region 外部设备
        /// <summary>
        /// 外部设备登陆扫码
        /// </summary>
        /// <param name="login_url">二维码url</param>
        /// <returns></returns>
        Task<Protocol.Protos.ExtDeviceLoginConfirmGetResponse> WXExtDeviceLoginConfirmGet(string login_url);
        /// <summary>
        /// 外部设备登陆确认
        /// </summary>
        /// <param name="login_url">二维码url</param>
        /// <returns></returns>
        Task<Protocol.Protos.ExtDeviceLoginConfirmOKResponse> WXExtDeviceLoginConfirmOK(string login_url);
        #endregion

        #region 拓展登录
        /// <summary>
        /// 获取辅助登录二维码
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        Task<HelpQRCode> WXGetHelpQrcode(string username, string password);
        /// <summary>
        /// 辅助登录新设备,格式：https://login.weixin.qq.com/q/xxxxx
        /// </summary>
        /// <param name="login_url">二维码url,格式：https://login.weixin.qq.com/q/xxxxx</param>
        /// <returns></returns>
        Task<string> WXHelpDeviceLogin(string login_url);
        /// <summary>
        /// 重提数据
        /// </summary>
        /// <returns></returns>
        Task<string> WXExtractData(WXTerminal terminal);
        #endregion
    }
    public partial class WXApp
    {
        #region 事件
        /// <summary>
        /// 登录状态改变后事件
        /// </summary>
        public event EventHandler OnLoginStatusChanged;
        #endregion

        #region 基础登录
        /// <summary>
        /// 改变登录状态
        /// </summary>
        /// <param name="status"></param>
        protected virtual void OnChangeLoginStatus(WXStatus status)
        {
            var statuscode = _Status.Code;
            _Status.Code = status.Code;
            _Status.Message = status.Message;
            _Status.Url = status.Url;
            _Status.Ticket = status.Ticket;
            _Status.LoginMode = status.LoginMode;
            _Status.LoginChannel = status.LoginChannel;
            if (statuscode != _Status.Code) { OnLoginStatusChanged?.Invoke(this, new EventArgs()); }
        }

        /// <summary>
        /// 新设备登录成功初始化
        /// </summary>
        /// <param name="current_sync_key"></param>
        /// <param name="max_sync_key"></param>
        /// <returns></returns>
        public virtual async Task<Protocol.Protos.NewInitResponse> WXNewInit(byte[] current_sync_key = null, byte[] max_sync_key = null)
        {
            var cur_key = current_sync_key ?? new byte[0];
            var max_key = max_sync_key ?? new byte[0];
            return await Request<Protocol.Protos.NewInitResponse>(new Protocol.Protos.NewInitRequest()
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
                CurrentSynckey = new Protocol.Protos.SKBuiltinBuffer_t { Buffer = cur_key, iLen = (uint)cur_key.Length },
                MaxSynckey = new Protocol.Protos.SKBuiltinBuffer_t { Buffer = max_key, iLen = (uint)max_key.Length },
                Language = "zh",
                UserName = _Profile.UserName
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_newinit);
        }

        /// <summary>
        /// 人工登录（23XML）
        /// </summary>
        /// <param name="channel">通道</param>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="slider">过滑块</param>
        /// <returns></returns>
        public virtual async Task<UnifyAuthResponse> WXManualAuth(WXLoginChannel channel, string username, string password, bool slider = true)
        {
            if (!TestProxy(WXCGIUrl.micromsg_bin_manualauth))
            {
                _Status = new WXStatus()
                {
                    Code = 2,
                    Message = "登录失败[代理超时]"
                };
                return null;
            }
            _Status = default;
            var result = default(UnifyAuthResponse);
            var retry = 3;
            var ecdh = new ECKeyPair(Curve.SecP224r1);
            var ccd = new DeviceRunningInfo23
            {
                Version = "00000003",
                Encrypted = 1,
                Data = WCAES03.BuildClientCheckData(_Environment.BuildClientCheckDataXml()),
            }.SerializeToProtoBuf();

            var pubkey = ecdh.PublicKey;
            var pb = new ManualAuthRequest
            {
                rsaRequest = new ManualAuthRsaReqData()
                {
                    aes = new AesKey() { key = _Cache.SessionKey, len = (int)(_Cache.SessionKey?.Length) },
                    ecdh = new Ecdh { ecdhkey = new EcdhKey { key = pubkey, len = (int)(pubkey?.Length) }, nid = 713 },
                    password1 = channel == WXLoginChannel.Normal ? password.MD5() : password,
                    password2 = channel == WXLoginChannel.Normal ? password.MD5() : password,
                    userName = username
                },
                deviceRequest = new ManualAuthAesReqData()
                {
                    baseRequest = new BaseRequest
                    {
                        clientVersion = _Environment.Terminal.GetWeChatVersion(),
                        devicelId = _Environment.WeChatDataId.ToByteArray(16, 2),
                        osType = _Environment.WeChatOsType,
                        sessionKey = _Cache.SessionKey,
                        scene = 1,
                        uin = _Cache.Uin
                    },
                    baseReqInfo = new BaseAuthReqInfo { },
                    imei = _Environment.DeviceImei.ToByteArray(16, 2),
                    softInfoXml = _Environment.WeChatXmlInfo,
                    Builtinipseq = 0,
                    clientSeqID = _Environment.DeviceImei + "-" + DateTime.Now.ToTimeStamp().ToString(),
                    loginDeviceName = _Environment.DeviceName,
                    deviceInfoXml = _Environment.Device.ToString(),
                    language = "Zh",
                    timeZone = "8.0",
                    Channel = 0,
                    Timestamp = DateTime.Now.ToTimeStamp(),
                    deviceBrand = _Environment.DeviceBrand,
                    realCountry = "cn",
                    Bundleid = _Environment.WeChatBundleId,
                    Inputtype = 2,
                    Signature = _Environment.WeChatSignature,
                    osType = _Environment.WeChatOsType,
                    deviceModel = _Environment.Device.Model,
                    Clientcheckdat = new SKBuiltinString_() { buffer = ccd, iLen = (uint)ccd.Length }
                }
            };
            var pb_acount = pb.rsaRequest?.SerializeToProtoBuf();
            var pb_device = pb.deviceRequest?.SerializeToProtoBuf();

            var body = new byte[] { };
            var rsa_verson = _Cache.Terminal.GetRsaVersion();
            var rsa_acount = pb_acount.ZIPCompress().RSAEncrypt(rsa_verson.GetKey().ToByteArray(16, 2), rsa_verson.GetExponent());
            var aes_device = pb_device.ZIPCompress().AESEncrypt(_Cache.SessionKey);
            body = body.Concat(pb_acount.Length.ToByteArray(Endian.Big)).ToArray();
            body = body.Concat(pb_device.Length.ToByteArray(Endian.Big)).ToArray();
            body = body.Concat(rsa_acount.Length.ToByteArray(Endian.Big)).ToArray();
            body = body.Concat(rsa_acount).ToArray();
            body = body.Concat(aes_device).ToArray();
            var package = Pack(body, (int)WXCGIUrl.micromsg_bin_manualauth, _Cache.Terminal.GetWeChatVersion().Code, false, body.Length, body.Length, 0, 7, (int)rsa_verson);
            do
            {
                result = await Request<UnifyAuthResponse>(package, WXCGIUrl.micromsg_bin_manualauth);
            } while ((result?.baseResponse?.ret == RetConst.MM_ERR_IDC_REDIRECT) && --retry > 0);
            if (result == null)
            {
                _Status = new WXStatus()
                {
                    Code = 2,
                    Message = "登录失败[网络异常/代理超时]"
                };
                return null;
            }
            if ((result?.baseResponse?.errMsg?.@string?.Contains("系统检测到环境存在异常") ?? false) == true && slider == true)
            {
                var sliderRes = await WXSliderOCR("2000000038");
                var ticket = result?.baseResponse?.errMsg.@string.Substring("ticket=", 34);
                string url1 = $"https://shminorshort.weixin.qq.com/security/readtemplate?t=login_verify_entrances/w_tcaptcha_ret&wechat_real_lang=zh_CN&aid=2000000038&clientype=1&lang=2052&apptype=undefined&captype=7&disturblevel=1&secticket={ticket}&ret=0&ticket={sliderRes.Ticket}&randstr={sliderRes.RandStr}";
                HttpHelper http = new HttpHelper();
                HttpItem item = new HttpItem()
                {
                    URL = url1,
                    Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8"
                };
                HttpResult httpResult1 = http.GetHtml(item);
                string url2 = url1.Replace("readtemplate", "secondauth") + "&step=8";
                item = new HttpItem()
                {
                    URL = url2,
                    Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8",
                    Referer = url1,
                    Cookie = httpResult1.Cookie
                };
                http.GetHtml(item);
                //return await WXManualAuth(channel, username, password, false);
                retry = 3;
                do
                {
                    result = await Request<UnifyAuthResponse>(package, WXCGIUrl.micromsg_bin_manualauth);
                } while ((result?.baseResponse?.ret == RetConst.MM_ERR_IDC_REDIRECT) && --retry > 0);
            }
            result?.CallWhen(result?.baseResponse?.ret == RetConst.MM_OK, _ =>
            {
                _Cache.EcdhKey = ecdh.GetSharedKey(result.authParam.ecdh.ecdhkey.key);
                _Cache.SessionKey = result.authParam.session.key.AESDecrypt(_Cache.EcdhKey.MD5());
                _Profile.UserName = result.accountInfo.wxid;
                _Profile.NickName = result.accountInfo.nickName;
                _Profile.BindEmail = result.accountInfo.bindMail;
                _Profile.BindMobile = result.accountInfo.bindMobile;
                _Profile.Alias = result.accountInfo.Alias;
                _Profile.Password = channel == WXLoginChannel.Normal ? password : "";
                _Profile.PasswordMd5 = channel == WXLoginChannel.Normal ? password.MD5() : password;
            });
            result?.CallWhen(true, _ =>
            {
                _Status = new WXStatus
                {
                    Code = result?.baseResponse?.ret == RetConst.MM_OK ? 1 : (int)(result?.baseResponse?.ret ?? RetConst.MM_ERR_NOT),
                    Message = result?.baseResponse?.ret == RetConst.MM_OK ? _Profile.ToJson() : result?.baseResponse?.errMsg.@string.Between("<Content><![CDATA[", "]]></Content>"),
                    Url = result?.baseResponse?.ret == RetConst.MM_OK ? "" : result?.baseResponse?.errMsg.@string.Between("<Url><![CDATA[", "]]></Url>"),
                    Ticket = result?.baseResponse?.ret == RetConst.MM_OK ? "" : result?.baseResponse?.errMsg.@string.Substring("ticket=", 34),
                    LoginChannel = channel,
                    LoginMode = WXLoginMode.Manual
                };
                if (_Status.Code == -1)
                {
                    _Status.Message = "登录失败[未登录/已退出]";
                }
                if (string.IsNullOrEmpty(_Status.Message))
                {
                    _Status.Code = 3;
                    _Status.Message = "登录失败[实例环境异常]";
                }
            });
            return result;
        }

        /// <summary>
        /// 安全人工登录（24PB）
        /// </summary>
        /// <param name="channel">通道</param>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="slider">过滑块</param>
        /// <returns></returns>
        public virtual async Task<UnifyAuthResponse> WXSecManualAuth(WXLoginChannel channel, string username, string password, bool slider = true)
        {
            if (!TestProxy(WXCGIUrl.micromsg_bin_secmanualauth))
            {
                _Status = new WXStatus()
                {
                    Code = 2,
                    Message = "登录失败[代理超时]"
                };
                return null;
            }
            _Status = default;
            var retry = 3;
            var result = default(UnifyAuthResponse);
            var ecdh = new ECKeyPair(Curve.SecP224r1);
            var ccdata = new DeviceRunningInfo24
            {
                Version = "00000003",
                Encrypted = 1,
                Data = WCAES03.BuildClientCheckData(_Environment.BuildClientCheckDataPB()),
                Timestamp = (uint)(DateTime.UtcNow.ToTimeStamp()),
                Optype = 5,
                Uin = 0
            }.SerializeToProtoBuf();
            var devicetoken = new DeviceRunningInfo24
            {
                Version = "",
                Encrypted = 1,
                Data = new SKBuiltinString { @string = "" }.SerializeToProtoBuf(),
                Timestamp = (uint)(DateTime.UtcNow.ToTimeStamp()),
                Optype = 2,
                Uin = 0
            }.SerializeToProtoBuf();
            var extspam = new WCExtInfo
            {
                CcData = new SKBuiltinString_ { buffer = ccdata, iLen = (uint)(ccdata.Length) },
                DeviceToken = new SKBuiltinString_ { buffer = devicetoken, iLen = (uint)devicetoken.Length }
            }.SerializeToProtoBuf();
            var pubkey = ecdh.PublicKey;
            var pb = new ManualAuthRequest()
            {
                rsaRequest = new ManualAuthRsaReqData
                {
                    aes = new AesKey { key = _Cache.SessionKey, len = (int)(_Cache.SessionKey?.Length) },
                    ecdh = new Ecdh { ecdhkey = new EcdhKey { key = pubkey, len = (int)(pubkey?.Length) }, nid = 713 },
                    password1 = channel == WXLoginChannel.Normal ? password.MD5() : password,
                    password2 = channel == WXLoginChannel.Normal ? password.MD5() : password,
                    userName = username
                },
                deviceRequest = new ManualAuthAesReqData
                {
                    baseRequest = new BaseRequest
                    {
                        clientVersion = _Environment.Terminal.GetWeChatVersion(),
                        devicelId = _Environment.WeChatDataId.ToByteArray(16, 2),
                        osType = _Environment.WeChatOsType,
                        sessionKey = _Cache.SessionKey,
                        scene = 1,
                        uin = _Cache.Uin
                    },
                    baseReqInfo = new BaseAuthReqInfo { },
                    imei = _Environment.DeviceImei.ToByteArray(16, 2),
                    softInfoXml = _Environment.WeChatXmlInfo,
                    Builtinipseq = 0,
                    clientSeqID = _Environment.DeviceImei + "-" + DateTime.Now.ToTimeStamp().ToString(),
                    loginDeviceName = _Environment.DeviceName,
                    deviceInfoXml = _Environment.Device.ToString(),
                    language = "Zh",
                    timeZone = "8.0",
                    Channel = 0,
                    Timestamp = DateTime.Now.ToTimeStamp(),
                    deviceBrand = _Environment.DeviceBrand,
                    realCountry = "cn",
                    Bundleid = _Environment.WeChatBundleId,
                    Inputtype = 2,
                    ExtSpamInfo = new SKBuiltinString_ { buffer = extspam, iLen = (uint)(extspam.Length) }
                }
            }.SerializeToProtoBuf();
            do
            {
                result = await Request<UnifyAuthResponse>(pb, WXCGIUrl.micromsg_bin_secmanualauth);
            } while ((result?.baseResponse?.ret == RetConst.MM_ERR_IDC_REDIRECT) && --retry > 0);
            if (result == null)
            {
                _Status = new WXStatus()
                {
                    Code = 2,
                    Message = "登录失败[网络异常/代理超时]"
                };
                return null;
            }
            if ((result?.baseResponse?.errMsg?.@string?.Contains("系统检测到环境存在异常") ?? false) == true && slider == true)
            {
                //System.Diagnostics.Debug.WriteLine($"开始过滑块:{username}");
                var sliderRes = await WXSliderOCR("2000000038");
                var ticket = result?.baseResponse?.errMsg.@string.Substring("ticket=", 34);
                string url1 = $"https://shminorshort.weixin.qq.com/security/readtemplate?t=login_verify_entrances/w_tcaptcha_ret&wechat_real_lang=zh_CN&aid=2000000038&clientype=1&lang=2052&apptype=undefined&captype=7&disturblevel=1&secticket={ticket}&ret=0&ticket={sliderRes.Ticket}&randstr={sliderRes.RandStr}";
                HttpHelper http = new HttpHelper();
                HttpItem item = new HttpItem()
                {
                    URL = url1,
                    Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8"
                };
                HttpResult httpResult1 = http.GetHtml(item);
                string url2 = url1.Replace("readtemplate", "secondauth") + "&step=8";
                item = new HttpItem()
                {
                    URL = url2,
                    Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8",
                    Referer = url1,
                    Cookie = httpResult1.Cookie
                };
                http.GetHtml(item);
                //return await WXSecManualAuth(channel, username, password, false);
                retry = 3;
                do
                {
                    result = await Request<UnifyAuthResponse>(pb, WXCGIUrl.micromsg_bin_secmanualauth);
                } while ((result?.baseResponse?.ret == RetConst.MM_ERR_IDC_REDIRECT) && --retry > 0);
            }
            result?.CallWhen(result?.baseResponse?.ret == RetConst.MM_OK, _ =>
            {
                _Cache.EcdhKey = ecdh.GetSharedKey(result.authParam.ecdh.ecdhkey.key);
                _Cache.SessionKey = result.authParam.session.key.AESDecrypt(_Cache.EcdhKey.MD5());
                _Profile.UserName = result.accountInfo.wxid;
                _Profile.NickName = result.accountInfo.nickName;
                _Profile.BindEmail = result.accountInfo.bindMail;
                _Profile.BindMobile = result.accountInfo.bindMobile;
                _Profile.Alias = result.accountInfo.Alias;
                _Profile.Password = channel == WXLoginChannel.Normal ? password : "";
                _Profile.PasswordMd5 = channel == WXLoginChannel.Normal ? password.MD5() : password;
            });
            result?.CallWhen(true, _ =>
            {
                _Status = new WXStatus
                {
                    Code = result?.baseResponse?.ret == RetConst.MM_OK ? 1 : (int)(result?.baseResponse?.ret ?? RetConst.MM_ERR_NOT),
                    Message = result?.baseResponse?.ret == RetConst.MM_OK ? _Profile.ToJson() : result?.baseResponse?.errMsg.@string.Between("<Content><![CDATA[", "]]></Content>"),
                    Url = result?.baseResponse?.ret == RetConst.MM_OK ? "" : result?.baseResponse?.errMsg.@string.Between("<Url><![CDATA[", "]]></Url>"),
                    Ticket = result?.baseResponse?.ret == RetConst.MM_OK ? "" : result?.baseResponse?.errMsg.@string.Substring("ticket=", 34),
                    LoginChannel = channel,
                    LoginMode = WXLoginMode.Manual
                };
                if (_Status.Code == -1)
                {
                    _Status.Message = "登录失败[未登录/已退出]";
                }
                if (string.IsNullOrEmpty(_Status.Message))
                {
                    _Status.Code = 3;
                    _Status.Message = "登录失败[实例环境异常]";
                }
            });
            return result;
        }

        /// <summary>
        /// 自动登录/二次登录（23XML）
        /// </summary>
        /// <returns></returns>
        public virtual async Task<UnifyAuthResponse> WXAutoAuth()
        {
            if (!TestProxy(WXCGIUrl.micromsg_bin_autoauth))
            {
                _Status = new WXStatus()
                {
                    Code = 2,
                    Message = "登录失败[代理超时]"
                };
                return null;
            }
            _Status = default;
            var retry = 3;
            var result = default(UnifyAuthResponse);
            var ecdh = new ECKeyPair(Curve.SecP224r1);
            var ccd = new DeviceRunningInfo23
            {
                Version = "00000003",
                Encrypted = 1,
                Data = WCAES03.BuildClientCheckData(_Environment.BuildClientCheckDataXml()),
            }.SerializeToProtoBuf();

            var pubkey = ecdh.PublicKey;
            var pb = new AutoAuthRequest
            {
                rsaReqData = new AutoAuthRsaReqData()
                {
                    aesEncryptKey = new AesKey() { key = _Cache.SessionKey, len = (int)(_Cache.SessionKey?.Length) },
                    cliPubEcdhKey = new Ecdh { ecdhkey = new EcdhKey { key = pubkey, len = (int)(pubkey?.Length) }, nid = 713 }
                },
                aesReqData = new AutoAuthAesReqData()
                {
                    baseRequest = new BaseRequest
                    {
                        clientVersion = _Environment.Terminal.GetWeChatVersion(),
                        devicelId = _Environment.WeChatDataId.ToByteArray(16, 2),
                        osType = _Environment.WeChatOsType,
                        sessionKey = _Cache.SessionKey,
                        uin = 0,
                        scene = 1
                    },
                    autoAuthKey = new SKBuiltinString_() { buffer = _Cache.AutoAuthToken, iLen = (uint)(_Cache.AutoAuthToken?.Length) },
                    BaseAuthReqInfo = new BaseAuthReqInfo(),
                    clientSeqId = _Environment.DeviceImei + "-" + DateTime.Now.ToTimeStamp().ToString(),
                    deviceName = _Environment.DeviceName,
                    deviceType = _Environment.WeChatOsType,
                    imei = _Environment.DeviceImei,
                    timeZone = "8.00",
                    language = "zh_CN",
                    builtinIpseq = 0,
                    signature = "",
                    clientCheckData = new SKBuiltinString_ { buffer = ccd, iLen = (uint)ccd.Length }
                }
            };
            var pb_acount = pb?.rsaReqData?.SerializeToProtoBuf();
            var pb_device = pb?.aesReqData?.SerializeToProtoBuf();

            var body = new byte[] { };
            var rsa_verson = WXRSAVersion.RSA_VER_135;
            var rsa_acount = pb_acount.ZIPCompress().RSAEncrypt(rsa_verson.GetKey().ToByteArray(16, 2), rsa_verson.GetExponent());
            var aes_acount = pb_acount.ZIPCompress().AESEncrypt(_Cache.SessionKey);
            var aes_device = pb_device.ZIPCompress().AESEncrypt(_Cache.SessionKey);
            body = body.Concat(pb_acount.Length.ToByteArray(Endian.Big)).ToArray();
            body = body.Concat(pb_device.Length.ToByteArray(Endian.Big)).ToArray();
            body = body.Concat(rsa_acount.Length.ToByteArray(Endian.Big)).ToArray();
            body = body.Concat(aes_acount.Length.ToByteArray(Endian.Big)).ToArray();
            body = body.Concat(rsa_acount).ToArray();
            body = body.Concat(aes_acount).ToArray();
            body = body.Concat(aes_device).ToArray();
            var package = Pack(body, (int)WXCGIUrl.micromsg_bin_autoauth, _Cache.Terminal.GetWeChatVersion().Code, false, body.Length, body.Length, 0, 9, (int)rsa_verson);
            do
            {
                result = await Request<UnifyAuthResponse>(package, WXCGIUrl.micromsg_bin_autoauth);
            } while ((result?.baseResponse?.ret == RetConst.MM_ERR_IDC_REDIRECT) && --retry > 0);
            result?.CallWhen(result?.baseResponse?.ret == RetConst.MM_OK, _ =>
            {
                _Cache.EcdhKey = ecdh.GetSharedKey(result.authParam.ecdh.ecdhkey.key);
                _Cache.SessionKey = result.authParam.session.key.AESDecrypt(_Cache.EcdhKey.MD5());
            });
            result?.CallWhen(true, _ =>
            {
                _Status = new WXStatus
                {
                    Code = result?.baseResponse?.ret == RetConst.MM_OK ? 1 : (int)(result?.baseResponse?.ret ?? RetConst.MM_ERR_NOT),
                    Message = result?.baseResponse?.ret == RetConst.MM_OK ? _Profile.ToJson() : result?.baseResponse?.errMsg.@string.Between("<Content><![CDATA[", "]]></Content>"),
                    Url = result?.baseResponse?.ret == RetConst.MM_OK ? "" : result?.baseResponse?.errMsg.@string.Between("<Url><![CDATA[", "]]></Url>"),
                    Ticket = result?.baseResponse?.ret == RetConst.MM_OK ? "" : result?.baseResponse?.errMsg.@string.Substring("ticket=", 34),
                    LoginChannel = _Status.LoginChannel,
                    LoginMode = WXLoginMode.Auto
                };
                if (_Status.Code == -1)
                {
                    _Status.Message = "登录失败[未登录/已退出]";
                }
                if (string.IsNullOrEmpty(_Status.Message))
                {
                    _Status.Code = 3;
                    _Status.Message = "登录失败[实例环境异常]";
                }
            });
            return result;
        }

        /// <summary>
        /// 安全自动登录/二次登录（24PB）
        /// </summary>
        /// <returns></returns>
        public virtual async Task<UnifyAuthResponse> WXSecAutoAuth()
        {
            if (!TestProxy(WXCGIUrl.micromsg_bin_secautoauth))
            {
                _Status = new WXStatus()
                {
                    Code = 2,
                    Message = "登录失败[代理超时]"
                };
                return null;
            }
            _Status = default;
            var retry = 3;
            var result = default(UnifyAuthResponse);
            var ecdh = new ECKeyPair(Curve.SecP224r1);
            var ccd = new DeviceRunningInfo24
            {
                Version = "00000003",
                Encrypted = 1,
                Data = WCAES03.BuildClientCheckData(_Environment.BuildClientCheckDataPB()),
                Timestamp = (uint)(DateTime.UtcNow.ToTimeStamp()),
                Optype = 5,
                Uin = 0
            }.SerializeToProtoBuf();
            var devicetoken = new DeviceRunningInfo24
            {
                Version = "",
                Encrypted = 1,
                Data = new SKBuiltinString { @string = "" }.SerializeToProtoBuf(),
                Timestamp = (uint)(DateTime.UtcNow.ToTimeStamp()),
                Optype = 2,
                Uin = 0
            }.SerializeToProtoBuf();
            var extspam = new WCExtInfo
            {
                CcData = new SKBuiltinString_ { buffer = ccd, iLen = (uint)ccd.Length },
                DeviceToken = new SKBuiltinString_ { buffer = devicetoken, iLen = (uint)devicetoken.Length }
            }.SerializeToProtoBuf();
            var pubkey = ecdh.PublicKey;
            var pb = new AutoAuthRequest
            {
                rsaReqData = new AutoAuthRsaReqData
                {
                    aesEncryptKey = new AesKey() { key = _Cache.SessionKey, len = (int)(_Cache.SessionKey?.Length) },
                    cliPubEcdhKey = new Ecdh { ecdhkey = new EcdhKey { key = pubkey, len = (int)(pubkey?.Length) }, nid = 713 }
                },
                aesReqData = new AutoAuthAesReqData
                {
                    baseRequest = new BaseRequest
                    {
                        clientVersion = _Environment.Terminal.GetWeChatVersion(),
                        devicelId = _Environment.WeChatDataId.ToByteArray(16, 2),
                        osType = _Environment.WeChatOsType,
                        sessionKey = _Cache.SessionKey,
                        uin = _Cache.Uin,
                        scene = 2
                    },
                    autoAuthKey = new SKBuiltinString_() { buffer = _Cache.AutoAuthToken, iLen = (uint)_Cache.AutoAuthToken?.Length },
                    BaseAuthReqInfo = new BaseAuthReqInfo(),
                    imei = _Environment.DeviceImei,
                    softType = _Environment.WeChatXmlInfo,
                    builtinIpseq = 0,
                    clientSeqId = _Environment.DeviceImei + "-" + DateTime.Now.ToTimeStamp().ToString(),
                    deviceName = _Environment.DeviceName,
                    deviceType = _Environment.WeChatOsType,
                    timeZone = "8.0",
                    language = "Zh",
                    signature = "",
                    ExtSpamInfo = new SKBuiltinString_ { buffer = extspam, iLen = (uint)extspam.Length }
                }
            }.SerializeToProtoBuf();
            do
            {
                result = await Request<UnifyAuthResponse>(pb, WXCGIUrl.micromsg_bin_secautoauth);
            } while ((result?.baseResponse?.ret == RetConst.MM_ERR_IDC_REDIRECT) && --retry > 0);
            result?.CallWhen(result?.baseResponse?.ret == RetConst.MM_OK, _ =>
            {
                _Cache.EcdhKey = ecdh.GetSharedKey(result.authParam.ecdh.ecdhkey.key);
                _Cache.SessionKey = result.authParam.session.key.AESDecrypt(_Cache.EcdhKey.MD5());
            });
            result?.CallWhen(true, _ =>
            {
                _Status = new WXStatus
                {
                    Code = result?.baseResponse?.ret == RetConst.MM_OK ? 1 : (int)(result?.baseResponse?.ret ?? RetConst.MM_ERR_NOT),
                    Message = result?.baseResponse?.ret == RetConst.MM_OK ? _Profile.ToJson() : result?.baseResponse?.errMsg.@string.Between("<Content><![CDATA[", "]]></Content>"),
                    Url = result?.baseResponse?.ret == RetConst.MM_OK ? "" : result?.baseResponse?.errMsg.@string.Between("<Url><![CDATA[", "]]></Url>"),
                    Ticket = result?.baseResponse?.ret == RetConst.MM_OK ? "" : result?.baseResponse?.errMsg.@string.Substring("ticket=", 34),
                    LoginChannel = _Status.LoginChannel,
                    LoginMode = WXLoginMode.Auto
                };
                if (_Status.Code == -1)
                {
                    _Status.Message = "登录失败[未登录/已退出]";
                }
                if (string.IsNullOrEmpty(_Status.Message))
                {
                    _Status.Code = 3;
                    _Status.Message = "登录失败[实例环境异常]";
                }
            });
            return result;
        }

        /// <summary>
        /// 注销
        /// </summary>
        /// <returns></returns>
        public virtual async Task<Protocol.Protos.LogOutResponse> WXLogout()
        {
            var result = await Request<Protocol.Protos.LogOutResponse>(new Protocol.Protos.LogOutRequest()
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
                Scene = 0,
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_logout);
            result?.CallWhen(result?.BaseResponse?.Ret == (int)(RetConst.MM_OK), _ =>
            {
                OnChangeLoginStatus(new WXStatus { Code = 1, Message = result?.BaseResponse?.ErrMsg?.String, LoginMode = _Status.LoginMode });
            });
            return result;
        }
        #endregion

        #region 扫码登录
        /// <summary>
        /// 获取登陆二维码
        /// 不含data:img/jpg;base64,
        /// </summary>
        /// <returns></returns>
        public virtual async Task<GetLoginQRCodeResponse> WXGetLoginQrcode()
        {
            var result = await Request<GetLoginQRCodeResponse>(new GetLoginQRCodeRequest()
            {
                aes = new AesKey() { key = _Cache.SessionKey, len = _Cache.SessionKey.Length },
                baseRequest = new BaseRequest
                {
                    clientVersion = _Environment.Terminal.GetWeChatVersion(),
                    devicelId = _Environment.WeChatDataId.ToByteArray(16, 2),
                    osType = _Environment.WeChatOsType,
                    sessionKey = _Cache.SessionKey,
                    scene = 0,
                    uin = _Cache.Uin
                },
                opcode = 0
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_getloginqrcode);
            return result;
        }

        /// <summary>
        /// 发送扫码二次登陆请求（唤醒登录）
        /// </summary>
        /// <returns></returns>
        public virtual async Task<PushLoginURLResponse> WXTwiceLoginQrcode()
        {
            var rsapem = new StringBuilder();
            rsapem.AppendLine("-----BEGIN PUBLIC KEY-----");
            rsapem.AppendLine("MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQDBw+dIjc55pK47M6nPpXkIl77EbnOtQ2BXzceN9jrbexgjgafu1fZMsDz3Yr365VHBfRnM0MxB3Q79te9bEsrCooocc5KKqPD66qeq3dFL0WCYLKBi54e8sIhuVXid5HqIUBr/S9ak7rFNH7lPrLPDsSqUaRJLnHE19wYO7nkqfwIDAQAB");
            rsapem.AppendLine("-----END PUBLIC KEY-----");
            return await Request<PushLoginURLResponse>(new PushLoginURLRequest()
            {
                baseRequest = new BaseRequest
                {
                    clientVersion = _Environment.Terminal.GetWeChatVersion(),
                    devicelId = _Environment.WeChatDataId.ToByteArray(16, 2),
                    osType = _Environment.WeChatOsType,
                    sessionKey = _Cache.SessionKey,
                    scene = 0,
                    uin = 0
                },
                rsa = new RSAPem() { pem = rsapem.ToString(), len = (uint)(rsapem.Length) },
                randomEncryKey = new AesKey { key = _Cache.SessionKey, len = _Cache.SessionKey.Length },
                Autoauthkey = new SKBuiltinString_ { buffer = _Cache.AutoAuthToken, iLen = (uint)(_Cache.AutoAuthToken.Length) },
                Autoauthticket = _Cache.AutoAuthTicket,
                ClientId = _Environment.DeviceImei + "-" + DateTime.Now.ToTimeStamp().ToString(),
                Devicename = _Environment.DeviceName,
                username = _Profile.UserName,
                opcode = 3
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_pushloginurl);
        }

        /// <summary>
        /// 获取登陆二维码扫码状态
        /// </summary>
        /// <param name="uuid">获取二维码时返回的uuid</param>
        /// <returns></returns>
        public virtual async Task<CheckLoginQRCodeResponse> WXCheckLoginQrcode(string uuid)
        {
            return await Request<CheckLoginQRCodeResponse>(new CheckLoginQRCodeRequest()
            {
                aes = new AesKey() { key = _Cache.SessionKey, len = _Cache.SessionKey.Length },
                baseRequest = new BaseRequest
                {
                    clientVersion = _Environment.Terminal.GetWeChatVersion(),
                    devicelId = _Environment.WeChatDataId.ToByteArray(16, 2),
                    osType = _Environment.WeChatOsType,
                    sessionKey = _Cache.SessionKey,
                    scene = 0,
                    uin = _Cache.Uin
                },
                uuid = uuid,
                timeStamp = (uint)(DateTime.Now.ToTimeStamp()),
                opcode = 0
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_checkloginqrcode);
        }

        /// <summary>
        /// 获取登陆二维码扫码状态详情
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public virtual async Task<LoginQRCodeNotify> WXCheckLoginQrcodeDetail(CheckLoginQRCodeResponse response)
        {
            var result = default(LoginQRCodeNotify);
            if (response?.baseResponse?.ret == RetConst.MM_OK)
            {
                var buffer = response.data.notifyData.buffer.AESDecrypt(_Cache.SessionKey);
                result = buffer?.DeserializeFromProtoBuf<LoginQRCodeNotify>();
            }
            result?.CallWhen(true, _ => _Profile.HeadImage = result.headImgUrl);
            return await Task.FromResult(result);
        }
        #endregion

        #region 短信登录
        /// <summary>
        /// 获取登陆验证码
        /// </summary>
        /// <param name="phone_number">手机号码,格式+8613666666666</param>
        /// <returns></returns>
        public virtual async Task<Protocol.Protos.BindOpMobileForRegResponse> WXGetLoginVerifyCode(string phone_number)
        {
            return await WXBindOpMobileForReg(16, phone_number, "", 0, "", "");
        }

        /// <summary>
        /// 效验登陆验证码
        /// </summary>
        /// <param name="phone_number">手机号码,格式+8613666666666</param>
        /// <param name="verify_code">验证码</param>
        /// <returns></returns>
        public virtual async Task<Protocol.Protos.BindOpMobileForRegResponse> WXCheckLoginVerifyCode(string phone_number, string verify_code)
        {
            return await WXBindOpMobileForReg(17, phone_number, verify_code, 0, "", "");
        }
        #endregion

        #region 外部设备
        /// <summary>
        /// 外部设备登陆扫码
        /// </summary>
        /// <param name="login_url">二维码url</param>
        /// <returns></returns>
        public virtual async Task<Protocol.Protos.ExtDeviceLoginConfirmGetResponse> WXExtDeviceLoginConfirmGet(string login_url)
        {

            return await Request<Protocol.Protos.ExtDeviceLoginConfirmGetResponse>(new Protocol.Protos.ExtDeviceLoginConfirmGetRequest()
            {
                LoginUrl = login_url
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_extdeviceloginconfirmget);
        }

        /// <summary>
        /// 外部设备登陆确认
        /// </summary>
        /// <param name="login_url">二维码url</param>
        /// <returns></returns>
        public virtual async Task<Protocol.Protos.ExtDeviceLoginConfirmOKResponse> WXExtDeviceLoginConfirmOK(string login_url)
        {
            return await Request<Protocol.Protos.ExtDeviceLoginConfirmOKResponse>(new Protocol.Protos.ExtDeviceLoginConfirmOKRequest()
            {
                LoginUrl = login_url
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_extdeviceloginconfirmok);
        }
        #endregion

        #region 拓展登录

        /// <summary>
        /// 获取辅助登录二维码
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public virtual async Task<HelpQRCode> WXGetHelpQrcode(string username, string password)
        {
            HelpQRCode helpQR = new HelpQRCode();
            var newLogin = await WXSecManualAuth(WXLoginChannel.Normal, username, password);
            if (Status.Message.Contains("系统检测到环境存在异常"))
            {
                System.Diagnostics.Debug.WriteLine($"开始过滑块:{username}");
                var sliderRes = await WXSliderOCR("2000000038");
                string url1 = $"https://shminorshort.weixin.qq.com/security/readtemplate?t=login_verify_entrances/w_tcaptcha_ret&wechat_real_lang=zh_CN&aid=2000000038&clientype=1&lang=2052&apptype=undefined&captype=7&disturblevel=1&secticket={Status.Ticket}&ret=0&ticket={sliderRes.Ticket}&randstr={sliderRes.RandStr}";
                HttpHelper http = new HttpHelper();
                HttpItem item = new HttpItem()
                {
                    URL = url1,
                    Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8",
                    ProxyIp = _Linker.Proxy.ToStrProxy()
                };
                HttpResult httpResult1 = http.GetHtml(item);
                string url2 = url1.Replace("readtemplate", "secondauth") + "&step=8";
                item = new HttpItem()
                {
                    URL = url2,
                    Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8",
                    Referer = url1,
                    Cookie = httpResult1.Cookie,
                    ProxyIp = _Linker.Proxy.ToStrProxy()
                };
                http.GetHtml(item);
                return await WXGetHelpQrcode(username, password);
            }
            else if (Status.Message.Contains("本次登录需要进行安全验证"))
            {
                string referer = $"https://shminorshort.weixin.qq.com/security/readtemplate?&ticket={Status.Ticket}&wechat_real_lang=&idc=2&t=login_verify_entrances/entrances";
                string url = $"https://shminorshort.weixin.qq.com/security/secondauth?&ticket={Status.Ticket}&wechat_real_lang=&idc=2&t=login_verify_entrances/entrances&step=1&sessionid=";
                HttpHelper http = new HttpHelper();
                HttpItem item = new HttpItem()
                {
                    URL = url,
                    Referer = referer,
                    ProxyIp = _Linker.Proxy.ToStrProxy()
                };
                HttpResult httpResult1 = http.GetHtml(item);

                var temp = httpResult1?.Html?.ToJObject<Protocol.Protos.GetVerifyWayResponse>();
                url = $"https://shminorshort.weixin.qq.com/security/secondauth?&ticket={Status.Ticket}&wechat_real_lang=&idc=2&t=login_verify_entrances/entrances&step=21&sessionid={temp.sessionid}";
                item = new HttpItem()
                {
                    URL = url,
                    Referer = referer,
                    Accept = "application/json, text/plain, */*",
                    Cookie = httpResult1.Cookie,
                    ProxyIp = _Linker.Proxy.ToStrProxy()
                };
                HttpResult httpResult2 = http.GetHtml(item);

                temp = httpResult2?.Html?.ToJObject<Protocol.Protos.GetVerifyWayResponse>();
                url = $"https://login.weixin.qq.com/jslogin?appid=wx_newdev_verify&t=simple_auth/w_qrcode_show&&ticket={Status.Ticket}&wechat_real_lang=zh_CN&idc=2&qrcliticket={temp.qrcodeticket}";
                referer = $"https://shminorshort.weixin.qq.com/security/readtemplate?t=simple_auth/w_qrcode_show&&ticket={Status.Ticket}&wechat_real_lang=zh_CN&idc=2&qrcliticket={temp.qrcodeticket}";
                item = new HttpItem()
                {
                    URL = url,
                    Referer = referer,
                    Cookie = httpResult2.Cookie,
                    ProxyIp = _Linker.Proxy.ToStrProxy()
                };
                HttpResult httpResult3 = http.GetHtml(item);

                helpQR.UUID = (httpResult3?.Html ?? "").Replace("window.QRLogin.code = 200; window.QRLogin.uuid = ", "").Replace("\"", "").Replace(";", "").Trim();
                helpQR.Ticket = Status.Ticket;
                helpQR.QrCliTicket = temp.qrcodeticket;
                helpQR.Message = "获取成功";
                return helpQR;
            }
            else
            {
                helpQR.Message = $"{Status.Message}[{newLogin?.baseResponse?.ret}]";
                helpQR.Status = (int)(newLogin?.baseResponse?.ret);
                return helpQR;
            }
        }

        /// <summary>
        /// 辅助登录新设备,格式：https://login.weixin.qq.com/q/xxxxx
        /// </summary>
        /// <param name="login_url">二维码url,格式：https://login.weixin.qq.com/q/xxxxx</param>
        /// <returns></returns>
        public virtual async Task<string> WXHelpDeviceLogin(string login_url)
        {
            var result = default(string);
            var a8key = await WXGetA8Key(login_url);
            if (a8key?.FullURL?.IsEmpty() ?? true) { result = "授权失败"; return result; }
            HttpHelper http = new HttpHelper();
            HttpItem item = new HttpItem()
            {
                URL = a8key.FullURL,
                Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8",
                ProxyIp = _Linker.Proxy.ToStrProxy()
            };
            HttpResult httpResult1 = http.GetHtml(item);
            var content = httpResult1?.Html ?? "";
            if (content.Contains("的微信扫描该二维码"))
            {
                result = "二维码和当前账号不匹配";
                return result;
            }
            else if (content.Contains("二维码已失效"))
            {
                result = "二维码已失效";
                return result;
            }
            else
            {
                string urlConfirm = content.Between("confirm=1", ">");
                login_url = "https://login.weixin.qq.com/confirm?confirm=1" + urlConfirm.Replace("\"", "");
                item = new HttpItem()
                {
                    URL = login_url,
                    Method = "POST",
                    Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8",
                    Cookie = httpResult1.Cookie,
                    ContentType = "application/x-www-form-urlencoded",
                    ProxyIp = _Linker.Proxy.ToStrProxy()
                };
                HttpResult httpResult2 = http.GetHtml(item);

                result = httpResult2?.Html;
            }
            if ((result?.Contains("已授权使用你的微信号") ?? false))
            {
                return "授权成功，请在新设备再次点击登录。";
            }
            return "授权失败";
        }

        /// <summary>
        /// 重提数据
        /// </summary>
        /// <returns></returns>
        public virtual async Task<string> WXExtractData(WXTerminal terminal)
        {
            if (!TestProxy(WXCGIUrl.micromsg_bin_secmanualauth))
            {
                return "重提数据失败[代理超时]";
            }
            var environment = new WXEnvironment(terminal);
            var linker = new WXShortLinker(environment.Terminal);
            await linker.InitSession();
            var client = new WXApp(linker, environment);

            var qrcode = await client?.WXGetHelpQrcode(Profile.UserName, Profile.Password);
            if (qrcode.Status == 0)
            {
                return client?.Environment.WeChatData;
            }
            if (qrcode.Message == "获取成功")
            {
                string qrurl = $"https://login.weixin.qq.com/q/{qrcode.UUID}";
                var helpLogin = await WXHelpDeviceLogin(qrurl);
                if (!(helpLogin?.Contains("授权成功") ?? false))
                {
                    return "重提数据失败[无法授权]";
                }
                string returl = $"https://login.weixin.qq.com/cgi-bin/mmwebwx-bin/login?uuid={qrcode.UUID}&r={(DateTime.Now.ToUniversalTime().Ticks - 621355968000000000L) / 10000000}&t=simple_auth/w_qrcode_show&&ticket={qrcode.Ticket}&wechat_real_lang=zh_CN&idc=2&qrcliticket={qrcode.QrCliTicket}";
                HttpHelper http = new HttpHelper();
                HttpItem item = new HttpItem()
                {
                    URL = returl,
                    ProxyIp = _Linker.Proxy.ToStrProxy()
                };
                HttpResult httpResult1 = http.GetHtml(item);

                item = new HttpItem()
                {
                    URL = (httpResult1?.Html ?? "").Between("window.redirect_uri=", ";").Replace("\"", "").Trim(),
                    ProxyIp = _Linker.Proxy.ToStrProxy()
                };
                http.GetHtml(item);

                var newLogin = await client?.WXSecManualAuth(WXLoginChannel.Normal, Profile.UserName, Profile.Password);
                if (newLogin?.baseResponse?.ret == RetConst.MM_OK)
                {
                    return client?.Environment.WeChatData;
                }
                else
                {
                    return "重提数据失败[状态异常]";
                }
            }
            else
            {
                return $"重提数据失败[{qrcode.Message}]";
            }
        }
        #endregion
    }
}
