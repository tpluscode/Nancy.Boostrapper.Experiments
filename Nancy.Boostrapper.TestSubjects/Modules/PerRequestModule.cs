using System.Collections.Generic;
using System.Linq;
using Nancy.Boostrapper.TestSubjects.Services;

namespace Nancy.Boostrapper.TestSubjects.Modules
{
    public class PerRequestModule : NancyModule
    {
        public PerRequestModule(IEnumerable<IPerRequest> deps)
        {
            Get[""] = _ => deps.Count().ToString();
        }
    }
}