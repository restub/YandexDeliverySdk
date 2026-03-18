using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace YandexDeliverySdk
{
    public static class ExtensionMethods
    {
        public static void AddQueryParameterIfNotEmpty(this IRestRequest rest, string name, string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                rest.AddQueryParameter(name, value);
            }
        }

        public static void AddQueryParameterIfNotDefault<T> (this IRestRequest rest, string name,
            T value, T defaultValue = default, Func<T, string> toString = null)
        {
            if (!Equals(value, defaultValue))
            {
                var jsonValue = rest.ToJsonString(value);
                rest.AddQueryParameter(name, jsonValue);
            }
        }

        public static string ToJsonString<T>(this IRestRequest rest, T value)
        {
            var jsonValue = rest?.JsonSerializer?.Serialize(value) ?? JsonConvert.SerializeObject(value);
            return jsonValue.Trim('"');
        }
    }
}
