using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Trashcan.DAL.Repositories;
using Trashcan.Domain.Entity;
using Trashcan.Domain.Interfaces.BaseRepository;

namespace Trashcan.DAL.DependensyInjection;

public static class DependensyInjection
{
    public static void AddDataAccessLayer(this IServiceCollection? services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("MSSQL");

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });
		//services.AddDbContext<ApplicationDbContext>(options =>
		//options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

		services.InitRepositories();
    }

    public static void InitRepositories(this IServiceCollection services)
    {
        services.AddScoped<IBaseRepository<Actor>, BaseRepository<Actor>>();
        services.AddScoped<IBaseRepository<Address>, BaseRepository<Address>>();
        services.AddScoped<IBaseRepository<AddressBase>, BaseRepository<AddressBase>>();
        services.AddScoped<IBaseRepository<Event>, BaseRepository<Event>>();
        services.AddScoped<IBaseRepository<Institution>, BaseRepository<Institution>>();
        services.AddScoped<IBaseRepository<Role>, BaseRepository<Role>>();
        services.AddScoped<IBaseRepository<Rubric>, BaseRepository<Rubric>>();
        services.AddScoped<IBaseRepository<Template>, BaseRepository<Template>>();
        services.AddScoped<IBaseRepository<ActorToken>, BaseRepository<ActorToken>>();
    }
}