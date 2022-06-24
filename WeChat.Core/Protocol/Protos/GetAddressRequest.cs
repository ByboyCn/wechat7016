namespace WeChat.Core.Protocol.Protos
{
    using ProtoBuf;
    using System;

    [Serializable, ProtoContract(Name = "GetAddressRequest")]
    public class GetAddressRequest : IExtensible
    {
        private WeChat.Core.Protocol.Protos.BaseRequest _BaseRequest;
        private double _Latitude;
        private double _Longitude;
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

        [ProtoMember(3, IsRequired = true, Name = "Latitude", DataFormat = DataFormat.TwosComplement)]
        public double Latitude
        {
            get
            {
                return this._Latitude;
            }
            set
            {
                this._Latitude = value;
            }
        }

        [ProtoMember(2, IsRequired = true, Name = "Longitude", DataFormat = DataFormat.TwosComplement)]
        public double Longitude
        {
            get
            {
                return this._Longitude;
            }
            set
            {
                this._Longitude = value;
            }
        }
    }
}

