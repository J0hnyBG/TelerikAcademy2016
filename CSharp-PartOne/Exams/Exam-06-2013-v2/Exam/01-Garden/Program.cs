using System;


namespace _01_Garden
{
    class Program
    {
        static void Main()
        {
            int tomatoSeeds = int.Parse(Console.ReadLine());
            int tomatoArea = int.Parse(Console.ReadLine());
            double tomatoCost = 0.5d;

            int cucumberSeeds = int.Parse(Console.ReadLine());
            int cucumberArea = int.Parse(Console.ReadLine());
            double cucumberCost = 0.4d;

            int potatoSeeds = int.Parse(Console.ReadLine());
            int potatoArea = int.Parse(Console.ReadLine());
            double potatoCost = 0.25d;

            int carrotSeeds = int.Parse(Console.ReadLine());
            int carrotArea = int.Parse(Console.ReadLine());
            double carrotCost = 0.6d;

            int cabbageSeeds = int.Parse(Console.ReadLine());
            int cabbageArea = int.Parse(Console.ReadLine());
            double cabbageCost = 0.3d;

            int beansSeeds = int.Parse(Console.ReadLine());
            double beansCost = 0.4d;

            const int totalArea = 250;

            double totalCost = tomatoCost*tomatoSeeds + cucumberCost*cucumberSeeds + potatoCost*potatoSeeds +
                                carrotCost*carrotSeeds + cabbageCost*cabbageSeeds + beansCost*beansSeeds;

            int beansArea = 250 - (tomatoArea + cucumberArea + potatoArea + carrotArea + cabbageArea);
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
