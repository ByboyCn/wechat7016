﻿using ProtoBuf;
using System;
using System.ComponentModel;

namespace WeChat.Core.Protocol.Protos
{

    [Serializable, ProtoContract(Name = "BackupCommandResponse")]
    public class BackupCommandResponse : IExtensible
    {
        private int _Command;
        private byte[] _Data = null;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(1, IsRequired = true, Name = "Command", DataFormat = DataFormat.TwosComplement)]
        public int Command
        {
            get
            {
                return this._Command;
            }
            set
            {
                this._Command = value;
            }
        }

        [ProtoMember(2, IsRequired = false, Name = "Data", DataFormat = DataFormat.Default), DefaultValue((string)null)]
        public byte[] Data
        {
            get
            {
                return this._Data;
            }
            set
            {
                this._Data = value;
            }
        }
    }
}

