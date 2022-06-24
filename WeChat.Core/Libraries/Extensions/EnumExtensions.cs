using System.Collections.Generic;

namespace System
{
    public static partial class Enum<TEnum> where TEnum : Enum
    {
        public static ICollection<TEnum> GetValues()
        {
            var items = new List<TEnum>();
            var values = Enum.GetValues(typeof(TEnum));
            foreach (var value in values) { items.Add((TEnum)value); }
            return items;
        }

        public static T GetAttribute<T>(TEnum element) where T : Attribute
        {
            var result = default(T);
            var attris = element.GetType().GetField(element.ToString()).GetCustomAttributes(typeof(T), true);
            if (attris != null && attris.Length > 0) { result = (attris[0] as T) ?? result; }
            return result;
        }
    }
}
