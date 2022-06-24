using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using WeChat.Api.Models;
using WeChat.Api.Models.Payment;

namespace WeChat.Api.Controllers
{
    /// <summary>
    /// 支付操作
    /// </summary>
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [ApiGroupSort(60)]
    public class PaymentController : BaseController
    {
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="cache">缓存</param>
        public PaymentController(IDistributedCache cache)
            : base(cache)
        {
        }
        #endregion

        /// <summary>
        /// 查询绑定的银行卡信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXBindQuery))]
        public async Task<ActionResult<RestfulData<object>>> WXBindQuery([FromBody] BaseDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXBindQuery();
            });
        }

        /// <summary>
        /// 获取收款二维码
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXF2FQrcode))]
        public async Task<ActionResult<RestfulData<object>>> WXF2FQrcode([FromBody] BaseDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXF2FQrcode();
            });
        }

        /// <summary>
        /// 获取自定义金额收款码
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXTransferSetF2FFee))]
        public async Task<ActionResult<RestfulData<object>>> WXTransferSetF2FFee([FromBody] TransferSetF2FFeeDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXTransferSetF2FFee(dto.Fee, dto.Description);
            });
        }

        /// <summary>
        /// 创建转账
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXCreatePreTransfer))]
        public async Task<ActionResult<RestfulData<object>>> WXCreatePreTransfer([FromBody] CreatePreTransferDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXCreatePreTransfer(dto.UserName, dto.Fee, dto.Description);
            });
        }

        /// <summary>
        /// 确认转账
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXConfirmPreTransfer))]
        public async Task<ActionResult<RestfulData<object>>> WXConfirmPreTransfer([FromBody] ConfirmPreTransferDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXConfirmPreTransfer(dto.BankType, dto.BindSerial, dto.ReqKey, dto.PayPassword);
            });
        }

        /// <summary>
        /// 查询收款状态
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXTransferQuery))]
        public async Task<ActionResult<RestfulData<object>>> WXTransferQuery([FromBody] TransferOperateDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXTransferQuery(dto.InvalidTime, dto.TransId, dto.TransactionId);
            });
        }

        /// <summary>
        /// 确认收款
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXTransferConfirm))]
        public async Task<ActionResult<RestfulData<object>>> WXTransferConfirm([FromBody] TransferOperateDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXTransferConfirm(dto.InvalidTime, dto.TransId, dto.TransactionId);
            });
        }

        /// <summary>
        /// 创建红包
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXCreateRedPacket))]
        public async Task<ActionResult<RestfulData<object>>> WXCreateRedPacket([FromBody] CreateRedPacketDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXCreateRedPacket(dto.Type, dto.UserName, dto.From, dto.Count, dto.Amount, dto.Content);
            });
        }

        /// <summary>
        /// 接收红包
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXReceiveRedPacket))]
        public async Task<ActionResult<RestfulData<object>>> WXReceiveRedPacket([FromBody] ReceiveRedPacketDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXReceiveRedPacket(dto.ChannelId, dto.MsgType, dto.NativeUrl, dto.SendId, dto.Ver);
            });
        }

        /// <summary>
        /// 打开红包
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXOpenRedPacket))]
        public async Task<ActionResult<RestfulData<object>>> WXOpenRedPacket([FromBody] OpenRedPacketDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXOpenRedPacket(dto.ChannelId, dto.MsgType, dto.NativeUrl, dto.SendId, dto.SendUserName, dto.TimingIdentifier, dto.Ver);
            });
        }

        /// <summary>
        /// 接收企业红包
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXeceiveunionhbRedPacket))]
        public async Task<ActionResult<RestfulData<object>>> WXeceiveunionhbRedPacket([FromBody] ReceiveRedPacketDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXeceiveunionhbRedPacket(dto.ChannelId, dto.MsgType, dto.NativeUrl, dto.SendId, dto.Ver);
            });
        }

        /// <summary>
        /// 打开企业红包
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXOpenunionhbRedPacket))]
        public async Task<ActionResult<RestfulData<object>>> WXOpenunionhbRedPacket([FromBody] OpenRedPacketDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXOpenunionhbRedPacket(dto.ChannelId, dto.MsgType, dto.NativeUrl, dto.SendId, dto.SendUserName, dto.TimingIdentifier, dto.Ver);
            });
        }

        /// <summary>
        /// 查询红包
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXQueryRedPacket))]
        public async Task<ActionResult<RestfulData<object>>> WXQueryRedPacket([FromBody] QueryRedPacketDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXQueryRedPacket(dto.ChannelId, dto.MsgType, dto.NativeUrl, dto.SendId, dto.Offset, dto.Limit);
            });
        }

        /// <summary>
        /// 查询企业红包
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost(nameof(WXQrydetailunionhbRedPacket))]
        public async Task<ActionResult<RestfulData<object>>> WXQrydetailunionhbRedPacket([FromBody] QueryRedPacketDto dto)
        {
            return await Business<object>(dto, async (client, result) =>
            {
                result.data = await client?.WXQrydetailunionhbRedPacket(dto.ChannelId, dto.MsgType, dto.NativeUrl, dto.SendId, dto.Offset, dto.Limit);
            });
        }
    }
}