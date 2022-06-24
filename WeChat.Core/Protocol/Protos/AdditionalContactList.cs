using ProtoBuf;
using System;
using System.ComponentModel;
namespace WeChat.Core.Protocol.Protos
{
    [Serializable, ProtoContract(Name = "AdditionalContactList")]
    public class AdditionalContactList : IExtensible
    {
        private WeChat.Core.Protocol.Protos.LinkedinContactItem _LinkedinContactItem = null;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(1, IsRequired = false, Name = "LinkedinContactItem", DataFormat = DataFormat.Default), DefaultValue((string)null)]
        public WeChat.Core.Protocol.Protos.LinkedinContactItem LinkedinContactItem
        {
            get
            {
                return this._LinkedinContactItem;
            }
            set
            {
                this._LinkedinContactItem = value;
            }
        }
    }
}

