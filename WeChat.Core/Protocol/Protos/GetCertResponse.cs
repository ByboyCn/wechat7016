namespace WeChat.Core.Protocol.Protos
{
    using ProtoBuf;
    using System;

    [Serializable, ProtoContract(Name = "GetCertResponse")]
    public class GetCertResponse : IExtensible
    {
        private WeChat.Core.Protocol.Protos.BaseResponse _BaseResponse;
        private RSACert _CertValue;
        private uint _CertVersion;
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

        [ProtoMember(2, IsRequired = true, Name = "CertValue", DataFormat = DataFormat.Default)]
        public RSACert CertValue
        {
            get
            {
                return this._CertValue;
            }
            set
            {
                this._CertValue = value;
            }
        }

        [ProtoMember(3, IsRequired = true, Name = "CertVersion", DataFormat = DataFormat.TwosComplement)]
        public uint CertVersion
        {
            get
            {
                return this._CertVersion;
            }
            set
            {
                this._CertVersion = value;
            }
        }
    }
}

