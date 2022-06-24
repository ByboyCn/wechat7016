namespace WeChat.Core.Protocol.Protos
{
    using ProtoBuf;
    using System;

    [Serializable, ProtoContract(Name = "SnsTagOptionResponse")]
    public class SnsTagOptionResponse : IExtensible
    {
        private WeChat.Core.Protocol.Protos.BaseResponse _BaseResponse;
        private WeChat.Core.Protocol.Protos.SnsTag _SnsTag;
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

        [ProtoMember(2, IsRequired = true, Name = "SnsTag", DataFormat = DataFormat.Default)]
        public WeChat.Core.Protocol.Protos.SnsTag SnsTag
        {
            get
            {
                return this._SnsTag;
            }
            set
            {
                this._SnsTag = value;
            }
        }
    }
}

