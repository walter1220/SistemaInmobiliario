using SistemaInmobilario.Dominio.Entidades;

namespace SistemaInmobiliario.Aplicacion.CasosDeUso.Clientes.Queries.ObtenerListadoClientes
{
    public static class MapeadorExtensions
    {
        public static ClienteListadoDTO ADto(this Cliente cliente)
        {
            ClienteListadoDTO dto = new()
            {
                Id = cliente.Id,
                Nombres = cliente.Nombres + ' ' + cliente.Apellidos,
                //Apellidos = cliente.Apellidos,
                Dni = cliente.Dni,
                Correo = cliente.Correo,
                Telefono = cliente.Telefono,
                Direccion = cliente.Direccion,
                TipoCliente = cliente.TipoCliente
            };
            return dto;
        }
    }
}
