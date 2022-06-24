namespace WeChat.Core.Protocol.Protos
{
    using ProtoBuf;
    using System;

    [Serializable, ProtoContract(Name = "OplogResponse")]
    public class OplogResponse : IExtensible
    {
        private WeChat.Core.Protocol.Protos.OplogRet _OplogRet;
        private int _Ret;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(2, IsRequired = true, Name = "OplogRet", DataFormat = DataFormat.Default)]
        public WeChat.Core.Protocol.Protos.OplogRet OplogRet
        {
            get
            {
                return this._OplogRet;
            }
            set
            {
                this._OplogRet = value;
            }
        }

        [ProtoMember(1, IsRequired = true, Name = "Ret", DataFormat = DataFormat.TwosComplement)]
        public int Ret
        {
            get
            {
                return this._Ret;
            }
            set
            {
                this._Ret = value;
            }
        }
    }
}

