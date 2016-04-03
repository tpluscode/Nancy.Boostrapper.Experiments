using System.Collections.Generic;
using System.Linq;

namespace Nancy.Bootstrapper.TestSubjects
{
    public class Test5Module : NancyModule
    {
        public Test5Module(IEnumerable<IPerRequestAsMultiple> multiples) : base("per-request")
        {
            Get["multiple"] = _ => multiples.Count().ToString();
        }
    }

    public class Test5Registrations : Registrations
    {
        public Test5Registrations()
        {
            RegisterAll<IPerRequestAsMultiple>();
        }
    }
    
    public interface IPerRequestAsMultiple
    {
    }

    public class PerRequestAsMultiple1 : IPerRequestAsMultiple
    {
    }

    public class PerRequestAsMultiple2 : IPerRequestAsMultiple
    {
    }
}