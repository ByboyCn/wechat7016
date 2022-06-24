namespace WeChat.Core.Protocol.Protos
{
    using ProtoBuf;
    using System;

    [Serializable, ProtoContract(Name = "GetPSMImgResponse")]
    public class GetPSMImgResponse : IExtensible
    {
        private WeChat.Core.Protocol.Protos.BaseResponse _BaseResponse;
        private SKBuiltinBuffer_t _Data;
        private uint _TotalLength;
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

        [ProtoMember(2, IsRequired = true, Name = "Data", DataFormat = DataFormat.Default)]
        public SKBuiltinBuffer_t Data
        {
            get
            {
                return this._Data;
            }
            set
            {
                this._Data = value;
            }
        }

        [ProtoMember(3, IsRequired = true, Name = "TotalLength", DataFormat = DataFormat.TwosComplement)]
        public uint TotalLength
        {
            get
            {
                return this._TotalLength;
            }
            set
            {
                this._TotalLength = value;
            }
        }
    }
}

