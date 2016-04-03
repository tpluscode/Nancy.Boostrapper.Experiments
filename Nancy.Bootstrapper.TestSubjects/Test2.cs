using System.Collections.Generic;
using System.Linq;

namespace Nancy.Bootstrapper.TestSubjects
{
    public class Test2Module : NancyModule
    {
        public Test2Module(IEnumerable<ISingleton> individuals) : base("singletons")
        {
            Get["individuals"] = _ => individuals.Count().ToString();
        }
    }

    public class Test2Registrations : Registrations
    {
        public Test2Registrations()
        {
            Register<ISingleton>(typeof(Singleton1));
            Register<ISingleton>(typeof(Singleton2));
        }
    }

    public interface ISingleton
    {
    }

    public class Singleton1 : ISingleton
    {
    }

    public class Singleton2 : ISingleton
    {
    }
}