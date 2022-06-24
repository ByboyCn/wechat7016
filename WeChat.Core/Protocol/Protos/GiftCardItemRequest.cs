namespace WeChat.Core.Protocol.Protos
{
    using ProtoBuf;
    using System;

    [Serializable, ProtoContract(Name = "GiftCardItemRequest")]
    public class GiftCardItemRequest : IExtensible
    {
        private WeChat.Core.Protocol.Protos.BaseRequest _BaseRequest;
        private string _card_id;
        private string _to_username;
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

        [ProtoMember(2, IsRequired = true, Name = "card_id", DataFormat = DataFormat.Default)]
        public string card_id
        {
            get
            {
                return this._card_id;
            }
            set
            {
                this._card_id = value;
            }
        }

        [ProtoMember(3, IsRequired = true, Name = "to_username", DataFormat = DataFormat.Default)]
        public string to_username
        {
            get
            {
                return this._to_username;
            }
            set
            {
                this._to_username = value;
            }
        }
    }
}

