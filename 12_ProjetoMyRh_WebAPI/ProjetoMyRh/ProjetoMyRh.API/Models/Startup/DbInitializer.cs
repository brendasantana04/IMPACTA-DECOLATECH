using ProjetoMyRh.API.Models.Contexts;

namespace ProjetoMyRh.API.Models.Startup
{
    public class DbInitializer
    {
        public static void Initialize(MyRhContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
