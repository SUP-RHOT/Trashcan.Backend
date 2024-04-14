using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Trashcan.Application.Mapping;
using Trashcan.Application.Mapping.ActorMapping;
using Trashcan.Application.Mapping.AddressMapping;
using Trashcan.Application.Mapping.EventMapping;
using Trashcan.Application.Services;
using Trashcan.Domain.Interfaces.Services;

namespace Trashcan.Application.DependensyInjection;

/// <summary>
/// Внедрение зависимостей.
/// </summary>
public static class DependensyInjection
{
    /// <summary>
    /// Создание приложения.
    /// </summary>
    /// <param name="services"> Список сервисов. </param>
    /// <param name="configuration"> Конфигурация. </param>
    public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMappers();
        services.InitServices();
    }

    /// <summary>
    /// Добавление автомаперов.
    /// </summary>
    /// <param name="services"> Сервисы. </param>
    private static void AddMappers(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ActorMapping));
        services.AddAutoMapper(typeof(AddressMapping));
        services.AddAutoMapper(typeof(AddressBaseMapping));
        services.AddAutoMapper(typeof(EventMapping));
        services.AddAutoMapper(typeof(InstitutionMapping));
        services.AddAutoMapper(typeof(RoleMapping));
        services.AddAutoMapper(typeof(RubricMapping));
        services.AddAutoMapper(typeof(TemplateMapping));
        services.AddAutoMapper(typeof(RegisterActorMapping));

    }

    /// <summary>
    /// Инициализация сервисов.
    /// </summary>
    /// <param name="services"> Сервисы. </param>
    private static void InitServices(this IServiceCollection services)
    {
        services.AddTransient<IActorService, ActorService>();
        services.AddTransient<IAddressService, AddressService>();
        services.AddTransient<IAddressBaseService, AddressBaseService>();
        services.AddTransient<IEventService, EventService>();
        services.AddTransient<IInstitutionService, InstitutionService>();
        services.AddTransient<IRoleService, RoleService>();
        services.AddTransient<IRubricService, RubricService>();
        services.AddTransient<ITemplateService, TemplateService>();
        services.AddTransient<ITokenService, TokenService>();
        services.AddTransient<IAuthService, AuthService>();
        services.AddTransient<ITokenService, TokenService>();
        services.AddTransient<IMailService, MailService>();
    }
}