using ProjetoMyTE.WebApp.DAL;
using ProjetoMyTE.WebApp.Models.Contexts;
using ProjetoMyTE.WebApp.Models.Entities;

namespace ProjetoMyTE.WebApp.Services
{
    public class RegistroHorasService
    {
        public GenericDao<RegistroHoras> RegistroHorasDao { get; set; }

        public RegistroHorasService(MyTEContext context)
        {
            this.RegistroHorasDao = new GenericDao<RegistroHoras>(context);
        }

        //adaptacao dos metodos genericos Dao para o model area
        public IEnumerable<RegistroHoras> ListarRegistroHoras()
        {
            return RegistroHorasDao.Listar();
        }
        public RegistroHoras? Buscar(int id)
        {
            return RegistroHorasDao.Buscar(id);
        }
        public void Adicionar(RegistroHoras registroHoras)
        {
            RegistroHorasDao.Adicionar(registroHoras);
        }
        public void Alterar(RegistroHoras registroHoras)
        {
            RegistroHorasDao.Alterar(registroHoras);
        }
        public void Remover(RegistroHoras registroHoras)
        {
            RegistroHorasDao.Remover(registroHoras);
        }
    }
}
