namespace WeChat.Core.Protocol.Protos
{
    using ProtoBuf;

    [ProtoContract(Name = "ExtDevLoginType")]
    public enum ExtDevLoginType
    {
        [ProtoEnum(Name = "EXTDEV_LOGINTYPE_NORMAL")]
        EXTDEV_LOGINTYPE_NORMAL = 0,
        [ProtoEnum(Name = "EXTDEV_LOGINTYPE_PAIR")]
        EXTDEV_LOGINTYPE_PAIR = 2,
        [ProtoEnum(Name = "EXTDEV_LOGINTYPE_TMP")]
        EXTDEV_LOGINTYPE_TMP = 1
    }
}

