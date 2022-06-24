using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Label
{
    /// <summary>
    /// 修改标签列表DTO
    /// </summary>
    public class ModifyContactLabelListDto : BaseDto
    {
        /// <summary>
        /// 标签列表
        /// </summary>
        public Core.Protocol.Protos.UserLabelInfo[] userLabelInfos { get; set; }
    }
}
