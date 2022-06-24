namespace WeChat.Core.Protocol.Protos
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [Serializable, ProtoContract(Name = "SetPwdResponse")]
    public class SetPwdResponse : IExtensible
    {
        private SKBuiltinBuffer_t _AutoAuthKey = null;
        private WeChat.Core.Protocol.Protos.BaseResponse _BaseResponse;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(2, IsRequired = false, Name = "AutoAuthKey", DataFormat = DataFormat.Default), DefaultValue((string)null)]
        public SKBuiltinBuffer_t AutoAuthKey
        {
            get
            {
                return this._AutoAuthKey;
            }
            set
            {
                this._AutoAuthKey = value;
            }
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
    }
}

