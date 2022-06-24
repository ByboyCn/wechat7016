using System;
using System.Threading.Tasks;
using WeChat.Core.Protocol;
using WeChat.Core.Protocol.Protos.V2;

namespace WeChat.Core
{
    public partial interface IWXApp
    {
        /// <summary>
        /// 获取收款二维码
        /// </summary>
        /// <returns></returns>
        Task<F2FQrcodeResponse> WXF2FQrcode();
        /// <summary>
        /// 获取自定义金额收款码
        /// </summary>
        /// <param name="fee">金额，单位分，比如一块就是100</param>
        /// <param name="description">收款备注</param>
        /// <returns></returns>
        Task<TenPayResponse> WXTransferSetF2FFee(uint fee, string description);
        /// <summary>
        /// 查询绑定的银行卡信息
        /// </summary>
        /// <returns></returns>
        Task<TenPayResponse> WXBindQuery();
        /// <summary>
        /// 创建转账
        /// </summary>
        /// <param name="username">对方用户名</param>
        /// <param name="fee">金额，单位：分</param>
        /// <param name="description">描述，如：转账</param>
        /// <returns></returns>
        Task<TenPayResponse> WXCreatePreTransfer(string username, uint fee, string description);
        /// <summary>
        /// 确认转账
        /// </summary>
        /// <param name="bankType">银行类型</param>
        /// <param name="bankSerial">银行卡ID</param>
        /// <param name="reqKey">创建转账票据</param>
        /// <param name="payPassword">支付密码</param>
        /// <returns></returns>
        Task<TenPayResponse> WXConfirmPreTransfer(string bankType, string bankSerial, string reqKey, string payPassword);
        /// <summary>
        /// 查询收款状态
        /// </summary>
        /// <param name="transferid"></param>
        /// <param name="transcationid"></param>
        /// <param name="invalidtime"></param>
        /// <returns></returns>
        Task<TenPayResponse> WXTransferQuery(string transferid, string transcationid, string invalidtime);
        /// <summary>
        /// 确认收款
        /// </summary>
        /// <param name="transferid"></param>
        /// <param name="transcationid"></param>
        /// <param name="invalidtime"></param>
        /// <returns></returns>
        Task<TenPayResponse> WXTransferConfirm(string transferid, string transcationid, string invalidtime);
        /// <summary>
        /// 腾讯支付
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="req_text"></param>
        /// <param name="req_text_wx"></param>
        /// <returns></returns>
        Task<TenPayResponse> WXTenPay(enMMTenPayCgiCmd type, string req_text = "", string req_text_wx = "");
        /// <summary>
        /// 创建红包
        /// </summary>
        /// <param name="type">红包类型：0普通红包，1拼手气红包</param>
        /// <param name="username">对方用户名</param>
        /// <param name="from">0个人红包，1群红包，3分享红包</param>
        /// <param name="count">红包个数，必须大于等于1</param>
        /// <param name="amount">红包金额，必须大于等于1，单位：分</param>
        /// <param name="content">红包语 如: 恭喜发财，大吉大利</param>
        /// <returns></returns>
        Task<HongBaoResponse> WXCreateRedPacket(uint type, string username, uint from, uint count, uint amount, string content);
        /// <summary>
        /// 接收红包
        /// </summary>
        /// <param name="channelId"></param>
        /// <param name="msgType"></param>
        /// <param name="nativeUrl"></param>
        /// <param name="sendId"></param>
        /// <param name="ver"></param>
        /// <returns></returns>
        Task<HongBaoResponse> WXReceiveRedPacket(string channelId, int msgType, string nativeUrl, string sendId, string ver);

