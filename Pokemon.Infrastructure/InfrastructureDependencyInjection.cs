using Microsoft.Extensions.DependencyInjection;
using Pokemon.Domain.Interfaces;
using Pokemon.Infrastructure.Repositories;

namespace Pokemon.Infrastructure
{
    public static class InfrastructureDependencyInjection
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {

            services.AddScoped<IPokemonRepository, PokemonRepository>();
            services.AddHttpClient<PokeApiHttpClient>(client =>
            {
                client.BaseAddress = new Uri("https://pokeapi.co/api/v2/");
                client.DefaultRequestHeaders.Add("Accept", "application/json");

            });
            return services;
        }
    }
}
