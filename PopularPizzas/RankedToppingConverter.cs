using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PopularPizzas
{
    class RankedToppingConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(RankedTopping));
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer seiralizer)
        {
            writer.WriteValue(((RankedTopping)value).Name);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            string s = (string)reader.Value;
            return new RankedTopping(s);
        }
    }
}
