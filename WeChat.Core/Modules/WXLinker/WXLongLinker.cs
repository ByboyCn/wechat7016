using Sodao.FastSocket.Client;
using Sodao.FastSocket.Client.Messaging;
using Sodao.FastSocket.Client.Protocol;
using Sodao.FastSocket.SocketBase;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using WeChat.Core.Protocol;
using WeChat.Core.Protocol.Protos.V2;

namespace WeChat.Core
{
    /// <summary>
    /// 微信长链接消息
    /// </summary>
    public class WXLongLinkMessage : IMessage
    {
        #region 常量
        /// <summary>
        /// 固定头部长度常量
        /// </summary>
        public const short FIXED_HEAD_LENGTH = 0x10;
        /// <summary>
        /// 固定客户端版本号常量
        /// </summary>
        public const short FIXED_CLIENT_VERSION = 0x01;
        #endregion

        #region 属性
        /// <summary>
        /// 封包长度(含包头)，可变
        /// </summary>
        public uint PacketLength => (uint)(0x10 + (Payload?.Length ?? 0));
        /// <summary>
        /// 头部长度,固定值，0x10
        /// </summary>
        public short HeadLength { get; protected set; }
        /// <summary>
        /// 协议版本,固定值，0x01
        /// </summary>
        public short ClientVersion { get; protected set; }
        /// <summary>
        /// 4字节cmd，可变
        /// </summary>
        public uint Cmd { get; set; }
        /// <summary>
        /// 4字节封包编号，可变
        /// </summary>
        public int SeqID { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        public byte[] Payload { get; set; }
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造微信长链接消息
        /// </summary>
        public WXLongLinkMessage()
        {
            HeadLength = FIXED_HEAD_LENGTH;
            ClientVersion = FIXED_CLIENT_VERSION;
        }
        #endregion

        #region 接口
        /// <summary>
        /// 转换成字节数组
        /// </summary>
        /// <returns></returns>
        public byte[] ToByteArray()
        {
            var result = new byte[] { };
            result = result.Concat(PacketLength.ToByteArray(Endian.Big)).ToArray();                      // 4字节封包长度(含包头)，可变
            result = result.Concat(new byte[] { 0x0, 0x10 }).ToArray();                                  // 2字节表示头部长度，固定值，0x10
            result = result.Concat(new byte[] { 0x0, 0x01 }).ToArray();                                  // 2字节表示协议版本，固定值，0x01
            result = result.Concat(Cmd.ToByteArray(Endian.Big)).ToArray();                               // 4字节cmdid，可变
            result = result.Concat(SeqID.ToByteArray(Endian.Big)).ToArray();                             // 4字节封包编号，可变
            result = result.Concat(Payload).ToArray();
            return result;
        }
        /// <summary>
        /// 解析字节数组为对象
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static WXLongLinkMessage Parse(byte[] array)
        {
            return Parse(array, 0, array?.Length ?? 0);
        }
        /// <summary>
        /// 解析字节数组为对象
        /// </summary>
        /// <param name="array"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static WXLongLinkMessage Parse(byte[] array, int offset, int length)
        {
            var index = 0; var result = default(WXLongLinkMessage);
            if ((array?.Length ?? 0) < 0x10) { return result; }
            if (length < 0x10 || length > array.Length) { return result; }
            if (offset < 0 || offset > array.Length) { return result; }

            index += offset; result = new WXLongLinkMessage() { Payload = new byte[length - 0x10] };
            index += 4; result.HeadLength = array.Copy(index, 2).GetInt16(Endian.Big);
            index += 2; result.ClientVersion = array.Copy(index, 2).GetInt16(Endian.Big);
            index += 2; result.Cmd = array.Copy(index, 4).GetUInt32(Endian.Big);
            index += 4; result.SeqID = array.Copy(index, 4).GetInt32(Endian.Big);
            index += 4; Buffer.BlockCopy(array, index, result.Payload, 0, length - index + offset);
            return result;
        }
        #endregion
    }
    /// <summary>
    /// 微信长链接
    /// </summary>
    /// <typeparam name="TSession"></typeparam>
    public class WXLongLinker : WXShortLinker, IWXLinker, IProtocol<WXLongLinkMessage>
    {
        #region 字段
        private ECKeyPair[] _SessionEcdh;
        private byte[] _SessionHash;
        /// <summary>
        /// Socket客户端
        /// </summary>
        protected WXSocketClient _SocketClient;
        /// <summary>
        /// 心跳
        /// </summary>
        protected Timer _HeartTimer;
        #endregion

