using Microsoft.EntityFrameworkCore;
using Virtumart_MVC_3.Models;

var builder = WebApplication.CreateBuilder(args);

// Get the connection string from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("virtumart");

// Register DbContext with the connection string
builder.Services.AddDbContext<VirtuMartContext>(options =>
    options.UseSqlServer(connectionString));

// Add MVC services to the container
builder.Services.AddControllersWithViews();

// Add session services
builder.Services.AddDistributedMemoryCache(); // For in-memory session storage
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Session timeout duration
    options.Cookie.HttpOnly = true; // Makes session cookie inaccessible via client-side scripts
    options.Cookie.IsEssential = true; // Essential cookie for GDPR compliance
});

builder.Services.AddHttpContextAccessor(); // Ensure this is added to access HttpContext

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // Adds HTTP Strict Transport Security in production
}
else
{
    app.UseDeveloperExceptionPage(); // Shows detailed error pages in development
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Enable session middleware before routing
app.UseSession();

app.UseAuthorization();

// Set up the default controller route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
