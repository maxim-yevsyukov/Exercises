
namespace PopularPizzas
{
    abstract class RankedProduct
    {
        public RankedProduct(int rank = 0)
        {
            Rank = (rank == 0) ? 1 : rank;
        }
        public int Rank { get; set; }
    }
}
