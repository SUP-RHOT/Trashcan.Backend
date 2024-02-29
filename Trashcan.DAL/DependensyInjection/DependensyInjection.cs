using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
    }
}