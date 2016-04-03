using Nancy.Boostrapper.TestSubjects.Services;
using Nancy.Bootstrappers.Ninject;
using Ninject;

namespace Nancy.Bootstrapper.Tests.Bootstrappers
{
    public class NinjectBootstrapper : NinjectNancyBootstrapper
    {
        protected override void ConfigureRequestContainer(IKernel container, NancyContext context)
        {
            container.Bind<IRegisteredOnContainerPerRequest>().To<RegisteredOnContainerPerRequest>();
        }
    }
}