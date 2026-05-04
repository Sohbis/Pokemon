using Microsoft.Extensions.DependencyInjection;
using Pokemon.Application.Common.Interfaces;
using Pokemon.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Application
{
    public static  class DependencyInjection
    {
        public static IServiceCollection  AddApplicationDependencies(this IServiceCollection services)
        {
            services.AddScoped<IPokemonService,PokemonService>();
            return services;
        }
    }
}
