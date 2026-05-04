using Pokemon.Domain.Enums;

namespace Pokemon.Application.Models;

/// <summary>
/// Carries search input from Controller to Service.
/// Created once in the Controller via named factory methods.
/// CriteriaType enum is set at creation — no downstream class
/// needs to re-inspect Id or Name to figure out which search to run.
/// </summary>
public class PokemonSearchRequest
{
    public int? Id { get; init; }
    public string? Name { get; init; }
    //public SearchCriteriaType CriteriaType { get; init; }

    //// Named constructors — intent is explicit at the call site
    //public static PokemonSearchRequest ById(int id) => new()
    //{
    //    Id = id,
    //    CriteriaType = SearchCriteriaType.ById
    //};

    //public static PokemonSearchRequest ByName(string name) => new()
    //{
    //    Name = name,
    //    CriteriaType = SearchCriteriaType.ByName
    //};
}