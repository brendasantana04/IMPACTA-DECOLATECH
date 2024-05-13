using Microsoft.AspNetCore.Mvc;
using ProjetoMyTE.WebApp.Models.Entities;
using ProjetoMyTE.WebApp.Services;

namespace ProjetoMyTE.WebApp.Controllers
{
    public class WBSController : Controller
    {
        private readonly WBSService wbsService;

        public IActionResult Index()
        {
            return View();
        }

        public WBSController(WBSService wbsService)
        {
            this.wbsService = wbsService;
        }
        public IActionResult ListarWBS()
        {
            var lista = wbsService.Listar();
            return View(lista);
        }

        //adicionar
        [HttpGet]
        public IActionResult IncluirWBS()
        {
            return View();
        }
        [HttpPost]
        public IActionResult IncluirWBS(WBS wbs)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                wbsService.Incluir(wbs);
                return RedirectToAction("ListarWBS"); // requisição get
            }
            catch
            {
                throw;
            }
        }

        //metodo de alterar area
        [HttpGet]
        public IActionResult AlterarWBS(int id)
        {
            try
            {
                //verificando se o id informado é valido
                if (id <= 0)
                {
                    throw new
                        ArgumentException($"O valor informado na URL ({id}) é inválido");
                }
                WBS? wbs = wbsService.Buscar(id);
                if (wbs == null)
                {
                    throw new ArgumentException($"Nenhum objeto encontrado com este id: ({id})");
                }
                return View(wbs);
            }
            catch (Exception e)
            {
                return View("_Erro", e);
            }

        }
        [HttpPost]
        public IActionResult AlterarWBS(WBS wbs)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                wbsService.Alterar(wbs);
                return RedirectToAction("ListarWBS"); // requisição get
            }
            catch
            {
                throw;
            }
        }

        //action para excluir uma area
        [HttpGet]
        public IActionResult RemoverWBS(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new
                        ArgumentException($"O valor informado na URL ({id}) é inválido");
                }
                WBS? wbs = wbsService.Buscar(id);
                if (wbs == null)
                {
                    throw new
                        ArgumentException($"Nenhum objeto encontrado com este id: ({id})");
                }
                return View(wbs);
            }
            catch (Exception e)
            {
                return View("_Erro", e);
            }
        }
        [HttpPost]
        public IActionResult RemoverWBS(WBS wbs)
        {
            try
            {
                wbsService.Remover(wbs);
                return RedirectToAction("ListarWBS");
            }
            catch (Exception e)
            {
                return View("_Erro", e);
            }
        }
    }
}
