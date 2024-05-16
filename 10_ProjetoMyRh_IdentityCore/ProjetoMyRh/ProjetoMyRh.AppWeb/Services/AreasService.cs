using ProjetoMyRh.AppWeb.DAL;
using ProjetoMyRh.AppWeb.Models.Contexts;
using ProjetoMyRh.AppWeb.Models.DTO;
using ProjetoMyRh.AppWeb.Models.Entities;

namespace ProjetoMyRh.AppWeb.Services
{
    public class AreasService
    {
        public GenericDao<Area> AreasDao { get; set; }

        public AreasService(MyRhContext context)
        {
            this.AreasDao = new GenericDao<Area>(context);
        }

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

        public IEnumerable<AreaDTO> ListarAreasDTO()
        {
            List<AreaDTO> areas = new List<AreaDTO>();
            foreach (var item in AreasDao.Listar())
            {
                areas.Add(new AreaDTO
                {
                    Id = item.Id,
                    Descricao = item.Id + " - " + item.Descricao
                });
            }
            return areas;
        }
    }
}
