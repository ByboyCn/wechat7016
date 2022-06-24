using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Favor
{
    /// <summary>
    /// 同步收藏夹DTO
    /// </summary>
    public class FavSyncDto : BaseDto
    {
        /// <summary>
        /// 上一次同步Key,首次为null
        /// </summary>
        public string SyncKeyBase64 { get; set; }
    }
}
