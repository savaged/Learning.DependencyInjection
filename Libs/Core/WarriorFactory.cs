using System;

namespace Core
{
    public class WarriorFactory : IWarriorFactory
    {
        public T Create<T>() where T : class, IWarrior, new()
        {
            return Activator.CreateInstance<T>();
        }

    }
}
