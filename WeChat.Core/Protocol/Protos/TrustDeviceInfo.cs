using ProtoBuf;

namespace WeChat.Pb.Entites
{
    [ProtoContract]
    public class TrustDeviceInfo
    {
        [ProtoMember(1)]
        public string Key { get; set; }

        [ProtoMember(2)]
        public string Val { get; set; }
    }
}