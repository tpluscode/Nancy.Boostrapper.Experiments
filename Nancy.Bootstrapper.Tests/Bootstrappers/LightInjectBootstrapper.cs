using LightInject;
using LightInject.Nancy;
using Nancy.Bootstrapper.TestSubjects;

namespace Nancy.Bootstrapper.Tests.Bootstrappers
{
    public class LightInjectBootstrapper : LightInjectNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(IServiceContainer existingContainer)
        {
            existingContainer.Register<IRegisteredOnContainerPerRequest, RegisteredOnContainerPerRequest>(new PerScopeLifetime());
        }
    }
}