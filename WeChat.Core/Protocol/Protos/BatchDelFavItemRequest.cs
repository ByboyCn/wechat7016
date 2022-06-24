﻿namespace WeChat.Core.Protocol.Protos
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;

    [Serializable, ProtoContract(Name = "BatchDelFavItemRequest")]
    public class BatchDelFavItemRequest : IExtensible
    {
        private WeChat.Core.Protocol.Protos.BaseRequest _BaseRequest;
        private uint _Count;
        private readonly List<uint> _FavIdList = new List<uint>();
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(1, IsRequired = true, Name = "BaseRequest", DataFormat = DataFormat.Default)]
        public WeChat.Core.Protocol.Protos.BaseRequest BaseRequest
        {
            get
            {
                return this._BaseRequest;
            }
            set
            {
                this._BaseRequest = value;
            }
        }

        [ProtoMember(2, IsRequired = true, Name = "Count", DataFormat = DataFormat.TwosComplement)]
        public uint Count
        {
            get
            {
                return this._Count;
            }
            set
            {
                this._Count = value;
            }
        }

        [ProtoMember(3, Name = "FavIdList", DataFormat = DataFormat.TwosComplement, Options = MemberSerializationOptions.Packed)]
        public List<uint> FavIdList
        {
            get
            {
                return this._FavIdList;
            }
        }
    }
}

