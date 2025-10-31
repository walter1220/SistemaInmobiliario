using FluentValidation;
using FluentValidation.Results;
using SistemaInmobiliario.Aplicacion.Excepciones;
using System.Reflection;

namespace SistemaInmobiliario.Aplicacion.Utilidades.Mediador
{
    public class MediadorSimple : IMediator
    {
        private readonly IServiceProvider serviceProvider;
        public MediadorSimple(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }


        public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request)
        {
            await RealizarValidaciones(request);

            Type tipoCasoDeUso = typeof(IRequestHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));

            object? casoDeUso = serviceProvider.GetService(tipoCasoDeUso);

            if (casoDeUso is null)
            {
                throw new ExcepcionDeMediador($"No se encontro un handler para {request.GetType().Name}");
            }

            MethodInfo? metodo = tipoCasoDeUso.GetMethod("Handle");
            return await (Task<TResponse>)metodo!.Invoke(casoDeUso, new object[] { request })!;
        }

        public async Task Send(IRequest request)
        {
            await RealizarValidaciones(request);

            Type tipoCasoDeUso = typeof(IRequestHandler<>).MakeGenericType(request.GetType());
            object? casoDeUso = serviceProvider.GetService(tipoCasoDeUso);
            if (casoDeUso is null)
            {
                throw new ExcepcionDeMediador($"No se encontro un handler para {request.GetType().Name}");
            }
            MethodInfo? metodo = tipoCasoDeUso.GetMethod("Handle");
            await (Task)metodo!.Invoke(casoDeUso, new object[] { request })!;

        }

        private async Task RealizarValidaciones(object request)
        {
            Type tipoValidador = typeof(IValidator<>).MakeGenericType(request.GetType());

            object? validador = serviceProvider.GetService(tipoValidador);

            if (validador is not null)
            {
                MethodInfo? metodoValidador = tipoValidador.GetMethod("ValidateAsync");
                Task tareaValidar = (Task)metodoValidador!.Invoke(validador, new object[] { request, CancellationToken.None })!;

                await tareaValidar.ConfigureAwait(false);

                PropertyInfo? resultado = tareaValidar.GetType().GetProperty("Result");
                ValidationResult validationResult = (ValidationResult)resultado!.GetValue(tareaValidar)!;

                if (!validationResult.IsValid)
                {
                    IEnumerable<string> errores = validationResult.Errors.Select(e => e.ErrorMessage);
                    throw new ExcepcionDeValidacion(errores);
                    //throw new ExcepcionDeValidacion(validationResult);
                }
            }
        }
    }
}
