namespace WeChat.Core.Protocol.Protos
{
    using ProtoBuf;
    using System;

    [Serializable, ProtoContract(Name = "GameGiftResp")]
    public class GameGiftResp : IExtensible
    {
        private WeChat.Core.Protocol.Protos.BaseResponse _BaseResponse;
        private uint _CheckLeftTime;
        private uint _LifeNum;
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

        [ProtoMember(3, IsRequired = true, Name = "CheckLeftTime", DataFormat = DataFormat.TwosComplement)]
        public uint CheckLeftTime
        {
            get
            {
                return this._CheckLeftTime;
            }
            set
            {
                this._CheckLeftTime = value;
            }
        }

        [ProtoMember(2, IsRequired = true, Name = "LifeNum", DataFormat = DataFormat.TwosComplement)]
        public uint LifeNum
        {
            get
            {
                return this._LifeNum;
            }
            set
            {
                this._LifeNum = value;
            }
        }
    }
}

