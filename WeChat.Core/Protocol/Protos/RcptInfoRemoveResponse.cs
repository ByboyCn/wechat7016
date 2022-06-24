namespace WeChat.Core.Protocol.Protos
{
    using ProtoBuf;
    using System;

    [Serializable, ProtoContract(Name = "RcptInfoRemoveResponse")]
    public class RcptInfoRemoveResponse : IExtensible
    {
        private WeChat.Core.Protocol.Protos.BaseResponse _BaseResponse;
        private uint _id;
        private RcptInfoList _rcptinfolist;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(3, IsRequired = true, Name = "BaseResponse", DataFormat = DataFormat.Default)]
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

        [ProtoMember(1, IsRequired = true, Name = "id", DataFormat = DataFormat.TwosComplement)]
        public uint id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }

        [ProtoMember(2, IsRequired = true, Name = "rcptinfolist", DataFormat = DataFormat.Default)]
        public RcptInfoList rcptinfolist
        {
            get
            {
                return this._rcptinfolist;
            }
            set
            {
                this._rcptinfolist = value;
            }
        }
    }
}

