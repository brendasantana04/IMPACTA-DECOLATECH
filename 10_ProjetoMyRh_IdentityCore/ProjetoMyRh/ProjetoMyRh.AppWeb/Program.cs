using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjetoMyRh.AppWeb.Models.Common;
using ProjetoMyRh.AppWeb.Models.Contexts;
using ProjetoMyRh.AppWeb.Models.Startup;
using ProjetoMyRh.AppWeb.Services;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager config = builder.Configuration;

// Add services to the container. CONTEXTOS
builder.Services.AddDbContext<MyRhContext>(options =>
    options.UseSqlServer(config.GetConnectionString("MyRhConnection")));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(config.GetConnectionString("IdentityConnection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores <ApplicationDbContext>();

//opcional, mas importante
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequiredLength = 8;
    options.Password.RequiredUniqueChars = 3;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Autenticacao/Login";
    options.LogoutPath = "/Autenticacao/Logout";
    options.AccessDeniedPath = "/Autenticacao/AccessDenied";
});

//habilitandoo serviço de areasservice e cargosservice para injeção de dependencia
builder.Services.AddScoped<AreasService>();
builder.Services.AddScoped<CargosService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

var scope = app.Services.CreateScope();
var provider = scope.ServiceProvider;
var context = provider.GetRequiredService<MyRhContext>();

//sincronizando o contexto com o banco de dados
DbInitializer.Initialize(context);
Utils.CreateRoles(provider).Wait();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
