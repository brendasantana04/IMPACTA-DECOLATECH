namespace ProjetoMyRh.AppWeb.Models.Entities
{
    public class Cargo
    {
        public int Id { get; set; }
        public int AreaId { get; set; }
        public string? Descricao { get; set; }
        public double Salario { get; set; }
        public int TipoSalario { get; set; }
        public Area? AreaAtuação { get; set; }

    }
}
