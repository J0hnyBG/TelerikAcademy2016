using System;
using System.Collections.Generic;

namespace _03_Slides2
{
    class Ball
    {
        public Ball(int ballWidth, int ballHeight, int ballDepth)
        {
            BallWidth = ballWidth;
            BallHeight = ballHeight;
            BallDepth = ballDepth;
        }

        public Ball(Ball ball)
        {
            BallWidth = ball.BallWidth;
            BallHeight = ball.BallHeight;
            BallDepth = ball.BallDepth;
        }
        public int BallWidth { get; set; }
        public int BallHeight { get; set; }
        public int BallDepth { get; set; }
    }
    class Slides2
    {
        private static int width, height, depth;
        private static string[,,] cube;
        private static Ball cubeBall;

        static void Main()
        {
            string[] rawNumbers = Console.ReadLine().Split();
            width = int.Parse(rawNumbers[0]);
            height = int.Parse(rawNumbers[1]);
            depth = int.Parse(rawNumbers[2]);

            FillCube();
            ProcessBallCommands();

        }

        static void ProcessBallCommands()
        {
            while (true)
            {
                string currCell = cube[cubeBall.BallWidth, cubeBall.BallHeight, cubeBall.BallDepth];

                string[] splitCell = currCell.Split();
                string command = splitCell[0];
                switch (command)
                {
                    case "S":
                        ProcessBallSlides(splitCell[1]);
                        break;
                    case "T":
                        cubeBall.BallWidth = int.Parse(splitCell[1]);
                        cubeBall.BallDepth = int.Parse(splitCell[2]);
                        break;
                    case "E":
                        if (cubeBall.BallHeight == height - 1)
                        {
                            PrintMessage();
                            return;
                        }
                        cubeBall.BallHeight++;
                        break;
                    case "B":
                        PrintMessage();
                        return;
                    default:
                        throw new ArgumentException("Invalid command");
                        
                }
            }
        }

        static void ProcessBallSlides(string param)
        {
            Ball newCubeBall = new Ball(cubeBall);
            switch (param)
            {
                case "R":
                    newCubeBall.BallHeight++;
                    newCubeBall.BallWidth++;
                    break;
                case "L":
                    newCubeBall.BallHeight++;
                    newCubeBall.BallWidth--;
                    break;
                case "F":
                    newCubeBall.BallHeight++;
                    newCubeBall.BallDepth--;
                    break;
                case "B":
                    newCubeBall.BallHeight++;
                    newCubeBall.BallDepth++;
                    break;
                case "FL":
                    newCubeBall.BallHeight++;
                    newCubeBall.BallWidth--;
                    newCubeBall.BallDepth--;
                    break;
                case "FR":
                    newCubeBall.BallHeight++;
                    newCubeBall.BallWidth++;
                    newCubeBall.BallDepth--;
                    break;
                case "BL":
                    newCubeBall.BallHeight++;
                    newCubeBall.BallDepth++;
                    newCubeBall.BallWidth--;
                    break;
                case "BR":
                    newCubeBall.BallHeight++;
                    newCubeBall.BallDepth++;
                    newCubeBall.BallWidth++;
                    break;
                default:
                    throw new ArgumentException("Invalid slide command");
            }
            if (IsPassable(newCubeBall))
            {
                cubeBall = new Ball(newCubeBall);
            }
            else
            {
                PrintMessage();
                Environment.Exit(0);
            }
        }

        static void PrintMessage()
        {
            string currentCell = cube[cubeBall.BallWidth, cubeBall.BallHeight, cubeBall.BallDepth];

            if ( currentCell == "B" || cubeBall.BallHeight != height - 1)
            {
                Console.WriteLine("No");
            }
            else
            {
                Console.WriteLine("Yes");
            }
            Console.WriteLine("{0} {1} {2}", cubeBall.BallWidth, cubeBall.BallHeight, cubeBall.BallDepth);
        }
        private static bool IsPassable(Ball ball)
        {
            if ( ball.BallWidth >= 0 && ball.BallHeight >= 0 && ball.BallDepth >= 0
                && ball.BallWidth < width && ball.BallHeight < height && ball.BallDepth < depth )
            {
                return true;
            }
            return false;
        }
        static void FillCube()
        {

            cube = new string[width, depth, height];

            for ( int h = 0; h < height; h++ )
            {
                string[] lineFragment = Console.ReadLine().Split(new[] { " | " }, StringSplitOptions.RemoveEmptyEntries);

                for ( int d = 0; d < depth; d++ )
                {
                    string[] cellContent = lineFragment[d].Split(new[] { ')', '(' }, StringSplitOptions.RemoveEmptyEntries);
                    for ( int w = 0; w < width; w++ )
                    {
                        cube[w, h, d] = cellContent[w];
                    }
                }
            }
            string[] rawBallCoords = Console.ReadLine().Split();
            int ballWidth = int.Parse(rawBallCoords[0]);
            int ballDepth = int.Parse(rawBallCoords[1]);

            cubeBall = new Ball(ballWidth, 0, ballDepth);
        }
    }
}
