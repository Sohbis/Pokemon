
using Pokemon.Api.Middleware;
using Pokemon.Application;
using Pokemon.Application.Factories;
using Pokemon.Application.Strategies;
using Pokemon.Infrastructure.DependencyInjection;
namespace Pokemon.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //builder.Services.AddScoped<IPokemonService, PokemonService>();
            builder.Services.AddApplicationDependencies();
            builder.Services.AddInfrastructureDependencies();
            builder.Services.AddScoped<ISearchStrategy, PokemonByIdStrategy>();
            builder.Services.AddScoped<ISearchStrategy, PokemonByNameStrategy>();
            //builder.Services.AddScoped<ISearchStrategy<int>, PokemonByIdStrategy>();
            //builder.Services.AddScoped<ISearchStrategy<string>, PokemonByNameStrategy>();
            builder.Services.AddScoped<SearchStrategyFactory>();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
          


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseGlobalExceptionHandler(); // ← add (before MapControllers)
            app.MapControllers();

            app.Run();
        }
    }
}
