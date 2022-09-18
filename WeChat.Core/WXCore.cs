using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using WeChat.Core.Protocol;
using WeChat.Core.Protocol.Protos.V2;

namespace WeChat.Core
{
    /// <summary>
    /// 微信客户端内核
    /// </summary>
    public interface IWXCore : IDisposable
    {
        /// <summary>
        /// 获取缓存对象
        /// </summary>
        WXCache Cache { get; }
        /// <summary>
        /// 获取连接
        /// </summary>
        IWXLinker Linker { get; }
        /// <summary>
        /// 发送请求
        /// </summary>
        /// <typeparam name="TResponse">响应类型</typeparam>
        /// <param name="request">请求</param>
        /// <param name="cgi">路由</param>
        /// <returns></returns>
        Task<TResponse> Request<TResponse>(byte[] request, WXCGIUrl cgi) where TResponse : class;
    }
    /// <summary>
    /// 微信客户端内核
    /// </summary>
    public class WXCore : Component, IWXCore
    {
        #region 字段
        /// <summary>
        /// 缓存
        /// </summary>
        protected WXCache _Cache;
        /// <summary>
        /// 连接
        /// </summary>
        protected IWXLinker _Linker;
        #endregion

        #region 属性
        /// <summary>
        /// 获取缓存对象
        /// </summary>
        public WXCache Cache => _Cache;
        /// <summary>
        /// 获取连接
        /// </summary>
        public IWXLinker Linker => _Linker;
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造微信客户端内核
        /// </summary>
        /// <param name="terminal">终端</param>
        /// <param name="linker">连接器</param>
        public WXCore(WXTerminal? terminal, IWXLinker linker)
        {
            var brid = new HyBridEcdh();
            _Linker = linker;
            _Cache = new WXCache()
            {
                Terminal = terminal,
                ReportCcdContext = 0,
                Uin = 0,
                Scene = 0,
                Cookie = "",
                EcdhKey = new byte[0],
                HybridEcdhPubKey = brid.Ecdh.PublicKey,
                HybridEcdhPriKey = brid.Ecdh.PrivateKey,
                SyncKey = new byte[0],
                SessionKey = (new Random()).NextBytes(16),
                ClientSessionKey = new byte[0],
                ServerSessionKey = new byte[0],
                AutoAuthToken = new byte[0],
                AutoAuthTicket = ""
            };
        }
        /// <summary>
        /// 构造微信客户端内核
        /// </summary>
        /// <param name="linker">连接器</param>
        /// <param name="cache">缓存</param>
        public WXCore(IWXLinker linker, WXCache cache)
        {
            _Linker = linker;
            _Cache = cache;
        }
        #endregion

