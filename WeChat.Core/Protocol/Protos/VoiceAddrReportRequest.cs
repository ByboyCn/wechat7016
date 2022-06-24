namespace WeChat.Core.Protocol.Protos
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [Serializable, ProtoContract(Name = "VoiceAddrReportRequest")]
    public class VoiceAddrReportRequest : IExtensible
    {
        private WeChat.Core.Protocol.Protos.BaseRequest _BaseRequest;
        private uint _HitPos;
        private string _HitUserName = "";
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

        [ProtoMember(2, IsRequired = true, Name = "HitPos", DataFormat = DataFormat.TwosComplement)]
        public uint HitPos
        {
            get
            {
                return this._HitPos;
            }
            set
            {
                this._HitPos = value;
            }
        }

        [ProtoMember(3, IsRequired = false, Name = "HitUserName", DataFormat = DataFormat.Default), DefaultValue("")]
        public string HitUserName
        {
            get
            {
                return this._HitUserName;
            }
            set
            {
                this._HitUserName = value;
            }
        }
    }
}

