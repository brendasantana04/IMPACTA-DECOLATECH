namespace ProjetoMyTE.WebApp.Models.Entities
{
    public class RegistroHoras
    {
        public int Id { get; set; }
        public int QtdHoras { get; set; }
        public DateTime Dia { get; set; }
        public int ColaboradorId { get; set; }
        public int WBSId{ get; set; }
        public Colaborador? Colaborador{ get; set; }
        public WBS? WBS{ get; set; }
    }
}
