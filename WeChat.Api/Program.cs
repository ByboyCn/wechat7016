using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;

namespace WeChat.Api
{
    /// <summary>
    /// 应用程序启动类
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main函数
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            System.Console.WriteLine($"欢迎使用WeChat.Api");
            System.Console.WriteLine($"VS部署访问链接：http://localhost:62110");
            System.Console.WriteLine($"IIS部署访问链接：http://localhost:7620");
            System.Console.WriteLine($"EXE运行访问链接：http://localhost:81");
            System.Console.WriteLine($"Docker部署访问链接：http://localhost:62111");
            System.Console.WriteLine($"");
            System.Console.WriteLine($"异常日志查看：站点目录/Logs");
            System.Console.WriteLine($"修改appsettings配置文件后必须重启应用");
            System.Console.WriteLine($"");
            System.Console.WriteLine($"Runing....请勿关闭此窗口");
            System.Net.ServicePointManager.DefaultConnectionLimit = 1024;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// 创建 host 主机
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            }).ConfigureLogging(logging =>
            {
                logging.ClearProviders();
                logging.SetMinimumLevel(LogLevel.Trace);
            }).UseNLog();
        }
    }
}
