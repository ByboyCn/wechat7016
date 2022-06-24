﻿namespace WeChat.Core.Protocol.Protos
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;

    [Serializable, ProtoContract(Name = "ListBBMContactRequest")]
    public class ListBBMContactRequest : IExtensible
    {
        private WeChat.Core.Protocol.Protos.BaseRequest _BaseRequest;
        private uint _ClickSource;
        private uint _ContinueFlag;
        private uint _Count;
        private readonly List<BBMContactUploadItem> _List = new List<BBMContactUploadItem>();
        private uint _Opcode;
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

        [ProtoMember(5, IsRequired = true, Name = "ClickSource", DataFormat = DataFormat.TwosComplement)]
        public uint ClickSource
        {
            get
            {
                return this._ClickSource;
            }
            set
            {
                this._ClickSource = value;
            }
        }

        [ProtoMember(4, IsRequired = true, Name = "ContinueFlag", DataFormat = DataFormat.TwosComplement)]
        public uint ContinueFlag
        {
            get
            {
                return this._ContinueFlag;
            }
            set
            {
                this._ContinueFlag = value;
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

        [ProtoMember(3, Name = "List", DataFormat = DataFormat.Default)]
        public List<BBMContactUploadItem> List
        {
            get
            {
                return this._List;
            }
        }

        [ProtoMember(6, IsRequired = true, Name = "Opcode", DataFormat = DataFormat.TwosComplement)]
        public uint Opcode
        {
            get
            {
                return this._Opcode;
            }
            set
            {
                this._Opcode = value;
            }
        }
    }
}

