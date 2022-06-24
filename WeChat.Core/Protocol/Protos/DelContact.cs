namespace WeChat.Core.Protocol.Protos
{
    using ProtoBuf;
    using System;

    [Serializable, ProtoContract(Name = "DelContact")]
    public class DelContact : IExtensible
    {
        private SKBuiltinString_t _UserName;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(1, IsRequired = true, Name = "UserName", DataFormat = DataFormat.Default)]
        public SKBuiltinString_t UserName
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
    }

    public class BatchDelContact
    {
        /// <summary>
        /// 删除成功数
        /// </summary>
        public int successCount { get; set; }
        /// <summary>
        /// 删除失败数
        /// </summary>
        public int errorCount { get; set; }
        /// <summary>
        /// 删除成功列表
        /// </summary>
        public string[] successList { get; set; }
        /// <summary>
        /// 删除失败列表
        /// </summary>
        public string[] errorList { get; set; }
    }
}

