namespace HW
{
    using System.Globalization;
    using System.Threading;
    using Tests;

    internal class StartUp
    {
        private static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            GsmTest.StartTest();
            GsmCallHistoryTest.StartTest();
        }
    }
}