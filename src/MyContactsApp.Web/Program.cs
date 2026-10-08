using Microsoft.EntityFrameworkCore;
using MyContactsApp.Web.Components;

var builder = WebApplication.CreateBuilder(args);

// 1. Add Services to the Container
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);

builder.Services.AddScoped<ContactService>();

// Web & UI Services
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

var app = builder.Build();

// 2. Configure the HTTP Request Pipeline (Middleware Order Matters!)
app.UseHttpsRedirection();
app.UseStaticFiles();

// Routing MUST come before Antiforgery, Authorization, and Endpoints
app.UseRouting();

app.UseAntiforgery();
app.UseAuthorization();

// 3. Endpoint Mappings
app.MapStaticAssets();
app.MapRazorPages();
app.MapBlazorHub();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Contacts}/{action=Index}/{id?}")
    .WithStaticAssets();
app.MapControllers();

app.MapFallbackToController("Index", "Contacts");
app.Run();