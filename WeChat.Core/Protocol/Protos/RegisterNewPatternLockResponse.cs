namespace WeChat.Core.Protocol.Protos
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [Serializable, ProtoContract(Name = "RegisterNewPatternLockResponse")]
    public class RegisterNewPatternLockResponse : IExtensible
    {
        private WeChat.Core.Protocol.Protos.BaseResponse _BaseResponse;
        private PatternLockBuffer _patternlockbuf = null;
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

        [ProtoMember(2, IsRequired = false, Name = "patternlockbuf", DataFormat = DataFormat.Default), DefaultValue((string)null)]
        public PatternLockBuffer patternlockbuf
        {
            get
            {
                return this._patternlockbuf;
            }
            set
            {
                this._patternlockbuf = value;
            }
        }
    }
}

