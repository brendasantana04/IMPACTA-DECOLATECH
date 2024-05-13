using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoMyRh.AppWeb.Models.Entities
{
    public class Area
    {
        //propriedades da area
        public int Id { get; set; }

        [DisplayName("Descrição")]
        //atributo
        [Required(
            ErrorMessage = "A descrição da área é obrigatória",
            AllowEmptyStrings = false)]
        public string? Descricao { get; set; }
        //coleção de cargos
        public ICollection<Cargo>? Cargos { get; set; }
    }
}
