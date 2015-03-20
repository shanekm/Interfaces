using System;

namespace IDisposableProject
{
    public class MyUnmanagedResource : IDisposable
    {
        public void Method()
        {
            // using resources
        }

        public void Dispose()
        {
            // dispose of resource
        }
    }
}
