using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Api.Models.Chatroom
{
    /// <summary>
    /// 面对面创群DTO
    /// </summary>
    public class CreateFaceChatroomDto : BaseDto
    {
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 纬度
        /// </summary>
        public float Latitude { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        public float Longitude { get; set; }
    }
}
