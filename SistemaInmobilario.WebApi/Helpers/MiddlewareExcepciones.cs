using SistemaInmobiliario.Aplicacion.Excepciones;

namespace SistemaInmobilario.WebApi.Helpers
{
    public class MiddlewareExcepciones
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<MiddlewareExcepciones> _logger;

        public MiddlewareExcepciones(RequestDelegate next, ILogger<MiddlewareExcepciones> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ExcepcionBase ex) // excepciones controladas
            {
                _logger.LogError(ex, "Error controlado: {Mensaje}", ex.Message);
                await EscribirRespuestaAsync(context, ex.CodigoHttp, ex.Titulo, ex.Message);
            }
            catch (Exception ex) // errores no controlados
            {
                _logger.LogError(ex, "Error no controlado: {Mensaje}", ex.Message);
                await EscribirRespuestaAsync(
                    context,
                    StatusCodes.Status500InternalServerError,
                    "Error interno del servidor",
                    ex.Message);
            }
        }

        private static async Task EscribirRespuestaAsync(HttpContext context, int status, string titulo, string detalle)
        {
            context.Response.ContentType = "application/problem+json";
            context.Response.StatusCode = status;

            var problem = new
            {
                status,
                title = titulo,
                detail = detalle,
                instance = context.Request.Path
            };

            await context.Response.WriteAsJsonAsync(problem);
        }
    }
}
