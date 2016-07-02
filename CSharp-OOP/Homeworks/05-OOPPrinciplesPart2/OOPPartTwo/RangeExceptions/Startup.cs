namespace RangeExceptions
{
    using System;

    internal class Startup
    {
        static void Main()
        {
            try
            {
                var number = 200;
                if ( number < 1 || number > 100 )
                {
                    throw new InvalidRangeException<int>("Number must be between 1 and 100!", 1, 100);
                }
            }
            catch ( InvalidRangeException<int> ex )
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                var date = new DateTime(1981, 12, 31);

                if ( date < new DateTime(1980, 01, 01) || date > new DateTime(2013, 12, 31) )
                {
                    throw new InvalidRangeException<DateTime>("Date must be between 1.1.1980 and 31.12.2013!", new DateTime(1980, 01, 01), new DateTime(2013, 12, 31));
                }
            }
            catch ( InvalidRangeException<DateTime> ex )
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
