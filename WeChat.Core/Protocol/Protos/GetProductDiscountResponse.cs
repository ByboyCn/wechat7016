﻿namespace WeChat.Core.Protocol.Protos
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [Serializable, ProtoContract(Name = "GetProductDiscountResponse")]
    public class GetProductDiscountResponse : IExtensible
    {
        private WeChat.Core.Protocol.Protos.BaseResponse _BaseResponse;
        private string _DiscountDetail = "";
        private int _RetCode = 0;
        private string _RetMsg = "";
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

        [ProtoMember(2, IsRequired = false, Name = "DiscountDetail", DataFormat = DataFormat.Default), DefaultValue("")]
        public string DiscountDetail
        {
            get
            {
                return this._DiscountDetail;
            }
            set
            {
                this._DiscountDetail = value;
            }
        }

        [ProtoMember(3, IsRequired = false, Name = "RetCode", DataFormat = DataFormat.TwosComplement), DefaultValue(0)]
        public int RetCode
        {
            get
            {
                return this._RetCode;
            }
            set
            {
                this._RetCode = value;
            }
        }

        [ProtoMember(4, IsRequired = false, Name = "RetMsg", DataFormat = DataFormat.Default), DefaultValue("")]
        public string RetMsg
        {
            get
            {
                return this._RetMsg;
            }
            set
            {
                this._RetMsg = value;
            }
        }
    }
}

