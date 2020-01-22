using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Net.Http;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PopularPizzas
{
    public partial class Form1 : Form
    {
        private const string Url = "http://files.olo.com/pizzas.json";
        public const string ToppingsKeyName = "toppings";

        private HttpClient _client;


        public Form1()
        {
            InitializeComponent();
            _client = new HttpClient();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string json = _client.GetStringAsync(Url).Result;

            JToken[] jTokens;
            using (JsonTextReader reader = new JsonTextReader(new StringReader(json)))
            {
                jTokens = JToken.ReadFrom(reader).ToArray();
            }

            var serializer = new JsonSerializer();                                                  // set up a serializer with a relevant converter
            serializer.Converters.Add(new RankedPizzaConverter());

            var uniquePizzas = new List<RankedPizza>();
            foreach (JObject jo in jTokens)
            {
                RankedPizza runningRp = jo.ToObject<RankedPizza>(serializer);
                var existingPizza = uniquePizzas.Find(p => p.Name == runningRp.Name);

                if (existingPizza is null)
                {
                    uniquePizzas.Add(runningRp);                                                    // runningRp does not exist in uniquePizzas list, so add

                    foreach (var t in runningRp.Toppings)
                    {                                    
                        var pizzasWithCurTopp = uniquePizzas.FindAll(p => p.Name.Contains(t.Name)); // in uniquePizzas, find all that contain current topping,
                        foreach (var p in pizzasWithCurTopp)
                        {
                            var existT = p.Toppings.Find(tt => tt.Name == t.Name);                  // and among toppings of each, find current topping
                            if (existT != null)                                                     // and, if exists,
                                existT.Rank += 1;                                                   // increment its rank
                        }       
                    }
                }
                else
                {
                    existingPizza.Rank += 1;                                                        // since runningRp already exists in the uniquePizzas, don't add it but increment existing pizza's rank instead
                    existingPizza.Toppings.ForEach(t => t.Rank += 1);                               // naturally, each topping of the existing pizza gets to increment its rank as well
                }
            }


            // display results
            var top20pizzas = uniquePizzas.OrderByDescending(p => p.Rank).ToList().GetRange(0, 20);
            foreach (var p in top20pizzas)
                textBox1.Text += p.ToString();
            
        }
    }
}
