using Microsoft.OpenApi.Models;

namespace ApiEcommerce.Extensions;

public static class SwaggerRegistration
{
    public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "Nuestra API utiliza la Autenticación JWT usando el esquema Bearer. \n\r\n\r" +
                              "Ingresa la palabra a continuación el token generado en login.\n\r\n\r" +
                              "Ejemplo: \"12345abcdef\"",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer"
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header
                    },
                    new List<string>()
                }
            });

            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "API Ecommerce",
                Description = " API para gestionar productos y usuarios",
                TermsOfService = new Uri("http://example.com/terms"),
                Contact = new OpenApiContact
                {
                    Name = "DevCorp",
                    Url = new Uri("https://devcorp.com")
                },
                License = new OpenApiLicense
                {
                    Name = "Licencia de uso",
                    Url = new Uri("https://example.com/license")
                }
            });

            options.SwaggerDoc("v2", new OpenApiInfo
            {
                Version = "v2",
                Title = "API Ecommerce",
                Description = " API para gestionar productos y usuarios",
                TermsOfService = new Uri("http://example.com/terms"),
                Contact = new OpenApiContact
                {
                    Name = "DevCorp",
                    Url = new Uri("https://devcorp.com")
                },
                License = new OpenApiLicense
                {
                    Name = "Licencia de uso",
                    Url = new Uri("https://example.com/license")
                }
            });
        });

        return services;
    }

    public static WebApplication UseSwaggerDocumentation(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.SwaggerEndpoint("/swagger/v2/swagger.json", "v2");
            }); 
        }
        return app;
    }
}