using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetoMyTE.WebApp.Models.Entities;
using ProjetoMyTE.WebApp.Services;

namespace ProjetoMyTE.WebApp.Controllers
{
    public class RegistroHorasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly RegistroHorasService registroHorasService;
        private readonly ColaboradoresService colaboradoresService;
        private readonly WBSService wbsService;

        public RegistroHorasController(RegistroHorasService registroHorasService, ColaboradoresService colaboradoresService, WBSService wbsService)
        {
            this.colaboradoresService = colaboradoresService;
            this.registroHorasService = registroHorasService;
            this.wbsService = wbsService;
        }

        [HttpGet]
        public IActionResult AdicionarRegistroHoras()
        {
            ViewBag.ListadeRegistroHoras = new SelectList(registroHorasService.ListarRegistroHoras(), "Id", "QtdHoras");
            return View();
        }

        [HttpPost]
        public IActionResult AdicionarRegistroHoras(RegistroHoras registroHoras)
        {
            try
            {
                if (registroHoras.ColaboradorId == 0 || registroHoras.WBSId == 0)
                {
                    ModelState.AddModelError("ColaboradorId, WBSId", "Nenhum colaborador e/ou WBS foi selecionado");
                }

                if (!ModelState.IsValid)
                {
                    return AdicionarRegistroHoras();
                }
                registroHorasService.Adicionar(registroHoras);
                return RedirectToAction("ListarRegistroHoras");
            }
            catch (Exception e)
            {

                return View("_Erro", e);
            }
        }

        [HttpGet]
        public IActionResult ListarRegistroHoras()
        {
            var lista = registroHorasService.ListarRegistroHoras();
            return View(lista);
        }

    }
}
