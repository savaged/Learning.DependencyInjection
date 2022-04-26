using System;

namespace Core
{
    public class WeaponFactory : IWeaponFactory
    {
        public T Create<T>() where T : class, IWeapon, new()
        {
            return Activator.CreateInstance<T>();
        }

    }
}
