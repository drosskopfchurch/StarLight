using Microsoft.EntityFrameworkCore;

public class MarketDataContext(DbContextOptions<MarketDataContext> options) : DbContext(options)
{
    public DbSet<Company> Companies { get; set; } = null!;
    public DbSet<HistoricalPrice> HistoricalPrices { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.Symbol);
            entity.Property(e => e.Name).IsRequired();
            entity.HasData(CompanyData.SeedData);
        });

        modelBuilder.Entity<HistoricalPrice>(entity =>
        {
            entity.HasKey(e => new { e.Symbol, e.DateTime });
            entity.Property(e => e.Symbol).IsRequired();
            entity.HasData(Prices.SeedData);
        });
    }
}