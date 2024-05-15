using ProjetoMyRh.AppWeb.DAL;
using ProjetoMyRh.AppWeb.Models.Contexts;
using ProjetoMyRh.AppWeb.Models.DTO;
using ProjetoMyRh.AppWeb.Models.Entities;

namespace ProjetoMyRh.AppWeb.Services
{
    public class CargosService
    {
        public GenericDao<Cargo> CargosDao { get; set; }
        public MyRhContext Context { get; set; }
        public CargosService(MyRhContext context)
        {
            this.CargosDao = new GenericDao<Cargo>(context);
            this.Context = context;
        }
        public void Adicionar(Cargo cargo)
        {
            CargosDao.Adicionar(cargo);
        }
        public IEnumerable<Cargo> ListarCargos(int idArea)
        {
            if (idArea > 0)
            {
                return CargosDao.Listar()
                                .Where(c => c.AreaId == idArea)
                                .ToList();
            }
            return CargosDao.Listar();
        }

        // uso do DTO: CargoDTO
        public IEnumerable<CargoDTO> ListarCargosDTO(int idArea)
        {
            List<CargoDTO> cargos = new List<CargoDTO>();
            foreach (var item in CargosDao.Listar())
            {
                var c = new CargoDTO()
                {
                    Id = item.Id,
                    AreaId = item.AreaId,
                    DescricaoArea = item.AreaAtuacao!.Descricao,
                    DescricaoCargo = item.Descricao,
                    Salario = item.Salario,
                    TipoSalario = item.TipoSalario == 1 ? "Mensal" : "Por Hora"
                };
                cargos.Add(c);
            }
            if (idArea > 0)
            {
                return cargos.Where(p => p.AreaId == idArea);
            }
            return cargos;
        }

        //usando join entre area e cargo (entidades area e cargo)
        //metodo para listar as informações do cargo  e sua respectiva area
        public IEnumerable<CargoDTO> ListarCargosJoin(int idArea)
        {
            var lista = Context.Areas.Join(
                Context.Cargos,
                a => a.Id,
                c => c.AreaId,
                (a, c) => new CargoDTO
                {
                    Id = c.Id,
                    AreaId = c.AreaId, //a.Id, //ou c.AreaId
                    DescricaoArea = a.Descricao,
                    DescricaoCargo = c.Descricao,
                    Salario = c.Salario,
                    TipoSalario = c.TipoSalario == 1 ? "Mensal" : "Por Hora"
                });

            if (idArea > 0)
            {
                return lista.Where(p => p.AreaId == idArea).ToList();
            }
            return lista.ToList();
        }
        public IEnumerable<CargoDTO> ListarCargosLINQ(int idArea)
        {
            var lista = from a in Context.Areas
                        join c in Context.Cargos
                        on a.Id equals c.AreaId
                        select new CargoDTO
                        {
                            Id = c.Id,
                            AreaId = a.Id,
                            DescricaoArea = a.Descricao,
                            DescricaoCargo = c.Descricao,
                            Salario = c.Salario,
                            TipoSalario = c.TipoSalario ==1 ? "Mensal" : "Por Hora"
                        };
            if (idArea > 0)
            {
                return lista.Where(p => p.AreaId == idArea).ToList();
            }
            return lista.ToList();
        }
    }
}
