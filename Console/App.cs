using Core;
using System;
using System.Threading;
using Warriors;
using Weapons;

namespace DependencyInjection
{
    class App : IApp
    {
        private readonly IFeedbackService _feedbackService;
        private readonly IWarrior _bandit;
        private readonly IWarrior _samurai;
        private bool _warriorDeath;

        public App(
            IFeedbackService feedbackService,
            IWarriorFactory characterFactory,
            IWeaponFactory weaponFactory)
        {
            _feedbackService = feedbackService ??
                throw new ArgumentNullException(nameof(feedbackService));

            if (characterFactory == null)
                throw new ArgumentNullException(nameof(characterFactory));
            if (weaponFactory == null)
                throw new ArgumentNullException(nameof(weaponFactory));

            _bandit = characterFactory.Create<Bandit>() ??
                throw new InvalidOperationException($"{nameof(Bandit)} not found!");
            _samurai = characterFactory.Create<Samurai>() ??
                throw new InvalidOperationException($"{nameof(Samurai)} not found!");

            _bandit.Injury += OnCharacterInjury;
            _samurai.Injury += OnCharacterInjury;

            _bandit.Dead += OnCharacterDead;
            _samurai.Dead += OnCharacterDead;

            _bandit.Weapon = weaponFactory.Create<Yari>() ??
                throw new InvalidOperationException($"{nameof(Yari)} not found!");
            _samurai.Weapon = weaponFactory.Create<Katana>() ??
                throw new InvalidOperationException($"{nameof(Katana)} not found!");
        }

        public void Run()
        {
            while (!_warriorDeath)
            {
                Exchange();
            }
        }

        private void Exchange()
        {
            Attack(_bandit, _samurai);
            Thread.Sleep(1000);
            Attack(_samurai, _bandit);
        }

        private void Attack(IWarrior attacker, IWarrior target)
        {
            _feedbackService.Feedback($"{attacker} attacks {target}");
            attacker.Attack(target);
        }

        private void OnCharacterInjury(object sender, InjuryEventArgs e)
        {
            _feedbackService.Feedback($"{sender}'s appearance is {e.Appearance}");
        }

        private void OnCharacterDead(object sender, EventArgs e)
        {
            _warriorDeath = true;
            _feedbackService.Feedback($"{sender} is dead");
        }

    }
}
