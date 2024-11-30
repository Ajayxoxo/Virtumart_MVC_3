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
    public DbSet<ImageUrl> ImageUrls { get; set; }
    


}
