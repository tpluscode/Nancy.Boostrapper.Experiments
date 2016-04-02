using Nancy.Testing;
using Xunit;

namespace Nancy.Bootstrapper.Tests
{
    public class BootstrapperTests
    {
        [Theory]
        [ClassData(typeof(TestedBootstrappers))]
        public void TypesRegisteredPerRequestAsCollection_Should_BeInjectedAsCollection(INancyBootstrapper bootstrapper)
        {
            // given
            var browser = new Browser(bootstrapper);

            // when
            var response = browser.Get("per-request/multiple");

            // then
            Assert.Equal("2", response.Body.AsString());
        }

        [Theory]
        [ClassData(typeof(TestedBootstrappers))]
        public void TypeRegisteredPerRequestAsIndividuals_Should_BeInjectedAsCollection(INancyBootstrapper bootstrapper)
        {
            // given
            var browser = new Browser(bootstrapper);

            // when
            var response = browser.Get("per-request/individuals");

            // then
            Assert.Equal("2", response.Body.AsString());
        }
    }
}
