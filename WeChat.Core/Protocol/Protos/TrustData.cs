using ProtoBuf;
using System.Collections.Generic;

namespace WeChat.Pb.Entites
{
    [ProtoContract]
    public class TrustData
    {
        [ProtoMember(1)]
        public List<TrustDeviceInfo> Tdi { get; set; }
    }

    //[ProtoContract]
    //public class TrustData2
    //{

    //    [ProtoMember(2)]
    //    public string Md { get; set; }
    //}
}