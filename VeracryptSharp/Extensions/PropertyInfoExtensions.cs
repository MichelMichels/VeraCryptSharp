using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using VeraCryptSharp.Attributes;
using VeraCryptSharp.Core;

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
            return IsSameOrSubclass(typeof(T), property.PropertyType) && property.GetValue(source) != null;
        }
        public static IEnumerable<PropertyInfo> OfType<T>(this IEnumerable<PropertyInfo> properties, object source)
        {
            return properties.Where(x => x.IsOfType<T>(source));
        }
        public static KeyValuePair<string, TValue> Unpack<TValue>(this PropertyInfo property, object source)
        {
            var name = property.GetCustomAttribute<ArgumentName>()?.Name ?? property.Name;
            var value = property.GetValue<TValue>(source);

            return new KeyValuePair<string, TValue>(name, value);
        }
        public static IEnumerable<KeyValuePair<string, TValue>> Unpack<TValue>(this IEnumerable<PropertyInfo> properties, object source)
        {
            return properties.Select(x => x.Unpack<TValue>(source));
        }
        public static CommandLineSwitch ToCommandLineSwitch(this PropertyInfo property, object source)
        {
            return new CommandLineSwitch(property.GetCustomAttribute<ArgumentName>().Name);
        }

        private static bool IsSameOrSubclass(Type potentialBase, Type potentialDescendant)
        {
            return potentialDescendant.IsSubclassOf(potentialBase)
                   || potentialDescendant == potentialBase;
        }
    }
}
