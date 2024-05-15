using ProjetoMyTE.WebApp.DAL;
using ProjetoMyTE.WebApp.Models.Contexts;
using ProjetoMyTE.WebApp.Models.Entities;

namespace ProjetoMyTE.WebApp.Services
{
    public class ColaboradoresService
    {
        public GenericDao<Colaborador> CalaboradoresDao { get; set; }

        public ColaboradoresService(MyTEContext context)
        {
            this.CalaboradoresDao = new GenericDao<Colaborador>(context);
        }

        public void Adicionar(Colaborador colaborador)
        {
            CalaboradoresDao.Adicionar(colaborador);
        }

        public IEnumerable<Colaborador> ListarColaboradores()
        {
            return CalaboradoresDao.Listar();
        }

        public Colaborador? Buscar(int id)
        {
            return CalaboradoresDao.Buscar(id);
        }

        public void Alterar(Colaborador colaborador)
        {
            CalaboradoresDao.Alterar(colaborador);
        }

        public void Remover(Colaborador colaborador)
        {
            CalaboradoresDao.Remover(colaborador);
        }

    }
}
