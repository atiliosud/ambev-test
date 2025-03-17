using Microsoft.AspNetCore.Mvc;

namespace AmbevTest.Controllers
{

    [Route("api/mock-ambev")]
    [ApiController]
    public class MockAmbevApiController : ControllerBase
    {
        [HttpPost("pedidos")]
        public IActionResult ReceberPedido([FromBody] object pedido)
        {
            return Ok(new { pedidoId = Guid.NewGuid(), status = "Recebido com sucesso" });
        }
    }
}
