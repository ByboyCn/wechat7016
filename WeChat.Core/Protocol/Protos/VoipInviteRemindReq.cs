namespace WeChat.Core.Protocol.Protos
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [Serializable, ProtoContract(Name = "VoipInviteRemindReq")]
    public class VoipInviteRemindReq : IExtensible
    {
        private WeChat.Core.Protocol.Protos.BaseRequest _BaseRequest;
        private uint _InviteType = 0;
        private uint _ListCount;
        private readonly List<SKBuiltinString_t> _ToUserNameList = new List<SKBuiltinString_t>();
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

        [ProtoMember(4, IsRequired = false, Name = "InviteType", DataFormat = DataFormat.TwosComplement), DefaultValue((long)0L)]
        public uint InviteType
        {
            get
            {
                return this._InviteType;
            }
            set
            {
                this._InviteType = value;
            }
        }

        [ProtoMember(2, IsRequired = true, Name = "ListCount", DataFormat = DataFormat.TwosComplement)]
        public uint ListCount
        {
            get
            {
                return this._ListCount;
            }
            set
            {
                this._ListCount = value;
            }
        }

        [ProtoMember(3, Name = "ToUserNameList", DataFormat = DataFormat.Default)]
        public List<SKBuiltinString_t> ToUserNameList
        {
            get
            {
                return this._ToUserNameList;
            }
        }
    }
}

