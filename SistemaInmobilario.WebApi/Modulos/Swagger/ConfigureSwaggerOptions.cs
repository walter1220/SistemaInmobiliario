using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SistemaInmobilario.WebApi.Modulos.Swagger
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        readonly IApiVersionDescriptionProvider provider;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigureSwaggerOptions"/> class.
        /// </summary>
        /// <param name="provider">The <see cref="IApiVersionDescriptionProvider">provider</see> used to generate Swagger documents.</param>
        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            this.provider = provider;
        }

        /// <inheritdoc />
        public void Configure(SwaggerGenOptions options)
        {
            // add a swagger document for each discovered API version
            // note: you might choose to skip or document deprecated API versions differently
            foreach (ApiVersionDescription description in provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
            }
        }

        static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
        {
            OpenApiInfo info = new()
            {
                Version = description.ApiVersion.ToString(),
                Title = "Sistema Inmobiliario Integral API",
                Description = "Sistema de Venta y Alquiler de Propiedades ASP.NET Core Web API.",
                TermsOfService = new Uri("https://sistemaInmobiliarioWbc.com/terms"),
                Contact = new OpenApiContact
                {
                    Name = "Walter Brenis Casiano",
                    Email = "walterbc12@gmail.com",
                    Url = new Uri("https://sistemaInmobiliarioWbc.com/contact")
                },
                License = new OpenApiLicense
                {
                    Name = "Use under LICX",
                    Url = new Uri("https://sistemaInmobiliarioWbc.com/licence")
                }
            };

            if (description.IsDeprecated)
            {
                info.Description += "Esta versión de la API ha quedado obsoleta.";
            }

            return info;
        }
    }
}
