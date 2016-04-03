using System.Collections.Generic;
using System.Linq;

namespace Nancy.Bootstrapper.TestSubjects
{
    public class Test3Module : NancyModule
    {
        public Test3Module(IEnumerable<ISingletonAsMultiple> multiples) : base("singletons")
        {
            Get["multiple"] = _ => multiples.Count().ToString();
        }
    }

    public class Test3Registrations : Registrations
    {
        public Test3Registrations()
        {
            RegisterAll<ISingletonAsMultiple>();
        }
    }

    public interface ISingletonAsMultiple
    {
    }

    public class SingletonAsMultiple1 : ISingletonAsMultiple
    {
    }

    public class SingletonAsMultiple2 : ISingletonAsMultiple
    {
    }
}