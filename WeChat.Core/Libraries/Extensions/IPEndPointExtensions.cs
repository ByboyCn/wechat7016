using System.Net.Sockets;

namespace System.Net
{
    public static class IPEndPointExtensions
    {
        /// <summary>
        /// 地址是否可连通
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool IsReachable(this IPEndPoint target)
        {
            var result = true;
            if (target == null) { return false; }
            using (Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                try { sock.Connect(target); } catch { result = false; } finally { sock.Close(); }
            }
            return result;
        }
    }
}
