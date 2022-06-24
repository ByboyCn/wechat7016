
using ProtoBuf;
using System;
using System.ComponentModel;
namespace WeChat.Core.Protocol.Protos
{
    [Serializable, ProtoContract(Name = "AcceptCardItemRequest")]
    public class AcceptCardItemRequest : IExtensible
    {
        private WeChat.Core.Protocol.Protos.BaseRequest _BaseRequest;
        private string _card_ext = "";
        private string _card_id;
        private uint _from_scene;
        private string _from_username = "";
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

        [ProtoMember(5, IsRequired = false, Name = "card_ext", DataFormat = DataFormat.Default), DefaultValue("")]
        public string card_ext
        {
            get
            {
                return this._card_ext;
            }
            set
            {
                this._card_ext = value;
            }
        }

        [ProtoMember(4, IsRequired = true, Name = "card_id", DataFormat = DataFormat.Default)]
        public string card_id
        {
            get
            {
                return this._card_id;
            }
            set
            {
                this._card_id = value;
            }
        }

        [ProtoMember(3, IsRequired = true, Name = "from_scene", DataFormat = DataFormat.TwosComplement)]
        public uint from_scene
        {
            get
            {
                return this._from_scene;
            }
            set
            {
                this._from_scene = value;
            }
        }

        [ProtoMember(2, IsRequired = false, Name = "from_username", DataFormat = DataFormat.Default), DefaultValue("")]
        public string from_username
        {
            get
            {
                return this._from_username;
            }
            set
            {
                this._from_username = value;
            }
        }
    }
}

