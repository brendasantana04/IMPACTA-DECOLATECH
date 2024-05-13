using ProjetoMyTE.WebApp.DAL;
using ProjetoMyTE.WebApp.Models.Contexts;
using ProjetoMyTE.WebApp.Models.Entities;

namespace ProjetoMyTE.WebApp.Services
{
    public class CargosService
    {
        GenericDao<Cargo> CargosDao {  get; set; }

        //controller do cargos
        public CargosService(MyTEContext context)
        {
            this.CargosDao = new GenericDao<Cargo>(context);
        }

        public void Adicionar(Cargo cargo)
        {
            CargosDao.Adicionar(cargo);
        }

        public IEnumerable<Cargo> ListarCargos(int idArea)
        {
            if (idArea > 0)
            {
                return CargosDao.Listar().Where(c => c.AreaId == idArea);
            }
            return CargosDao.Listar();
        }
        public Cargo? Buscar(int id)
        {
            return CargosDao.Buscar(id);
        }

        public void Alterar(Cargo cargo)
        {
            CargosDao.Alterar(cargo);
        }

        public void Remover(Cargo cargo)
        {
            CargosDao.Remover(cargo);
        }


    }
}
