using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoMyRh.AppWeb.Models.Entities
{
    [Keyless]
    public class LogonViewModel
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Senha { get; set; }

        [Display(Name = "Lembrar-Me")]
        public bool RememberMe { get; set; }

    }
}
