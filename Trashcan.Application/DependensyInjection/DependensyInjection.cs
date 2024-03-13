using Microsoft.Extensions.DependencyInjection;
using Trashcan.Application.Mapping;
using Trashcan.Application.Services;
using Trashcan.Domain.Interfaces.Services;

namespace Trashcan.Application.DependensyInjection;

public static class DependensyInjection
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddMappers();
    }

    private static void AddMappers(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ActorMapping));
        services.AddAutoMapper(typeof(AddressMapping));
        services.AddAutoMapper(typeof(AddressBaseMapping));
        services.AddAutoMapper(typeof(EventMapping));
        services.AddAutoMapper(typeof(InstitutionMapping));
        services.AddAutoMapper(typeof(RoleMapping));

    }

    private static void InitServices(this IServiceCollection services)
    {
        services.AddScoped<IActorService, ActorService>();
        services.AddScoped<IAddressService, AddressService>();
        services.AddScoped<IAddressBaseService, AddressBaseService>();
        services.AddScoped<IEventService, EventService>();
        services.AddScoped<IInstitutionService, InstitutionService>();
        services.AddScoped<IRoleService, RoleService>();
    }
}