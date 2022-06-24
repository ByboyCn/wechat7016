using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Favor
{
    /// <summary>
    /// 批量操作收藏夹Dto
    /// </summary>
    public class BatchFavItemDto : BaseDto
    {
        /// <summary>
        /// 收藏夹Id列表
        /// </summary>
        public uint[] FavIds { get; set; }
    }

    /// <summary>
    /// 操作收藏夹Dto
    /// </summary>
    public class FavItemDto : BaseDto
    {
        /// <summary>
        /// 收藏夹Id
        /// </summary>
        public uint FavId { get; set; }
    }
}
