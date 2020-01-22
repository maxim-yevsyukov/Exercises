using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PopularPizzas
{
    class RankedTopping : RankedProduct
    {
        public RankedTopping(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public override string ToString()
        {
            return $"topping: {Name}; number of times ordered: {Rank}";
        }
    }
}
