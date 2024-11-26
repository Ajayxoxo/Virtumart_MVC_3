using Virtumart_MVC_3.Models;
using Microsoft.EntityFrameworkCore;
using VirtuMart_MVC_3.Models;

public class VirtuMartContext : DbContext
{
    public VirtuMartContext(DbContextOptions<VirtuMartContext> options)
    : base(options)
    {
    }

    public DbSet<User> userinfo { get; set; }
    public DbSet<Admin> admininfo { get; set; }
    public DbSet<Product> productinfo { get; set; }
    public DbSet<ProductInfo> ProductInfos { get; set; }
    public DbSet<ImageUrl> ImageUrls { get; set; }
   

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ImageUrl>()
            .HasOne(i => i.ProductInfo)
            .WithMany(p => p.Images)
            .HasForeignKey(i => i.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        base.OnModelCreating(modelBuilder);
    }
}
