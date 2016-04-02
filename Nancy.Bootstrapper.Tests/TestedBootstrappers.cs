using System;
using System.Collections;
using System.Collections.Generic;

namespace Nancy.Bootstrapper.Tests
{
    public class TestedBootstrappers : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}