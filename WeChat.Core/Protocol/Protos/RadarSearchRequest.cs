﻿namespace WeChat.Core.Protocol.Protos
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [Serializable, ProtoContract(Name = "RadarSearchRequest")]
    public class RadarSearchRequest : IExtensible
    {
        private WeChat.Core.Protocol.Protos.BaseRequest _BaseRequest;
        private string _CellId = "";
        private int _GPSSource = 0;
        private float _Latitude;
        private float _Longitude;
        private string _MacAddr = "";
        private uint _OpCode;
        private int _Precision;
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

        [ProtoMember(7, IsRequired = false, Name = "CellId", DataFormat = DataFormat.Default), DefaultValue("")]
        public string CellId
        {
            get
            {
                return this._CellId;
            }
            set
            {
                this._CellId = value;
            }
        }

        [ProtoMember(8, IsRequired = false, Name = "GPSSource", DataFormat = DataFormat.TwosComplement), DefaultValue(0)]
        public int GPSSource
        {
            get
            {
                return this._GPSSource;
            }
            set
            {
                this._GPSSource = value;
            }
        }

        [ProtoMember(4, IsRequired = true, Name = "Latitude", DataFormat = DataFormat.FixedSize)]
        public float Latitude
        {
            get
            {
                return this._Latitude;
            }
            set
            {
                this._Latitude = value;
            }
        }

        [ProtoMember(3, IsRequired = true, Name = "Longitude", DataFormat = DataFormat.FixedSize)]
        public float Longitude
        {
            get
            {
                return this._Longitude;
            }
            set
            {
                this._Longitude = value;
            }
        }

        [ProtoMember(6, IsRequired = false, Name = "MacAddr", DataFormat = DataFormat.Default), DefaultValue("")]
        public string MacAddr
        {
            get
            {
                return this._MacAddr;
            }
            set
            {
                this._MacAddr = value;
            }
        }

        [ProtoMember(2, IsRequired = true, Name = "OpCode", DataFormat = DataFormat.TwosComplement)]
        public uint OpCode
        {
            get
            {
                return this._OpCode;
            }
            set
            {
                this._OpCode = value;
            }
        }

        [ProtoMember(5, IsRequired = true, Name = "Precision", DataFormat = DataFormat.TwosComplement)]
        public int Precision
        {
            get
            {
                return this._Precision;
            }
            set
            {
                this._Precision = value;
            }
        }
    }
}

