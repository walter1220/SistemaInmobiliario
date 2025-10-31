using Microsoft.AspNetCore.Http;

namespace SistemaInmobiliario.Aplicacion.Excepciones
{
    public sealed class ExcepcionDeValidacion : ExcepcionBase
    {
        public IReadOnlyList<string> Errores { get; }

        public ExcepcionDeValidacion(IEnumerable<string> errores)
            : base("Uno o más errores de validación ocurrieron.")
        {
            Errores = errores.ToList();
        }

        public override int CodigoHttp => StatusCodes.Status400BadRequest;
        public override string Titulo => "Error de validación";
    }
}
