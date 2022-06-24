namespace WeChat.Core.Protocol.Protos
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [Serializable, ProtoContract(Name = "UploadMContactRequest")]
    public class UploadMContactRequest : IExtensible
    {
        private WeChat.Core.Protocol.Protos.BaseRequest _BaseRequest;
        private readonly List<MEmail> _EmailList = new List<MEmail>();
        private int _EmailListSize;
        private string _Mobile = "";
        private readonly List<WeChat.Core.Protocol.Protos.Mobile> _MobileList = new List<WeChat.Core.Protocol.Protos.Mobile>();
        private int _MobileListSize;
        private int _Opcode;
        private string _UserName = "";
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

        [ProtoMember(8, Name = "EmailList", DataFormat = DataFormat.Default)]
        public List<MEmail> EmailList
        {
            get
            {
                return this._EmailList;
            }
        }

        [ProtoMember(7, IsRequired = true, Name = "EmailListSize", DataFormat = DataFormat.TwosComplement)]
        public int EmailListSize
        {
            get
            {
                return this._EmailListSize;
            }
            set
            {
                this._EmailListSize = value;
            }
        }

        [ProtoMember(4, IsRequired = false, Name = "Mobile", DataFormat = DataFormat.Default), DefaultValue("")]
        public string Mobile
        {
            get
            {
                return this._Mobile;
            }
            set
            {
                this._Mobile = value;
            }
        }

        [ProtoMember(6, Name = "MobileList", DataFormat = DataFormat.Default)]
        public List<WeChat.Core.Protocol.Protos.Mobile> MobileList
        {
            get
            {
                return this._MobileList;
            }
        }

        [ProtoMember(5, IsRequired = true, Name = "MobileListSize", DataFormat = DataFormat.TwosComplement)]
        public int MobileListSize
        {
            get
            {
                return this._MobileListSize;
            }
            set
            {
                this._MobileListSize = value;
            }
        }

        [ProtoMember(3, IsRequired = true, Name = "Opcode", DataFormat = DataFormat.TwosComplement)]
        public int Opcode
        {
            get
            {
                return this._Opcode;
            }
            set
            {
                this._Opcode = value;
            }
        }

        [ProtoMember(2, IsRequired = false, Name = "UserName", DataFormat = DataFormat.Default), DefaultValue("")]
        public string UserName
        {
            get
            {
                return this._UserName;
            }
            set
            {
                this._UserName = value;
            }
        }
    }
}

