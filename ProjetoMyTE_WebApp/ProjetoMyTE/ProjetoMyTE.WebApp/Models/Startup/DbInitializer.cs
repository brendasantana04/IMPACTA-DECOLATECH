using ProjetoMyTE.WebApp.Models.Contexts;

namespace ProjetoMyTE.WebApp.Models.Startup
{
    public class DbInitializer
    {
        public static void Initialize(MyRhContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
