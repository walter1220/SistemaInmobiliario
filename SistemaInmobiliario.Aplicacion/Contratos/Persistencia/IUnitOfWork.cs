namespace SistemaInmobiliario.Aplicacion.Contratos.Persistencia
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
