﻿using System.Collections.Generic;
using System.Linq;
using Nancy.Boostrapper.TestSubjects.Services;

namespace Nancy.Boostrapper.TestSubjects.Modules
{
    public class PerRequestModule : NancyModule
    {
        public PerRequestModule(
            IEnumerable<IPerRequestAsMultiple> asMultiple,
            IEnumerable<IPerRequest> individuals) : base("per-request")
        {
            Get["multiple"] = _ => asMultiple.Count().ToString();
            Get["individuals"] = _ => individuals.Count().ToString();
        }
    }
}