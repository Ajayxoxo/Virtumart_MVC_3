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
    public DbSet<IProduct> productinfo { get; set; }
    public DbSet<ProductInfo> ProductInfos { get; set; }
    public DbSet<ImageUrl> imageurl { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IProduct>()
            .HasMany(p => p.Urls)
            .WithOne(i => i.Product)
            .HasForeignKey(i => i.productid);

        base.OnModelCreating(modelBuilder);
    }


}
