using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Warriors;
using Weapons;

namespace DependencyInjection
{
    class App : IApp
    {
        private readonly IFeedbackService _feedbackService;
        private readonly IList<IWarrior> _bandits;
        private readonly IWarrior _samurai;
        private bool _battleOver;

        public App(
            IFeedbackService feedbackService,
            IWarriorFactory warriorFactory,
            IWeaponFactory weaponFactory)
        {
            _feedbackService = feedbackService ??
                throw new ArgumentNullException(nameof(feedbackService));

            if (warriorFactory == null)
                throw new ArgumentNullException(nameof(warriorFactory));
            if (weaponFactory == null)
                throw new ArgumentNullException(nameof(weaponFactory));

            _bandits = new List<IWarrior>();
            _bandits?.Add(warriorFactory?.Create<Bandit>());
            _bandits?.Add(warriorFactory?.Create<Bandit>());
            if (_bandits.Count == 0)
                throw new InvalidOperationException("No bandits!");

            _samurai = warriorFactory.Create<Samurai>() ??
                throw new InvalidOperationException($"{nameof(Samurai)} not found!");

            foreach (var bandit in _bandits)
            {
                bandit.Injury += OnCharacterInjury;
                bandit.Dead += OnCharacterDead;
            }
            _samurai.Injury += OnCharacterInjury;
            _samurai.Dead += OnCharacterDead;

            _bandits.First().Weapon = weaponFactory.Create<Shuriken>() ??
                throw new InvalidOperationException($"{nameof(Shuriken)} not found!");
            _bandits.Last().Weapon = weaponFactory.Create<Yari>() ??
                throw new InvalidOperationException($"{nameof(Yari)} not found!");

            _samurai.Weapon = weaponFactory.Create<Katana>() ??
                throw new InvalidOperationException($"{nameof(Katana)} not found!");
        }

        public void Run()
        {
            while (!_battleOver)
            {
                Exchange();
            }
            _feedbackService.Feedback("battle over");
        }

        private void Exchange()
        {
            Attack(_bandits.FirstOrDefault(), _samurai);
            Thread.Sleep(1000);
            Attack(_samurai, _bandits.FirstOrDefault());
            Thread.Sleep(1000);
            Attack(_bandits.LastOrDefault(), _samurai);
            Thread.Sleep(1000);
            Attack(_samurai, _bandits.LastOrDefault());
        }

        private void Attack(IWarrior attacker, IWarrior target)
        {
            if (attacker?.IsDead == true) return;
            _feedbackService.Feedback($"{attacker} attacks {target}");
            attacker?.Attack(target);
        }

        private void OnCharacterInjury(object sender, InjuryEventArgs e)
        {
            _feedbackService.Feedback($"{sender}'s appearance is {e.Appearance}");
        }

        private void OnCharacterDead(object sender, EventArgs e)
        {
            _feedbackService.Feedback($"{sender} is dead");
            _battleOver = _bandits.All(b => b.IsDead) || sender is Samurai;
        }

    }
}