        #region 属性
        /// <summary>
        /// 默认异步请求号
        /// </summary>
        public int DefaultSyncSeqID { get; set; }
        /// <summary>
        /// 是否异步模式
        /// </summary>
        public bool IsAsync => true;
        #endregion

        #region 事件
        /// <summary>
        /// 新消息触发事件
        /// </summary>
        public event EventHandler<WXLongLinkMessage> OnMessageReachable;
        #endregion

        #region 构造函数
        /// <summary>
        /// 构建长链接
        /// </summary>
        public WXLongLinker()
        {
            _Server.LongServerPort = 8080;
            _Server.LongServerAddress = GetDnsServers("long.weixin.qq.com")?.FirstOrDefault() ?? "long.weixin.qq.com";
            _SocketClient = new WXSocketClient(this);
            _SocketClient.OnClientConnected += _OnLongLinkClientConnected;
            _SocketClient.ReceivedUnknowMessage += _OnReceivedUnknowMessage;
            _SocketClient.TryRegisterEndPoint("WECHAT_LONG_SERVER", new[]
            {
                new IPEndPoint(IPAddress.Parse(_Server.LongServerAddress), _Server.LongServerPort)
            });
            _HeartTimer = new Timer(OnHeartBeat, this, 0, 60 * 1000);
        }
        /// <summary>
        /// 构建长链接
        /// </summary>
        /// <param name="terminal"></param>
        public WXLongLinker(WXTerminal terminal)
        {
            _Server.LongServerPort = 8080;
            _Server.LongServerAddress = GetDnsServers("long.weixin.qq.com")?.FirstOrDefault() ?? "long.weixin.qq.com";
            _SocketClient = new WXSocketClient(this);
            _SocketClient.OnClientConnected += _OnLongLinkClientConnected;
            _SocketClient.ReceivedUnknowMessage += _OnReceivedUnknowMessage;
            _SocketClient.TryRegisterEndPoint("WECHAT_LONG_SERVER", new[]
            {
                new IPEndPoint(IPAddress.Parse(_Server.LongServerAddress), _Server.LongServerPort)
            });
            _HeartTimer = new Timer(OnHeartBeat, this, 0, 60 * 1000);
        }
        /// <summary>
        /// 构建长链接
        /// </summary>
        /// <param name="server">服务器</param>
        /// <param name="session">微信会话</param>
        public WXLongLinker(WXServer server, WXSession session)
            : base(server, session)
        {
            if (_Server.LongServerPort <= 0) { _Server.LongServerPort = 8080; }
            if (_Server.LongServerAddress.IsEmpty()) { _Server.LongServerAddress = GetDnsServers("long.weixin.qq.com")?.FirstOrDefault() ?? "long.weixin.qq.com"; }
            _SocketClient = new WXSocketClient(this);
            _SocketClient.OnClientConnected += _OnLongLinkClientConnected;
            _SocketClient.ReceivedUnknowMessage += _OnReceivedUnknowMessage;
            _SocketClient.TryRegisterEndPoint("WECHAT_LONG_SERVER", new[]
            {
                new IPEndPoint(IPAddress.Parse(_Server.LongServerAddress), _Server.LongServerPort)
            });
            _HeartTimer = new Timer(OnHeartBeat, this, 0, 60 * 1000);
        }
        #endregion

        #region 内部消息处理
        /// <summary>
        /// 未知消息事件处理
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="message"></param>
        private void _OnReceivedUnknowMessage(IConnection connection, WXLongLinkMessage message)
        {
            try { OnMessageReachable?.DynamicInvoke(this, message); } catch { }
        }
        /// <summary>
        /// 连接器连接成功事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="connection"></param>
        private void _OnLongLinkClientConnected(object sender, IConnection connection)
        {
            DefaultSyncSeqID = 0;
            Task.Run(async () => await InitSession());
        }
        #endregion

