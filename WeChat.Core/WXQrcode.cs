using System;
using System.Runtime.CompilerServices;
using System.Timers;
using WeChat.Core.Protocol.Protos.V2;

namespace WeChat.Core
{
    /// <summary>
    /// 微信二维码组件
    /// </summary>
    public class WXQrcode : Timer
    {
        #region 枚举
        /// <summary>
        /// 二维码状态类型
        /// </summary>
        public enum QrcodeStatus
        {
            /// <summary>
            /// 初始化
            /// </summary>
            Init = -1,
            /// <summary>
            /// 未扫描
            /// </summary>
            UnScaned = 0,
            /// <summary>
            /// 已扫描
            /// </summary>
            Scaned = 1,
            /// <summary>
            /// 已授权
            /// </summary>
            Authorized = 2,
            /// <summary>
            /// 已过期
            /// </summary>
            Timeout = 3,
            /// <summary>
            /// 已取消
            /// </summary>
            Canceled = 4
        }
        #endregion

        #region 字段
        /// <summary>
        /// 扫码状态
        /// </summary>
        private QrcodeStatus _Status;
        #endregion

        #region 属性
        /// <summary>
        /// 二维码Uuid
        /// </summary>
        public string UUid { get; protected set; }
        /// <summary>
        /// 头像地址
        /// </summary>
        public string HeadUrl { get; protected set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; protected set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; protected set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; protected set; }
        /// <summary>
        /// 二维码Base64
        /// </summary>
        public string Qrcode { get; protected set; }
        /// <summary>
        /// 二维码有效时间
        /// </summary>
        public int ValidTime { get; protected set; }
        /// <summary>
        /// 客户端对象
        /// </summary>
        public IWXApp Client { get; set; }
        /// <summary>
        /// 扫码状态
        /// </summary>
        public QrcodeStatus Status
        {
            get { return _Status; }
            protected set
            {
                if (_Status == value) return;
                _Status = value;
                OnStatusChanged?.DynamicInvoke(this, new EventArgs());
            }
        }
        #endregion

        #region 事件
        /// <summary>
        /// 二维码扫码状态改变事件
        /// </summary>
        public event EventHandler OnStatusChanged;
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造微信二维码组件
        /// </summary>
        public WXQrcode()
        {
            UUid = "";
            HeadUrl = "";
            NickName = "";
            UserName = "";
            Password = "";
            Qrcode = "";
            ValidTime = 0;
            Client = null;
            Status = QrcodeStatus.Init;
            Elapsed += _OnElapsed;
        }
        #endregion

        #region 接口
        /// <summary>
        /// 启动
        /// </summary>
        public new void Start()
        {
            Client?.CallWhen(true, async _ =>
            {
                var result = false;
                if ((Client.Cache.AutoAuthToken?.Length ?? 0) > 0)
                {
                    var response = await Client?.WXTwiceLoginQrcode();
                    if (response?.baseResponse?.ret == RetConst.MM_OK)
                    {
                        UUid = response.uuid;
                        Status = QrcodeStatus.Scaned;
                        result = true;
                    }
                }
                if (!result)
                {
                    var response = await Client?.WXGetLoginQrcode();
                    if (response?.baseResponse?.ret == RetConst.MM_OK)
                    {
                        UUid = response.uuid;
                        Status = QrcodeStatus.UnScaned;
                        Qrcode = response.qRCode.src.Base64Encode();
                        result = true;
                    }
                }
            });
            base.Start();
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private void _OnElapsed(object sender, ElapsedEventArgs e)
        {
            Client?.CallWhen(!UUid.IsEmpty() && Client.Status.Code <= 0 && Status < QrcodeStatus.Authorized, async _ =>
            {
                var response = await Client?.WXCheckLoginQrcode(UUid);
                var qrcode = await Client?.WXCheckLoginQrcodeDetail(response);
                if (qrcode != null)
                {
                    ValidTime = qrcode.EffectiveTime;
                    Status = (QrcodeStatus)(qrcode.state);
                    if (Status == QrcodeStatus.Scaned)
                    {
                        HeadUrl = qrcode.headImgUrl;
                        NickName = qrcode.nickName;
                    }
                    if (Status == QrcodeStatus.Authorized)
                    {
                        Password = qrcode.wxnewpass;
                        UserName = qrcode.wxid;
                        await Client?.WXSecManualAuth(WXLoginChannel.Qrcode, UserName, Password);
                        System.Threading.ThreadPool.UnsafeQueueUserWorkItem(p => Stop(), this);
                    }
                }
            });
        }
        #endregion
    }
}
