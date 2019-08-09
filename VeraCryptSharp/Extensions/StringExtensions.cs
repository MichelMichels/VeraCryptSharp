using System;
using System.Collections.Generic;
using System.Text;

namespace VeraCryptSharp.Extensions
{
    public static class StringExtensions
    {
        public static void AddRange(this List<string> collection, params string[] values) => collection.AddRange(values);
    }
}
