using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Nancy.Boostrapper.TestSubjects.Services;
using Nancy.Bootstrappers.Windsor;

namespace Nancy.Bootstrapper.Tests.Bootstrappers
{
    public class WindsorBootstrapper : WindsorNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(IWindsorContainer existingContainer)
        {
            base.ConfigureApplicationContainer(existingContainer);

            existingContainer.Register(
                Component.For<IRegisteredOnContainerPerRequest>().ImplementedBy<RegisteredOnContainerPerRequest>().LifestyleTransient());
        }
    }
}