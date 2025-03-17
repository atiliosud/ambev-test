using AmbevTest.Data;
using AmbevTest.Domain.Entities;
using AmbevTest.Models.Pedido;
using AmbevTest.Services;
using Microsoft.AspNetCore.Mvc;

namespace AmbevTest.Controllers
{

    [Route("api/pedidos")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly PedidoService _pedidoService;

        public PedidoController(ApplicationDbContext context, PedidoService pedidoService)
        {
            _context = context;
            _pedidoService = pedidoService;
        }
        
        [HttpPost]
        public async Task<IActionResult> CriarPedido([FromBody] CriarPedidoRequest request)
        {
            if (request.Items.Sum(i => i.Quantidade) < 1000)
            {
                return BadRequest("O pedido deve conter pelo menos 1000 unidades.");
            }

            CriarPedidoResponse respostaPedido = await _pedidoService.CriarPedido(request);

            if(respostaPedido.IdDoPedido > 0)
            {
                var resposta = await _pedidoService.EnviarPedidoParaAmbev((int)respostaPedido.IdDoPedido);
                return Ok(resposta);
            }
            return StatusCode(500, "Ocorreu um erro interno no servidor.");

        }
    }
}
