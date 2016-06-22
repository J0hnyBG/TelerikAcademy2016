namespace _03_ExtensionMethodsAndStuff.Timer
{
    using System;
    using System.Threading;
    public static class Timer
    {
        public static void SetInterval(Action f, int t)
        {
            var thread = new Thread(Meth(f, t));
            thread.Start();
        }

        private static ThreadStart Meth(Action f, int t)
        {
            while ( true )
            {
                Thread.Sleep(t * 1000);
                f();
            }
        }
    }
}
