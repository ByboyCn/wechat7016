﻿namespace WeChat.Core.Protocol.Protos
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [Serializable, ProtoContract(Name = "TalkNoopReq")]
    public class TalkNoopReq : IExtensible
    {
        private WeChat.Core.Protocol.Protos.BaseRequest _BaseRequest;
        private int _RoomId;
        private long _RoomKey;
        private uint _Scene = 0;
        private uint _UpdateTime = 0;
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

        [ProtoMember(2, IsRequired = true, Name = "RoomId", DataFormat = DataFormat.TwosComplement)]
        public int RoomId
        {
            get
            {
                return this._RoomId;
            }
            set
            {
                this._RoomId = value;
            }
        }

        [ProtoMember(3, IsRequired = true, Name = "RoomKey", DataFormat = DataFormat.TwosComplement)]
        public long RoomKey
        {
            get
            {
                return this._RoomKey;
            }
            set
            {
                this._RoomKey = value;
            }
        }

        [ProtoMember(5, IsRequired = false, Name = "Scene", DataFormat = DataFormat.TwosComplement), DefaultValue((long)0L)]
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

        [ProtoMember(4, IsRequired = false, Name = "UpdateTime", DataFormat = DataFormat.TwosComplement), DefaultValue((long)0L)]
        public uint UpdateTime
        {
            get
            {
                return this._UpdateTime;
            }
            set
            {
                this._UpdateTime = value;
            }
        }
    }
}

