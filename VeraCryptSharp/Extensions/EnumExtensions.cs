using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using VeraCryptSharp.Attributes;

namespace VeraCryptSharp.Extensions
{
    public static class EnumExtensions
    {
        public static string ToFriendlyString(this Enum enumeration)
        {
            var enumType = enumeration.GetType();
            var memInfo = enumType.GetMember(enumeration.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                var attrs = memInfo[0].GetCustomAttributes(typeof(ArgumentName), false);
                if (attrs != null && attrs.Length > 0)
                    return ((ArgumentName)attrs[0]).Name;
            }

            return enumeration.ToString();
        }
    }
}
