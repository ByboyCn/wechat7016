namespace WeChat.Core.Protocol.Protos
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [Serializable, ProtoContract(Name = "CheckLoginQRCodeResponse")]
    public class CheckLoginQRCodeResponse : IExtensible
    {
        private WeChat.Core.Protocol.Protos.BaseResponse _BaseResponse;
        private LoginQRCodeNotifyPkg _NotifyPkg = null;
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

        [ProtoMember(3, IsRequired = false, Name = "NotifyPkg", DataFormat = DataFormat.Default), DefaultValue((string)null)]
        public LoginQRCodeNotifyPkg NotifyPkg
        {
            get
            {
                return this._NotifyPkg;
            }
            set
            {
                this._NotifyPkg = value;
            }
        }
    }
}

