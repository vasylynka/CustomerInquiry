using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CustomerInquiry.Api.Infrastructure
{
    public static class JsonSerializeSettingsExtensions
    {
        public static JsonSerializerSettings CamelCase => new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        public static void UseJsonCamelCaseResolver(this HttpConfiguration config, params JsonConverter[] customConvertors)
        {
            var jsonFormatters = config.Formatters.OfType<JsonMediaTypeFormatter>().ToArray();

            if (jsonFormatters.Any())
            {
                var customSettings = GetDefaultSettings();

                foreach (var formatter in jsonFormatters)
                {
                    formatter.SerializerSettings.ContractResolver = customSettings.ContractResolver;
                    formatter.SerializerSettings.NullValueHandling = customSettings.NullValueHandling;
                    formatter.SerializerSettings.ReferenceLoopHandling = customSettings.ReferenceLoopHandling;
                    formatter.SerializerSettings.DateTimeZoneHandling = customSettings.DateTimeZoneHandling;
                    formatter.SerializerSettings.DateFormatString = customSettings.DateFormatString;
                    if (customConvertors?.Count() > 0)
                        customConvertors.ToList().ForEach(x => formatter.SerializerSettings.Converters.Add(x));

                }
            }
            else
            {
                config.Formatters.Add(new JsonMediaTypeFormatter { SerializerSettings = CamelCase });
            }
        }

        public static JsonSerializerSettings GetDefaultSettings()
        {
            return new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                DateTimeZoneHandling = DateTimeZoneHandling.Utc
            };
        }
    }
}