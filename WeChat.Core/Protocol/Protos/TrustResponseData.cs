using ProtoBuf;
using WeChat.Core.Protocol.Protos;

namespace WeChat.Pb.Entites
{
    [ProtoContract]
    public class TrustResponseData
    {
        [ProtoMember(1)]
        public BaseResponse BaseResponse { get; set; }
        [ProtoMember(2)]
        public TrustSoftData SoftData { get; set; }

        [ProtoMember(3)]
        public string DeviceToken { get; set; }

        [ProtoMember(4)]
        public uint Timestamp { get; set; }

    }
}