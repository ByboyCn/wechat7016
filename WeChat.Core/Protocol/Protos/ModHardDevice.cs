namespace WeChat.Core.Protocol.Protos
{
    using ProtoBuf;
    using System;

    [Serializable, ProtoContract(Name = "ModHardDevice")]
    public class ModHardDevice : IExtensible
    {
        private uint _BindFlag;
        private WeChat.Core.Protocol.Protos.HardDevice _HardDevice;
        private WeChat.Core.Protocol.Protos.HardDeviceAttr _HardDeviceAttr;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(3, IsRequired = true, Name = "BindFlag", DataFormat = DataFormat.TwosComplement)]
        public uint BindFlag
        {
            get
            {
                return this._BindFlag;
            }
            set
            {
                this._BindFlag = value;
            }
        }

        [ProtoMember(1, IsRequired = true, Name = "HardDevice", DataFormat = DataFormat.Default)]
        public WeChat.Core.Protocol.Protos.HardDevice HardDevice
        {
            get
            {
                return this._HardDevice;
            }
            set
            {
                this._HardDevice = value;
            }
        }

        [ProtoMember(2, IsRequired = true, Name = "HardDeviceAttr", DataFormat = DataFormat.Default)]
        public WeChat.Core.Protocol.Protos.HardDeviceAttr HardDeviceAttr
        {
            get
            {
                return this._HardDeviceAttr;
            }
            set
            {
                this._HardDeviceAttr = value;
            }
        }
    }
}

