namespace WeChat.Core.Protocol.Protos
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [Serializable, ProtoContract(Name = "GetProductInfoResponse")]
    public class GetProductInfoResponse : IExtensible
    {
        private WeChat.Core.Protocol.Protos.BaseResponse _BaseResponse;
        private string _DescXML = "";
        private string _ProductID = "";
        private uint _Type;
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

        [ProtoMember(3, IsRequired = false, Name = "DescXML", DataFormat = DataFormat.Default), DefaultValue("")]
        public string DescXML
        {
            get
            {
                return this._DescXML;
            }
            set
            {
                this._DescXML = value;
            }
        }

        [ProtoMember(4, IsRequired = false, Name = "ProductID", DataFormat = DataFormat.Default), DefaultValue("")]
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

        [ProtoMember(2, IsRequired = true, Name = "Type", DataFormat = DataFormat.TwosComplement)]
        public uint Type
        {
            get
            {
                return this._Type;
            }
            set
            {
                this._Type = value;
            }
        }
    }
}

