using Solway.Interfaces.Services;
using Solway.Services;
using Solway.Interfaces;
using Solway.DAC;
using Solway.Interfaces.Repository;
using Solway.DAC.Repository;

using Microsoft.Extensions.DependencyInjection;

namespace Solway.Extensions;

public static class ApplicationServicesExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IUniteOfWork, UniteOfWork>();
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
        //services.AddScoped<IAppUserService, AppUserService>();

        return services;
    }
}