        /// <summary>
        /// 接收企业红包
        /// </summary>
        /// <param name="channelId"></param>
        /// <param name="msgType"></param>
        /// <param name="nativeUrl"></param>
        /// <param name="sendId"></param>
        /// <param name="groupName"></param>
        /// <returns></returns>
        Task<HongBaoResponse> WXeceiveunionhbRedPacket(string channelId, int msgType, string nativeUrl, string sendId, string groupName);
        /// <summary>
        /// 打开企业红包
        /// </summary>
        /// <param name="channelId"></param>
        /// <param name="msgType"></param>
        /// <param name="nativeUrl"></param>
        /// <param name="sendId"></param>
        /// <param name="sendUserName"></param>
        /// <param name="timingIdentifier"></param>
        /// <param name="ver"></param>
        /// <returns></returns>
        Task<HongBaoResponse> WXOpenunionhbRedPacket(string channelId, int msgType, string nativeUrl, string sendId, string sendUserName, string timingIdentifier, string ver);
        /// <summary>
        /// 打开红包
        /// </summary>
        /// <param name="channelId"></param>
        /// <param name="msgType"></param>
        /// <param name="nativeUrl"></param>
        /// <param name="sendId"></param>
        /// <param name="sendUserName"></param>
        /// <param name="timingIdentifier"></param>
        /// <param name="ver"></param>
        /// <returns></returns>
        Task<HongBaoResponse> WXOpenRedPacket(string channelId, int msgType, string nativeUrl, string sendId, string sendUserName, string timingIdentifier, string ver);
        /// <summary>
        /// 查看红包
        /// </summary>
        /// <param name="channelId"></param>
        /// <param name="msgType"></param>
        /// <param name="nativeUrl"></param>
        /// <param name="sendId"></param>
        /// <param name="offset">偏移，第一页：0，第二页：11，第三页：22</param>
        /// <param name="limit">固定11</param>
        /// <returns></returns>
        Task<HongBaoResponse> WXQueryRedPacket(string channelId, int msgType, string nativeUrl, string sendId, uint offset = 0, uint limit = 11);


        /// <summary>
        /// 查看企业红包
        /// </summary>
        /// <param name="channelId"></param>
        /// <param name="msgType"></param>
        /// <param name="nativeUrl"></param>
        /// <param name="sendId"></param>
        /// <param name="offset">偏移，第一页：0，第二页：11，第三页：22</param>
        /// <param name="limit">固定11</param>
        /// <returns></returns>
        Task<HongBaoResponse> WXQrydetailunionhbRedPacket(string channelId, int msgType, string nativeUrl, string sendId, uint offset = 0, uint limit = 11);

    }
    public partial class WXApp
    {
        /// <summary>
        /// 获取收款二维码
        /// </summary>
        /// <returns></returns>
        public virtual async Task<F2FQrcodeResponse> WXF2FQrcode()
        {
            return await Request<F2FQrcodeResponse>(new F2FQrcodeRequest()
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
            }.SerializeToProtoBuf(), WXCGIUrl.mmpay_bin_f2fqrcode);
        }

        /// <summary>
        /// 获取自定义金额收款码
        /// </summary>
        /// <param name="fee">金额，单位分，比如一块就是100</param>
        /// <param name="description">收款备注</param>
        /// <returns></returns>
        public virtual async Task<TenPayResponse> WXTransferSetF2FFee(uint fee, string description)
        {
            var req_text = $"delay_confirm_flag=0&desc={description}&fee={fee}&fee_type=CNY&pay_scene=31&receiver_name={_Profile.UserName}&scene=31&transfer_scene=2";
            req_text += $"&WCPaySign={req_text.WXPaySign()}";
            return await WXTenPay(enMMTenPayCgiCmd.MMTENPAY_CGICMD_GET_FIXED_AMOUNT_QRCODE, req_text);
        }

        /// <summary>
        /// 查询绑定的银行卡信息
        /// </summary>
        /// <returns></returns>
        public virtual async Task<TenPayResponse> WXBindQuery()
        {
            return await WXTenPay(enMMTenPayCgiCmd.MMTENPAY_CGICMD_BIND_QUERY_NEW);
        }

        /// <summary>
        /// 创建转账
        /// </summary>
        /// <param name="username">对方用户名</param>
        /// <param name="fee">金额，单位：分</param>
        /// <param name="description">描述，如：转账</param>
        /// <returns></returns>
        public virtual async Task<TenPayResponse> WXCreatePreTransfer(string username, uint fee, string description)
        {
            var req_text = $"delay_confirm_flag=0&desc={description}&fee={fee}&fee_type=CNY&pay_scene=31&receiver_name={username}&scene=31&transfer_scene=2";
            req_text += $"&WCPaySign={req_text.WXPaySign()}";
            return await WXTenPay(enMMTenPayCgiCmd.MMTENPAY_CGICMD_GEN_PRE_TRANSFER, req_text);
        }

