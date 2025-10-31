using SistemaInmobilario.Dominio.Entidades;
using SistemaInmobiliario.Aplicacion.Contratos.Repositorios;
using SistemaInmobiliario.Aplicacion.Utilidades.Mediador;
using SistemaInmobiliario.Transversal.Comun;

namespace SistemaInmobiliario.Aplicacion.CasosDeUso.Clientes.Queries.ObtenerListadoClientes
{
    public class CasoDeUsoObtenerListadoClientes : IRequestHandler<ConsultaObtenerListadoClientes, Response<IEnumerable<ClienteListadoDTO>>>
    {
        private readonly IRepositorioClientes repositorioClientes;

        public CasoDeUsoObtenerListadoClientes(IRepositorioClientes repositorioClientes)
        {
            this.repositorioClientes = repositorioClientes;
        }

        public async Task<Response<IEnumerable<ClienteListadoDTO>>> Handle(ConsultaObtenerListadoClientes request)
        {
            Response<IEnumerable<ClienteListadoDTO>> response = new();
            IEnumerable<Cliente> clientes = await repositorioClientes.ObtenerTodos();
            response.Data = clientes.Select(c => c.ADto()).ToList();
            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "Consulta Exitosa!!!";
            }
            //List<ClienteListadoDTO> clientesDto = clientes.Select(c => c.ADto()).ToList();
            //return clientesDto;
            return response;
        }
    }
}
