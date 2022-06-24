﻿namespace WeChat.Core.Protocol.Protos
{
    using ProtoBuf;
    using System;

    [Serializable, ProtoContract(Name = "VerifyVoicePrintResponse")]
    public class VerifyVoicePrintResponse : IExtensible
    {
        private WeChat.Core.Protocol.Protos.BaseResponse _BaseResponse;
        private VoicePieceCtx _NextPiece;
        private uint _Result;
        private uint _VoiceTicket;
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

        [ProtoMember(2, IsRequired = true, Name = "NextPiece", DataFormat = DataFormat.Default)]
        public VoicePieceCtx NextPiece
        {
            get
            {
                return this._NextPiece;
            }
            set
            {
                this._NextPiece = value;
            }
        }

        [ProtoMember(3, IsRequired = true, Name = "Result", DataFormat = DataFormat.TwosComplement)]
        public uint Result
        {
            get
            {
                return this._Result;
            }
            set
            {
                this._Result = value;
            }
        }

        [ProtoMember(4, IsRequired = true, Name = "VoiceTicket", DataFormat = DataFormat.TwosComplement)]
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

