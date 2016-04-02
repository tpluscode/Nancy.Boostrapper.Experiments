using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy.Testing;
using Xunit;

namespace Nancy.Bootstrapper.Tests
{
    public class Class1
    {
        [Theory]
        [ClassData(typeof(TestedBootstrappers))]
        public void Should_inject_each_type_once(INancyBootstrapper bootstrapper)
        {
            // given
            var browser = new Browser(bootstrapper);
        }
    }
}
