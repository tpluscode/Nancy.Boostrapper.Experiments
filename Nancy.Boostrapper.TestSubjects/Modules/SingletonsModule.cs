using System.Collections.Generic;
using System.Linq;
using Nancy.Boostrapper.TestSubjects.Services;

namespace Nancy.Boostrapper.TestSubjects.Modules
{
    public class SingletonsModule : NancyModule
    {
        public SingletonsModule(
            IEnumerable<ISingletonAsMultiple> asMultiple,
            IEnumerable<ISingleton> individuals) : base("singletons")
        {
            Get["multiple"] = _ => asMultiple.Count().ToString();
            Get["individuals"] = _ => individuals.Count().ToString();
        }
    }
}