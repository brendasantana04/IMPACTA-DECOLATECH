namespace Conceitos.WebApi.Models
{
    public class Listas
    {
        public static IEnumerable<Curso> ListarCursos()
        {
            return new List<Curso>()
            {
                new Curso() { Id = 10, Descricao = "Asp.Net", Ch = 60 },
                new Curso() { Id = 20, Descricao = "Turismo", Ch = 2000 },
                new Curso() { Id = 30, Descricao = "Corte e Costura", Ch = 400 },
                new Curso() { Id = 40, Descricao = "Culinária", Ch = 100 }
            };
        }
    }
}   
