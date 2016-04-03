using System;

namespace Nancy.Bootstrapper.TestSubjects
{
    public class Test6Module : NancyModule
    {
        public Test6Module()
        {
            Get["startup/value"] = _ =>
            {
                object value;
                if (Context.Items.TryGetValue("the-value", out value))
                {
                    return value;
                }

                return "nope, not here";
            };
        }
    }

    public class RequestStartupWithPerRequestInjection : IRequestStartup
    {
        private readonly InjectedIntoRequestStartup _injected;

        public RequestStartupWithPerRequestInjection(InjectedIntoRequestStartup injected)
        {
            _injected = injected;
        }

        public void Initialize(IPipelines pipelines, NancyContext context)
        {
            context.Items["the-value"] = _injected.SomeText;
        }
    }

    public class InjectedIntoRequestStartup
    {
        public string SomeText = "hello request startup";
    }

    public class RequestStartupRegistrations : Registrations
    {
        public RequestStartupRegistrations()
        {
            Register<InjectedIntoRequestStartup>(Lifetime.PerRequest);
        }
    }
}
