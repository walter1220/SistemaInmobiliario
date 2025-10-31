using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using SistemaInmobiliario.Aplicacion.CasosDeUso.Clientes.Queries.ObtenerListadoClientes;
using SistemaInmobiliario.Aplicacion.Utilidades.Mediador;

namespace SistemaInmobilario.WebApi.Controllers.v1
{
    //[Authorize]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class ClientesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ClientesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("ObtenerTodos")]
        public async Task<IActionResult> ObtenerTodosClientes()
        {
            var response = await _mediator.Send(new ConsultaObtenerListadoClientes());
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }
    }
}
