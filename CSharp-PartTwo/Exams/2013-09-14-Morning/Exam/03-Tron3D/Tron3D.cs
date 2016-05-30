using System;
using System.Linq;

internal class Tron3D
{
    private static bool[,] used;
    private static int oldX, oldY, oldZ;
    private static int X, Y;
    static string redMoves, blueMoves;
    private static Player BluePlayer;
    private static Player RedPlayer;

    private static void Main()
    {
        ReadInput();
        X = oldX;
        Y = oldY + oldZ + oldY + oldZ;
        used = new bool[X + 1, Y];

        RedPlayer = new Player(oldX/2, oldY/2, 0, redMoves);
        BluePlayer = new Player(oldX/2, oldY / 2 + oldZ + oldY, 2, blueMoves);

        while (true)
        {
            while (RedPlayer.Index < RedPlayer.Moves.Length && RedPlayer.Moves[RedPlayer.Index] != 'M')
            {
                RotatePlayer(RedPlayer);
                RedPlayer.Index++;
            }
            RedPlayer.Move();
            RedPlayer.Index++;
            
            if ( RedPlayer.PosY >= Y )
            {
                RedPlayer.PosY = 0;
            }
            if ( RedPlayer.PosY < 0 )
            {
                RedPlayer.PosY = Y - 1;
            }

            while ( BluePlayer.Index < BluePlayer.Moves.Length && BluePlayer.Moves[BluePlayer.Index] != 'M' )
            {
                RotatePlayer(BluePlayer);
                BluePlayer.Index++;
            }
            BluePlayer.Move();
            BluePlayer.Index++;
            if ( BluePlayer.PosY >= Y )
            {
                BluePlayer.PosY = 0;
            }
            if ( BluePlayer.PosY < 0 )
            {
                BluePlayer.PosY = Y - 1;
            }

            bool redLooses = Looses(RedPlayer);
            bool blueLooses = Looses(BluePlayer);

            if (redLooses || blueLooses)
            {
                //TODO: Calculate distance between crash and start
                if ( redLooses && blueLooses )
                {
                    Console.WriteLine("DRAW");
                    //RedPlayer.MoveBack();
                    Console.WriteLine(GetDistanceFromStart(RedPlayer.PosX, RedPlayer.PosY, oldX, oldY, oldZ) - 1);

                }
                else if ( redLooses )
                {
                    Console.WriteLine("BLUE");
                    Console.WriteLine(GetDistanceFromStart(BluePlayer.PosX, BluePlayer.PosY, oldX, oldY, oldZ));

                }
                else if ( blueLooses )
                {
                    Console.WriteLine("RED");
                    Console.WriteLine(GetDistanceFromStart(RedPlayer.PosX, RedPlayer.PosY, oldX, oldY, oldZ));
                }

                break;
            }
            used[RedPlayer.PosX, RedPlayer.PosY] = true;
            used[BluePlayer.PosX, BluePlayer.PosY] = true;
        }
    }

    static double GetDistanceFromStart(int h, int v, int x, int y, int z)
    {
        if ( h > z + y + y / 2 )
            h = 2 * z + y - h;

        return Math.Abs(h - y / 2) + Math.Abs(v - x / 2);
    }

    public static bool Looses(Player player)
    {
        if (player.PosX < 0 || player.PosX > X)
        {
            return true;
        }
        return used[player.PosX, player.PosY];
    }

    static void RotatePlayer(Player player)
    {
        switch ( player.Moves[player.Index] )
        {
            case 'L':
                player.RotateLeft();
                break;
            case 'R':
                player.RotateRight();
                break;
            default:
                throw new ArgumentException("The move is invalid.");
        }
    }
    public static void ReadInput()
    {
        var dimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        oldX = dimensions[0];
        oldY = dimensions[1];
        oldZ = dimensions[2];
        redMoves = Console.ReadLine();
        blueMoves = Console.ReadLine();
    }
}

class Player
{
    public int PosX { get; set; }
    public int PosY { get; set; }
    public int Direction { get; set; }
    public int Index { get; set; }
    public string Moves { get; set; }

    public Player(int posX, int posY, int direction, string moves, int index = 0)
    {
        PosX = posX;
        PosY = posY;
        Direction = direction;
        Index = index;
        Moves = moves;
    }

    //Directions:
    //0 -> right
    //1 -> down
    //2 -> left
    //3 -> up
    //4 -> 0
    //rotate right -> direction++;
    //rotate left -> direction--;
   public void Move()
    {
        switch (Direction)
        {
            case 0:
                PosY++;
                break;
            case 1:
                PosX++;
                break;
            case 2:
                PosY--;
                break;
            case 3:
                PosX--;
                break;
        }
    }
    public void MoveBack()
    {
        switch ( Direction )
        {
            case 0:
                PosY--;
                break;
            case 1:
                PosX--;
                break;
            case 2:
                PosY++;
                break;
            case 3:
                PosX++;
                break;
        }
    }

    public void RotateLeft()
    {
        Direction--;
        if (Direction < 0)
        {
            Direction = 3;
        }
    }
    public void RotateRight()
    {
        Direction++;
        if ( Direction > 3 )
        {
            Direction = 0;
        }
    }
}