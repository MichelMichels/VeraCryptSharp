using System;
using System.Collections.Generic;
using System.Text;

namespace VeraCryptSharp.Attributes
{
    public class ArgumentName : Attribute
    {
        public ArgumentName(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}
