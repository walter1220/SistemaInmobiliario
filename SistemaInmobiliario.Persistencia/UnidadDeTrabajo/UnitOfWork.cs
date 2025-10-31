using SistemaInmobiliario.Aplicacion.Contratos.Persistencia;

namespace SistemaInmobiliario.Persistencia.UnidadDeTrabajo
{
    public sealed class UnitOfWork(IDbSession session) : IUnitOfWork
    {
        public void BeginTransaction()
        {
            session.Transaction = session.Connection.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                session.Transaction?.Commit();
            }
            finally
            {
                Dispose();
            }
        }

        public void Rollback()
        {
            session.Transaction?.Rollback();

            Dispose();
        }

        public void Dispose()
        {
            session.Transaction?.Dispose();
        }

    }
}
