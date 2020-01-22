using System.Collections.Generic;
using System.Linq;

namespace PopularPizzas
{
    class RankedPizza : RankedProduct
    {
        private string _name = "";

        public RankedPizza(List<RankedTopping> toppings)
        {
            Toppings = toppings.OrderBy(x => x.Name).ToList();
            Toppings.ForEach(t => _name += t.Name + "-");
            _name = _name.TrimEnd('-');
        }

        public string Name => _name;

        public List<RankedTopping> Toppings { get; private set; }

        public override string ToString()
        {
            var ret = $"Combination: {Name}; Number of times ordered: {Rank}";
            Toppings.ForEach(t => ret += "\r\n\t" + t.ToString());
            return ret + "\r\n\r\n";
        }
    }
}
