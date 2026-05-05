using MediatR;
using Pokemon.Application.Models;
using Pokemon.Application.Strategies;
using Pokemon.Domain.Entities;
using System;
using Pokemon.Application.Constants;
using Pokemon.Domain.Enums;
namespace Pokemon.Application.Factories
{
    public class SearchStrategyFactory
    {
        private readonly IEnumerable<ISearchStrategy> _searchStrategies;
        public SearchStrategyFactory(IEnumerable<ISearchStrategy> searchStrategies)
        {
            _searchStrategies = searchStrategies;
        }

        //public ISearchStrategy GetSearchStrategy(PokemonSearchRequest query)
        //{
        //    if (query.Id.HasValue)
        //    {
        //        var strategyID = _searchStrategies.OfType<ISearchStrategy<int>>().First();
        //        //return strategyID.SearchAsync(query.Id.Value);
        //        return strategyID;
        //    }
        //    else
        //    {
        //        var strategyName = _searchStrategies.OfType<ISearchStrategy<string>>().First();

        //        //if (!string.IsNullOrWhiteSpace(query.Name))
        //        //{
        //        //    return strategyName.SearchAsync(query.Name);
        //        //}

        //        return strategyName;
        //    }

        //    throw new ArgumentException("Search criteria must include an Id or a Name.");

        //}

        public ISearchStrategy GetSearchStrategy(PokemonSearchRequest request)
        {

            var strategy =
            request.Id.HasValue
               ? _searchStrategies.FirstOrDefault(s => s.StrategyName == SearchCriteriaType.ById) :
               _searchStrategies.FirstOrDefault(s => s.StrategyName == SearchCriteriaType.ByName);

            if (strategy != null)
            {
                return strategy;
            }
            throw new InvalidOperationException("No Strategy found for given Id/Name.");

        }


    }
}
