using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using SistemaInmobiliario.Aplicacion.Contratos.Persistencia;
using SistemaInmobiliario.Aplicacion.Utilidades.Configuracion;
using System.Data;

namespace SistemaInmobiliario.Persistencia.Contexts
{
    public sealed class DbSession : IDbSession
    {
        public IDbConnection Connection { get; }
        public required IDbTransaction? Transaction { get; set; }

        public DbSession(IOptions<ApplicationOptions> appConfig)
        {
            Connection = new SqlConnection(appConfig.Value.ConnectionStringDbSistemaInmobiliario);

            Connection.Open();

            Transaction = null;
        }

        public void Dispose()
        {
            Connection.Dispose();
        }

    }
}
