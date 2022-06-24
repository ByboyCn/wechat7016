namespace WeChat.Core.Protocol.Protos
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [Serializable, ProtoContract(Name = "UpdateSafeDeviceRequest")]
    public class UpdateSafeDeviceRequest : IExtensible
    {
        private WeChat.Core.Protocol.Protos.BaseRequest _BaseRequest;
        private string _DeviceType = "";
        private string _Name = "";
        private string _Uuid = "";
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

        [ProtoMember(4, IsRequired = false, Name = "DeviceType", DataFormat = DataFormat.Default), DefaultValue("")]
        public string DeviceType
        {
            get
            {
                return this._DeviceType;
            }
            set
            {
                this._DeviceType = value;
            }
        }

        [ProtoMember(3, IsRequired = false, Name = "Name", DataFormat = DataFormat.Default), DefaultValue("")]
        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                this._Name = value;
            }
        }

        [ProtoMember(2, IsRequired = false, Name = "Uuid", DataFormat = DataFormat.Default), DefaultValue("")]
        public string Uuid
        {
            get
            {
                return this._Uuid;
            }
            set
            {
                this._Uuid = value;
            }
        }
    }
}

