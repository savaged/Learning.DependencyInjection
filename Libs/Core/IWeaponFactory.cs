namespace Core
{
    public interface IWeaponFactory
    {
        T Create<T>() where T : class, IWeapon, new();
    }
}