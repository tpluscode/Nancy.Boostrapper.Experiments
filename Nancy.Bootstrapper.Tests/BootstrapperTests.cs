using LightInject.Nancy;
using Nancy.Bootstrapper.Tests.Bootstrappers;
using Nancy.Testing;
using Xunit;

namespace Nancy.Bootstrapper.Tests
{
    public abstract class BootstrapperTests<TBs> where TBs : INancyBootstrapper, new()
    {
        private readonly Browser _browser;

        protected BootstrapperTests()
        {
            _browser = new Browser(new TBs());
        }

        [Fact]
        public void TypesRegisteredPerRequestAsCollection_Should_BeInjectedAsCollection()
        {
            // when
            var response = _browser.Get("per-request/multiple");

            // then
            Assert.Equal("2", response.Body.AsString());
        }

        [Fact]
        public void TypeRegisteredPerRequestAsIndividuals_Should_BeInjectedAsCollection()
        {
            // when
            var response = _browser.Get("per-request/individuals");

            // then
            Assert.Equal("2", response.Body.AsString());
        }

        [Fact]
        public void TypeRegisteredAsSingletonsAsIndividuals_Should_BeInjectedAsCollection()
        {
            // when
            var response = _browser.Get("singletons/individuals");

            // then
            Assert.Equal("2", response.Body.AsString());
        }

        [Fact]
        public void TypeRegisteredAsSingletonsAsMultiple_Should_BeInjectedAsCollection()
        {
            // when
            var response = _browser.Get("singletons/multiple");

            // then
            Assert.Equal("2", response.Body.AsString());
        }

        [Fact]
        public void TypeRegisteredAsPerRequest_Should_BeInjectedWithDependencyRegistereInBootstrapper()
        {
            // when
            var response = _browser.Get("mixed/per-request/depends-on/container-registered");

            // then
            Assert.Equal("I'm ok", response.Body.AsString());
        }
    }

    public class WindsorBootsrapperTests : BootstrapperTests<WindsorBootstrapper>
    {
    }

    public class AutofacBootstrapperTests : BootstrapperTests<AutofacBootstrapper>
    {
    }

    public class DefaultBootstrapperNoAutoregistrationTests : BootstrapperTests<DefaultBootstrapperNoAutoregistration>
    {
    }

    public class DefaultNancyBootstrapperTests : BootstrapperTests<DefaultNancyBootstrapper>
    {
    }

    public class DryIocBootstrapperTests : BootstrapperTests<DryIocBootstrapper>
    {
    }

    public class GraceBootsrapperTests : BootstrapperTests<GraceBootstrapper>
    {
    }

    public class NinjectBootsrapperTests : BootstrapperTests<NinjectBootstrapper>
    {
    }

    public class StructureMapBootsrapperTests : BootstrapperTests<StructureMapBootstrapper>
    {
    }

    public class UnityBootsrapperTests : BootstrapperTests<UnityBootstrapper>
    {
    }

    public class Mef2BootsrapperTests : BootstrapperTests<Mef2Bootstrapper>
    {
    }

    public class LightInjectBootsrapperTests : BootstrapperTests<LightInjectBootstrapper>
    {
    }
}
