namespace WeChat.Core.Protocol.Protos
{
    using ProtoBuf;
    using System;

    [Serializable, ProtoContract(Name = "ModDisturbSetting")]
    public class ModDisturbSetting : IExtensible
    {
        private WeChat.Core.Protocol.Protos.DisturbSetting _DisturbSetting;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(1, IsRequired = true, Name = "DisturbSetting", DataFormat = DataFormat.Default)]
        public WeChat.Core.Protocol.Protos.DisturbSetting DisturbSetting
        {
            get
            {
                return this._DisturbSetting;
            }
            set
            {
                this._DisturbSetting = value;
            }
        }
    }
}

