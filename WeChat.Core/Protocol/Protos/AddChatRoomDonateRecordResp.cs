using ProtoBuf;
using System;
namespace WeChat.Core.Protocol.Protos
{
    [Serializable, ProtoContract(Name = "AddChatRoomDonateRecordResp")]
    public class AddChatRoomDonateRecordResp : IExtensible
    {
        private WeChat.Core.Protocol.Protos.BaseResponse _BaseResponse;
        private uint _MaxCount;
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

        [ProtoMember(2, IsRequired = true, Name = "MaxCount", DataFormat = DataFormat.TwosComplement)]
        public uint MaxCount
        {
            get
            {
                return this._MaxCount;
            }
            set
            {
                this._MaxCount = value;
            }
        }
    }
}

