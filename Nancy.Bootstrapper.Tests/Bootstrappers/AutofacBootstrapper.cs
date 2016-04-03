using Autofac;
using Nancy.Boostrapper.TestSubjects.Services;
using Nancy.Bootstrappers.Autofac;

namespace Nancy.Bootstrapper.Tests.Bootstrappers
{
    public class AutofacBootstrapper : AutofacNancyBootstrapper
    {
        protected override void ConfigureRequestContainer(ILifetimeScope container, NancyContext context)
        {
            container.Update(b => b.RegisterType<RegisteredOnContainerPerRequest>().As<IRegisteredOnContainerPerRequest>());
        }
    }
}