using Microsoft.EntityFrameworkCore;
using ProjetoMyTE.WebApp.Models.Contexts;
using ProjetoMyTE.WebApp.Models.Startup;
using ProjetoMyTE.WebApp.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        //configuration manager
        ConfigurationManager config = builder.Configuration;

        builder.Services.AddDbContext<MyRhContext>(options =>
                    options.UseSqlServer(config.GetConnectionString("MyRhConnection")));

        //adicionando servicos das models
        builder.Services.AddScoped<AreasService>();
        builder.Services.AddScoped<CargosService>();

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        //adicionando servicos pro 
        var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<MyRhContext>(); //momento em que myrhcontext é instanciado

        //sincronizando com banco de dados
        DbInitializer.Initialize(context);

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
    }
}