using Microsoft.Extensions.DependencyInjection;
using SistemaInmobiliario.Aplicacion.Utilidades.Mediador;
using System.Reflection;

namespace SistemaInmobiliario.Aplicacion
{
    public static class RegistroDeServicioDeAplicacion
    {
        public static IServiceCollection AgregarServiciosDeAplicacion(this IServiceCollection services)
        {
            services.AddTransient<IMediator, MediadorSimple>();

            Assembly assembly = Assembly.GetExecutingAssembly();

            // Registrar todos los IRequestHandler<,> automáticamente
            List<Type> handlers = assembly.GetTypes()
                .Where(t => t.GetInterfaces().Any(i =>
                    i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>)))
                .ToList();

            foreach (Type? handler in handlers)
            {
                IEnumerable<Type> interfaces = handler.GetInterfaces()
                    .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>));

                foreach (Type? i in interfaces)
                {
                    services.AddTransient(i, handler);
                }
            }

            //services.Scan(scan => scan.FromAssembliesOf(typeof(IMediator))
            //.AddClasses(c => c.AssignableTo(typeof(IRequestHandler<>)))
            //.AsImplementedInterfaces()
            //.WithScopedLifetime()
            //.AddClasses(c => c.AssignableTo(typeof(IRequestHandler<,>)))
            //.AsImplementedInterfaces()
            //.WithScopedLifetime());

            //services.AddScoped<IRequestHandler<ComandoCrearConsultorio, Guid>, CasoDeUsoCrearConsultorio>();
            //services.AddScoped<IRequestHandler<ConsultaObtenerDetalleConsultorio, ConsultorioDetalleDTO>, CasoDeUsoObtenerDetalleConsultorio>();
            //services.AddScoped<IRequestHandler<ConsultaObtenerListadoConsultorios, List<ConsultorioListadoDTO>>, CasoDeUsoObtenerListadoConsultorios>();
            //services.AddScoped<IRequestHandler<ComandoActualizarConsultorio>, CasoDeUsoActualizarConsultorio>();
            //services.AddScoped<IRequestHandler<ComandoBorrarConsultorio>, CasoDeUsoBorrarConsultorio>();

            return services;
        }
    }
}
