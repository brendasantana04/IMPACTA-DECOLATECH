using ProjetoMyTE.WebApp.DAL;
using ProjetoMyTE.WebApp.Models.Contexts;
using ProjetoMyTE.WebApp.Models.Entities;

namespace ProjetoMyTE.WebApp.Services
{
    public class WBSService
    {
        public GenericDao<WBS> WBSDao { get; set; }

        public WBSService(MyTEContext context)
        {
            this.WBSDao = new GenericDao<WBS>(context);
        }

        public IEnumerable<WBS> Listar()
        {
            return WBSDao.Listar();
        }

        public WBS? Buscar(int id)
        {
            return WBSDao.Buscar(id);
        }

        public void Incluir(WBS wbs)
        {
            WBSDao.Adicionar(wbs);
        }

        public void Alterar(WBS wbs)
        {
            WBSDao.Alterar(wbs);
        }

        public void Remover(WBS wbs)
        {
            WBSDao.Remover(wbs);
        }

    }
}
