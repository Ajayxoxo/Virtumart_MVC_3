using Virtumart_MVC_3.Models;
using Microsoft.EntityFrameworkCore;

public class VirtuMartContext : DbContext
{
    public VirtuMartContext(DbContextOptions<VirtuMartContext> options)
    : base(options)
    {
    }

    public DbSet<User> userinfo { get; set; }
    public DbSet<Admin> admininfo { get; set; }
}
