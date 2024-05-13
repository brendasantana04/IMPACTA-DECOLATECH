using ProjetoMyTE.WebApp.DAL;
using ProjetoMyTE.WebApp.Models.Contexts;
using ProjetoMyTE.WebApp.Models.Entities;

namespace ProjetoMyTE.WebApp.Services
{
    public class AreasService
    {
        public GenericDao<Area> AreasDao { get; set; }

        public AreasService(MyTEContext context)
        {
            this.AreasDao = new GenericDao<Area>(context);
        }

        //adaptacao dos metodos genericos Dao para o model area
        public IEnumerable<Area> Listar()
        {
            return AreasDao.Listar();
        }
        public Area? Buscar(int id)
        {
            return AreasDao.Buscar(id);
        }
        public void Incluir(Area area)
        {
            AreasDao.Adicionar(area);
        }
        public void Alterar(Area area)
        {
            AreasDao.Alterar(area);
        }
        public void Remover(Area area)
        {
            AreasDao.Remover(area);
        }
    }
}
