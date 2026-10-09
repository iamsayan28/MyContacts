using Microsoft.EntityFrameworkCore;
using MyContactsApp.Web.Components;

var builder = WebApplication.CreateBuilder(args);

// 1. Database & Services
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);

builder.Services.AddScoped<ContactService>();
builder.Services.AddScoped<AddressBookService>();

// 2. Pure Blazor Services
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

var app = builder.Build();

// 3. Middleware Pipeline
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// 4. Endpoints - All routes go to Blazor Router
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();