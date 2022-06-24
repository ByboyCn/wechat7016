using System;

namespace WeChat.Core
{
    /// <summary>
    /// 登陆方式
    /// </summary>
    public enum WXLoginMode
    {
        /// <summary>
        /// 无
        /// </summary>
        None,
        /// <summary>
        /// 人工
        /// </summary>
        Manual,
        /// <summary>
        /// 自动
        /// </summary>
        Auto
    }
    /// <summary>
    /// 登录通道
    /// </summary>
    public enum WXLoginChannel
    {
        /// <summary>
        /// 常规通道
        /// </summary>
        Normal,
        /// <summary>
        /// 二维码通道
        /// </summary>
        Qrcode,
        /// <summary>
        /// 手机通道
        /// </summary>
        Mobile
    }
    /// <summary>
    /// 微信状态
    /// </summary>
    [Serializable]
    public struct WXStatus
    {
        #region 属性
        /// <summary>
        /// 登陆状态码
        /// -1:未登录/已退出
        /// 1:登陆成功
        /// 2:代理超时
        /// 3:实例环境异常（GUID对应实例将自动释放）
        /// 其它:错误码
        /// </summary>
        public int Code;
        /// <summary>
        /// 登陆状态消息
        /// </summary>
        public string Message;
        /// <summary>
        /// 处理URL
        /// </summary>
        public string Url;
        /// <summary>
        /// 处理URL凭证
        /// </summary>
        public string Ticket;
        /// <summary>
        /// 微信服务器
        /// </summary>
        public string Server;
        /// <summary>
        /// 登陆方式
        /// </summary>
        public WXLoginMode LoginMode;
        /// <summary>
        /// 登录通道
        /// </summary>
        public WXLoginChannel LoginChannel;
        #endregion

        #region 构造函数

        #endregion

        #region 重载
        /// <summary>
        /// 判断是否相等
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (!(obj is WXStatus)) return false;
            var target = (WXStatus)obj;
            if (target == null) return false;
            return Code == target.Code;
        }
        /// <summary>
        /// 获取hash码
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Code.GetHashCode();
        }
        /// <summary>
        /// 重载==运算符
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(WXStatus v1, WXStatus v2) { return Equals(v1, v2); }
        /// <summary>
        /// 重载!=运算符
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(WXStatus v1, WXStatus v2) { return !Equals(v1, v2); }
        #endregion
    }
}
