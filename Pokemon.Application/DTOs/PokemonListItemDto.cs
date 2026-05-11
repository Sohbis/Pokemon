using System.Text.Json.Serialization;

namespace Pokemon.Application.DTOs;

public class PokemonListItemDto
{
    public string Name { get; set; } = string.Empty;
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Order { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? NotFound { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Abilities { get; set; } = string.Empty; // "Blaze, Solar Power"
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Type { get; set; } = string.Empty; // "Fire, Flying"
}