using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Nafaqa.Application.MappingProfiles;
using Nafaqa.Application.Services;
using Nafaqa.Application.Services.Implementation;

namespace Nafaqa.Application;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services,
        IWebHostEnvironment builderEnvironment)
    {
        services.AddServices(builderEnvironment);

        services.RegisterAutoMapper();

        return services;
    }

    private static void AddServices(this IServiceCollection services,IWebHostEnvironment env)
    {
        services.AddScoped<IPetitionService, PetitionService>();
    }

    private static void RegisterAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(IMappingProfilesMarker));
    }
}
