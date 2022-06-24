using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace WeChat.Api.Controllers
{
    /// <summary>
    /// Token令牌操作
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    //[ApiExplorerSettings(IgnoreApi = true)]
    [ApiGroupSort(999)]
    public class TokenController : ControllerBase
    {
        #region 全局变量
        /// <summary>
        /// 配置器
        /// </summary>
        public IConfiguration Configuration { get; }
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="configuration">配置器</param>
        public TokenController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        #endregion

        /// <summary>
        /// 创建Token令牌
        /// </summary>
        /// <param name="password">创建指令(在appsettings.json配置)</param>
        /// <param name="minutes">token有效期(默认30分钟)</param>
        /// <returns></returns>
        [HttpGet(nameof(Create))]
        public object Create(string password, int minutes = 30)
        {
            string result;
            if (password != Configuration["Jwt:CreatePassword"])
            {
                result = "创建指令错误";
                return result;
            }
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,DateTime.Now.ToString()),
            };
            try
            {
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:SecurityKey"]));
                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var jwtToken = new JwtSecurityToken(
                    issuer: Configuration["Jwt:Issuer"],
                    audience: Configuration["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(minutes),
                    signingCredentials: credentials);

                result = new JwtSecurityTokenHandler().WriteToken(jwtToken);
                result = $"Bearer {result}";
            }
            catch (Exception ex)
            {
                result = $"{ex.Message}\r\n{ex.StackTrace}";
            }
            return result;
        }
    }
}
