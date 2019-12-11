using Microsoft.Extensions.DependencyInjection;
using StarWarsShips.Infra.CrossCutting.IoC;
using StarWarsShips.UI.Prompt.Apps;
using StarWarsShips.UI.Prompt.Extensions;
using System.Threading.Tasks;

namespace StarWarsShips.UI.Prompt
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();
            ConfigureServices(services);

            await services.BuildServiceProvider().GetService<StarshipApp>().Run();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<StarshipApp>();
            services.AddAutoMapperSetup();

            // .NET Native DI Abstraction
            RegisterServices(services);
        }

        private static void RegisterServices(IServiceCollection services)
        {
            // Adding dependencies from another layers (isolated from Presentation)
            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}