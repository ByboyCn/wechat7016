using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Other
{
    /// <summary>
    /// 位置DTO
    /// </summary>
    public class LocationDto : BaseDto
    {
        /// <summary>
        /// 经度
        /// </summary>
        public float Latitude { get; set; }
        /// <summary>
        /// 纬度
        /// </summary>
        public float Longitude { get; set; }
    }
}
