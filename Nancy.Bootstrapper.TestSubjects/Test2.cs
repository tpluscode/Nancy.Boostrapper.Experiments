using System.Collections.Generic;
using System.Linq;

namespace Nancy.Bootstrapper.TestSubjects
{
    public class Test2Module : NancyModule
    {
        public Test2Module(IEnumerable<ISingleton> individuals) : base("singletons")
        {
            Get["individuals"] = _ => individuals.Aggregate(0, (i, singleton) => i + singleton.Num).ToString();
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
        int Num { get; }
    }

    public class Singleton1 : ISingleton
    {
        public int Num => 1;
    }

    public class Singleton2 : ISingleton
    {
        public int Num => 3;
    }
}