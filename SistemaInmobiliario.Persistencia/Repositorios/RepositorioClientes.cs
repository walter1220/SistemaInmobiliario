using Dapper;
using SistemaInmobilario.Dominio.Entidades;
using SistemaInmobiliario.Aplicacion.Contratos.Persistencia;
using SistemaInmobiliario.Aplicacion.Contratos.Repositorios;
using SistemaInmobiliario.Aplicacion.Excepciones;
using System.Data;
using System.Text;

namespace SistemaInmobiliario.Persistencia.Repositorios
{
    public class RepositorioClientes(IDbSession session) : IRepositorioClientes
    {
        public async Task<IEnumerable<Cliente>> ObtenerTodos()
        {
            StringBuilder query = new(@"
                        SELECT Id, Nombres, Apellidos, Dni, Correo,Telefono,Direccion,TipoCliente
                        FROM Clientes");

            try
            {
                IDbConnection connection = session.Connection;

                //return await connection.QueryAsync<Clientes>(query.ToString(), param: null, commandType: CommandType.Text, transaction: session.Transaction);
                IEnumerable<Cliente> result = await connection.QueryAsync<Cliente>(query.ToString(), param: null, commandType: CommandType.Text, transaction: session.Transaction);

                return result?.ToList() ?? new List<Cliente>();
            }
            catch (Exception ex)
            {
                throw new ExcepcionDeConsulta($"No se pudo realizar la consulta a {nameof(ObtenerTodos)}", ex);
            }
        }
    }
}
