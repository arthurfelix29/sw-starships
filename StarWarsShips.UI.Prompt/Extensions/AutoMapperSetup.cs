using Microsoft.Extensions.DependencyInjection;
using StarWarsShips.Application.AutoMapper;
using System;

namespace StarWarsShips.UI.Prompt.Extensions
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            var mappingConfig = AutoMapperConfig.RegisterMappings();
            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}