using InvoiceApp.Application.Common.Interfaces;
using InvoiceApp.Infrastructure.Security;
using Microsoft.Extensions.DependencyInjection;


namespace InvoiceApp.Infrastructure;

public static class InfrastructureServicesRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IPasswordHasher, BCryptPasswordHasher>();
        services.AddScoped<ITokenService, JwtTokenService>();

        return services;
    }
}