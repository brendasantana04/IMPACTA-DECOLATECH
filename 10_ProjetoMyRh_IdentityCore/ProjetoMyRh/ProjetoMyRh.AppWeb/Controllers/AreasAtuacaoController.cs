using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoMyRh.AppWeb.Models.Entities;
using ProjetoMyRh.AppWeb.Services;

namespace ProjetoMyRh.AppWeb.Controllers
{
    public class AreasAtuacaoController : Controller
    {
        private readonly AreasService areasService;
        public AreasAtuacaoController(AreasService areasService)
        {
            this.areasService = areasService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ListarAreas()
        {
            var lista = areasService.Listar();
            return View(lista);
        }
        [HttpGet]
        [Authorize]
        public IActionResult IncluirArea()
        {
            return View();
        }
        [HttpPost]
        public IActionResult IncluirArea(Area area)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                areasService.Incluir(area);
                return RedirectToAction("ListarAreas"); // requisição get
            }
            catch
            {
                throw;
            }
        }

        //action para alterar a descricao de uma area
        [HttpGet]
        public IActionResult AlterarArea(int id) 
        {
            try
            {
                //verificando se o id informado é valido
                if (id <= 0)
                {
                    throw new 
                        ArgumentException($"O valor informado na URL ({id}) é inválido");
                }
                Area? area = areasService.Buscar(id);
                if (area == null)
                {
                    throw new ArgumentException($"Nenhum objeto encontrado com este id: ({id})");
                }
                return View(area);
            }
            catch (Exception e)
            {
                return View("_Erro", e);
            }
            
        }
        [HttpPost]
        public IActionResult AlterarArea(Area area)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                areasService.Alterar(area);
                return RedirectToAction("ListarAreas"); // requisição get
            }
            catch
            {
                throw;
            }

        }
        //action para excluir uma area
        [HttpGet]
        public IActionResult RemoverArea(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new
                        ArgumentException($"O valor informado na URL ({id}) é inválido");
                }
                Area? area = areasService.Buscar(id);
                if (area == null)
                {
                    throw new
                        ArgumentException($"Nenhum objeto encontrado com este id: ({id})");
                }
                return View(area);
            }
            catch (Exception e)
            {
                return View("_Erro", e);
            }
        }
        [HttpPost]
        public IActionResult RemoverArea(Area area)
        {
            try
            {
                areasService.Remover(area);
                return RedirectToAction("ListarAreas");
            }
            catch (Exception e)
            {
                return View("_Erro", e);
            }
        }
    }
}
