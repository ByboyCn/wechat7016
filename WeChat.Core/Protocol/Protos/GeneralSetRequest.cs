namespace WeChat.Core.Protocol.Protos
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [Serializable, ProtoContract(Name = "GeneralSetRequest")]
    public class GeneralSetRequest : IExtensible
    {
        private WeChat.Core.Protocol.Protos.BaseRequest _BaseRequest;
        private int _SetType;
        private string _SetValue = "";
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

        [ProtoMember(2, IsRequired = true, Name = "SetType", DataFormat = DataFormat.TwosComplement)]
        public int SetType
        {
            get
            {
                return this._SetType;
            }
            set
            {
                this._SetType = value;
            }
        }

        [ProtoMember(3, IsRequired = false, Name = "SetValue", DataFormat = DataFormat.Default), DefaultValue("")]
        public string SetValue
        {
            get
            {
                return this._SetValue;
            }
            set
            {
                this._SetValue = value;
            }
        }
    }
}

