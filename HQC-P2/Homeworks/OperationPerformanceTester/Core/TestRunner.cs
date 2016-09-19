using System;
using System.Diagnostics;
using System.Threading;

namespace OperationPerformanceTester.Core
{
    public static class TestRunner
    {
        public static decimal RunPerformanceTests<T>(T[] testCases, Func<T, T, T> action, long repeatCount)
        {
            var timer = new Stopwatch();

            var oldThreadPriority = Thread.CurrentThread.Priority;
            Thread.CurrentThread.Priority = ThreadPriority.Highest;

            var totalElapsedTime = new TimeSpan();

            for (uint k = 0; k < repeatCount; k++)
            {
                var result = default(T);

                timer.Start();

                for (var i = 0; i < testCases.Length; i++)
                {
                    result = action.Invoke(result, testCases[i]);
                }

                timer.Stop();
                totalElapsedTime += timer.Elapsed;
                timer.Reset();
            }

            Thread.CurrentThread.Priority = oldThreadPriority;

            return (decimal)totalElapsedTime.TotalMilliseconds / repeatCount;
        }

        //public static decimal RunPerformanceTests<T>(T[] testCases, Func<T, T, T> action, long repeatCount)
        //{
        //    var timer = new Stopwatch();

        //    var oldThreadPriority = Thread.CurrentThread.Priority;
        //    Thread.CurrentThread.Priority = ThreadPriority.Highest;

        //    var totalElapsedTime = new TimeSpan();

        //    for ( uint k = 0; k < repeatCount; k++ )
        //    {
        //        var result = default(T);

        //        timer.Start();

        //        for ( var i = 0; i < testCases.Length; i++ )
        //        {
        //            result = action.Invoke(result, testCases[i]);
        //        }

        //        timer.Stop();
        //        totalElapsedTime += timer.Elapsed;
        //        timer.Reset();
        //    }

        //    Thread.CurrentThread.Priority = oldThreadPriority;

        //    return (decimal)totalElapsedTime.TotalMilliseconds / repeatCount;
        //}
    }
}
