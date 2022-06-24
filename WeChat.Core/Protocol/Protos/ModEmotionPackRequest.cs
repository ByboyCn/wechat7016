namespace WeChat.Core.Protocol.Protos
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [Serializable, ProtoContract(Name = "ModEmotionPackRequest")]
    public class ModEmotionPackRequest : IExtensible
    {
        private WeChat.Core.Protocol.Protos.BaseRequest _BaseRequest;
        private uint _OpCode;
        private string _ProductID = "";
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

        [ProtoMember(3, IsRequired = true, Name = "OpCode", DataFormat = DataFormat.TwosComplement)]
        public uint OpCode
        {
            get
            {
                return this._OpCode;
            }
            set
            {
                this._OpCode = value;
            }
        }

        [ProtoMember(2, IsRequired = false, Name = "ProductID", DataFormat = DataFormat.Default), DefaultValue("")]
        public string ProductID
        {
            get
            {
                return this._ProductID;
            }
            set
            {
                this._ProductID = value;
            }
        }
    }
}

