using System;
using System.Collections.Generic;
using Grace.DependencyInjection;

namespace Nancy.Bootstrapper.Tests.Bootstrappers
{
    public class GraceBootstrapper : Nancy.Bootstrappers.Grace.GraceNancyBootstrapper
    {
        protected override IEnumerable<IRequestStartup> RegisterAndGetRequestStartupTasks(IExportLocator container, Type[] requestStartupTypes)
        {
            yield break;
        }

        protected override IEnumerable<IRegistrations> GetRegistrationTasks()
        {
            yield break;
        }

        protected override IExportLocator CreateRequestContainer(NancyContext context)
        {
            return new DependencyInjectionContainer();
        }
    }
}