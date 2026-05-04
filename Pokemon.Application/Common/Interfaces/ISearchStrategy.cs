using Pokemon.Application.Models;
using Pokemon.Domain.Entities;

public interface ISearchStrategy
{
    //public bool CanHandle (string criteria);
    string StrategyName { get; }
    public Task<PokemonDetails> SearchAsync(PokemonSearchRequest criteria);
}
//public interface ISearchStrategy<T> : ISearchStrategy
//{

//    public Task<PokemonDetails> SearchAsync(T criteria);
//}