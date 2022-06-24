namespace WeChat.Core.Protocol.Protos
{
    using ProtoBuf;
    using System;

    [Serializable, ProtoContract(Name = "GetEmotionDetailResponse")]
    public class GetEmotionDetailResponse : IExtensible
    {
        private WeChat.Core.Protocol.Protos.BaseResponse _BaseResponse;
        private WeChat.Core.Protocol.Protos.EmotionDetail _EmotionDetail;
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

        [ProtoMember(2, IsRequired = true, Name = "EmotionDetail", DataFormat = DataFormat.Default)]
        public WeChat.Core.Protocol.Protos.EmotionDetail EmotionDetail
        {
            get
            {
                return this._EmotionDetail;
            }
            set
            {
                this._EmotionDetail = value;
            }
        }
    }
}

