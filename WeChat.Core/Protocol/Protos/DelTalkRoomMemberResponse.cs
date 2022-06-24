namespace WeChat.Core.Protocol.Protos
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;

    [Serializable, ProtoContract(Name = "DelTalkRoomMemberResponse")]
    public class DelTalkRoomMemberResponse : IExtensible
    {
        private WeChat.Core.Protocol.Protos.BaseResponse _BaseResponse;
        private uint _MemberCount;
        private readonly List<DelMemberResp> _MemberList = new List<DelMemberResp>();
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(1, IsRequired = true, Name = "BaseResponse", DataFormat = DataFormat.Default)]
        public WeChat.Core.Protocol.Protos.BaseResponse BaseResponse
        {
            get
            {
                return this._BaseResponse;
            }
            set
            {
                this._BaseResponse = value;
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
        public List<DelMemberResp> MemberList
        {
            get
            {
                return this._MemberList;
            }
        }
    }
}

