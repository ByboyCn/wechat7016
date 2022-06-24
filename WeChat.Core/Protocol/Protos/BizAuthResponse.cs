﻿namespace WeChat.Core.Protocol.Protos
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [Serializable, ProtoContract(Name = "BizAuthResponse")]
    public class BizAuthResponse : IExtensible
    {
        private WeChat.Core.Protocol.Protos.BaseResponse _BaseResponse;
        private SKBuiltinBuffer_t _ImgBuf;
        private string _ImgSid = "";
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

        [ProtoMember(3, IsRequired = true, Name = "ImgBuf", DataFormat = DataFormat.Default)]
        public SKBuiltinBuffer_t ImgBuf
        {
            get
            {
                return this._ImgBuf;
            }
            set
            {
                this._ImgBuf = value;
            }
        }

        [ProtoMember(2, IsRequired = false, Name = "ImgSid", DataFormat = DataFormat.Default), DefaultValue("")]
        public string ImgSid
        {
            get
            {
                return this._ImgSid;
            }
            set
            {
                this._ImgSid = value;
            }
        }
    }
}

