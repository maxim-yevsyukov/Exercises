using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace PopularPizzas
{
    class RankedPizzaConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(RankedPizza));
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer seiralizer)
        {
            throw new NotImplementedException("should never get here");
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var toppings = ((JTokenReader)reader).CurrentToken[Form1.ToppingsKeyName];

            var toppingsList = new List<RankedTopping>();
            foreach (string topping in toppings)
                toppingsList.Add(new RankedTopping(topping));

            return new RankedPizza(toppingsList);
        }

    }
}
