namespace WeChat.Core.Protocol.Protos
{
    using ProtoBuf;

    [ProtoContract(Name = "CommandTypeEnum")]
    public enum CommandTypeEnum
    {
        [ProtoEnum(Name = "COMMAND_CONFIRM_BACKUP")]
        COMMAND_CONFIRM_BACKUP = 2,
        [ProtoEnum(Name = "COMMAND_CONFIRM_CONTINUE_BACKUP")]
        COMMAND_CONFIRM_CONTINUE_BACKUP = 6,
        [ProtoEnum(Name = "COMMAND_CONFIRM_CONTINUE_RECOVER")]
        COMMAND_CONFIRM_CONTINUE_RECOVER = 8,
        [ProtoEnum(Name = "COMMAND_CONFIRM_RECOVER")]
        COMMAND_CONFIRM_RECOVER = 4,
        [ProtoEnum(Name = "COMMAND_REQUEST_TO_BACKUP")]
        COMMAND_REQUEST_TO_BACKUP = 1,
        [ProtoEnum(Name = "COMMAND_REQUEST_TO_CONTINUE_BACKUP")]
        COMMAND_REQUEST_TO_CONTINUE_BACKUP = 5,
        [ProtoEnum(Name = "COMMAND_REQUEST_TO_CONTINUE_RECOVER")]
        COMMAND_REQUEST_TO_CONTINUE_RECOVER = 7,
        [ProtoEnum(Name = "COMMAND_REQUEST_TO_RECOVER")]
        COMMAND_REQUEST_TO_RECOVER = 3
    }
}

