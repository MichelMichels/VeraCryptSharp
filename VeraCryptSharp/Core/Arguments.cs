using System;
using System.Collections.Generic;
using System.Reflection;
using VeraCryptSharp.Extensions;
using VeraCryptSharp.Attributes;
using VeraCryptSharp.Enums;
using System.Linq;

namespace VeraCryptSharp.Core
{
    public abstract class Arguments
    {
        public override string ToString()
        {
            var arguments = new List<string>();
            var properties = GetType().GetProperties();

            arguments.AddRange(GetStringArgumentsString(properties));
            arguments.AddRange(GetBooleanArgumentsString(properties));
            arguments.AddRange(GetEnumArgumentsString(properties));
            arguments.AddRange(GetIEnumerableEnumArgumentsString(properties));

            return String.Join(" ", arguments);
        }        

        public virtual IEnumerable<string> GetBooleanArgumentsString(IEnumerable<PropertyInfo> properties)
        {
            return properties
                .OfType<bool>(this)
                .Unpack<bool>(this)
                .Where(x => x.Value)
                .Select(x => x.Key);
        }
        public virtual IEnumerable<string> GetStringArgumentsString(IEnumerable<PropertyInfo> properties)
        {
            return properties
                .OfType<string>(this)
                .Unpack<string>(this)
                .SelectMany(x => new[] { x.Key, x.Value });
        }
        public virtual IEnumerable<string> GetEnumArgumentsString(IEnumerable<PropertyInfo> properties)
        {
            return properties
                .OfType<Enum>(this)
                .Unpack<Enum>(this)
                .SelectMany(x => new[] { x.Key, x.Value.ToFriendlyString() });
        }
        public virtual IEnumerable<string> GetIEnumerableEnumArgumentsString(IEnumerable<PropertyInfo> properties)
        {
            return properties
                .OfType<IEnumerable<Enum>>(this)
                .Unpack<IEnumerable<Enum>>(this)
                .SelectMany(x => x.Value.SelectMany(y => new[] { x.Key, y.ToFriendlyString() }));
        }
    }
}
