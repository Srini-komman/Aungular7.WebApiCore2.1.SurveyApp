using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Angular.WebApiCore.SurveyApp.Utilities;
using System.IO;
using System.Reflection;

namespace Angular.WebApiCore.SurveyApp.Services
{
    public class CsvDataReader : ICsvDataReader
    {
        public IEnumerable<T> Read<T>(string filePath, bool hasHeaders) where T : class, new()
        {
            using (var reader = new StreamReader(filePath))
            {
                string currentLine = reader.ReadLine();
                string[] usedHeaders = currentLine.Split(',');

                while ((currentLine = reader.ReadLine()) != null)
                {
                    var fields = currentLine.Split(',');
                    var result = new T();
                    PropertyInfo[] properties = typeof(T).GetProperties();
                    for (var i = 0; i < usedHeaders.Length; i++)
                    {
                        var value = fields[i];
                        //var propInfo = typeof(T).GetProperties()[i];

                        var propInfo = properties.FirstOrDefault(prop => prop.Name == usedHeaders[i]);
                        if (propInfo != null) { 
                            result = ReflectionUtility.SetPropertyValue(propInfo, result, value);
                        }

                    }
                    yield return result;
                }
            }

        }
    }
}