        #region 虚函数
        /// <summary>
        /// 解长链包
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="readlength"></param>
        /// <returns></returns>
        protected virtual WXLongLinkMessage Parse(ArraySegment<byte> buffer, out int readlength)
        {
            var result = default(WXLongLinkMessage);
            if (buffer.Count < 0x10) { readlength = 0; return result; }
            var packlen = buffer.Array.Copy(buffer.Offset, 4).GetInt32(Endian.Big);
            if (packlen > buffer.Count) { readlength = 0; return result; }
            if (packlen < 0x10) { throw new BadProtocolException("bad wechat protocol"); }

            result = WXLongLinkMessage.Parse(buffer.Array, buffer.Offset, packlen);
            readlength = packlen; return result;
        }
        /// <summary>
        /// 解mmtls包
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="buffer"></param>
        /// <param name="readlength"></param>
        /// <returns></returns>
        public virtual WXLongLinkMessage Parse(IConnection connection, ArraySegment<byte> buffer, out int readlength)
        {
            if (!(buffer.Count > 5 && buffer.Array[1] == 0xf1 && buffer[2] == 0x03) && !_Session.Initialized) { return Parse(buffer, out readlength); }
            var result = default(WXLongLinkMessage); var offset = 0; var pskcount = 0; var data = new ArraySegment<byte>();
            while (buffer.Count - offset > 5 && buffer.Array[offset + 1] == 0xf1 && buffer.Array[offset + 2] == 0x03)
            {
                var datalen = buffer.Array.Skip(offset + 3).Take(2).ToArray().GetInt16(Endian.Big);
                if (buffer.Count - offset < datalen + 5) { break; }
                var item = buffer.Array.Skip(offset).Take(datalen + 5).ToArray();
                offset += item.Length;
                if (item[0] == 0x16)
                {
                    data = data.Concat(item).ToArray();
                    pskcount++;
                    if (pskcount >= 4)
                    {
                        result = new WXLongLinkMessage() { SeqID = 0, Cmd = 0, Payload = data.ToArray() };
                        break;
                    }
                }
                if (item[0] == 0x17)
                {
                    data = data.Concat(_Session.LongLinkUnPack(item)).ToArray();
                    result = Parse(data, out int len);
                    if (len > 0 && result != null) { break; }
                }
            }
            readlength = (result == null ? 0 : offset);
            return result;
        }

        /// <summary>
        /// 长链心跳
        /// </summary>
        /// <param name="state"></param>
        protected virtual void OnHeartBeat(object state)
        {
            var message = new WXLongLinkMessage()
            {
                SeqID = -1,
                Cmd = 6,
                Payload = new byte[0]
            };
            var packets = message.ToByteArray();
            _Session.CallWhen(_Session.Initialized, _ => packets = _Session.LongLinkPack(packets));
            Debug.WriteLine($"连接个数：{_SocketClient.CountConnection()} ，发送心跳数据：{packets.ToString(16, 2)}");
            _SocketClient?.Send(new Request<WXLongLinkMessage>(message.SeqID, "SEND_NOOP_CMDID", packets, 3000,
                err => Debug.WriteLine($"心跳错误：{err.Message}"),
                ret => Debug.WriteLine($"心跳返回：{ret.ToByteArray().ToString(16, 2)}")
                ));
        }
        #endregion

