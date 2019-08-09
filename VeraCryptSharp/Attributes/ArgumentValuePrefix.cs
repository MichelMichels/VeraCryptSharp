using System;
using System.Collections.Generic;
using System.Text;

namespace VeraCryptSharp.Attributes
{
    public class ArgumentValuePrefix : Attribute
    {
        public ArgumentValuePrefix(string value)
        {
            Value = value;
        }

        public string Value { get; set; }
    }
}
