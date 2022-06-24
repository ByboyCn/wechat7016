﻿using ProtoBuf;
using System;

namespace WeChat.Core.Protocol.Protos
{

    [Serializable, ProtoContract(Name = "AppCenterResponse")]
    public class AppCenterResponse : IExtensible
    {
        private WeChat.Core.Protocol.Protos.BaseResponse _BaseResponse;
        private SKBuiltinBuffer_t _RespBuf;
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

        [ProtoMember(2, IsRequired = true, Name = "RespBuf", DataFormat = DataFormat.Default)]
        public SKBuiltinBuffer_t RespBuf
        {
            get
            {
                return this._RespBuf;
            }
            set
            {
                this._RespBuf = value;
            }
        }
    }
}