        #region 接口
        /// <summary>
        /// 初始化Mmtls会话
        /// </summary>
        /// <returns></returns>
        public override async Task<bool> InitSession()
        {
            var init_task = new TaskCompletionSource<List<byte[]>>();
            _SocketClient?.Send(new Request<WXLongLinkMessage>(0, "INIT_MMTLS_SESSION", _Session.BuildRequest(_Session.PskKey,out _SessionEcdh, out _SessionHash), 3000,
                error => init_task.TrySetException(error),
                message => init_task.TrySetResult(WXSession.Parse(message.Payload).Item2)));
            var ack_task = init_task.Task.ContinueWith(initact =>
            {
                var ack = _Session.Initialize(initact.Result, _SessionEcdh, _SessionHash);
                if (ack == null)
                {
                    return false;
                }
                _SocketClient.Send(new Packet(ack));
                return true;
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            return await ack_task;
        }
        /// <summary>
        /// 重定向
        /// </summary>
        /// <param name="network"></param>
        /// <returns></returns>
        public override async Task Redirect(NetworkSectResp network)
        {
            var dns = network?.newHostList?.list?.First(t => t.origin == "long.weixin.qq.com")?.substitute;
            var ips = network?.builtinIplist?.longConnectIplist?.Where(t => t.domain.Replace("\0", "") == dns)?.ToArray();
            var end = ips?.Select(t => new IPEndPoint(IPAddress.Parse(t.ip.Replace("\0", "")), (int)t.port))?.FirstOrDefault(t => t.IsReachable());
            if (end != null)
            {
                _Server.LongServerAddress = end.Address.ToString();
                _Server.LongServerPort = end.Port;
                _SocketClient.GetAllRegisteredEndPoint()?.ToList()?.ForEach(t =>
                {
                    try { _SocketClient.UnRegisterEndPoint(t.Key); } catch { }
                });
                _SocketClient.TryRegisterEndPoint("WECHAT_LONG_SERVER", new[] { end });
                Debug.WriteLine($"【长链重定向】地址:[{_Server.ShortServerAddress}:{_Server.ShortServerPort}]");
            }
            await base.Redirect(network);
        }
        /// <summary>
        /// 发送请求
        /// </summary>
        /// <param name="data"></param>
        /// <param name="cgi"></param>
        /// <returns></returns>
        public override async Task<byte[]> Request(byte[] data, WXCGIUrl cgi)
        {
            if (cgi.GetRequestID() == 0) { return await base.Request(data, cgi); }
            var result = new TaskCompletionSource<byte[]>();
            var message = new WXLongLinkMessage()
            {
                SeqID = DefaultSyncSeqID + 1,
                Cmd = cgi.GetRequestID(),
                Payload = data
            };
            Debug.WriteLine($"【长链接】封包号:[{message.SeqID}] 请求号:[{cgi.GetRequestID()}] 请求地址:[{cgi.GetUrl()}] 请求长度:[{data.Length}]");
            var request = message.ToByteArray();
            _Session.CallWhen(_Session.Initialized, _ => request = _Session.LongLinkPack(request));
            _SocketClient.Send(new Request<WXLongLinkMessage>(message.SeqID, $"{cgi.GetUrl()}", request, 3000,
                err => result.TrySetException(err),
                ret => { DefaultSyncSeqID++; result.TrySetResult(ret.Payload); }));
            return await result.Task;
        }
        /// <summary>
        /// 认证确认（登陆后调用一次）
        /// 只有确认后服务器才会直接推送cmdid==122的消息内容到客户端;
        /// 否则服务器只下发cmdid==24的消息通知客户端有新消息,消息内容需要客户端主动调用newsync获取
        /// </summary>
        /// <param name="payload">负荷数据</param>
        /// <returns></returns>
        public virtual async Task<byte[]> Identify(byte[] payload)
        {
            var result = new TaskCompletionSource<byte[]>();
            var message = new WXLongLinkMessage()
            {
                SeqID = -2,
                Cmd = 205,
                Payload = payload
            };
            var packets = message.ToByteArray();
            _Session.CallWhen(_Session.Initialized, _ => packets = _Session.LongLinkPack(packets));
            Debug.WriteLine($"连接个数：{_SocketClient.CountConnection()} ，发送认证数据：{packets.ToString(16, 2)}");
            _SocketClient?.Send(new Request<WXLongLinkMessage>(message.SeqID, "SEND_LONGLINK_IDENTIFY", packets, 3000,
                    err => Debug.WriteLine($"认证确认错误：{err.Message}"),
                    ret => result.TrySetResult(ret.Payload)
                    ));
            return await result.Task;
        }
        #endregion
    }
}
