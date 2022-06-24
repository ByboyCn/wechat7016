using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeChat.Api.Models;

namespace WeChat.Api.Extensions
{
    /// <summary>
    /// 全局异常拦截器
    /// </summary>
    public class GlobalExceptionFilter: IExceptionFilter
    {
        private IWebHostEnvironment _env;
        private ILogger<GlobalExceptionFilter> _logger;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_env"></param>
        /// <param name="_logger"></param>
        public GlobalExceptionFilter(IWebHostEnvironment _env, ILogger<GlobalExceptionFilter> _logger)
        {
            this._env = _env;
            this._logger = _logger;
        }

        /// <summary>
        /// 接口实现
        /// </summary>
        /// <param name="context"></param>
        public void OnException(ExceptionContext context)
        {

            //if (context.Exception.GetType() == typeof(TestException))
            //{
            //    //自定义异常处理


            //}

            //日志记入数据库


            //异步推送异常邮件


            //返回结果处理 
            _logger.LogError($"{context.Exception.Message}\r\n{context.Exception.StackTrace}\r\n");
            context.Result = new JsonResult(new RestfulData<object> { code = -1, message = $"系统异常：{context.Exception.Message}" });
            context.ExceptionHandled = true;
        }
    }
}
