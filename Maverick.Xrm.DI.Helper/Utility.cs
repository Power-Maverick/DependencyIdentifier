using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Maverick.Xrm.DI.Helper
{
    internal class Utility
    {
        public static T GetPropertyValue<T>(object data, PropertyInfo p, int languageCode = 1033)
        {
            T propValue = default(T);
            object dataValue = p.GetValue(data);

            if (dataValue != null)
            {
                if (dataValue is Guid)
                {
                    dataValue = ((Guid)dataValue).ToString("b");
                }
                else if (dataValue is AttributeTypeDisplayName)
                {
                    dataValue = ((AttributeTypeDisplayName)dataValue).Value;
                }
                else if (dataValue is BooleanManagedProperty)
                {
                    var boolean = (BooleanManagedProperty)dataValue;
                    dataValue = boolean.Value;

                }
                else if (dataValue is AttributeRequiredLevelManagedProperty)
                {
                    var reqLevel = (AttributeRequiredLevelManagedProperty)dataValue;
                    dataValue = reqLevel.Value;
                }
                else if (dataValue is AttributeTypeCode)
                {
                    var val = (AttributeTypeCode)dataValue;
                    dataValue = val.ToString();

                }
                else if (dataValue is String[])
                {
                    var val = (String[])dataValue;
                    if (val.Length > 0)
                    {
                        dataValue = val[0];
                    }
                }

                else if (dataValue is Microsoft.Xrm.Sdk.Label)
                {
                    var label = (Microsoft.Xrm.Sdk.Label)dataValue;
                    if (label.LocalizedLabels.Count > 0)
                    {
                        var localLabel = label.LocalizedLabels.Where(l => l.LanguageCode == languageCode).FirstOrDefault();
                        if (localLabel != null)
                        {
                            dataValue = localLabel.Label;
                        }
                    }
                }
            }
            if (dataValue is IConvertible)
            {
                propValue = (T)Convert.ChangeType(dataValue, typeof(T));
            }

            return propValue;
        }

    }
}
