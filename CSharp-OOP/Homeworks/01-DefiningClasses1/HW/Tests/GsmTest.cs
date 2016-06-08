namespace HW.Tests
{
    using System;
    using Enum;
    static class GsmTest
    {
        //Problem 7
        public static void StartTest()
        {
            var samsung = new Gsm("Samsung", "S300");
            var nokia = new Gsm("Nokia", "3310", BatteryType.NiCd, 30, "Pesho", "SKU1254", 150.5, 72.2, 1.6, 2);
            var sony = new Gsm("Sony", "Xperia X", BatteryType.LiIon, 799.99, "Petar Petrov", null, null, null, 5, 16000000);
            var alcatel = new Gsm("Alcatel", "OT-363", BatteryType.LiIon, 99.99, "Ivan Ivanov", null, null, 2.5, 1.8, 65536);

            Gsm[] arr = { samsung, nokia, sony, alcatel};
            Console.WriteLine("Started instance test:\n");
            foreach (var gsm in arr)
            {
                Console.WriteLine(gsm.ToString());
            }
            Console.WriteLine("Started static test:\n");
            Console.WriteLine(Gsm.Iphone4S);
        }
    }
}
