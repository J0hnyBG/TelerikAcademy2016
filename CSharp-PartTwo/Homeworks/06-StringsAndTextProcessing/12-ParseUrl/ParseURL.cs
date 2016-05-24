using System;

namespace _12_ParseUrl
{
    class ParseURL
    {
        private static void Main()
        {
            var inputUrl = @Console.ReadLine();

            var url = new Uri(inputUrl);

            Console.WriteLine("[protocol] = " + url.Scheme);
            Console.WriteLine("[server] = " + url.Host);
            Console.WriteLine("[resource] = " + url.AbsolutePath);
        }
    }
}
