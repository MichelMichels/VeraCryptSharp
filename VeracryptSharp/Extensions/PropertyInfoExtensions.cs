using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

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
            return property.PropertyType == typeof(T) && property.GetValue(source) != null;
        }
    }
}
