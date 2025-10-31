using Microsoft.AspNetCore.Http;

namespace SistemaInmobiliario.Aplicacion.Excepciones
{
    public sealed class ExcepcionDeConsulta : ExcepcionBase
    {
        public ExcepcionDeConsulta(string mensaje, Exception? innerException = null)
           : base(mensaje, innerException)
        {
        }

        public override int CodigoHttp => StatusCodes.Status503ServiceUnavailable;
        public override string Titulo => "Error en la consulta a la base de datos";
    }
}
