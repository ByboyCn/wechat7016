namespace WeChat.Core.Protocol.Protos
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [Serializable, ProtoContract(Name = "GetBrandListResponse")]
    public class GetBrandListResponse : IExtensible
    {
        private WeChat.Core.Protocol.Protos.BaseResponse _BaseResponse;
        private string _BrandList = "";
        private SKBuiltinBuffer_t _RequestBuffer;
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

        [ProtoMember(2, IsRequired = false, Name = "BrandList", DataFormat = DataFormat.Default), DefaultValue("")]
        public string BrandList
        {
            get
            {
                return this._BrandList;
            }
            set
            {
                this._BrandList = value;
            }
        }

        [ProtoMember(3, IsRequired = true, Name = "RequestBuffer", DataFormat = DataFormat.Default)]
        public SKBuiltinBuffer_t RequestBuffer
        {
            get
            {
                return this._RequestBuffer;
            }
            set
            {
                this._RequestBuffer = value;
            }
        }
    }
}

