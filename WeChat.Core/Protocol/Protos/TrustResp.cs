using ProtoBuf;
using WeChat.Core.Protocol.Protos;

namespace WeChat.Pb.Entites
{
    [ProtoContract]
    public class TrustResp
    {
        [ProtoMember(1)]
        public BaseResponse BaseResponse { get; set; }

        [ProtoMember(2)]
        public TrustResponseData TrustResponseData { get; set; }
    }
}