namespace WeChat.Core.Protocol.Protos
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [Serializable, ProtoContract(Name = "Snapshot")]
    public class Snapshot : IExtensible
    {
        private WeChat.Core.Protocol.Protos.Address _Address = null;
        private WeChat.Core.Protocol.Protos.Express _Express = null;
        private string _LockId = "";
        private uint _ProductCount;
        private readonly List<Production> _Productions = new List<Production>();
        private readonly List<WeChat.Core.Protocol.Protos.Receipt> _Receipt = new List<WeChat.Core.Protocol.Protos.Receipt>();
        private uint _ReceiptCount = 0;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(4, IsRequired = false, Name = "Address", DataFormat = DataFormat.Default), DefaultValue((string)null)]
        public WeChat.Core.Protocol.Protos.Address Address
        {
            get
            {
                return this._Address;
            }
            set
            {
                this._Address = value;
            }
        }

        [ProtoMember(3, IsRequired = false, Name = "Express", DataFormat = DataFormat.Default), DefaultValue((string)null)]
        public WeChat.Core.Protocol.Protos.Express Express
        {
            get
            {
                return this._Express;
            }
            set
            {
                this._Express = value;
            }
        }

        [ProtoMember(7, IsRequired = false, Name = "LockId", DataFormat = DataFormat.Default), DefaultValue("")]
        public string LockId
        {
            get
            {
                return this._LockId;
            }
            set
            {
                this._LockId = value;
            }
        }

        [ProtoMember(1, IsRequired = true, Name = "ProductCount", DataFormat = DataFormat.TwosComplement)]
        public uint ProductCount
        {
            get
            {
                return this._ProductCount;
            }
            set
            {
                this._ProductCount = value;
            }
        }

        [ProtoMember(2, Name = "Productions", DataFormat = DataFormat.Default)]
        public List<Production> Productions
        {
            get
            {
                return this._Productions;
            }
        }

        [ProtoMember(5, Name = "Receipt", DataFormat = DataFormat.Default)]
        public List<WeChat.Core.Protocol.Protos.Receipt> Receipt
        {
            get
            {
                return this._Receipt;
            }
        }

        [ProtoMember(6, IsRequired = false, Name = "ReceiptCount", DataFormat = DataFormat.TwosComplement), DefaultValue((long)0L)]
        public uint ReceiptCount
        {
            get
            {
                return this._ReceiptCount;
            }
            set
            {
                this._ReceiptCount = value;
            }
        }
    }
}

