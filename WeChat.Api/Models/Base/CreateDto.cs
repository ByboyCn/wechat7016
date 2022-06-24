using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeChat.Core;

namespace WeChat.Api.Models.Base
{
    /// <summary>
    /// 尝试创建实例
    /// </summary>
    public class TryCreateDto
    {
        /// <summary>
        /// 微信实例唯一ID
        /// 如果存在则恢复目标实例，不存在则创建
        /// </summary>
        public string Guid { get; set; }
        /// <summary>
        /// 终端（0：安卓，1：IPAD，2：扫码）
        /// </summary>
        public int Terminal { get; set; }
        /// <summary>
        /// 微信数据（A16/62）
        ///     扫码登录或不读62时请留空
        ///     数据请对应终端类型填写
        /// </summary>
        public string WxData { get; set; } = "";
        /// <summary>
        /// 代理IP(不使用可删除)
        /// </summary>
        public string Proxy { get; set; } = "";
    }

    /// <summary>
    /// 创建DTO
    /// </summary>
    public class CreateDto
    {
        /// <summary>
        /// 终端（0：安卓，1：IPAD，2：扫码）
        /// </summary>
        public int Terminal { get; set; }
        /// <summary>
        /// 微信数据（A16/62）
        ///     扫码登录或不读62时请留空
        ///     数据请对应终端类型填写
        /// </summary>
        public string WxData { get; set; } = "";
        /// <summary>
        /// 代理IP(不使用可删除)
        /// </summary>
        public string Proxy { get; set; } = "";
        /// <summary>
        /// 设备品牌(不使用可删除)
        ///     非安卓设备品牌只能为Apple
        /// </summary>
        public string Brand { get; set; } = "";
        /// <summary>
        /// 设备名称(不使用可删除)
        /// </summary>
        public string Name { get; set; } = "";
        /// <summary>
        /// 设备IMEI(不使用可删除)
        /// </summary>
        public string Imei { get; set; } = "";
        /// <summary>
        /// 设备MAC地址(不使用可删除)
        /// </summary>
        public string Mac { get; set; } = "";
    }
}
