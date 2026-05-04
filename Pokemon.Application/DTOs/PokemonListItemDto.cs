namespace Pokemon.Application.DTOs;

public class PokemonListItemDto
{
    public string Name { get; set; } = string.Empty;
    public int Order { get; set; }
    public string Abilities { get; set; } = string.Empty; // "Blaze, Solar Power"
    public string Type { get; set; } = string.Empty; // "Fire, Flying"
}