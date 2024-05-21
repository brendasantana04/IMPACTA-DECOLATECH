using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjetoMyRh.API.Models.Entities
{
    public class Candidato
    {

        /*public int Id { get; set; }*/
        [Key]
        public string? Cpf { get; set; }
        public string? Nome { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }

        //usar com cautela
        [JsonIgnore]
        public ICollection<Inscricao>? Inscricoes { get; set; }
    }
}
