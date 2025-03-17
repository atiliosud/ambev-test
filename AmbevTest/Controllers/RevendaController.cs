using AmbevTest.Data;
using AmbevTest.Domain.Entities;
using AmbevTest.Models.Revenda;
using AmbevTest.Services;
using Microsoft.AspNetCore.Mvc;

namespace AmbevTest.Controllers
{

    [Route("api/revendas")]
    [ApiController]
    public class RevendaController : ControllerBase
    {
        private readonly RevendaService _service;

        public RevendaController(RevendaService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CriarRevenda([FromBody] CriarRevendaRequest request)
        {
            String resposta = await _service.CriarRevenda(request);

            if(resposta == $"{request.CNPJ} já cadastrado" || resposta == "Escolha apenas um contato como principal")
            {
                return BadRequest(resposta);
            }

            if(resposta == "Cadastrado com sucesso"){
                return Ok(resposta);
            }

            if( resposta == "Ocorreu um erro")
            {
                return StatusCode(500, "Ocorreu um erro interno no servidor.");

            }
            return StatusCode(500, "Ocorreu um erro interno no servidor.");
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> ObterRevenda(int id)
        {
            RetornoRevenda retorno = await _service.BuscarRevendaPorID(id);

            if (retorno.Id == 0) return NotFound();

            return Ok(retorno);
        }
        
    }
}
