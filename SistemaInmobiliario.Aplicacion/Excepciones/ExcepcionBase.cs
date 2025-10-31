using Microsoft.AspNetCore.Http;

namespace SistemaInmobiliario.Aplicacion.Excepciones
{
    public abstract class ExcepcionBase : Exception
    {
        protected ExcepcionBase(string mensaje, Exception? innerException = null)
           : base(mensaje, innerException)
        {
        }

        /// <summary>
        /// Código HTTP asociado a la excepción (por defecto 500).
        /// </summary>
        public virtual int CodigoHttp => StatusCodes.Status500InternalServerError;

        /// <summary>
        /// Título estándar mostrado en el ProblemDetails.
        /// </summary>
        public virtual string Titulo => "Error interno del servidor";
    }
}
