namespace WeChat.Core.Protocol.Protos
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [Serializable, ProtoContract(Name = "SnsWhatsnewResponse")]
    public class SnsWhatsnewResponse : IExtensible
    {
        private WeChat.Core.Protocol.Protos.BaseResponse _BaseResponse;
        private WeChat.Core.Protocol.Protos.Whatsnew61 _Whatsnew61 = null;
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

        [ProtoMember(2, IsRequired = false, Name = "Whatsnew61", DataFormat = DataFormat.Default), DefaultValue((string)null)]
        public WeChat.Core.Protocol.Protos.Whatsnew61 Whatsnew61
        {
            get
            {
                return this._Whatsnew61;
            }
            set
            {
                this._Whatsnew61 = value;
            }
        }
    }
}