        /// <summary>
        /// 确认转账
        /// </summary>
        /// <param name="bankType">银行类型</param>
        /// <param name="bankSerial">银行卡ID</param>
        /// <param name="reqKey">创建转账票据</param>
        /// <param name="payPassword">支付密码</param>
        /// <returns></returns>
        public virtual async Task<TenPayResponse> WXConfirmPreTransfer(string bankType, string bankSerial, string reqKey, string payPassword)
        {
            var req_text = $"auto_deduct_flag=0&bank_type={bankType}&bind_serial={bankSerial}&busi_sms_flag=0&flag=3&passwd={reqKey}&pay_scene=37&req_key={payPassword}&use_touch=0";
            req_text += $"&WCPaySign={req_text.WXPaySign()}";
            return await WXTenPay(enMMTenPayCgiCmd.MMTENPAY_CGICMD_AUTHEN, req_text);
        }

        /// <summary>
        /// 查询收款状态
        /// </summary>
        /// <param name="transferid"></param>
        /// <param name="transcationid"></param>
        /// <param name="invalidtime"></param>
        /// <returns></returns>
        public virtual async Task<TenPayResponse> WXTransferQuery(string transferid, string transcationid, string invalidtime)
        {
            var req_text = $"invalid_time={invalidtime}&trans_id={transferid}&transfer_id={transcationid}";
            req_text += $"&WCPaySign={req_text.WXPaySign()}";
            return await WXTenPay(enMMTenPayCgiCmd.MMTENPAY_CGICMD_QUERY_TRANSFER_STATUS, req_text);
        }

        /// <summary>
        /// 确认收款
        /// </summary>
        /// <param name="transferid"></param>
        /// <param name="transcationid"></param>
        /// <param name="invalidtime"></param>
        /// <returns></returns>
        public virtual async Task<TenPayResponse> WXTransferConfirm(string transferid, string transcationid, string invalidtime)
        {
            var req_text = $"invalid_time={invalidtime}&op=confirm&trans_id={transferid}&transaction_id={transcationid}&username={_Profile.UserName}";
            req_text += $"&WCPaySign={req_text.WXPaySign()}";
            return await WXTenPay(enMMTenPayCgiCmd.MMTENPAY_CGICMD_TRANSFER_CONFIRM, req_text);
        }

        /// <summary>
        /// 腾讯支付
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="req_text"></param>
        /// <param name="req_text_wx"></param>
        /// <returns></returns>
        public virtual async Task<TenPayResponse> WXTenPay(enMMTenPayCgiCmd type, string req_text = "", string req_text_wx = "")
        {
            return await Request<TenPayResponse>(new TenPayRequest()
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
                cgiCmd = type,
                outPutType = 1,
                reqText = new SKBuiltinString_S { buffer = req_text, iLen = (uint)req_text.Length },
                reqTextWx = new SKBuiltinString_S { buffer = req_text_wx, iLen = (uint)req_text_wx.Length }
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_tenpay);
        }

