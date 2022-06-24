namespace WeChat.Core.Protocol.Protos
{
    using ProtoBuf;
    using System;

    [Serializable, ProtoContract(Name = "GetLocationResponse")]
    public class GetLocationResponse : IExtensible
    {
        private WeChat.Core.Protocol.Protos.BaseResponse _BaseResponse;
        private int _Latitude;
        private int _Longitude;
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

        [ProtoMember(3, IsRequired = true, Name = "Latitude", DataFormat = DataFormat.TwosComplement)]
        public int Latitude
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
        public int Longitude
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

