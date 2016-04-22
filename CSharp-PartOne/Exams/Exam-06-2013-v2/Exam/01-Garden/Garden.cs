using System;

namespace _01_Garden
{
    internal class Garden
    {
        private static void Main()
        {
            var tomatoSeeds = int.Parse(Console.ReadLine());
            var tomatoArea = int.Parse(Console.ReadLine());
            const double tomatoCost = 0.5d;

            var cucumberSeeds = int.Parse(Console.ReadLine());
            var cucumberArea = int.Parse(Console.ReadLine());
            const double cucumberCost = 0.4d;

            var potatoSeeds = int.Parse(Console.ReadLine());
            var potatoArea = int.Parse(Console.ReadLine());
            const double potatoCost = 0.25d;

            var carrotSeeds = int.Parse(Console.ReadLine());
            var carrotArea = int.Parse(Console.ReadLine());
            const double carrotCost = 0.6d;

            var cabbageSeeds = int.Parse(Console.ReadLine());
            var cabbageArea = int.Parse(Console.ReadLine());
            const double cabbageCost = 0.3d;

            var beansSeeds = int.Parse(Console.ReadLine());
            const double beansCost = 0.4d;

            const int totalArea = 250;

            var totalCost = tomatoCost*tomatoSeeds + cucumberCost*cucumberSeeds + potatoCost*potatoSeeds +
                            carrotCost*carrotSeeds + cabbageCost*cabbageSeeds + beansCost*beansSeeds;

            var beansArea = totalArea - (tomatoArea + cucumberArea + potatoArea + carrotArea + cabbageArea);
            Console.WriteLine("Total costs: {0:F2}", totalCost);

            if (beansArea > 0)
            {
                Console.WriteLine("Beans area: " + beansArea);
            }
            else if (beansArea == 0)
            {
                Console.WriteLine("No area for beans");
            }
            else
            {
                Console.WriteLine("Insufficient area");
            }
        }
    }
}