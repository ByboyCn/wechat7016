﻿namespace WeChat.Core.Protocol.Protos
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [Serializable, ProtoContract(Name = "QQFriendInGroup")]
    public class QQFriendInGroup : IExtensible
    {
        private string _AlbumBGImgID = "";
        private uint _AlbumFlag = 0;
        private uint _AlbumStyle = 0;
        private string _Alias = "";
        private string _AntispamTicket = "";
        private string _BigHeadImgUrl = "";
        private string _City = "";
        private string _Country = "";
        private WeChat.Core.Protocol.Protos.CustomizedInfo _CustomizedInfo = null;
        private string _MyBrandList = "";
        private string _NickName = "";
        private uint _PersonalCard = 0;
        private string _Province = "";
        private string _QQNickName = "";
        private string _QQRemarkName = "";
        private uint _QQUin;
        private int _Sex = 0;
        private string _Signature = "";
        private string _SmallHeadImgUrl = "";
        private WeChat.Core.Protocol.Protos.SnsUserInfo _SnsUserInfo = null;
        private string _UserName = "";
        private uint _WeixinStatus;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(15, IsRequired = false, Name = "AlbumBGImgID", DataFormat = DataFormat.Default), DefaultValue("")]
        public string AlbumBGImgID
        {
            get
            {
                return this._AlbumBGImgID;
            }
            set
            {
                this._AlbumBGImgID = value;
            }
        }

        [ProtoMember(13, IsRequired = false, Name = "AlbumFlag", DataFormat = DataFormat.TwosComplement), DefaultValue((long)0L)]
        public uint AlbumFlag
        {
            get
            {
                return this._AlbumFlag;
            }
            set
            {
                this._AlbumFlag = value;
            }
        }

        [ProtoMember(14, IsRequired = false, Name = "AlbumStyle", DataFormat = DataFormat.TwosComplement), DefaultValue((long)0L)]
        public uint AlbumStyle
        {
            get
            {
                return this._AlbumStyle;
            }
            set
            {
                this._AlbumStyle = value;
            }
        }

        [ProtoMember(12, IsRequired = false, Name = "Alias", DataFormat = DataFormat.Default), DefaultValue("")]
        public string Alias
        {
            get
            {
                return this._Alias;
            }
            set
            {
                this._Alias = value;
            }
        }

        [ProtoMember(0x16, IsRequired = false, Name = "AntispamTicket", DataFormat = DataFormat.Default), DefaultValue("")]
        public string AntispamTicket
        {
            get
            {
                return this._AntispamTicket;
            }
            set
            {
                this._AntispamTicket = value;
            }
        }

        [ProtoMember(20, IsRequired = false, Name = "BigHeadImgUrl", DataFormat = DataFormat.Default), DefaultValue("")]
        public string BigHeadImgUrl
        {
            get
            {
                return this._BigHeadImgUrl;
            }
            set
            {
                this._BigHeadImgUrl = value;
            }
        }

        [ProtoMember(9, IsRequired = false, Name = "City", DataFormat = DataFormat.Default), DefaultValue("")]
        public string City
        {
            get
            {
                return this._City;
            }
            set
            {
                this._City = value;
            }
        }

        [ProtoMember(0x11, IsRequired = false, Name = "Country", DataFormat = DataFormat.Default), DefaultValue("")]
        public string Country
        {
            get
            {
                return this._Country;
            }
            set
            {
                this._Country = value;
            }
        }

        [ProtoMember(0x13, IsRequired = false, Name = "CustomizedInfo", DataFormat = DataFormat.Default), DefaultValue((string)null)]
        public WeChat.Core.Protocol.Protos.CustomizedInfo CustomizedInfo
        {
            get
            {
                return this._CustomizedInfo;
            }
            set
            {
                this._CustomizedInfo = value;
            }
        }

        [ProtoMember(0x12, IsRequired = false, Name = "MyBrandList", DataFormat = DataFormat.Default), DefaultValue("")]
        public string MyBrandList
        {
            get
            {
                return this._MyBrandList;
            }
            set
            {
                this._MyBrandList = value;
            }
        }

        [ProtoMember(3, IsRequired = false, Name = "NickName", DataFormat = DataFormat.Default), DefaultValue("")]
        public string NickName
        {
            get
            {
                return this._NickName;
            }
            set
            {
                this._NickName = value;
            }
        }

        [ProtoMember(11, IsRequired = false, Name = "PersonalCard", DataFormat = DataFormat.TwosComplement), DefaultValue((long)0L)]
        public uint PersonalCard
        {
            get
            {
                return this._PersonalCard;
            }
            set
            {
                this._PersonalCard = value;
            }
        }

        [ProtoMember(8, IsRequired = false, Name = "Province", DataFormat = DataFormat.Default), DefaultValue("")]
        public string Province
        {
            get
            {
                return this._Province;
            }
            set
            {
                this._Province = value;
            }
        }

        [ProtoMember(4, IsRequired = false, Name = "QQNickName", DataFormat = DataFormat.Default), DefaultValue("")]
        public string QQNickName
        {
            get
            {
                return this._QQNickName;
            }
            set
            {
                this._QQNickName = value;
            }
        }

        [ProtoMember(6, IsRequired = false, Name = "QQRemarkName", DataFormat = DataFormat.Default), DefaultValue("")]
        public string QQRemarkName
        {
            get
            {
                return this._QQRemarkName;
            }
            set
            {
                this._QQRemarkName = value;
            }
        }

        [ProtoMember(1, IsRequired = true, Name = "QQUin", DataFormat = DataFormat.TwosComplement)]
        public uint QQUin
        {
            get
            {
                return this._QQUin;
            }
            set
            {
                this._QQUin = value;
            }
        }

        [ProtoMember(7, IsRequired = false, Name = "Sex", DataFormat = DataFormat.TwosComplement), DefaultValue(0)]
        public int Sex
        {
            get
            {
                return this._Sex;
            }
            set
            {
                this._Sex = value;
            }
        }

        [ProtoMember(10, IsRequired = false, Name = "Signature", DataFormat = DataFormat.Default), DefaultValue("")]
        public string Signature
        {
            get
            {
                return this._Signature;
            }
            set
            {
                this._Signature = value;
            }
        }

        [ProtoMember(0x15, IsRequired = false, Name = "SmallHeadImgUrl", DataFormat = DataFormat.Default), DefaultValue("")]
        public string SmallHeadImgUrl
        {
            get
            {
                return this._SmallHeadImgUrl;
            }
            set
            {
                this._SmallHeadImgUrl = value;
            }
        }

        [ProtoMember(0x10, IsRequired = false, Name = "SnsUserInfo", DataFormat = DataFormat.Default), DefaultValue((string)null)]
        public WeChat.Core.Protocol.Protos.SnsUserInfo SnsUserInfo
        {
            get
            {
                return this._SnsUserInfo;
            }
            set
            {
                this._SnsUserInfo = value;
            }
        }

        [ProtoMember(2, IsRequired = false, Name = "UserName", DataFormat = DataFormat.Default), DefaultValue("")]
        public string UserName
        {
            get
            {
                return this._UserName;
            }
            set
            {
                this._UserName = value;
            }
        }

        [ProtoMember(5, IsRequired = true, Name = "WeixinStatus", DataFormat = DataFormat.TwosComplement)]
        public uint WeixinStatus
        {
            get
            {
                return this._WeixinStatus;
            }
            set
            {
                this._WeixinStatus = value;
            }
        }
    }
}

