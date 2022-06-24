﻿namespace WeChat.Core.Protocol.Protos
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;

    [Serializable, ProtoContract(Name = "AddContactLabelResponse")]
    public class AddContactLabelResponse : IExtensible
    {
        private WeChat.Core.Protocol.Protos.BaseResponse _BaseResponse;
        private uint _LabelCount;
        private readonly List<LabelPair> _LabelPairList = new List<LabelPair>();
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

        [ProtoMember(2, IsRequired = true, Name = "LabelCount", DataFormat = DataFormat.TwosComplement)]
        public uint LabelCount
        {
            get
            {
                return this._LabelCount;
            }
            set
            {
                this._LabelCount = value;
            }
        }

        [ProtoMember(3, Name = "LabelPairList", DataFormat = DataFormat.Default)]
        public List<LabelPair> LabelPairList
        {
            get
            {
                return this._LabelPairList;
            }
        }
    }
}

