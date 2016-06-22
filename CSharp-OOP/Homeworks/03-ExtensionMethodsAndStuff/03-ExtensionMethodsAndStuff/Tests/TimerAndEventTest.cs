namespace _03_ExtensionMethodsAndStuff.Tests
{
    using System;
    using Timer;
    public static class TimerAndEventTest
    {
        public static void StartTest()
        {
            Console.Write("Press enter to start event tests.");
            Console.ReadLine();
            var timerWithEvent = new TimerWithEvent();

            timerWithEvent.Tick += OnTick;
            timerWithEvent.SetInterval(3);

        }

        static void OnTick(object sender, EventArgs e)
        {
            Console.WriteLine("Event fired!");
        }
    }
}
