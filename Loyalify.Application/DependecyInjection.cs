using FluentValidation;
using Hangfire;
using Loyalify.Application.Common.Behaviors;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Loyalify.Application;

public static class DenpendecyInjectcion
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        
        services.AddScoped(
            typeof(IPipelineBehavior<,>),
            typeof(ValidationBehavior<,>));
        services.AddHangfire(config => config.UseSqlServerStorage("Server=.\\SQLExpress;Database=Loyalify;Trusted_Connection=true;TrustServerCertificate=true;"));
        services.AddHangfireServer();
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return services;
    }
}
