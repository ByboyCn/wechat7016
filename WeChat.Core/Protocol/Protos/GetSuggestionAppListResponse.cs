namespace WeChat.Core.Protocol.Protos
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [Serializable, ProtoContract(Name = "GetSuggestionAppListResponse")]
    public class GetSuggestionAppListResponse : IExtensible
    {
        private uint _AdCount = 0;
        private readonly List<AdAppList> _AdList = new List<AdAppList>();
        private WeChat.Core.Protocol.Protos.BaseResponse _BaseResponse;
        private uint _GiftCount = 0;
        private WeChat.Core.Protocol.Protos.GiftEntranceItem _GiftEntranceItem = null;
        private readonly List<WeChat.Core.Protocol.Protos.GiftList> _GiftList = new List<WeChat.Core.Protocol.Protos.GiftList>();
        private uint _IsInternalDownload = 0;
        private uint _RcCount;
        private readonly List<RcAppList> _RcList = new List<RcAppList>();
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(5, IsRequired = false, Name = "AdCount", DataFormat = DataFormat.TwosComplement), DefaultValue((long)0L)]
        public uint AdCount
        {
            get
            {
                return this._AdCount;
            }
            set
            {
                this._AdCount = value;
            }
        }

        [ProtoMember(6, Name = "AdList", DataFormat = DataFormat.Default)]
        public List<AdAppList> AdList
        {
            get
            {
                return this._AdList;
            }
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

        [ProtoMember(7, IsRequired = false, Name = "GiftCount", DataFormat = DataFormat.TwosComplement), DefaultValue((long)0L)]
        public uint GiftCount
        {
            get
            {
                return this._GiftCount;
            }
            set
            {
                this._GiftCount = value;
            }
        }

        [ProtoMember(9, IsRequired = false, Name = "GiftEntranceItem", DataFormat = DataFormat.Default), DefaultValue((string)null)]
        public WeChat.Core.Protocol.Protos.GiftEntranceItem GiftEntranceItem
        {
            get
            {
                return this._GiftEntranceItem;
            }
            set
            {
                this._GiftEntranceItem = value;
            }
        }

        [ProtoMember(8, Name = "GiftList", DataFormat = DataFormat.Default)]
        public List<WeChat.Core.Protocol.Protos.GiftList> GiftList
        {
            get
            {
                return this._GiftList;
            }
        }

        [ProtoMember(4, IsRequired = false, Name = "IsInternalDownload", DataFormat = DataFormat.TwosComplement), DefaultValue((long)0L)]
        public uint IsInternalDownload
        {
            get
            {
                return this._IsInternalDownload;
            }
            set
            {
                this._IsInternalDownload = value;
            }
        }

        [ProtoMember(2, IsRequired = true, Name = "RcCount", DataFormat = DataFormat.TwosComplement)]
        public uint RcCount
        {
            get
            {
                return this._RcCount;
            }
            set
            {
                this._RcCount = value;
            }
        }

        [ProtoMember(3, Name = "RcList", DataFormat = DataFormat.Default)]
        public List<RcAppList> RcList
        {
            get
            {
                return this._RcList;
            }
        }
    }
}