        #region 组包/解包
        /// <summary>
        /// 构建包头
        /// </summary>
        /// <param name="body">BODY</param>
        /// <param name="cgi">CGI</param>
        /// <param name="version">微信版本，PATCH MMTLS：version & 0xF0000000 | 0x06060222</param>
        /// <param name="ziped">是否压缩</param>
        /// <param name="len_before_zip">压缩前长度</param>
        /// <param name="len_after_zip">压缩后长度</param>
        /// <param name="crc32">校验和</param>
        /// <param name="encoder_type">编码器类型</param>
        /// <param name="encoder_version">编码器版本</param>
        /// <returns></returns>
        protected virtual byte[] Pack(byte[] body, int cgi, int version, bool ziped, int len_before_zip, int len_after_zip, uint crc32, byte encoder_type, int encoder_version)
        {
            var cook = _Cache.Cookie?.ToByteArray(16, 2) ?? new byte[15];
            var result = new List<byte>(new byte[] { 0xBF });                                                           // 移动端标志位
            result = result.Concat(new byte[] { (byte)(ziped ? 0x1 : 0x2) }).ToList();                                  // 压缩标志(压缩：1，不压缩：2)
            result = result.Concat(new byte[] { (byte)((encoder_type << 4) + cook.Length) }).ToList();                  // 加密算法(前4bits), RSA加密(7)AES(5)HyBridEcdh(12)AESGCM(13)
            result = result.Concat(version.ToByteArray(Endian.Big)).ToList();                                           // 微信版本
            result = result.Concat(_Cache.Uin.ToByteArray(Endian.Big)).ToList();                                        // UIN
            result = result.Concat(cook).ToList();                                                                      // Cookie
            result = result.Concat(cgi.ToVariant()).ToList();                                                           // CGI
            result = result.Concat(len_before_zip.ToVariant()).ToList();                                                // 压缩前长度
            result = result.Concat(len_after_zip.ToVariant()).ToList();                                                 // 压缩后长度
            result = result.Concat(encoder_version.ToVariant()).ToList();                                               // 编码器版本
            result = result.Concat(new byte[] { _Cache.Terminal.GetTerminalFlag() }).ToList();                          // 终端标志
            result = result.Concat(crc32.ToVariant()).ToList();                                                         // CRC32校验
            result = result.Concat(new byte[] { _Cache.Terminal.GetFixFlag() }).ToList();                               // 固定标志
            result = result.Concat(body.SignRqt().ToVariant()).ToList();                                                // RQT
            result = result.Concat(new byte[] { 0x00 }).ToList();                                                       // 组包结束
            result[1] += (byte)(result.Count << 2);                                                                     // 更新总长度
            return result.Concat(body).ToArray();
        }
        /// <summary>
        /// 计算包头校验和
        /// </summary>
        /// <param name="pb"></param>
        /// <param name="uin"></param>
        /// <param name="ecdhkey"></param>
        /// <returns></returns>
        protected virtual uint CheckHeadCrc(byte[] pb, uint uin, byte[] ecdhkey)
        {
            var buin = uin.ToByteArray(Endian.Big);
            var bmd5 = buin.Concat(ecdhkey).ToArray().MD5();
            var bsrc = pb.Length.ToByteArray(Endian.Big);
            bmd5 = bsrc.Concat(ecdhkey).Concat(bmd5).ToArray().MD5();
            bsrc = bmd5.Concat(pb).ToArray();
            return bsrc.Crc32();
        }
        /// <summary>
        /// 解包
        /// </summary>
        /// <param name="package">包</param>
        /// <returns>包数据结构</returns>
        protected virtual WXPacket Unpack(byte[] package)
        {
            var index = 0; var len = 0;
            var result = new WXPacket() { Body = new byte[] { } };
            result.Head.Uin = 0;
            result.Head.Cookie = null;

            if (package.Length < 0x20) { return result; }
            if (0xbf == package[index]) { index++; }                            //标志

            var header_len = package[index] >> 2;                               //解析包头长度(前6bits)
            result.Head.Ziped = (1 == (package[index] & 0x3)) ? true : false;   //是否使用压缩(后2bits)
            index++;

            var cookie_len = package[index] & 0xF;                              //cookie长度(后4 bits)
            result.Head.Decrypt = package[index] >> 4;                          //解密算法(前4 bits)(05:aes / 07:rsa)(仅握手阶段的发包使用rsa公钥加密,由于没有私钥收包一律aes解密)
            index++;

            result.Head.Version = package.Copy(index, 4).GetInt32(Endian.Big);  //版本(4字节)
            index += 4;

            result.Head.Uin = package.Copy(index, 4).GetUInt32(Endian.Big);     //登录包 保存uin
            index += 4;

            if (cookie_len > 0xf) { return result; }                            //刷新cookie(超过15字节说明协议头已更新)
            if (cookie_len > 0 && cookie_len <= 0xf)
            {
                result.Head.Cookie = package.Copy(index, cookie_len).ToString(16, 2);
                index += cookie_len;
            }

            len = package.Copy(index, 5).DecodeVByte32(0, ref result.Head.CGI); //CGI,变长整数,无视
            index += len;

            var protobuf_len = 0;
            len = package.Copy(index, 5).DecodeVByte32(0, ref protobuf_len);    //解压后protobuf长度，变长整数
            index += len;

            var protobuf_compress_len = 0;
            len = package.Copy(index, 5).DecodeVByte32(0, ref protobuf_compress_len);//压缩后(加密前)的protobuf长度，变长整数
            index += len;

            if (header_len < package.Length) { result.Body = package.Copy(header_len, package.Length - header_len); }//解包完毕,取包体
            return result;
        }
        #endregion

