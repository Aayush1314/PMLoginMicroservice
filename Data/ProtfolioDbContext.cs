using Microsoft.EntityFrameworkCore;
using LoginMicroservice.Model;

namespace LoginMicroservice.Data
{
    public class ProtfolioDbContext:DbContext
    {
        public ProtfolioDbContext(DbContextOptions<ProtfolioDbContext> options):base(options)
        {

        }
        public DbSet<User> Users { get; set; }

        public DbSet<StockPriceDetails> StockPriceDetails { get; set; }

        public DbSet<StockDetails> StockDetails { get; set; }

        public DbSet<MutualFundDetails> MutualFundDetails { get; set; }

        public DbSet<MutualFundPriceDetails> MutualFundPriceDetails { get; set; }

        //public DbSet<AssetSellResponse> AssetSellResponse { get; set; }

        public DbSet<PortfolioDetails> PortfolioDetails { get; set; }

    }
}
