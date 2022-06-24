using ProtoBuf;
using System;
using System.Collections.Generic;

namespace WeChat.Core.Protocol.Protos
{

    [Serializable, ProtoContract(Name = "AlbumLbsResponse")]
    public class AlbumLbsResponse : IExtensible
    {
        private WeChat.Core.Protocol.Protos.BaseResponse _BaseResponse;
        private uint _ContactCount;
        private readonly List<AlbumLbsContactInfo> _ContactList = new List<AlbumLbsContactInfo>();
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

        [ProtoMember(2, IsRequired = true, Name = "ContactCount", DataFormat = DataFormat.TwosComplement)]
        public uint ContactCount
        {
            get
            {
                return this._ContactCount;
            }
            set
            {
                this._ContactCount = value;
            }
        }

        [ProtoMember(3, Name = "ContactList", DataFormat = DataFormat.Default)]
        public List<AlbumLbsContactInfo> ContactList
        {
            get
            {
                return this._ContactList;
            }
        }
    }
}

