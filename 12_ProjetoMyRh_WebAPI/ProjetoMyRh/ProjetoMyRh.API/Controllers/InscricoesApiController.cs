using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoMyRh.API.Services;

namespace ProjetoMyRh.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InscricoesApiController : ControllerBase
    {
        private readonly InscricoesService _inscricoesService;
        public InscricoesApiController(InscricoesService inscricoesService)
        {
            this._inscricoesService = inscricoesService;
        }

        [HttpGet]
        public IActionResult ListarInscricoes()
        {
            return Ok(_inscricoesService.ListarInscricoes());
        }
    }
}
