using Nancy.TinyIoc;

namespace Nancy.Bootstrapper.Tests.Bootstrappers
{
    public class DefaultBootstrapperNoAutoregistration : DefaultNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
        }
    }
}