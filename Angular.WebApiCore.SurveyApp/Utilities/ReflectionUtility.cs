using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;

namespace Angular.WebApiCore.SurveyApp.Utilities
{
    public class ReflectionUtility
    {
        public static T SetPropertyValue<T>(PropertyInfo propertyInfo, T result, dynamic value)
        {
            var type = propertyInfo.PropertyType.Name;
            switch (type)
            {
                case "Int32":
                    result.GetType()
                          .GetProperty(propertyInfo.Name)
                          .SetValue(result, int.Parse(value));
                    break;
                case "Int64":
                    result.GetType()
                          .GetProperty(propertyInfo.Name)
                          .SetValue(result, long.Parse(value));
                    break;
                default:
                    result.GetType()
                          .GetProperty(propertyInfo.Name)
                          .SetValue(result, value);
                    break;
            }
            return result;
        }
    }
}
