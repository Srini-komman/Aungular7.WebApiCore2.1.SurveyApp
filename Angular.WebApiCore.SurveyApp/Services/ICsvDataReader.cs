using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Angular.WebApiCore.SurveyApp.Services
{
    public interface ICsvDataReader
    {
        IEnumerable<T> Read<T>(string filePath, bool hasHeaders) where T : class, new();
    }
}
