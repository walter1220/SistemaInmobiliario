using System.Data;

namespace SistemaInmobiliario.Aplicacion.Contratos.Persistencia
{
    public interface IDbSession : IDisposable
    {
        IDbConnection Connection { get; }
        IDbTransaction? Transaction { get; set; }
    }
}
