using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace System
{
    public static partial class ObjectExtensions
    {
        /// <summary>
        /// 序列化到ProtoBuf
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] SerializeToProtoBuf<T>(this T data)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                ProtoBuf.Serializer.Serialize(memoryStream, data);
                return memoryStream.ToArray();
            }
        }

        /// <summary>
        /// 是否在指定集合中存在
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static bool In<T>(this T source, ICollection<T> collection)
        {
            return source == null ? false : (collection?.Contains(source) ?? false);
        }

        /// <summary>
        /// 序列化到二进制
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] SerializeToBinary<T>(this T data)
        {
            try
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(memoryStream, data);
                    return memoryStream.ToArray();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 将对象转换成json字符串
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static string ToJson(this object target) => JsonConvert.SerializeObject(target);

        /// <summary>
        /// 满足条件调用
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target"></param>
        /// <param name="express"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static T CallWhen<T>(this T target, bool express, Action<T> action)
        {
            if (target != null && express) { action?.Invoke(target); }
            return target;
        }
    }
}
