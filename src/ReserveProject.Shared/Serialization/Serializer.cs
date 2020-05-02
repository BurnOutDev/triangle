using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace ReserveProject.Shared.Serialization
{
    public class Serializer
    {
        public static T As<T>(string json)
        {
            if (string.IsNullOrEmpty(json)) return default(T);

            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Objects,
                DateFormatString = SystemSettings.ShortDatePattern
            };
            settings.Converters.Add(new IsoDateTimeConverter {DateTimeFormat = SystemSettings.LongDatePattern});
            return JsonConvert.DeserializeObject<T>(json, settings);
        }

        public static string Serialize(object value, bool typeNameHandling = true)
        {
            var settings = new JsonSerializerSettings
            {
                DateFormatString = SystemSettings.ShortDatePattern,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            if (typeNameHandling) settings.TypeNameHandling = TypeNameHandling.Objects;

            settings.Converters.Add(new IsoDateTimeConverter {DateTimeFormat = SystemSettings.LongDatePattern});
            var json = JsonConvert.SerializeObject(value, settings);

            return json;
        }

        public T GetPropertyValue<T>(string json, string propertyPath)
        {
            var jo = JObject.Parse(json);
            var token = jo.SelectToken(propertyPath);
            return token.ToObject<T>();
        }

        public T DeepCopy<T>(T obj, bool typeNameHandling = true)
        {
            var json = Serialize(obj, typeNameHandling);
            return As<T>(json);
        }
    }
}