using Microsoft.AspNetCore.Http;

namespace SistemaInmobiliario.Aplicacion.Excepciones
{
    public sealed class ExcepcionNoEncontrado : ExcepcionBase
    {
        public ExcepcionNoEncontrado(string mensaje)
            : base(mensaje)
        {
        }

        public override int CodigoHttp => StatusCodes.Status404NotFound;
        public override string Titulo => "Recurso no encontrado";
    }
}
