namespace WeChat.Core.Protocol.Protos
{
    using ProtoBuf;

    [ProtoContract(Name = "StartResponseStatusEnum")]
    public enum StartResponseStatusEnum
    {
        [ProtoEnum(Name = "START_RESPONSE_ID_WRONG")]
        START_RESPONSE_ID_WRONG = 1,
        [ProtoEnum(Name = "START_RESPONSE_SIZE_WRONG")]
        START_RESPONSE_SIZE_WRONG = 2,
        [ProtoEnum(Name = "START_RESPONSE_SUCCESS")]
        START_RESPONSE_SUCCESS = 0
    }
}

