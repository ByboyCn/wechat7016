namespace WeChat.Core.Protocol.Protos
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [Serializable, ProtoContract(Name = "GmailOperRequest")]
    public class GmailOperRequest : IExtensible
    {
        private WeChat.Core.Protocol.Protos.BaseRequest _BaseRequest;
        private string _GmailAcct = "";
        private string _GmailPwd = "";
        private uint _OpType;
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

        [ProtoMember(3, IsRequired = false, Name = "GmailAcct", DataFormat = DataFormat.Default), DefaultValue("")]
        public string GmailAcct
        {
            get
            {
                return this._GmailAcct;
            }
            set
            {
                this._GmailAcct = value;
            }
        }

        [ProtoMember(4, IsRequired = false, Name = "GmailPwd", DataFormat = DataFormat.Default), DefaultValue("")]
        public string GmailPwd
        {
            get
            {
                return this._GmailPwd;
            }
            set
            {
                this._GmailPwd = value;
            }
        }

        [ProtoMember(2, IsRequired = true, Name = "OpType", DataFormat = DataFormat.TwosComplement)]
        public uint OpType
        {
            get
            {
                return this._OpType;
            }
            set
            {
                this._OpType = value;
            }
        }
    }
}

