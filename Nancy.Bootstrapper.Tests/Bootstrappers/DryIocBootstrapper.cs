using DryIoc;
using Nancy.Boostrapper.TestSubjects.Services;
using Nancy.Bootstrappers.DryIoc;

namespace Nancy.Bootstrapper.Tests.Bootstrappers
{
    public class DryIocBootstrapper : DryIocNancyBootstrapper
    {
        protected override void ConfigureRequestContainer(IContainer container, NancyContext context)
        {
            container.Register<IRegisteredOnContainerPerRequest, RegisteredOnContainerPerRequest>();
        }
    }
}