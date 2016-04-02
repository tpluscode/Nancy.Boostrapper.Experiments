using Nancy.Boostrapper.TestSubjects.Services;
using Nancy.Bootstrapper;

namespace Nancy.Boostrapper.TestSubjects
{
    public class Registrations : Bootstrapper.Registrations
    {
        public Registrations()
        {
            RegisterAll<IPerRequest>(Lifetime.PerRequest);
        }
    }
}
