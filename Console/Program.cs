using Autofac;
using Core;
using System;

namespace DependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = GetContainer();
            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IApp>();
                app.Run();
            }
            Console.ReadLine();
        }

        static IContainer GetContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<FeedbackService>().As<IFeedbackService>();
            builder.RegisterType<WeaponFactory>().As<IWeaponFactory>();
            builder.RegisterType<CharacterFactory>().As<ICharacterFactory>();
            builder.RegisterType<App>().As<IApp>();
            return builder.Build();
        }
    }
}
