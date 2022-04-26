using Core;
using System;
using System.Threading;
using Warriors;

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
            IBandit bandit,
            ISamurai samurai)
        {
            _feedbackService = feedbackService ??
                throw new ArgumentNullException(nameof(feedbackService));

            _bandit = bandit ??
                throw new ArgumentNullException(nameof(bandit));
            _samurai = samurai ??
                throw new ArgumentNullException(nameof(samurai));

            _bandit.Injury += OnCharacterInjury;
            _samurai.Injury += OnCharacterInjury;

            _bandit.Dead += OnCharacterDead;
            _samurai.Dead += OnCharacterDead;
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
