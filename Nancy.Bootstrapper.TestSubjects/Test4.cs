using System.Collections.Generic;
using System.Linq;

namespace Nancy.Bootstrapper.TestSubjects
{
    public class Test4Module : NancyModule
    {
        public Test4Module(IEnumerable<IPerRequest> individuals) : base("per-request")
        {
            Get["individuals"] = _ => individuals.Count().ToString();
        }
    }

    public class Test4Registrations : Registrations
    {
        public Test4Registrations()
        {
            Register<IPerRequest>(typeof(PerRequest1), Lifetime.PerRequest);
            Register<IPerRequest>(typeof(PerRequest2), Lifetime.PerRequest);
        }
    }

    public interface IPerRequest
    {
    }

    public class PerRequest1 : IPerRequest
    {
    }

    public class PerRequest2 : IPerRequest
    {
    }
}