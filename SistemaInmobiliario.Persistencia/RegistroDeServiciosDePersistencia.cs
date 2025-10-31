using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaInmobiliario.Aplicacion.Contratos.Persistencia;
using SistemaInmobiliario.Aplicacion.Contratos.Repositorios;
using SistemaInmobiliario.Persistencia.Contexts;
using SistemaInmobiliario.Persistencia.Repositorios;
using SistemaInmobiliario.Persistencia.UnidadDeTrabajo;

namespace SistemaInmobiliario.Persistencia
{
    public static class RegistroDeServiciosDePersistencia
    {
        public static IServiceCollection AgregarServiciosDePersistencia(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddSingleton<DapperContext>();
            //services.AddScoped<AuditableEntitySaveChangesInterceptor>();
            //services.AddDbContext<ApplicationDbContext>(options =>
            //        options.UseSqlServer(configuration.GetConnectionString("NorthwindConnection"),
            //        builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            //services.AddScoped<ICustomersRepository, CustomersRepository>();
            //services.AddScoped<IUsersRepository, UsersRepository>();
            //services.AddScoped<ICategoriesRepository, CategoriesRepository>();
            //services.AddScoped<IDiscountRepository, DiscountRepository>();

            services.AddScoped<IDbSession, DbSession>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IRepositorioClientes, RepositorioClientes>();

            return services;
        }
    }
}
