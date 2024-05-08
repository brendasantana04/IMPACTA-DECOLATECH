using ProjetoMyTE.WebApp.DAL;
using ProjetoMyTE.WebApp.Models.Contexts;
using ProjetoMyTE.WebApp.Models.Entities;

namespace ProjetoMyTE.WebApp.Services
{
    public class CargosService
    {
        GenericDao<Cargo> CargosDao {  get; set; }

        //controller do cargos
        public CargosService(MyRhContext context)
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
                return CargosDao.Listar().Where(c => c.ID_AREA == idArea);
            }
            return CargosDao.Listar();
        }

    }
}
