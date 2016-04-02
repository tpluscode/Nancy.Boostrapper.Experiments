using System.Collections;
using System.Collections.Generic;
using Nancy.Bootstrapper.Tests.Bootstrappers;

namespace Nancy.Bootstrapper.Tests
{
    public class TestedBootstrappers : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {new DefaultBootstrapperNoAutoregistration()};
            yield return new object[] {new DefaultNancyBootstrapper() };
            yield return new object[] {new WindsorBootstrapper()};
            //yield return new object[] {new MefBootstrapper()};
            yield return new object[] {new Mef2Bootstrapper()};
            //yield return new object[] {new GraceBootstrapper()};
            yield return new object[] {new AutofacBootstrapper()};
            yield return new object[] {new NinjectBootstrapper()};
            yield return new object[] {new DryIocBootstrapper()};
            yield return new object[] {new UnityBootstrapper()};
            yield return new object[] {new StructureMapBootstrapper()};
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}