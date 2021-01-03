using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using TesteConfitec.Services.Implementacao;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TesteConfitec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EscolaridadeController : ControllerBase
    {
        private readonly IEscolaridadeService _escolaridadeService;

        public EscolaridadeController(IEscolaridadeService escolaridadeService)
        {
            _escolaridadeService = escolaridadeService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_escolaridadeService.GetEscolaridades());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_escolaridadeService.GetEscolaridadeById(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
