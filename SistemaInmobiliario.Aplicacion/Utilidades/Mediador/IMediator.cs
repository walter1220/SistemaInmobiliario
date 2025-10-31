namespace SistemaInmobiliario.Aplicacion.Utilidades.Mediador
{
    public interface IMediator
    {
        Task<TResponse> Send<TResponse>(IRequest<TResponse> reuqest);
        Task Send(IRequest reuqest);
    }
}
