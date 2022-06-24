namespace WeChat.Core.Protocol.Protos
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;

    [Serializable, ProtoContract(Name = "SearchNBSResponse")]
    public class SearchNBSResponse : IExtensible
    {
        private WeChat.Core.Protocol.Protos.BaseResponse _BaseResponse;
        private uint _NBSCount;
        private readonly List<NBSInfo> _NBSList = new List<NBSInfo>();
        private SKBuiltinBuffer_t _PageBuff;
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

        [ProtoMember(2, IsRequired = true, Name = "NBSCount", DataFormat = DataFormat.TwosComplement)]
        public uint NBSCount
        {
            get
            {
                return this._NBSCount;
            }
            set
            {
                this._NBSCount = value;
            }
        }

        [ProtoMember(3, Name = "NBSList", DataFormat = DataFormat.Default)]
        public List<NBSInfo> NBSList
        {
            get
            {
                return this._NBSList;
            }
        }

        [ProtoMember(4, IsRequired = true, Name = "PageBuff", DataFormat = DataFormat.Default)]
        public SKBuiltinBuffer_t PageBuff
        {
            get
            {
                return this._PageBuff;
            }
            set
            {
                this._PageBuff = value;
            }
        }
    }
}