        /// <summary>
        /// 创建红包
        /// </summary>
        /// <param name="type">红包类型：0普通红包，1拼手气红包</param>
        /// <param name="username">对方用户名</param>
        /// <param name="from">0个人红包，1群红包，3分享红包</param>
        /// <param name="count">红包个数，必须大于等于1</param>
        /// <param name="amount">红包金额，必须大于等于1，单位：分</param>
        /// <param name="content">红包语 如: 恭喜发财，大吉大利</param>
        /// <returns></returns>
        public virtual async Task<HongBaoResponse> WXCreateRedPacket(uint type, string username, uint from, uint count, uint amount, string content)
        {
            var req_text = $"city=Guangzhou&hbType={type}&headImg=&inWay={from}&needSendToMySelf=0&nickName={_Profile.NickName.UrlEncode()}&perValue={amount}&province=Guangdong&receiveNickName=&sendUserName={_Profile.UserName}&totalAmount={amount * count}&totalNum={count}&username={username}&wishing={content.UrlEncode()}";
            return await Request<HongBaoResponse>(new HongBaoRequest()
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
                cgiCmd = 0,
                outPutType = 0,
                reqText = new SKBuiltinString_S { buffer = req_text, iLen = (uint)req_text.Length }
            }.SerializeToProtoBuf(), WXCGIUrl.mmpay_bin_requestwxhb);
        }

        /// <summary>
        /// 接收红包
        /// </summary>
        /// <param name="channelId"></param>
        /// <param name="msgType"></param>
        /// <param name="nativeUrl"></param>
        /// <param name="sendId"></param>
        /// <param name="ver"></param>
        /// <returns></returns>
        public virtual async Task<HongBaoResponse> WXReceiveRedPacket(string channelId, int msgType, string nativeUrl, string sendId, string ver)
        {
            var req_text = $"agreeDuty=1&inWay=1&channelId={channelId}&msgType={msgType}&nativeUrl={nativeUrl.UrlEncode()}&sendId={sendId}&ver={ver}";
            return await Request<HongBaoResponse>(new HongBaoRequest()
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
                cgiCmd = 3,
                outPutType = 1,
                reqText = new SKBuiltinString_S { buffer = req_text, iLen = (uint)req_text.Length }
            }.SerializeToProtoBuf(), WXCGIUrl.mmpay_bin_receivewxhb);
        }

        /// <summary>
        /// 接收企业红包
        /// </summary>
        /// <param name="channelId"></param>
        /// <param name="msgType"></param>
        /// <param name="nativeUrl"></param>
        /// <param name="sendId"></param>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public virtual async Task<HongBaoResponse> WXeceiveunionhbRedPacket(string channelId, int msgType, string nativeUrl, string sendId, string groupName)
        {

            //group_name=21963598927%40chatroom&inWay=0&msgType=1&nativeUrl=wxpay%3A%2F%2Fc2cbizmessagehandler%2Fhongbao%2Freceivehongbao%3Fmsgtype%3D1%26channelid%3D1%26sendid%3D1800008896202102266252161823003%26ver%3D2%26sign%3DAARxHbYBAAABAAAAAABC4EjlqytOPbdJQ1k4YCAAAAD5K3H1P3TTsgLxNwDzPyfEp2uvjYg0WGAGRbvB%252BrLW1DpaM458%252FpsPFZYmNcKWotIUr0HDN%252BzhwR78C91D%252BCC%252FIBl%252FcH7SU0w8zZl5nJJVFV40%252FUgqp49wReFVFex2jeaZtx1S2o%252B2dAl4moI7q67Tt9e92%252F0NJ6oQXnsl2Q%253D%253D&province=Cathedral&sendId=1800008896202102266252161823003&union_source=0
            var req_text = $"agreeDuty=0&channelId={channelId}&group_name={groupName}&inWay=0&msgType={msgType}&nativeUrl={nativeUrl.UrlEncode()}&sendId={sendId}&union_source=0";
            return await Request<HongBaoResponse>(new HongBaoRequest()
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
                cgiCmd = 4536,
                outPutType = 1,
                reqText = new SKBuiltinString_S { buffer = req_text, iLen = (uint)req_text.Length }
            }.SerializeToProtoBuf(), WXCGIUrl.mmpay_bin_receiveunionhb);
        }

        /// <summary>
        /// 打开红包
        /// </summary>
        /// <param name="channelId"></param>
        /// <param name="msgType"></param>
        /// <param name="nativeUrl"></param>
        /// <param name="sendId"></param>
        /// <param name="sendUserName"></param>
        /// <param name="timingIdentifier"></param>
        /// <param name="ver"></param>
        /// <returns></returns>
        public virtual async Task<HongBaoResponse> WXOpenunionhbRedPacket(string channelId, int msgType, string nativeUrl, string sendId, string sendUserName, string timingIdentifier, string ver)
        {
            //var req_text = $"channelId={channelId}&msgType={msgType}&nativeUrl={nativeUrl.UrlEncode()}&sendId={sendId}&sessionUserName={sendUserName}&timingIdentifier={timingIdentifier}&ver={ver}";
            var req_text = $"channelId={channelId}&msgType={msgType}&nativeUrl={nativeUrl.UrlEncode()}&sendId={sendId}&sessionUserName={sendUserName}&timingIdentifier={timingIdentifier}&union_source=0";
            return await Request<HongBaoResponse>(new HongBaoRequest()
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
                cgiCmd = 5148,
                outPutType = 1,
                reqText = new SKBuiltinString_S { buffer = req_text, iLen = (uint)req_text.Length }
            }.SerializeToProtoBuf(), WXCGIUrl.mmpay_bin_openunionhb);
        }

        /// <summary>
        /// 打开红包
        /// </summary>
        /// <param name="channelId"></param>
        /// <param name="msgType"></param>
        /// <param name="nativeUrl"></param>
        /// <param name="sendId"></param>
        /// <param name="sendUserName"></param>
        /// <param name="timingIdentifier"></param>
        /// <param name="ver"></param>
        /// <returns></returns>
        public virtual async Task<HongBaoResponse> WXOpenRedPacket(string channelId, int msgType, string nativeUrl, string sendId, string sendUserName, string timingIdentifier, string ver)
        {
            var req_text = $"channelId={channelId}&msgType={msgType}&nativeUrl={nativeUrl.UrlEncode()}&sendId={sendId}&sessionUserName={sendUserName}&timingIdentifier={timingIdentifier}&ver={ver}";
            return await Request<HongBaoResponse>(new HongBaoRequest()
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
                cgiCmd = 4,
                outPutType = 1,
                reqText = new SKBuiltinString_S { buffer = req_text, iLen = (uint)req_text.Length }
            }.SerializeToProtoBuf(), WXCGIUrl.mmpay_bin_openwxhb);
        }

        /// <summary>
        /// 查看红包
        /// </summary>
        /// <param name="channelId"></param>
        /// <param name="msgType"></param>
        /// <param name="nativeUrl"></param>
        /// <param name="sendId"></param>
        /// <param name="offset">偏移，第一页：0，第二页：11，第三页：22</param>
        /// <param name="limit">固定11</param>
        /// <returns></returns>
        public virtual async Task<HongBaoResponse> WXQueryRedPacket(string channelId, int msgType, string nativeUrl, string sendId, uint offset = 0, uint limit = 11)
        {
            var req_text = $"agreeDuty=1&inWay=1&channelId={channelId}&msgType={msgType}&nativeUrl={nativeUrl.UrlEncode()}&province=&sendId={sendId}&limit={limit}&offset={offset}";
            return await Request<HongBaoResponse>(new HongBaoRequest()
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
                cgiCmd = 5,
                outPutType = 1,
                reqText = new SKBuiltinString_S { buffer = req_text, iLen = (uint)req_text.Length }
            }.SerializeToProtoBuf(), WXCGIUrl.mmpay_bin_qrydetailwxhb);
        }

        

        /// <summary>
        /// 查看红包
        /// </summary>
        /// <param name="channelId"></param>
        /// <param name="msgType"></param>
        /// <param name="nativeUrl"></param>
        /// <param name="sendId"></param>
        /// <param name="offset">偏移，第一页：0，第二页：11，第三页：22</param>
        /// <param name="limit">固定11</param>
        /// <returns></returns>
        public virtual async Task<HongBaoResponse> WXQrydetailunionhbRedPacket(string channelId, int msgType, string nativeUrl, string sendId, uint offset = 0, uint limit = 11)
        {
            //channelId=1&encrypt_key=sbj%2B5AFx9A2DanpMDt9jzu61KUaJQ2OEsoZ%2Fzo4zLyfq%2BBjdn0E6dso87QFCgf%2Bl4YLw9nPCqZErPs8wsFdnAYnoXhCoIBRXf3wMVHnmHlAW4WfdmdJMQxoyShGTZapAZYW2fjMVz%2B0frs%2BVNQXQeeVTJU8LJlnd%2BzgQ8CmRq1w%3D&encrypt_userinfo=pU3fOxELAjrE%2Bcx%2FSJhGrOh9286gXgEQzXl5YhGqA9tGPF77GSZVg%2BCGOGoepZMR&msgType=1&nativeUrl=wxpay%3A%2F%2Fc2cbizmessagehandler%2Fhongbao%2Freceivehongbao%3Fmsgtype%3D1%26channelid%3D1%26sendid%3D1800008896202102276117081080005%26ver%3D2%26sign%3DAARxHbYBAAABAAAAAAAQg%252FWxL8g7KFVbReg5YCAAAAD5K3H1P3TTsgLxNwDzPyfEp2uvjYg0WGAGRbvB%252BrLW1Ipc01%252Fa4AQgAuDFnBX%252FaHZGevxBYcYuxvSrM3oh997%252FOQn70EORftzD%252FLttReM%252BgjwfA44u%252FDp6DvY0Uz7WQnDlLwXCgUWzVMbHAB6PPU9K1djnRgSPUKFVH95XqQ%253D%253D&province=Cathedral&sendId=1800008896202102276117081080005&union_source=0
            //var req_text = $"agreeDuty=1&inWay=1&channelId={channelId}&msgType={msgType}&nativeUrl=&province=&sendId={sendId}&limit={limit}&offset={offset}";
            var req_text = $"channelId={channelId}& msgType={msgType}&nativeUrl={nativeUrl.UrlEncode()}&province=&sendId={sendId}&union_source=0&limit={limit}&offset={offset}";
            return await Request<HongBaoResponse>(new HongBaoRequest()
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
                cgiCmd = 4395,
                outPutType = 1,
                reqText = new SKBuiltinString_S { buffer = req_text, iLen = (uint)req_text.Length }
            }.SerializeToProtoBuf(), WXCGIUrl.mmpay_bin_qrydetailunionhb);
        }
    }
}
