using Pokemon.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Pokemon.Application.Models;

/// <summary>
/// Carries search input from Controller to Service.
/// Created once in the Controller via named factory methods.
/// CriteriaType enum is set at creation — no downstream class
/// needs to re-inspect Id or Name to figure out which search to run.
/// </summary>
public class PokemonSearchRequest : IValidatableObject
{
    [Range(1, 1350, ErrorMessage = "Id must be between 1 and 1350.")]
    public int? Id { get; init; }
    [MaxLength(50, ErrorMessage = "Name must be 50 characters or fewer.")]
    [MinLength(2, ErrorMessage = "Name must be at least 2 characters long.")]
    public string? Name { get; init; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var isIdProvided = !Id.ToString().IsNullOrZero();
        var isNameProvided = !Name.IsNullOrZero();
        if (!isIdProvided && !isNameProvided)
        {
            yield return new ValidationResult("Either Id or Name must be provided.", new[] { nameof(Id), nameof(Name) });
        }
        else if (isIdProvided && isNameProvided)
        {
            yield return new ValidationResult("Provide only one of Id or Name, not both.", new[] { nameof(Id), nameof(Name) });
        }
    }
}