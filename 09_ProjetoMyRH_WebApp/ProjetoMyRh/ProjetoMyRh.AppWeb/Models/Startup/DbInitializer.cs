using ProjetoMyRh.AppWeb.Models.Contexts;

namespace ProjetoMyRh.AppWeb.Models.Startup
{
    public class DbInitializer
    {
        public static void Initialize(MyRhContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
