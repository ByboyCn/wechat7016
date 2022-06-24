namespace WeChat.Core.Protocol.Protos
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [Serializable, ProtoContract(Name = "GetChatRoomInfoDetailResponse")]
    public class GetChatRoomInfoDetailResponse : IExtensible
    {
        private string _Announcement = "";
        private string _AnnouncementEditor = "";
        private uint _AnnouncementPublishTime = 0;
        private WeChat.Core.Protocol.Protos.BaseResponse _BaseResponse;
        private uint _ChatRoomInfoVersion = 0;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(2, IsRequired = false, Name = "Announcement", DataFormat = DataFormat.Default), DefaultValue("")]
        public string Announcement
        {
            get
            {
                return this._Announcement;
            }
            set
            {
                this._Announcement = value;
            }
        }

        [ProtoMember(4, IsRequired = false, Name = "AnnouncementEditor", DataFormat = DataFormat.Default), DefaultValue("")]
        public string AnnouncementEditor
        {
            get
            {
                return this._AnnouncementEditor;
            }
            set
            {
                this._AnnouncementEditor = value;
            }
        }

        [ProtoMember(5, IsRequired = false, Name = "AnnouncementPublishTime", DataFormat = DataFormat.TwosComplement), DefaultValue((long)0L)]
        public uint AnnouncementPublishTime
        {
            get
            {
                return this._AnnouncementPublishTime;
            }
            set
            {
                this._AnnouncementPublishTime = value;
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

        [ProtoMember(3, IsRequired = false, Name = "ChatRoomInfoVersion", DataFormat = DataFormat.TwosComplement), DefaultValue((long)0L)]
        public uint ChatRoomInfoVersion
        {
            get
            {
                return this._ChatRoomInfoVersion;
            }
            set
            {
                this._ChatRoomInfoVersion = value;
            }
        }
    }


    [Serializable, ProtoContract(Name = "ChatRoomProfile")]
    public class ChatRoomProfile : IExtensible
    {
        private string _UserName = "";
        private string _NickName = "";
        private string _PYInitial = "";
        private string _QuanPin = "";
        private string _Remark = "";
        private string _RemarkPYInitial = "";
        private string _RemarkQuanPin = "";
        private SKBuiltinBuffer_t _ImgBuf;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }



        [ProtoMember(1, IsRequired = false, Name = "UserName", DataFormat = DataFormat.Default), DefaultValue("")]
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

        [ProtoMember(2, IsRequired = false, Name = "NickName", DataFormat = DataFormat.Default), DefaultValue("")]
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

        [ProtoMember(3, IsRequired = false, Name = "PYInitial", DataFormat = DataFormat.Default), DefaultValue("")]
        public string PYInitial
        {
            get
            {
                return this._PYInitial;
            }
            set
            {
                this._PYInitial = value;
            }
        }

        [ProtoMember(4, IsRequired = false, Name = "QuanPin", DataFormat = DataFormat.Default), DefaultValue("")]
        public string QuanPin
        {
            get
            {
                return this._QuanPin;
            }
            set
            {
                this._QuanPin = value;
            }
        }

        [ProtoMember(9, IsRequired = false, Name = "Remark", DataFormat = DataFormat.Default), DefaultValue("")]
        public string Remark
        {
            get
            {
                return this._Remark;
            }
            set
            {
                this._Remark = value;
            }
        }

        [ProtoMember(11, IsRequired = false, Name = "RemarkPYInitial", DataFormat = DataFormat.Default), DefaultValue("")]
        public string RemarkPYInitial
        {
            get
            {
                return this._RemarkPYInitial;
            }
            set
            {
                this._RemarkPYInitial = value;
            }
        }

        [ProtoMember(12, IsRequired = false, Name = "RemarkQuanPin", DataFormat = DataFormat.Default), DefaultValue("")]
        public string RemarkQuanPin
        {
            get
            {
                return this._RemarkQuanPin;
            }
            set
            {
                this._RemarkQuanPin = value;
            }
        }

        [ProtoMember(6, IsRequired = true, Name = "ImgBuf", DataFormat = DataFormat.Default)]
        public SKBuiltinBuffer_t ImgBuf
        {
            get
            {
                return this._ImgBuf;
            }
            set
            {
                this._ImgBuf = value;
            }
        }
    }
}

