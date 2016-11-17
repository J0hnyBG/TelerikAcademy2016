using System;
using System.Diagnostics;

using Ninject.Extensions.Interception;

using SchoolSystem.Framework.Core.Contracts;

namespace SchoolSystem.Cli.Interceptors
{
    public class PerformanceLoggerInterceptor : IInterceptor
    {
        private readonly IWriter writer;

        public PerformanceLoggerInterceptor(IWriter writer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            this.writer = writer;
        }

        public void Intercept(IInvocation invocation)
        {
            var methodName = invocation.Request.Method.Name;
            var typeName = invocation.Request.Target
                                     .GetType()
                                     .Name.Replace("Proxy", string.Empty);

            this.writer.WriteLine($"Calling method {methodName} of type {typeName}...");

            var timer = new Stopwatch();
            timer.Start();
            invocation.Proceed();
            timer.Stop();

            var elapsed = timer.ElapsedMilliseconds;
            this.writer.WriteLine(
                                  $"Total execution time for method {methodName} of type {typeName} is {elapsed} milliseconds.");
        }
    }
}
