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
                if (cargo.ID_AREA == 0)
                {
                    ModelState.AddModelError("Id_Area", "Nenhuma área foi selecionada");
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
        public IActionResult ListarCargos(int ID_AREA)
        {
            //parametro id se refere ao id da area
            try
            {
                ViewBag.ListaDeAreas = new SelectList(areasService.Listar(), "Id", "Descricao");
                return View(cargosService.ListarCargos(ID_AREA));
            }
            catch (Exception e)
            {
                return View("_Erro", e);
            }   
        }

    }
}
