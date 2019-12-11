using Microsoft.Extensions.DependencyInjection;
using StarWarsShips.Application.Interfaces;
using StarWarsShips.Application.Services;
using StarWarsShips.Domain.Starships.Interfaces;
using StarWarsShips.Infra.Data.Repositories;

namespace StarWarsShips.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Application
            services.AddScoped<IStarshipService, StarshipService>();

            // Infra - Data
            services.AddScoped<IStarshipRepository, StarshipRepository>();
        }
    }
}