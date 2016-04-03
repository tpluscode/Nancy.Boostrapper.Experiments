using System.Composition;

namespace Nancy.Bootstrapper.TestSubjects
{
    public class Test1Module : NancyModule
    {
        public Test1Module(DependsOnPerRequestDirectDependency dep)
           : base("mixed")
        {
            Get["per-request/depends-on/container-registered"] = _ => dep.Inner.Value;
        }
    }

    public class Test1Registrations : Registrations
    {
        public Test1Registrations()
        {
            Register<DependsOnPerRequestDirectDependency>(Lifetime.PerRequest);

            // no registration of IRegisteredOnContainerPerRequest
            // will register with container directly
        }
    }

    public class DependsOnPerRequestDirectDependency
    {
        public DependsOnPerRequestDirectDependency(IRegisteredOnContainerPerRequest dep)
        {
            Inner = dep;
        }

        public IRegisteredOnContainerPerRequest Inner { get; private set; }
    }

    public interface IRegisteredOnContainerPerRequest
    {
        string Value { get; }
    }

    [Export(typeof(IRegisteredOnContainerPerRequest)), Shared("PerRequest")]
    public class RegisteredOnContainerPerRequest : IRegisteredOnContainerPerRequest
    {
        public string Value => "I'm ok";
    }
}