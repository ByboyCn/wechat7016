namespace WeChat.Core.Protocol.Protos
{
    using ProtoBuf;

    [ProtoContract(Name = "TransferTypeEnum")]
    public enum TransferTypeEnum
    {
        [ProtoEnum(Name = "TRANSFER_ADDON")]
        TRANSFER_ADDON = 1,
        [ProtoEnum(Name = "TRANSFER_NEW")]
        TRANSFER_NEW = 0
    }
}

