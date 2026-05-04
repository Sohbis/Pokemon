using Pokemon.Application.Models;
using Pokemon.Application.Strategies;
using Pokemon.Domain.Entities;
using System;

public class SearchStrategyFactory
{
    private readonly IEnumerable<ISearchStrategy> _searchStrategies;
    public SearchStrategyFactory(IEnumerable<ISearchStrategy> searchStrategies)
    {
        _searchStrategies = searchStrategies;
    }

    //public ISearchStrategy GetSearchStrategy(string searchCriteria)
    //{
    //    return _searchStrategies.FirstOrDefault(strategy => strategy.CanHandle(searchCriteria))
    //        ?? throw new InvalidOperationException($"No search strategy found for criteria: {searchCriteria}");
    //}

    //public ISearchStrategy GetSearchStrategy<T>(T searchCriteria)
    //{
    //    //My intent is just to check the type of searchCriteria and return PokemonByIdStrategy if it is an int.
    //    if (int.TryParse(searchCriteria.ToString(), out int id))
    //    {
    //        var temp = _searchStrategies.ToArray()[0];
    //       //var temp2 =(ISearchStrategy<T>)temp;
    //        return temp
    //            ?? throw new InvalidOperationException($"No search strategy found for criteria: {searchCriteria}");
    //    }
    //    else
    //    {
    //        var temp = _searchStrategies.ToArray()[1];
    //        return temp
    //            ?? throw new InvalidOperationException($"No search strategy found for criteria: {searchCriteria}");
    //    }

    //        throw new InvalidOperationException($"No search strategy found for criteria: {searchCriteria}");

    //}

    public Task<PokemonDetails> GetSearchStrategy(PokemonSearchRequest query)
    {
        if (query.Id.HasValue)
        {
            var strategyID = _searchStrategies.OfType<ISearchStrategy<int>>().First();
            return strategyID.SearchAsync(query.Id.Value);
        }
        else
        {
            var strategyName = _searchStrategies.OfType<ISearchStrategy<string>>().First();

            if (!string.IsNullOrWhiteSpace(query.Name))
            {
                return strategyName.SearchAsync(query.Name);
            }


        }

        throw new ArgumentException("Search criteria must include an Id or a Name.");

    }


}
