using Nancy.Boostrapper.TestSubjects.Services;

namespace Nancy.Boostrapper.TestSubjects.Modules
{
    public class MixedRegistrationModule : NancyModule
    {
        public MixedRegistrationModule(DependsOnPerRequestDirectDependency dep)
            : base("mixed")
        {
            Get["per-request/depends-on/container-registered"] = _ => dep.Inner.Value;
        }
    }
}