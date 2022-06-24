using Sodao.FastSocket.Client;
using Sodao.FastSocket.Client.Protocol;
using Sodao.FastSocket.SocketBase;
using System;
using System.Diagnostics;

namespace WeChat.Core
{
    /// <summary>
    /// 微信TCP客户端
    /// </summary>
    public class WXSocketClient : SocketClient<WXLongLinkMessage>
    {
        #region 事件
        /// <summary>
        /// 客户端连接成功事件
        /// </summary>
        public event EventHandler<IConnection> OnClientConnected;
        /// <summary>
        /// 客户端连接断开事件
        /// </summary>
        public event EventHandler<IConnection> OnClientDisconnected;
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造微信TCP客户端
        /// </summary>
        /// <param name="protocol"></param>
        public WXSocketClient(IProtocol<WXLongLinkMessage> protocol)
            : base(protocol) { }
        /// <summary>
        /// 构造微信TCP客户端
        /// </summary>
        /// <param name="protocol"></param>
        /// <param name="socketBufferSize"></param>
        /// <param name="messageBufferSize"></param>
        /// <param name="millisecondsSendTimeout"></param>
        /// <param name="millisecondsReceiveTimeout"></param>
        public WXSocketClient(IProtocol<WXLongLinkMessage> protocol, int socketBufferSize, int messageBufferSize, int millisecondsSendTimeout, int millisecondsReceiveTimeout)
            : base(protocol, socketBufferSize, messageBufferSize, millisecondsSendTimeout, millisecondsReceiveTimeout) { }
        #endregion

        #region 重载
        /// <summary>
        /// 连接成功
        /// </summary>
        /// <param name="connection"></param>
        protected override void OnConnected(IConnection connection)
        {
            Debug.WriteLine("连接成功...");
            try { OnClientConnected?.DynamicInvoke(this, connection); } catch { }
            base.OnConnected(connection);
        }
        /// <summary>
        /// 连接断开
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="ex"></param>
        protected override void OnDisconnected(IConnection connection, Exception ex)
        {
            Debug.WriteLine("断开连接...");
            try { OnClientDisconnected?.DynamicInvoke(this, connection); } catch { }
            base.OnDisconnected(connection, ex);
        }
        #endregion
    }
}
