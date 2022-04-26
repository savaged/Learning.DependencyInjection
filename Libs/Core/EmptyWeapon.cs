namespace Core
{
    public sealed class EmptyWeapon : Weapon
    {
        public override Effectiveness Deadliness => Effectiveness.None;

        private static readonly IWeapon _default = new EmptyWeapon();

        static EmptyWeapon() { }

        private EmptyWeapon() { }

        public static IWeapon Default => _default;
    }
}
