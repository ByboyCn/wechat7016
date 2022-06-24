using CSRedis;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Redis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NLog.Extensions.Logging;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using WeChat.Api.Extensions;


namespace WeChat.Api
{
    /// <summary>
    /// 启动类
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 配置器
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 配置服务
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            RedisHelper.Initialization(new CSRedisClient(null, Configuration.GetSection("ConnectionStrings:Redis").GetChildren().Select(s => s.Value).ToArray()));
            services.AddCors(options => options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(Configuration["Swagger:Version"], new OpenApiInfo
                {
                    Version = Configuration["Swagger:Version"],
                    Title = Configuration["Swagger:Title"],
                    Description = Configuration["Swagger:Description"],
                    //TermsOfService = new Uri(Configuration["Swagger:TermsOfService"]),//服务条款链接
                    //License = new OpenApiLicense() { Name = Configuration["Swagger:License:Name"], Url = new Uri(Configuration["Swagger:License:Url"]) },//开源协议
                   // Contact = new OpenApiContact() { Name = Configuration["Swagger:Contact:Name"], Url = new Uri(Configuration["Swagger:Contact:Url"]) }//联系方式
                });
                c.IncludeXmlComments(Path.Combine(Path.GetDirectoryName(typeof(Startup).Assembly.Location), $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"), true);
                c.CustomSchemaIds(type => type.FullName); //解决相同类名会报错的问题
                //添加对控制器的注释亦可通过IncludeXmlComments(path,true)
                //c.DocumentFilter<ClassDescriptions>();
                //添加自定义标记
                c.DocumentFilter<ApiGroupSortFilter>(); //接口组自定义排序
                //c.DocumentFilter<HiddenApiFilter>(); //等价于[ApiExplorerSettings(IgnoreApi = true)]
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.ApiKey,
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Description = "请输入Token令牌，前置Bearer 示例：Bearer ****"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { new OpenApiSecurityScheme{ Reference = new OpenApiReference(){ Id = "Bearer",Type = ReferenceType.SecurityScheme } }, Array.Empty<string>() }
                });
            });
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(jwtBearerOptions =>
            {
                jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(Configuration["Jwt:SecurityKey"])),
                    ValidateIssuer = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidateAudience = true,
                    ValidAudience = Configuration["Jwt:Audience"],
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(5)
                };
            });

            services.AddSingleton<IDistributedCache>(new CSRedisCache(RedisHelper.Instance));

            services.AddControllers(p =>
            {
                p.Filters.Add(typeof(GlobalExceptionFilter));
            }).AddJsonOptions(o =>
            {
                o.JsonSerializerOptions.PropertyNamingPolicy = null;
                o.JsonSerializerOptions.DictionaryKeyPolicy = null;
            }).AddNewtonsoftJson(o =>
            {
                o.SerializerSettings.ContractResolver = new DefaultContractResolver();
                o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                o.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm";
            });
        }

        /// <summary>
        /// 配置使用中间件
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) { app.UseDeveloperExceptionPage(); }
            app.UseHttpsRedirection();

            DefaultFilesOptions defaultFilesOptions = new DefaultFilesOptions();
            defaultFilesOptions.DefaultFileNames.Add("index.html");
            app.UseDefaultFiles(defaultFilesOptions);
            app.UseStaticFiles();//启动静态文件支持wwwroot
            app.UseCors("CorsPolicy");
            app.UseAuthentication();
            app.UseSwagger().UseSwaggerUI(c =>
            {
                //c.InjectJavascript("https://libs.baidu.com/jquery/2.0.0/jquery.min.js"); //加载jQuery
                //c.InjectJavascript("/swagger/zh_cn.js"); //加载中文包
                c.SwaggerEndpoint($"/swagger/{Configuration["Swagger:Version"]}/swagger.json", $"WECHAT API {Configuration["Swagger:Version"]}");
                c.RoutePrefix = Configuration["Swagger:RoutePrefix"];//自定义swagger ui路由前缀，默认swagger
                c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);//接口是否展开
                c.DefaultModelExpandDepth(1);//实体模型是否展开 -1全部不展开，1只展开注释实体
            });
            app.UseRouting();
            app.UseAuthorization();
            app.UseStatusCodePages(new StatusCodePagesOptions()
            {
                HandleAsync = (context) =>
                {
                    if (context.HttpContext.Response.StatusCode == 401)
                    {
                        using (var sw = new StreamWriter(context.HttpContext.Response.Body))
                        {
                            sw.Write(JsonConvert.SerializeObject(new { status = 401, message = "access denied!" }));
                        }
                    }
                    return Task.Delay(0);
                }
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
