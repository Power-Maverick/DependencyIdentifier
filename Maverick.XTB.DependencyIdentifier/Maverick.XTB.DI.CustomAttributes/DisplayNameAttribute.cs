using System;
using System.Collections.Generic;
using System.Text;

namespace Maverick.XTB.DI.CustomAttributes
{
    public class DisplayNameAttribute : Attribute
    {
        internal DisplayNameAttribute(string displayName)
        {
            this.Name = displayName;
        }
        public string Name { get; private set; }
    }
}
