namespace WeChat.Core.Protocol.Protos
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [Serializable, ProtoContract(Name = "LbsRoomResponse")]
    public class LbsRoomResponse : IExtensible
    {
        private WeChat.Core.Protocol.Protos.BaseResponse _BaseResponse;
        private string _RoomName = "";
        private string _RoomNickName = "";
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

        [ProtoMember(2, IsRequired = false, Name = "RoomName", DataFormat = DataFormat.Default), DefaultValue("")]
        public string RoomName
        {
            get
            {
                return this._RoomName;
            }
            set
            {
                this._RoomName = value;
            }
        }

        [ProtoMember(3, IsRequired = false, Name = "RoomNickName", DataFormat = DataFormat.Default), DefaultValue("")]
        public string RoomNickName
        {
            get
            {
                return this._RoomNickName;
            }
            set
            {
                this._RoomNickName = value;
            }
        }
    }
}

