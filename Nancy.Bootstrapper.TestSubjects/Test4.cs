using System.Collections.Generic;
using System.Linq;

namespace Nancy.Bootstrapper.TestSubjects
{
    public class Test4Module : NancyModule
    {
        public Test4Module(IEnumerable<IPerRequest> individuals) : base("per-request")
        {
            Get["individuals"] = _ => individuals.Aggregate(0, (i, request) => i + request.Num).ToString();
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
        int Num { get; }
    }

    public class PerRequest1 : IPerRequest
    {
        public int Num => 1;
    }

    public class PerRequest2 : IPerRequest
    {
        public int Num => 3;
    }
}