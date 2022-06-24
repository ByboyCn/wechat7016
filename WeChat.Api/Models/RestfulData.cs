using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeChat.Core;

namespace WeChat.Api.Models
{
    /// <summary>
    /// 返回数据
    /// </summary>
    public class RestfulData
    {
        /// <summary>
        /// 错误码
        /// </summary>
        public int code { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// 相关的链接帮助地址
        /// </summary>
        public string url { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string remark { get; set; }
    }

    /// <summary>
    /// 返回数据
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RestfulData<T> : RestfulData
    {
        /// <summary>
        /// 标志信息（标识环境信息是否已改变）
        /// </summary>
        public virtual int flag { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        public virtual T data { get; set; }
    }
}
