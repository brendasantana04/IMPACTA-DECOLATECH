using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetoMyTE.WebApp.Models.Entities;
using ProjetoMyTE.WebApp.Services;

namespace ProjetoMyTE.WebApp.Controllers
{
    public class CargosController : Controller
    {
        private readonly AreasService areasService;
        private readonly CargosService cargosService;

        //construtor
        public CargosController(AreasService areasService, CargosService cargosService)
        {
            this.areasService = areasService;
            this.cargosService = cargosService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AdicionarCargo()
        {
            ViewBag.ListaDeAreas = new SelectList(areasService.Listar(), "Id", "Descricao");
            return View();
        }
        [HttpPost]
        public IActionResult AdicionarCargo(Cargo cargo)
        {
            try
            {
                if (cargo.AreaId == 0)
                {
                    ModelState.AddModelError("AreaID", "Nenhuma área foi selecionada");
                }

                if (!ModelState.IsValid)
                {
                    return AdicionarCargo();
                }
                cargosService.Adicionar(cargo);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {

                return View("_Erro", e);
            }
        }

        [HttpGet]
        public IActionResult ListarCargos(int AreaID)
        {
            //parametro id se refere ao id da area
            try
            {
                ViewBag.ListaDeAreas = new SelectList(areasService.Listar(), "Id", "Descricao");
                return View(cargosService.ListarCargos(AreaID));
            }
            catch (Exception e)
            {
                return View("_Erro", e);
            }
        }
        [HttpGet]
        public IActionResult AlterarCargo(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentException($"O valor informado na URL ({id}) é inválido");
                }

                Cargo? cargo = cargosService.Buscar(id);
                if (cargo == null)
                {
                    throw new ArgumentException($"Nenhum objeto com este id: ({id})");
                }
                return View(cargo);
            }
            catch (Exception e)
            {

                return View("_Erro", e);
            }
        }

        [HttpPost]
        public IActionResult AlterarCargo(Cargo cargo)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                cargosService.Alterar(cargo);
                return RedirectToAction("ListarCargos");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public IActionResult RemoverCargo(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentException($"O valor informado na URL ({id}) é inválido");
                }

                Cargo? cargo = cargosService.Buscar(id);
                if (cargo == null)
                {
                    throw new NullReferenceException($"Nenhum objeto com este id: ({id})");
                }
                return View(cargo);
            }
            catch (Exception e)
            {
                return View("_Erro", e);
            }
        }

        [HttpPost]
        public IActionResult RemoverCargo(Cargo cargo)
        {
            try
            {
                cargosService.Remover(cargo);
                return RedirectToAction("ListarCargos");
            }
            catch (Exception e)
            {
                return View("_Erro", e);
            }
        }
    }
}
