using SistemaInmobiliario.Aplicacion.Utilidades.Mediador;
using SistemaInmobiliario.Transversal.Comun;

namespace SistemaInmobiliario.Aplicacion.CasosDeUso.Clientes.Queries.ObtenerListadoClientes
{
    public class ConsultaObtenerListadoClientes : IRequest<Response<IEnumerable<ClienteListadoDTO>>> { }
}
