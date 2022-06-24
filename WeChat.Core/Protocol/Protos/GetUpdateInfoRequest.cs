﻿namespace WeChat.Core.Protocol.Protos
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [Serializable, ProtoContract(Name = "GetUpdateInfoRequest")]
    public class GetUpdateInfoRequest : IExtensible
    {
        private WeChat.Core.Protocol.Protos.BaseRequest _BaseRequest;
        private uint _Channel = 0;
        private uint _UpdateType;
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

        [ProtoMember(3, IsRequired = false, Name = "Channel", DataFormat = DataFormat.TwosComplement), DefaultValue((long)0L)]
        public uint Channel
        {
            get
            {
                return this._Channel;
            }
            set
            {
                this._Channel = value;
            }
        }

        [ProtoMember(2, IsRequired = true, Name = "UpdateType", DataFormat = DataFormat.TwosComplement)]
        public uint UpdateType
        {
            get
            {
                return this._UpdateType;
            }
            set
            {
                this._UpdateType = value;
            }
        }
    }
}

