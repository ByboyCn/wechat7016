namespace WeChat.Core.Protocol.Protos
{
    using ProtoBuf;
    using System;

    [Serializable, ProtoContract(Name = "GameConsumeResp")]
    public class GameConsumeResp : IExtensible
    {
        private WeChat.Core.Protocol.Protos.BaseResponse _BaseResponse;
        private uint _ConsumeOk;
        private uint _GameCoinCount;
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

        [ProtoMember(2, IsRequired = true, Name = "ConsumeOk", DataFormat = DataFormat.TwosComplement)]
        public uint ConsumeOk
        {
            get
            {
                return this._ConsumeOk;
            }
            set
            {
                this._ConsumeOk = value;
            }
        }

        [ProtoMember(3, IsRequired = true, Name = "GameCoinCount", DataFormat = DataFormat.TwosComplement)]
        public uint GameCoinCount
        {
            get
            {
                return this._GameCoinCount;
            }
            set
            {
                this._GameCoinCount = value;
            }
        }
    }
}

