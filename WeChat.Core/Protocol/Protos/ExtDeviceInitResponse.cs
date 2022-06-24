﻿namespace WeChat.Core.Protocol.Protos
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [Serializable, ProtoContract(Name = "ExtDeviceInitResponse")]
    public class ExtDeviceInitResponse : IExtensible
    {
        private WeChat.Core.Protocol.Protos.BaseResponse _BaseResponse;
        private readonly List<string> _ChatContactList = new List<string>();
        private WeChat.Core.Protocol.Protos.CmdList _CmdList = null;
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

        [ProtoMember(3, Name = "ChatContactList", DataFormat = DataFormat.Default)]
        public List<string> ChatContactList
        {
            get
            {
                return this._ChatContactList;
            }
        }

        [ProtoMember(2, IsRequired = false, Name = "CmdList", DataFormat = DataFormat.Default), DefaultValue((string)null)]
        public WeChat.Core.Protocol.Protos.CmdList CmdList
        {
            get
            {
                return this._CmdList;
            }
            set
            {
                this._CmdList = value;
            }
        }
    }
}

