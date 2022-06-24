namespace WeChat.Core.Protocol.Protos
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [Serializable, ProtoContract(Name = "VerifyEmotionPresentationRequest")]
    public class VerifyEmotionPresentationRequest : IExtensible
    {
        private WeChat.Core.Protocol.Protos.BaseRequest _BaseRequest;
        private uint _MemberCount;
        private readonly List<EmotionMember> _MemberList = new List<EmotionMember>();
        private string _ProductID = "";
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

        [ProtoMember(3, IsRequired = true, Name = "MemberCount", DataFormat = DataFormat.TwosComplement)]
        public uint MemberCount
        {
            get
            {
                return this._MemberCount;
            }
            set
            {
                this._MemberCount = value;
            }
        }

        [ProtoMember(4, Name = "MemberList", DataFormat = DataFormat.Default)]
        public List<EmotionMember> MemberList
        {
            get
            {
                return this._MemberList;
            }
        }

        [ProtoMember(2, IsRequired = false, Name = "ProductID", DataFormat = DataFormat.Default), DefaultValue("")]
        public string ProductID
        {
            get
            {
                return this._ProductID;
            }
            set
            {
                this._ProductID = value;
            }
        }
    }
}

