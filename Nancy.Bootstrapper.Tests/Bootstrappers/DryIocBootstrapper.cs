using DryIoc;
using Nancy.Bootstrapper.TestSubjects;
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