using ProtoBuf;

namespace WeChat.Pb.Entites
{
    [ProtoContract]
    public class TrustSoftData
    {
        [ProtoMember(1)]
        public byte[] SoftConfig { get; set; }

        [ProtoMember(2)]
        public byte[] SoftData { get; set; }
    }
}