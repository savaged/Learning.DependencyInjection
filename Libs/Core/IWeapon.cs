﻿namespace Core
{
    public interface IWeapon
    {
        Effectiveness Deadliness { get; }
        void Hit(ICharacter target);
    }
}
