using System;
using System.Linq;

internal class Tron3D
{
    private static bool[,] VisitedCells;

    private static void Main()
    {
        int[] dimensions = Console.ReadLine().Split(' ').Select(n => int.Parse(n)).ToArray();
        int x = dimensions[0];
        int y = dimensions[1];
        int z = dimensions[2];
        VisitedCells = new bool[2 * x + 2 * z, y];
    }

    private static void Initialize(int x, int y, int z)
    {
    }
}

internal class Player
{
    private bool[,] VisitedCells;

    public Player(bool[,] visitedCells, int posX, int posY)
    {
        //VisitedCells = new bool[,];
        PosX = posX;
        PosY = posY;
    }

    private int PosX;
    private int PosY;
}