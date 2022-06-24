using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Biz
{
    /// <summary>
    /// 操作公众号菜单DTO
    /// </summary>
    public class ClickCommandDto : BaseBizDto
    {
        /// <summary>
        /// 菜单ID
        /// 例如"2672637330"
        /// </summary>
        public string MenuID { get; set; }

        /// <summary>
        /// 菜单Key
        /// 例如"rselfmenu_2_0"
        /// </summary>
        public string MenuKey { get; set; }
    }
}
