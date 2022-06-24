namespace WeChat.Core.Protocol.Protos
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;

    [Serializable, ProtoContract(Name = "GetChatRoomDonateHistoryResp")]
    public class GetChatRoomDonateHistoryResp : IExtensible
    {
        private WeChat.Core.Protocol.Protos.BaseResponse _BaseResponse;
        private readonly List<Donor> _List = new List<Donor>();
        private uint _TotalCount;
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

        [ProtoMember(3, Name = "List", DataFormat = DataFormat.Default)]
        public List<Donor> List
        {
            get
            {
                return this._List;
            }
        }

        [ProtoMember(2, IsRequired = true, Name = "TotalCount", DataFormat = DataFormat.TwosComplement)]
        public uint TotalCount
        {
            get
            {
                return this._TotalCount;
            }
            set
            {
                this._TotalCount = value;
            }
        }
    }
}

