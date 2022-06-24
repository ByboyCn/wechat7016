namespace WeChat.Core.Protocol.Protos
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [Serializable, ProtoContract(Name = "SubmitMallFreeOrderRequest")]
    public class SubmitMallFreeOrderRequest : IExtensible
    {
        private WeChat.Core.Protocol.Protos.BaseRequest _BaseRequest;
        private WeChat.Core.Protocol.Protos.Snapshot _Snapshot = null;
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

        [ProtoMember(2, IsRequired = false, Name = "Snapshot", DataFormat = DataFormat.Default), DefaultValue((string)null)]
        public WeChat.Core.Protocol.Protos.Snapshot Snapshot
        {
            get
            {
                return this._Snapshot;
            }
            set
            {
                this._Snapshot = value;
            }
        }
    }
}

