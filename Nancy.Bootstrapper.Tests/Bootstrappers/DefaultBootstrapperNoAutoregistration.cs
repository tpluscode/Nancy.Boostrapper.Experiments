using Nancy.Bootstrapper.TestSubjects;
using Nancy.TinyIoc;

namespace Nancy.Bootstrapper.Tests.Bootstrappers
{
    public class DefaultBootstrapperNoAutoregistration : DefaultNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
        }

        protected override void ConfigureRequestContainer(TinyIoCContainer container, NancyContext context)
        {
            container.Register<IRegisteredOnContainerPerRequest, RegisteredOnContainerPerRequest>();
        }
    }
}