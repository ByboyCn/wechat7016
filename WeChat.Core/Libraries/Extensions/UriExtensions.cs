using System.Collections.Generic;

namespace System
{
    public static partial class UriExtensions
    {
        public static Dictionary<string, object> GetQueryParams(this Uri uri)
        {
            var result = default(Dictionary<string, object>);
            var querys = uri.Query?.Replace("?", "")?.Split('&');
            if (querys != null && querys.Length > 0)
            {
                result = new Dictionary<string, object>();
                foreach (var item in querys)
                {
                    var index = item?.IndexOf('=') ?? 0;
                    if (index > 0)
                    {
                        result.Add(item.Substring(0, index), item.Substring(index + 1));
                    }
                }
            }
            return result;
        }
    }
}
