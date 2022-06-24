namespace WeChat.Core.Protocol.Protos
{
    using ProtoBuf;
    using System;

    [Serializable, ProtoContract(Name = "GetProfileResponse")]
    public class GetProfileResponse : IExtensible
    {
        private WeChat.Core.Protocol.Protos.BaseResponse _BaseResponse;
        private ModUserInfo _UserInfo;
        private WeChat.Core.Protocol.Protos.UserInfoExt _UserInfoExt;
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

        [ProtoMember(2, IsRequired = true, Name = "UserInfo", DataFormat = DataFormat.Default)]
        public ModUserInfo UserInfo
        {
            get
            {
                return this._UserInfo;
            }
            set
            {
                this._UserInfo = value;
            }
        }

        [ProtoMember(3, IsRequired = true, Name = "UserInfoExt", DataFormat = DataFormat.Default)]
        public WeChat.Core.Protocol.Protos.UserInfoExt UserInfoExt
        {
            get
            {
                return this._UserInfoExt;
            }
            set
            {
                this._UserInfoExt = value;
            }
        }
    }
}