        #region 发送请求/保存响应
        /// <summary>
        /// 发送请求
        /// </summary>
        /// <param name="data">包数据</param>
        /// <param name="cgi">路由</param>
        /// <param name="retry">重试次数</param>
        /// <returns></returns>
        protected virtual async Task<byte[]> OnRequest(byte[] data, WXCGIUrl cgi, int retry = 3)
        {
            var result = default(byte[]);
            try { result = await _Linker?.Request(data, cgi); } catch { if (retry > 0) { result = await OnRequest(data, cgi, --retry); } }
            return result;
        }
        /// <summary>
        /// 保存响应
        /// </summary>
        /// <param name="data">响应PB对象</param>
        /// <param name="cgi">路由</param>
        /// <param name="uin">uin</param>
        /// <param name="cookie">cookie</param>
        /// <returns></returns>
        protected virtual async Task OnResponse(object data, WXCGIUrl cgi, uint uin, string cookie)
        {
            data?.CallWhen(data is UnifyAuthResponse, r =>
            {
                var t = r as UnifyAuthResponse;
                t?.CallWhen(t?.baseResponse?.ret == RetConst.MM_ERR_IDC_REDIRECT, async _ =>
                {
                    await _Linker.Redirect(t.dnsInfo);
                });
                t?.CallWhen(t?.baseResponse?.ret == RetConst.MM_OK, _ =>
                {
                    _Cache.Uin = uin;
                    _Cache.Cookie = cookie;
                    _Cache.ClientSessionKey = t.authParam.clientSessionKey.buffer;
                    _Cache.ServerSessionKey = t.authParam.serverSessionKey.buffer;
                    _Cache.AutoAuthToken = t.authParam.autoAuthKey.buffer;
                    _Cache.AutoAuthTicket = t.authParam.authTicket;
                    _Cache.Scene = 0;
                });
            });
            data?.CallWhen(cgi == WXCGIUrl.micromsg_bin_getloginqrcode, r =>
            {
                var t = r as GetLoginQRCodeResponse;
                t?.CallWhen(t?.baseResponse?.ret == RetConst.MM_OK, _ => _Cache.SessionKey = _.AESKey.key);
            });
            data?.CallWhen(cgi == WXCGIUrl.micromsg_bin_pushloginurl, r =>
            {
                var t = r as PushLoginURLResponse;
                t?.CallWhen(t?.baseResponse?.ret == RetConst.MM_OK, _ => _Cache.SessionKey = _.Notifykey.key);
            });
            data?.CallWhen(cgi == WXCGIUrl.micromsg_bin_newinit, r =>
            {
                var t = r as Protocol.Protos.NewInitResponse;
                t?.CallWhen(t?.BaseResponse.Ret == (int)RetConst.MM_OK, _ => _Cache.SyncKey = t.CurrentSynckey.SerializeToProtoBuf());
            });
            data?.CallWhen(cgi == WXCGIUrl.micromsg_bin_newsync, r =>
            {
                var t = r as NewSyncResponse;
                t?.CallWhen(t?.ret == (int)RetConst.MM_OK, _ =>
                {
                    _Cache.SyncKey = _.sync_key;
                    var message = new WXMessage();
                    t?.SaveSyncResult(ref message);
                    var msg = message?.AddMsgs?.FirstOrDefault(m => m?.FromUserName.String == "weixin" && (bool)(m?.Content.String.StartsWith("<sysmsg type=\"ClientCheckGetExtInfo\">")));
                    if (msg != null) { _Cache.ReportCcdContext = msg.Content.String.GetXmlNodeInnerText("sysmsg/ClientCheckGetExtInfo/ReportContext").ToInt32().Value; }
                });
            });
            data?.CallWhen(cgi == WXCGIUrl.micromsg_bin_mmsnssync, r =>
            {
                var t = r as Protocol.Protos.SnsSyncResponse;
                t?.CallWhen(t?.BaseResponse?.Ret == (int)RetConst.MM_OK, _ => _Cache.SyncKey = _.KeyBuf.Buffer);
            });
            data?.CallWhen(cgi == WXCGIUrl.micromsg_bin_newsetpasswd, r =>
            {
                var t = r as Protocol.Protos.NewSetPasswdResponse;
                t?.CallWhen(t?.BaseResponse?.Ret == (int)RetConst.MM_OK, _ => _Cache.AutoAuthToken = _.AutoAuthKey.Buffer);
            });
            await Task.CompletedTask;
        }
        #endregion

