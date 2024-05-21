using Conceitos.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Conceitos.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public string ApresentarTexto()
        {
            return "ASP.NET CORE WEBAPI";
        }
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return $"Execução do método HTTP Get, com valor {id}";
        }

        [HttpGet("exibir/{id}")]
        public string GetText(int id)
        {
            return $"Execução de outra action com valor {id}";
        }

        //endpoint para listar os cursos parte 1
        [HttpGet]
        [Route("api/primeiralista")]
        public IEnumerable<Curso> GetCursos1()
        {
            return Listas.ListarCursos();
        }

        [HttpGet]
        [Route("segundalista")]
        public IActionResult GetCursos2()
        {
            try
            {
                var lista = Listas.ListarCursos();
                if (lista.Count() < 5)
                {
                    throw new Exception("A lista e muito pequena");
                }
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = 400, message = ex.Message });
            }
        }
    }

}
