using Pokemon.Application.Models;
using Pokemon.Domain.Entities;
using Pokemon.Domain.Enums;

public interface ISearchStrategy
{
    //public bool CanHandle (string criteria);
    public SearchCriteriaType StrategyName { get; }
    public Task<PokemonDetails> SearchAsync(PokemonSearchRequest criteria);
}
//public interface ISearchStrategy<T> : ISearchStrategy
//{

//    public Task<PokemonDetails> SearchAsync(T criteria);
//}