using System;
using System.Linq;

namespace _03_Tron3D
{
    class Tron3D
    {
        private static bool[,] _sideA;
        private static bool[,] _sideB;
        private static bool[,] _sideC;
        private static bool[,] _sideD;

        static void Main()
        {
            int[] dimensions = Console.ReadLine().Split(' ').Select(n => int.Parse(n)).ToArray();

        }

        static void Initialize(int x, int y, int z)
        {
            _sideA = new bool[x,y];
            _sideC = new bool[x,y];
            _sideB = new bool[z,y];
            _sideD = new bool[z,y];
        }
    }
}
