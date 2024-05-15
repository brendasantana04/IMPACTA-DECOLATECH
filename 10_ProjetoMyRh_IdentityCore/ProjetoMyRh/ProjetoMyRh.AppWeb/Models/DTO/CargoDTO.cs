using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoMyRh.AppWeb.Models.DTO
{
    public class CargoDTO
    {
        public int Id { get; set; }
        public int AreaId { get; set; }
        [DisplayName("Área")]
        public string? DescricaoArea { get; set; }
        [DisplayName("Cargo")]
        public string? DescricaoCargo { get; set; }
        [DisplayName("Salário")]
        [DataType(DataType.Currency)]
        public double Salario { get; set; }
        [DisplayName("Tipo de Salário")]
        public string? TipoSalario { get; set; }
    }
}
