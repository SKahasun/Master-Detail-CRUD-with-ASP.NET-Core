using _1294372_Master_Details.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "C",
    pattern: "C",
    defaults: new { controller = "Customer", action = "Index" }
);
app.MapControllerRoute(
    name: "ct",
    pattern: "ct",
    defaults: new { controller = "Customer", action = "Create" }
);
app.MapControllerRoute(
    name: "ED",
    pattern: "ED",
    defaults: new { controller = "Customer", action = "Edit" }
);

app.MapControllerRoute(
    name: "SI",
    pattern: "SI",
    defaults: new { controller = "Services", action = "Index" }
);
app.MapControllerRoute(
    name: "SDE",
    pattern: "SDE",
    defaults: new { controller = "Services", action = "Delete" }
);
app.MapControllerRoute(
    name: "SCR",
    pattern: "SCR",
    defaults: new { controller = "Services", action = "Create" }
);
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapRazorPages()
   .WithStaticAssets();

app.Run();
