namespace Core
{
    public class InjuryEventArgs
    {
        public InjuryEventArgs(Appearance appearance)
        {
            Appearance = appearance;
        }

        public Appearance Appearance { get; }
    }
}
