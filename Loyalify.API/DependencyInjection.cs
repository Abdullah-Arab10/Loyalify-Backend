using Loyalify.API.Common.Mapping;
using Microsoft.OpenApi.Models;

namespace Loyalify.API;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Enter 'Bearer'[space] and then your valid token in the text below.\r\n\n\r\nExample: \"Bearer jksdfshfkskfdj\""
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
               Reference = new OpenApiReference
               {
                   Type =ReferenceType.SecurityScheme,
                   Id = "Bearer"
               }
            },
            Array.Empty<string>()
        }
    });
        });

        services.AddMappings();
        return services;
    }
}
