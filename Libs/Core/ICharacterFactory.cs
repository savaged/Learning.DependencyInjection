namespace Core
{
    public interface ICharacterFactory
    {
        T Create<T>() where T : class, ICharacter, new();
    }
}