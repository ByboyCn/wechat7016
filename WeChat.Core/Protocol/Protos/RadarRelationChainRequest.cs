namespace WeChat.Core.Protocol.Protos
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;

    [Serializable, ProtoContract(Name = "RadarRelationChainRequest")]
    public class RadarRelationChainRequest : IExtensible
    {
        private WeChat.Core.Protocol.Protos.BaseRequest _BaseRequest;
        private uint _MemberCount;
        private readonly List<RadarChatRoomMember> _MemberList = new List<RadarChatRoomMember>();
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(1, IsRequired = true, Name = "BaseRequest", DataFormat = DataFormat.Default)]
        public WeChat.Core.Protocol.Protos.BaseRequest BaseRequest
        {
            get
            {
                return this._BaseRequest;
            }
            set
            {
                this._BaseRequest = value;
            }
        }

        [ProtoMember(2, IsRequired = true, Name = "MemberCount", DataFormat = DataFormat.TwosComplement)]
        public uint MemberCount
        {
            get
            {
                return this._MemberCount;
            }
            set
            {
                this._MemberCount = value;
            }
        }

        [ProtoMember(3, Name = "MemberList", DataFormat = DataFormat.Default)]
        public List<RadarChatRoomMember> MemberList
        {
            get
            {
                return this._MemberList;
            }
        }
    }
}

