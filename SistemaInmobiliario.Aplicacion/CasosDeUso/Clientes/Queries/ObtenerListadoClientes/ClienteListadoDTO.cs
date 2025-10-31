namespace SistemaInmobiliario.Aplicacion.CasosDeUso.Clientes.Queries.ObtenerListadoClientes
{
    public class ClienteListadoDTO
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Dni { get; set; } //DNI=8 Y CE:11
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string TipoCliente { get; set; } //'Comprador', 'Inquilino', 'Ambos'
    }
}
