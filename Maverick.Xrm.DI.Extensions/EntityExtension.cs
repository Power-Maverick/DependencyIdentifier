using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Text;

namespace Maverick.XTB.DI.Extensions
{
    public static class EntityExtension
    {
        public static string GetFormattedValue(this Entity value, string attributeName)
        {
            if (value.FormattedValues.Contains(attributeName))
            {
                return value.FormattedValues[attributeName];
            }
            else
            {
                return "--";
            }
        }
    }
}
