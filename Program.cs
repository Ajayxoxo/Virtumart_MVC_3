using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<VirtuMartContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("virtumart")));

// Add session services
builder.Services.AddDistributedMemoryCache(); // For in-memory storage of session data
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Session timeout duration
    options.Cookie.HttpOnly = true; // Makes the session cookie inaccessible via client-side scripts
    options.Cookie.IsEssential = true; // Ensures session cookies are used even without GDPR consent
});

// Add controllers with views
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor(); 


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else{
    app.UseDeveloperExceptionPage();
}

// Enable session middleware
app.UseSession();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
