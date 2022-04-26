namespace Core
{
    public interface IWarriorFactory
    {
        T Create<T>() where T : class, IWarrior, new();
    }
}