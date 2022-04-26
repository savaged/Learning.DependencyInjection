using System;
using System.Collections.Generic;

namespace Core
{
    public class CharacterFactory : ICharacterFactory
    {
        public T Create<T>() where T : class, ICharacter, new()
        {
            return default;
        }

    }
}
