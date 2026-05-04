using Pokemon.Domain.Entities;

public interface ISearchStrategy
{
    //public bool CanHandle (string criteria);
    public Task<PokemonDetails> SearchAsync(string criteria);
}
public interface ISearchStrategy<T> : ISearchStrategy
{

    public Task<PokemonDetails> SearchAsync(T criteria);
}