using Microsoft.EntityFrameworkCore;
using Mission_6Peal.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure the MoviesContext for Entity Framework Core
builder.Services.AddDbContext<MoviesContext>(options =>
{
    // Use SQLite as the database provider
    options.UseSqlite(builder.Configuration["ConnectionStrings:MovieConnection"]);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // Exception handling middleware for non-development environments
    app.UseExceptionHandler("/Home/Error");

    // HTTP Strict Transport Security (HSTS) middleware
    // Helps secure your site by only allowing HTTPS requests
    app.UseHsts();
}

// Redirect HTTP requests to HTTPS
app.UseHttpsRedirection();

// Serve static files from the wwwroot folder
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Configure the default controller route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Start the application
app.Run();

