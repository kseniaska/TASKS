using Microsoft.EntityFrameworkCore;

namespace Shop.Dal
{
    public sealed class ShopEntityContext : DbContext
    {
        public string DataSource { get; private set; }

        public DbSet<ShopDao> Shops { get; set; }
        public DbSet<GoodDao> Goods { get; set; }
        public DbSet<ClientDao> Clients { get; set; }
        public ShopEntityContext(string dataSource)
        {
            DataSource = dataSource;
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DataSource}");
        }
    }
}
