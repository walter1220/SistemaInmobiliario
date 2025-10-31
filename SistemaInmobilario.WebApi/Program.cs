
using Asp.Versioning.ApiExplorer;
using SistemaInmobilario.WebApi.Helpers;
using SistemaInmobilario.WebApi.Modulos.Swagger;
using SistemaInmobilario.WebApi.Versioning;
using SistemaInmobiliario.Aplicacion;
using SistemaInmobiliario.Aplicacion.Utilidades.Configuracion;
using SistemaInmobiliario.Persistencia;

namespace SistemaInmobilario.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            //builder.Services.AddOpenApi();
            builder.Services.AddEndpointsApiExplorer();

            //Enlazar la configuración ApplicationOptions con IOptions<T>
            builder.Services.Configure<ApplicationOptions>(
                builder.Configuration.GetSection(nameof(ApplicationOptions))
            );

            // Obtener instancia para uso directo si la necesitas
            ApplicationOptions appConfig = builder.Configuration.GetSection(nameof(ApplicationOptions)).Get<ApplicationOptions>()!;

            builder.Services.AddVersioning();
            builder.Services.AddSwagger();
            builder.Services.AgregarServiciosDePersistencia(builder.Configuration);
            //builder.Services.AddInfrastructureServices();
            builder.Services.AgregarServiciosDeAplicacion();

            WebApplication app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                //app.MapOpenApi();
                app.UseDeveloperExceptionPage();
                IApiVersionDescriptionProvider provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    // build a swagger endpoint for each discovered API version

                    foreach (ApiVersionDescription description in provider.ApiVersionDescriptions)
                    {
                        c.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                    }
                });
            }


            //app.UseCors("policyApiEcommerce");
            app.UseMiddleware<MiddlewareExcepciones>();

            app.UseHttpsRedirection();
            //app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
