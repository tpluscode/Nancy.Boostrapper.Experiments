namespace Nancy.Boostrapper.TestSubjects.Services
{
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

    public class RegisteredOnContainerPerRequest : IRegisteredOnContainerPerRequest
    {
        public string Value => "I'm ok";
    }
}