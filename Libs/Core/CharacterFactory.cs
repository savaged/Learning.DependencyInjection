﻿using System;

namespace Core
{
    public class CharacterFactory : ICharacterFactory
    {
        public T Create<T>() where T : class, ICharacter, new()
        {
            return Activator.CreateInstance<T>();
        }

    }
}
