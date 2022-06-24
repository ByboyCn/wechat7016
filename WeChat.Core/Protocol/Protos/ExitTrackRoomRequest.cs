﻿namespace WeChat.Core.Protocol.Protos
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [Serializable, ProtoContract(Name = "ExitTrackRoomRequest")]
    public class ExitTrackRoomRequest : IExtensible
    {
        private WeChat.Core.Protocol.Protos.BaseRequest _BaseRequest;
        private uint _Scene = 0;
        private string _TrackRoomID = "";
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

        [ProtoMember(3, IsRequired = false, Name = "Scene", DataFormat = DataFormat.TwosComplement), DefaultValue((long)0L)]
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

        [ProtoMember(2, IsRequired = false, Name = "TrackRoomID", DataFormat = DataFormat.Default), DefaultValue("")]
        public string TrackRoomID
        {
            get
            {
                return this._TrackRoomID;
            }
            set
            {
                this._TrackRoomID = value;
            }
        }
    }
}

