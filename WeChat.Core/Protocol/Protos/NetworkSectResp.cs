namespace WeChat.Core.Protocol.Protos
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [Serializable, ProtoContract(Name = "NetworkSectResp")]
    public class NetworkSectResp : IExtensible
    {
        private WeChat.Core.Protocol.Protos.BuiltinIPList _BuiltinIPList = null;
        private WeChat.Core.Protocol.Protos.NetworkControl _NetworkControl = null;
        private HostList _NewHostList = null;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(3, IsRequired = false, Name = "BuiltinIPList", DataFormat = DataFormat.Default), DefaultValue((string)null)]
        public WeChat.Core.Protocol.Protos.BuiltinIPList BuiltinIPList
        {
            get
            {
                return this._BuiltinIPList;
            }
            set
            {
                this._BuiltinIPList = value;
            }
        }

        [ProtoMember(2, IsRequired = false, Name = "NetworkControl", DataFormat = DataFormat.Default), DefaultValue((string)null)]
        public WeChat.Core.Protocol.Protos.NetworkControl NetworkControl
        {
            get
            {
                return this._NetworkControl;
            }
            set
            {
                this._NetworkControl = value;
            }
        }

        [ProtoMember(1, IsRequired = false, Name = "NewHostList", DataFormat = DataFormat.Default), DefaultValue((string)null)]
        public HostList NewHostList
        {
            get
            {
                return this._NewHostList;
            }
            set
            {
                this._NewHostList = value;
            }
        }
    }
}

