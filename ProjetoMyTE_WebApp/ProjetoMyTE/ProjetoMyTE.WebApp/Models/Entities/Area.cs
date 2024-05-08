using System.ComponentModel;

namespace ProjetoMyTE.WebApp.Models.Entities
{
    public class Area
    {
        //propriedades de area
        public int ID { get; set; }
        [DisplayName("Descrição")]
        public string? DESCRICAO { get; set; }
        public ICollection<Cargo>? Cargos { get; set; }
    }
}
