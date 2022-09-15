using ProtoBuf;
using WeChat.Core.Protocol.Protos;

namespace WeChat.Pb.Entites
{
    [ProtoContract]
    public class FPFresh
    {
        [ProtoMember(1)]
        public BaseRequest BaseRequest { get; set; }

        [ProtoMember(2)]
        public byte[] SessionKey { get; set; }

        [ProtoMember(3)]
        public byte[] ZTData /*ZTData */{ get; set; }
    }
}