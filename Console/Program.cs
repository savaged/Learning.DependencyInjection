using Autofac;
using System;
using Warriors;
using Weapons;

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
            builder.RegisterType<Shuriken>().As<IShuriken>();
            builder.RegisterType<Katana>().As<IKatana>();
            builder.RegisterType<Bandit>().As<IBandit>();
            builder.RegisterType<Samurai>().As<ISamurai>();
            builder.RegisterType<App>().As<IApp>();
            return builder.Build();
        }
    }
}
