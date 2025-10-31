namespace SistemaInmobiliario.Aplicacion.Utilidades.Configuracion
{
    public sealed class ApplicationOptions
    {
        public string Environment { get; init; } = string.Empty;
        public string ConnectionStringDbSistemaInmobiliario { get; init; } = string.Empty;
        public string ConnectionStringDbSistemaInmobiliarioLog { get; init; } = string.Empty;
        public int LogsBatchSize { get; init; }
        public int LogsTimerInsert { get; init; }
    }
}
