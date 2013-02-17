using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace XbmcNet
{
    /// <summary>
    /// Reads an integer JSON token as a time span, assuming the integer represents the total seconds count.
    /// </summary>
    internal class TimeSpanConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
                                        JsonSerializer serializer)
        {
            var seconds = serializer.Deserialize<int?>(reader);

            if (!seconds.HasValue)
            {
                return null;
            }

            return TimeSpan.FromSeconds(seconds.Value);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof (TimeSpan?);
        }
    }
}