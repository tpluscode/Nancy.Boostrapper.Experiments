using Nancy.Bootstrapper.TestSubjects;
using Nancy.Bootstrappers.StructureMap;
using StructureMap;

namespace Nancy.Bootstrapper.Tests.Bootstrappers
{
    public class StructureMapBootstrapper : StructureMapNancyBootstrapper
    {
        protected override void ConfigureRequestContainer(IContainer existingContainer, NancyContext context)
        {
            existingContainer.Configure(c => c.For<IRegisteredOnContainerPerRequest>().Use<RegisteredOnContainerPerRequest>());
        }
    }
}