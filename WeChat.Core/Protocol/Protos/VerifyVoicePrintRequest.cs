﻿namespace WeChat.Core.Protocol.Protos
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [Serializable, ProtoContract(Name = "VerifyVoicePrintRequest")]
    public class VerifyVoicePrintRequest : IExtensible
    {
        private WeChat.Core.Protocol.Protos.BaseRequest _BaseRequest;
        private VoicePieceCtx _Piece;
        private uint _ResId;
        private string _VerifyTicket = "";
        private uint _VoiceTicket;
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

        [ProtoMember(2, IsRequired = true, Name = "Piece", DataFormat = DataFormat.Default)]
        public VoicePieceCtx Piece
        {
            get
            {
                return this._Piece;
            }
            set
            {
                this._Piece = value;
            }
        }

        [ProtoMember(4, IsRequired = true, Name = "ResId", DataFormat = DataFormat.TwosComplement)]
        public uint ResId
        {
            get
            {
                return this._ResId;
            }
            set
            {
                this._ResId = value;
            }
        }

        [ProtoMember(5, IsRequired = false, Name = "VerifyTicket", DataFormat = DataFormat.Default), DefaultValue("")]
        public string VerifyTicket
        {
            get
            {
                return this._VerifyTicket;
            }
            set
            {
                this._VerifyTicket = value;
            }
        }

        [ProtoMember(3, IsRequired = true, Name = "VoiceTicket", DataFormat = DataFormat.TwosComplement)]
        public uint VoiceTicket
        {
            get
            {
                return this._VoiceTicket;
            }
            set
            {
                this._VoiceTicket = value;
            }
        }
    }
}

