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

            arguments.AddRange(
                properties
                .OfType<string>(this)
                .Unpack<string>(this)
                .SelectMany(x => new[] { x.Key, x.Value })
            );

            arguments.AddRange(
                properties
                .OfType<bool>(this)
                .Unpack<bool>(this)
                .Where(x => x.Value)
                .Select(x => x.Key)
            );

            arguments.AddRange(
                properties
                .OfType<Enum>(this)
                .Unpack<Enum>(this)
                .SelectMany(x => new[] { x.Key, x.Value.ToFriendlyString() })
            );

            arguments.AddRange(
                properties
                .OfType<IEnumerable<Enum>>(this)
                .Unpack<IEnumerable<Enum>>(this)
                .SelectMany(x => x.Value.SelectMany(y => new[] { x.Key, y.ToFriendlyString() }))
            );

            return String.Join(" ", arguments);
        }        
    }
}
