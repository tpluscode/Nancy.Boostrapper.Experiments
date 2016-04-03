using Microsoft.Practices.Unity;
using Nancy.Bootstrapper.TestSubjects;
using Nancy.Bootstrappers.Unity;

namespace Nancy.Bootstrapper.Tests.Bootstrappers
{
    public class UnityBootstrapper : UnityNancyBootstrapper
    {
        protected override void ConfigureRequestContainer(IUnityContainer container, NancyContext context)
        {
            container.RegisterType<IRegisteredOnContainerPerRequest, RegisteredOnContainerPerRequest>();
        }
    }
}