using Microsoft.AspNetCore.Identity;

namespace ProjetoMyRh.AppWeb.Models.Common
{
    public class Utils
    {
        public static async Task CreateRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider
                .GetRequiredService<RoleManager<IdentityRole>>();

            string[] roleNames = { "ADMIN", "USER", "GUEST" };

            IdentityResult result;

            foreach (var role in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(role);
                if (!roleExist)
                {
                    result = await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
        public static string? USERNAME = null;
        public static UsuarioLogado? UsuarioLogado { get; set; } = new UsuarioLogado();
    }
}
