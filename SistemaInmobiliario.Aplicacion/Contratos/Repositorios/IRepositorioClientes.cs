using SistemaInmobilario.Dominio.Entidades;

namespace SistemaInmobiliario.Aplicacion.Contratos.Repositorios
{
    public interface IRepositorioClientes
    {
        Task<IEnumerable<Cliente>> ObtenerTodos();
    }
}
