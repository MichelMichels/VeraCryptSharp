using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using VeraCryptSharp.Attributes;

namespace VeraCryptSharp.Extensions
{
    public static class PropertyInfoExtensions
    {
        public static T GetValue<T>(this PropertyInfo property, object source)
        {
            return (T)property.GetValue(source);
        }

        public static bool IsOfType<T>(this PropertyInfo property, object source)
        {
            return IsSameOrSubclass(property.PropertyType, typeof(T)) && property.GetValue(source) != null;
        }

        public static IEnumerable<PropertyInfo> OfType<T>(this IEnumerable<PropertyInfo> properties, object source)
        {
            return properties.Where(x => x.IsOfType<T>(source));
        }

        public static KeyValuePair<string, TValue> Unpack<TValue>(this PropertyInfo property, object source)
        {
            var name = property.GetCustomAttribute<ArgumentName>().Name;
            var value = property.GetValue<TValue>(source);

            return new KeyValuePair<string, TValue>(name, value);
        }

        public static IEnumerable<KeyValuePair<string, TValue>> Unpack<TValue>(this IEnumerable<PropertyInfo> properties, object source)
        {
            return properties.Select(x => x.Unpack<TValue>(source));
        }

        private static bool IsSameOrSubclass(Type potentialBase, Type potentialDescendant)
        {
            return potentialDescendant.IsSubclassOf(potentialBase)
                   || potentialDescendant == potentialBase;
        }
    }
}
