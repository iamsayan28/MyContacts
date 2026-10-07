using Microsoft.EntityFrameworkCore;
//using MyContactsApp.Infrastructure.Data; // Adjust if your AppDbContext namespace differs
//using MyContactsApp.Infrastructure.Services; // Adjust to your actual service namespace
//using MyContactsApp.Core.Interfaces; // Adjust to your actual interface namespace

var builder = WebApplication.CreateBuilder(args);

// 1. Add Services to the Container
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

//builder.Services.AddDbContext<AppDbContext>(options =>
//    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
//);

//builder.Services.AddScoped<IContactService, ContactService>();

// Web & UI Services
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddHttpClient();

var app = builder.Build();

// 2. Configure the HTTP Request Pipeline (Middleware Order Matters!)
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

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

// Fallback to Home/Index for single-page routing
app.MapFallbackToController("Index", "Contacts");

app.Run();