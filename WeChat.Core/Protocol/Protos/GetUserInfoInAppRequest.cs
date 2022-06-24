﻿namespace WeChat.Core.Protocol.Protos
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [Serializable, ProtoContract(Name = "GetUserInfoInAppRequest")]
    public class GetUserInfoInAppRequest : IExtensible
    {
        private string _AppID = "";
        private WeChat.Core.Protocol.Protos.BaseRequest _BaseRequest;
        private uint _Scene;
        private uint _UserCount;
        private readonly List<SKBuiltinString_t> _UserNameList = new List<SKBuiltinString_t>();
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(2, IsRequired = false, Name = "AppID", DataFormat = DataFormat.Default), DefaultValue("")]
        public string AppID
        {
            get
            {
                return this._AppID;
            }
            set
            {
                this._AppID = value;
            }
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

        [ProtoMember(5, IsRequired = true, Name = "Scene", DataFormat = DataFormat.TwosComplement)]
        public uint Scene
        {
            get
            {
                return this._Scene;
            }
            set
            {
                this._Scene = value;
            }
        }

        [ProtoMember(3, IsRequired = true, Name = "UserCount", DataFormat = DataFormat.TwosComplement)]
        public uint UserCount
        {
            get
            {
                return this._UserCount;
            }
            set
            {
                this._UserCount = value;
            }
        }

        [ProtoMember(4, Name = "UserNameList", DataFormat = DataFormat.Default)]
        public List<SKBuiltinString_t> UserNameList
        {
            get
            {
                return this._UserNameList;
            }
        }
    }
}

