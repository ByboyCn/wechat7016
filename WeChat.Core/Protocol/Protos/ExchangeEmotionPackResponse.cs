namespace WeChat.Core.Protocol.Protos
{
    using ProtoBuf;
    using System;

    [Serializable, ProtoContract(Name = "ExchangeEmotionPackResponse")]
    public class ExchangeEmotionPackResponse : IExtensible
    {
        private WeChat.Core.Protocol.Protos.BaseResponse _BaseResponse;
        private EmotionCDNUrl _DownloadInfo;
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

        [ProtoMember(2, IsRequired = true, Name = "DownloadInfo", DataFormat = DataFormat.Default)]
        public EmotionCDNUrl DownloadInfo
        {
            get
            {
                return this._DownloadInfo;
            }
            set
            {
                this._DownloadInfo = value;
            }
        }
    }
}

