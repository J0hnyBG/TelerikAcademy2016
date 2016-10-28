namespace CreationalPatterns
{
    using System;

    public class Startup
    {
        static void Main()
        {
            //Compile error due to protection level
            //var singleton = new Logger();

            var singleton = Logger.Instance;
            var sameSingleton = Logger.Instance;

            if (singleton == sameSingleton)
            {
                singleton.Log("Objects are the same instance.");
            }
        }
    }
}
