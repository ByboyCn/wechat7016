using ProtoBuf;

namespace WeChat.Pb.Entites
{
    [ProtoContract]
    public class TrustReq
    {
        [ProtoMember(1)]
        public TrustData Td { get; set; }
    }
}