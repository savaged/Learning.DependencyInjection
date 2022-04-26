using Core;

namespace Warriors
{
    public interface IWarrior : ICharacter
    {
        void Attack(ICharacter opponent);
    }
}