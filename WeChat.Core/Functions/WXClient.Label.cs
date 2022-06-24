using System;
using System.Threading.Tasks;
using WeChat.Core.Protocol;
using WeChat.Core.Protocol.Protos;

namespace WeChat.Core
{
    public partial interface IWXApp
    {
        /// <summary>
        /// 获取标签列表
        /// </summary>
        /// <returns></returns>
        Task<Protocol.Protos.V2.GetContactLabelListResponse> WXGetContactLabelList();
        /// <summary>
        /// 添加标签
        /// </summary>
        /// <param name="name">标签名</param>
        /// <returns></returns>
        Task<AddContactLabelResponse> WXAddContactLabel(string name);
        /// <summary>
        /// 修改标签列表
        /// </summary>
        /// <param name="labels"></param>
        /// <returns></returns>
        Task<ModifyContactLabelListResponse> WXModifyContactLabelList(UserLabelInfo[] labels);
        /// <summary>
        /// 删除标签
        /// </summary>
        /// <param name="id">欲删除的标签id</param>
        /// <returns></returns>
        Task<DelContactLabelResponse> WXDelContactLabel(string id);
    }
    public partial class WXApp
    {
        /// <summary>
        /// 获取标签列表
        /// </summary>
        /// <returns></returns>
        public virtual async Task<Protocol.Protos.V2.GetContactLabelListResponse> WXGetContactLabelList()
        {
            return await Request<Protocol.Protos.V2.GetContactLabelListResponse>(new Protocol.Protos.V2.GetContactLabelListRequest()
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
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_getcontactlabellist);
        }

        /// <summary>
        /// 添加标签
        /// </summary>
        /// <param name="name">标签名</param>
        /// <returns></returns>
        public virtual async Task<AddContactLabelResponse> WXAddContactLabel(string name)
        {
            return await Request<AddContactLabelResponse>(new AddContactLabelRequest()
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
                LabelCount = 1
            }.CallWhen(true, _ => _.LabelPairList.Add(new Protocol.Protos.LabelPair { LabelID = 0, LabelName = name })).SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_addcontactlabel);
        }

        /// <summary>
        /// 修改标签列表
        /// </summary>
        /// <param name="labels"></param>
        /// <returns></returns>
        public virtual async Task<ModifyContactLabelListResponse> WXModifyContactLabelList(UserLabelInfo[] labels)
        {
            var result = default(ModifyContactLabelListResponse);
            if ((labels?.Length ?? 0) <= 0) { return result; }
            return await Request<ModifyContactLabelListResponse>(new ModifyContactLabelListRequest()
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
                UserCount = (uint)(labels?.Length ?? 0)
            }.CallWhen(true, _ => _.UserLabelInfoList.AddRange(labels)).SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_modifycontactlabellist);
        }

        /// <summary>
        /// 删除标签
        /// </summary>
        /// <param name="id">欲删除的标签id</param>
        /// <returns></returns>
        public virtual async Task<DelContactLabelResponse> WXDelContactLabel(string id)
        {
            return await Request<DelContactLabelResponse>(new DelContactLabelRequest()
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
                LabelIDList = id
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_delcontactlabel);
        }
    }
}
