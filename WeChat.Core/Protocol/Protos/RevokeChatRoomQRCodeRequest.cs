﻿namespace WeChat.Core.Protocol.Protos
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [Serializable, ProtoContract(Name = "RevokeChatRoomQRCodeRequest")]
    public class RevokeChatRoomQRCodeRequest : IExtensible
    {
        private WeChat.Core.Protocol.Protos.BaseRequest _BaseRequest;
        private string _ChatRoomUserName = "";
        private string _QRCode = "";
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

        [ProtoMember(3, IsRequired = false, Name = "ChatRoomUserName", DataFormat = DataFormat.Default), DefaultValue("")]
        public string ChatRoomUserName
        {
            get
            {
                return this._ChatRoomUserName;
            }
            set
            {
                this._ChatRoomUserName = value;
            }
        }

        [ProtoMember(2, IsRequired = false, Name = "QRCode", DataFormat = DataFormat.Default), DefaultValue("")]
        public string QRCode
        {
            get
            {
                return this._QRCode;
            }
            set
            {
                this._QRCode = value;
            }
        }
    }
}

