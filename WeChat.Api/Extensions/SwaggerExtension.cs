using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


namespace WeChat.Api
{
    /// <summary>
    /// 控制注释
    /// </summary>
    public class ClassDescriptions : IDocumentFilter
    {
        /// <summary>
        /// 接口实现
        /// </summary>
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            swaggerDoc.Tags = new List<OpenApiTag>
            {
                new OpenApiTag { Name = "Extension", Description = "扩展功能" },
                new OpenApiTag { Name = "Client", Description = "客户端操作" }
                //.....
            };
        }
    }

    /// <summary>
    /// 接口组排序标记
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class ApiGroupSortAttribute : System.Attribute
    {
        /// <summary>
        /// 序号
        /// 越大越靠前
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="sort"></param>
        public ApiGroupSortAttribute(int sort) => Sort = sort;
    }

    /// <summary>
    /// 接口组排序标记
    /// </summary>
    public class ApiGroupSortFilter : IDocumentFilter
    {
        /// <summary>
        /// 接口实现
        /// </summary>
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            Dictionary<OpenApiTag, int> tags = new Dictionary<OpenApiTag, int>();
            var assembly = Assembly.GetExecutingAssembly();
            var fullname = $"{assembly.GetName().Name}.Controllers.{{0}}Controller"; //WeChat.Api.Controllers.{0}Controller
            foreach (var item in swaggerDoc.Tags)
            {
                tags.Add(item, assembly.GetType(string.Format(fullname, item.Name)).GetCustomAttribute<ApiGroupSortAttribute>()?.Sort ?? 0);
            }
            swaggerDoc.Tags = tags.OrderByDescending(p => p.Value).ToDictionary(k => k.Key, v => v.Value).Keys.ToList();
        }
    }

    /// <summary>
    /// 隐藏接口标记
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class HiddenApiAttribute : System.Attribute
    {
    }

    /// <summary>
    /// 隐藏接口标记
    /// </summary>
    public class HiddenApiFilter : IDocumentFilter
    {
        /// <summary>
        /// 接口实现
        /// </summary>
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            foreach (ApiDescription apiDescription in context.ApiDescriptions)
            {
                if (apiDescription.TryGetMethodInfo(out MethodInfo method))
                {
                    if (method.ReflectedType.CustomAttributes.Any(t => t.AttributeType == typeof(HiddenApiAttribute))
                            || method.CustomAttributes.Any(t => t.AttributeType == typeof(HiddenApiAttribute)))
                    {
                        string key = "/" + apiDescription.RelativePath;
                        if (key.Contains("?"))
                        {
                            int idx = key.IndexOf("?", System.StringComparison.Ordinal);
                            key = key.Substring(0, idx);
                        }
                        swaggerDoc.Paths.Remove(key);
                    }
                }
            }
        }
    }
}
