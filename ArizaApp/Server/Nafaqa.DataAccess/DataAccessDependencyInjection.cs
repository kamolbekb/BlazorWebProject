using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nafaqa.Core.Entities;
using Nafaqa.DataAccess.Persistence;
using Nafaqa.DataAccess.Repositories;
using Nafaqa.DataAccess.Repositories.Implementation;
namespace Nafaqa.DataAccess;

public static class DataAccessDependencyInjection
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDatabase(configuration);

        services.AddRepositories();

        return services;
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IPetitionRepository, PetitionRepository>();
        services.AddScoped<IPersonRepository, PersonRepository>();
        services.AddScoped<IPhotoRepository, PhotoRepository>();
        
    }

    private static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var databaseConfig = configuration.GetSection("Database").Get<DatabaseConfiguration>();
        
        services.AddDbContext<DatabaseContext>(options =>
            options.UseNpgsql(databaseConfig.ConnectionString,
                opt => opt.MigrationsAssembly(typeof(DatabaseContext).Assembly.FullName)));
    }
}


public class DatabaseConfiguration
{
    public bool UseInMemoryDatabase { get; set; }

    public string ConnectionString { get; set; }
}
