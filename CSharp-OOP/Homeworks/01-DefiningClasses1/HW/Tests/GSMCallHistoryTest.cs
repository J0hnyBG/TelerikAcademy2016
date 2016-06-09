namespace HW.Tests
{
    using System;
    //using Calls;

    internal static class GsmCallHistoryTest
    {
        private const double PricePerMin = 0.37;

        //Problem 12
        public static void StartTest()
        {
            var gsm = new Gsm("Samsung", "S300");

            gsm.AddCall("6/15/2009 1:45 PM", 50, "088889880");
            gsm.AddCall("7/16/2010 2:45 PM", 60, "088889861");
            gsm.AddCall("8/17/2011 3:45 PM", 70, "088889862");
            gsm.AddCall("9/18/2012 4:45 PM", 80, "088889863");
            gsm.AddCall("10/19/2014 6:45 PM", 1500, "088889865");
            gsm.AddCall("10/19/2013 5:45 PM", 100, "088889864");

            var longestCall = gsm.CallHistory[0];
            Console.WriteLine("Starting call history test:\n");
            foreach (var call in gsm.CallHistory)
            {
                Console.WriteLine("Call date: " + call.DateTime);
                Console.WriteLine("Call duration in seconds: " + call.DurationInSeconds);
                Console.WriteLine("Call to: " + call.DialedNumber + "\n");

                if (longestCall.DurationInSeconds < call.DurationInSeconds)
                {
                    longestCall = call;
                }
            }
            Console.WriteLine("Total price of calls before removing longest: {0:F2}\n",
                +gsm.GetTotalPriceOfCalls(PricePerMin));
            Console.WriteLine("Deleting longest call. Starting test:\n");
            gsm.DeleteCall(longestCall);

            foreach (var call in gsm.CallHistory)
            {
                Console.WriteLine("Call date: " + call.DateTime);
                Console.WriteLine("Call duration in seconds: " + call.DurationInSeconds);
                Console.WriteLine("Call to: " + call.DialedNumber + "\n");
            }
            Console.WriteLine("Total price of calls after removing longest: {0:F2}\n",
                +gsm.GetTotalPriceOfCalls(PricePerMin));
        }
    }
}