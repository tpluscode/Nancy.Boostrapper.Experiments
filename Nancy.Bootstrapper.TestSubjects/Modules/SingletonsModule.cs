using System.Collections.Generic;
using System.Linq;
using Nancy.Bootstrapper.TestSubjects.Services;

namespace Nancy.Bootstrapper.TestSubjects.Modules
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