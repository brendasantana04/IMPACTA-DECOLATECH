using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoMyTE.WebApp.Models.Entities
{
    public class WBS
    {
        public int Id { get; set; }
        [DisplayName("Código")]
        [StringLength(10, MinimumLength = 4)]
        public string? Codigo { get; set; }
        [DisplayName("Descrição")]
        [StringLength(100, MinimumLength = 4)]
        public string? Descricao { get; set;}
        [Range(1,2, ErrorMessage ="O tipo de WBS deve ser Chargeability ou Non-Chargeability")]
        public short Tipo { get; set;}
    }
}
