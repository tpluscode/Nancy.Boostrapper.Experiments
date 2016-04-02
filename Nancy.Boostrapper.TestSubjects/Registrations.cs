using Nancy.Boostrapper.TestSubjects.Services;
using Nancy.Bootstrapper;

namespace Nancy.Boostrapper.TestSubjects
{
    public class Registrations : Bootstrapper.Registrations
    {
        public Registrations()
        {
            RegisterAll<IPerRequestAsMultiple>(Lifetime.PerRequest);
            Register<IPerRequest>(typeof(PerRequest1), Lifetime.PerRequest);
            Register<IPerRequest>(typeof(PerRequest2), Lifetime.PerRequest);
            
            RegisterAll<ISingletonAsMultiple>();
            Register<ISingleton>(typeof(Singleton1));
            Register<ISingleton>(typeof(Singleton2));
        }
    }
}
