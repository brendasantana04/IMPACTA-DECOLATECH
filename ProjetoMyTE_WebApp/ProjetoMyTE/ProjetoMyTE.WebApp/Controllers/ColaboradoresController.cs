using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetoMyTE.WebApp.Models.Entities;
using ProjetoMyTE.WebApp.Services;

namespace ProjetoMyTE.WebApp.Controllers
{
    public class ColaboradoresController : Controller
    {

        private readonly ColaboradoresService colaboradoresService;
        private readonly CargosService cargosService;

        public ColaboradoresController(ColaboradoresService colaboradoresService, CargosService cargosService)
        {
            this.colaboradoresService = colaboradoresService;
            this.cargosService = cargosService;

        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AdicionarColaborador()
        {
            ViewBag.ListaDeColaboradores = new SelectList(colaboradoresService.ListarColaboradores(), "Id", "Nome");
            return View();
        }

        [HttpPost]
        public IActionResult AdicionarColaborador(Colaborador colaborador)
        {
            try
            {
                if (colaborador.CargoId == 0)
                {
                    ModelState.AddModelError("CargoId", "Nenhum cargo foi selecionado");
                }

                if (!ModelState.IsValid)
                {
                    return AdicionarColaborador();
                }
                colaboradoresService.Adicionar(colaborador);
                return RedirectToAction("ListarColaboradores");
            }
            catch (Exception e)
            {

                return View("_Erro", e);
            }
        }

        [HttpGet]
        public IActionResult ListarColaboradores()
        {
            var lista = colaboradoresService.ListarColaboradores();
            return View(lista);
        }

        [HttpGet]
        public IActionResult AlterarColaborador(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentException($"O valor informado na URL ({id}) é inválido");
                }

                Colaborador? colaborador = colaboradoresService.Buscar(id);
                if (colaborador == null)
                {
                    throw new ArgumentException($"Nenhum objeto com este id: ({id})");
                }
                return View(colaborador);
            }
            catch (Exception e)
            {

                return View("_Erro", e);
            }
        }

        [HttpPost]
        public IActionResult AlterarColaborares(Colaborador colaborador)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                colaboradoresService.Alterar(colaborador);
                return RedirectToAction("ListarColaboradores"); // requisição get
            }
            catch
            {
                throw;
            }
        }

        //action para excluir uma area
        [HttpGet]
        public IActionResult RemoverColaborador(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new
                        ArgumentException($"O valor informado na URL ({id}) é inválido");
                }
                Colaborador? colaborador = colaboradoresService.Buscar(id);
                if (colaborador == null)
                {
                    throw new
                        ArgumentException($"Nenhum objeto encontrado com este id: ({id})");
                }
                return View(colaborador);
            }
            catch (Exception e)
            {
                return View("_Erro", e);
            }
        }
        [HttpPost]
        public IActionResult RemoverColaborador(Colaborador colaborador)
        {
            try
            {
                colaboradoresService.Remover(colaborador);
                return RedirectToAction("ListarColaboradores");
            }
            catch (Exception e)
            {
                return View("_Erro", e);
            }
        }
    }
}