        #region 接口
        /// <summary>
        /// 发送请求
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="request"></param>
        /// <param name="cgi"></param>
        /// <returns></returns>
        public virtual async Task<TResponse> Request<TResponse>(byte[] request, WXCGIUrl cgi) where TResponse : class
        {
            var brid = default(HyBridEcdhData);
            var result = default(TResponse);
            var cryptor = default(HyBridEcdh);
            var encoder = cgi.GetEncode();
            request?.CallWhen(request.Length > 0, _ =>
            {
                request?.CallWhen(encoder == WXEncode.RSA, _ =>
                {
                    int len_before_zip = request.Length, len_after_zip = request.Length;
                    var rsa_version = _Cache.Terminal.GetRsaVersion();
                    request = request.RSAEncrypt(rsa_version.GetKey().ToByteArray(16, 2), rsa_version.GetExponent());
                    request = Pack(request, (int)cgi, _Cache.Terminal.GetWeChatVersion().Code, false, len_before_zip, len_after_zip, 0, (byte)(cgi.GetEncode()), (int)rsa_version);
                });
                request?.CallWhen(encoder == WXEncode.HYBRID_ECDH, _ =>
                {
                    int len_before_zip = request.Length, len_after_zip = request.Length;
                    cryptor = new HyBridEcdh(_Cache.HybridEcdhPriKey, _Cache.HybridEcdhPubKey);
                    brid = cryptor.Encrypt(request, null);
                    request = new HybridEcdhRequest()
                    {
                        Type = 1,
                        SecECDHKey = new SecEcdhKey
                        {
                            key = cryptor.Ecdh.PublicKey,
                            nid = (int)cryptor.Ecdh.Curve
                        },
                        RandomKeyData = brid.EncryptKeyData,
                        RandomKeyExtendData = brid.EncryptKeyExtendData,
                        EncyptData = brid.EncryptData
                    }.SerializeToProtoBuf();
                    request = Pack(request, (int)cgi, _Cache.Terminal.GetWeChatVersion().Code, false, len_before_zip, len_after_zip, 0, (byte)(cgi.GetEncode()), 10003);
                });
                request?.CallWhen(encoder == WXEncode.AES, _ =>
                {
                    var crc = CheckHeadCrc(request, _Cache.Uin, _Cache.EcdhKey);
                    var zip = request.ZIPCompress();
                    var len_before_zip = request.Length;
                    var len_after_zip = zip.Length;
                    request = Pack(zip.AESEncrypt(_Cache.SessionKey), (int)cgi, _Cache.Terminal.GetWeChatVersion().Code, true, len_before_zip, len_after_zip, crc, (byte)(cgi.GetEncode()), 0);
                });
                request?.CallWhen(encoder == WXEncode.AESGCM, _ =>
                {
                    var random = new Random();
                    var nonce = random.NextBytes(12);
                    var len_before_zip = request.Length;
                    var crc = CheckHeadCrc(request, _Cache.Uin, _Cache.EcdhKey);
                    request = request.ZIPCompress().AESGCMEncrypt(_Cache.ClientSessionKey, nonce, null).InsertLast(nonce, 16);
                    var len_after_zip = request.Length;
                    request = Pack(request, (int)cgi, _Cache.Terminal.GetWeChatVersion().Code, false, len_before_zip, len_after_zip, crc, (byte)(cgi.GetEncode()), 0);
                });
            });
            var respose = await OnRequest(request, cgi);
            respose?.CallWhen(respose.Length > 0x20, async _ =>
            {
                var packet = Unpack(respose);
                respose = packet.Body;
                respose?.CallWhen(packet.Head.Decrypt == (int)WXEncode.HYBRID_ECDH, _ =>
                {
                    try
                    {
                        var po = respose?.DeserializeFromProtoBuf<HybridEcdhResponse>();
                        respose = cryptor.Decrypt(po.DecryptData, po.SecECDHKey.key, brid.HashFinal);
                    }
                    catch (Exception)
                    {
                    }
                });
                respose?.CallWhen(packet.Head.Decrypt == (int)WXEncode.AES, _ =>
                {
                    try
                    {
                        respose = respose.AESDecrypt(_Cache.SessionKey);
                    }
                    catch (Exception)
                    {
                    }
                });
                respose?.CallWhen(packet.Head.Decrypt == (int)WXEncode.AESGCM, _ =>
                {
                    try
                    {
                        respose = respose.AESGCMDecrypt(_Cache.ServerSessionKey).ZIPDECompress();
                    }
                    catch (Exception)
                    {
                    }
                });
                respose?.CallWhen(packet.Head.Ziped, _ =>
                {
                    try
                    {
                        respose = respose.ZIPDECompress();
                    }
                    catch (Exception)
                    {
                    }
                });
                result = respose?.DeserializeFromProtoBuf<TResponse>();
                await OnResponse(result, cgi, packet.Head.Uin, packet.Head.Cookie);
            });
            return result;
        }
        #endregion
    }
}
