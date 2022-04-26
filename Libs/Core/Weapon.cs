namespace Core
{
    public abstract class Weapon : IWeapon
    {
        public abstract Effectiveness Deadliness { get; }

        public void Hit(IWarrior target)
        {
            target?.Struck(this);
        }

    }
}
