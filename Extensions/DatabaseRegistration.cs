using Microsoft.EntityFrameworkCore;
using ApiEcommerce.Data;

namespace ApiEcommerce.Extensions;

public static class DatabaseRegistration
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var dbConnectionString = configuration.GetConnectionString("ConexionSql");
                
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(dbConnectionString)
                .UseSeeding((context, _) =>
                {
                    var appContext = (ApplicationDbContext)context;
                    DataSeeder.SeedData(appContext);
                })
            );
            
        return services;
    }
}