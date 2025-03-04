using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SemanticKernelProductRanking.Data;
using SemanticKernelProductRanking.Services;

var builder = WebApplication.CreateBuilder(args);

// Veritabaný Baðlantýsý
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Semantic Kernel Servisi
builder.Services.AddScoped<SemanticKernelService>();

// MVC ve Razor Pages aktif et
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Middleware Ayarlarý
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Varsayýlan Route Ayarý
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
