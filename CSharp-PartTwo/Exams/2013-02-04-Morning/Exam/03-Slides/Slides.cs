using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text.RegularExpressions;

namespace _03_Slides
{
    internal class Slides
    {
        private static readonly Dictionary<string, int[]> Directions = new Dictionary<string, int[]>
        {
            //TODO: Fix directions
                            //w, h, d
            {"(S F)", new[] {0, 1, -1}},
            {"(S B)", new[] {0, 1, 1}},
            {"(S L)", new[] {-1, 1, 0}},
            {"(S R)", new[] {1, 1, 0}},
            {"(S FL)", new[] {-1, 1, -1}},
            {"(S FR)", new[] {1, 1, -1}},
            {"(S BL)", new[] {-1, 1, 1}},
            {"(S BR)", new[] {1, 1, 1}},
            {"(E)", new[] {0, 1, 0}},

        };

        private static string[,,] _cube;

        private static void Main()
        {
            int[] cubeSizes = Console.ReadLine().Trim().Split(' ').Select(n => int.Parse(n)).ToArray();
            FillCube(cubeSizes);
            int[] ballStart = Console.ReadLine().Trim().Split(' ').Select(n => int.Parse(n)).ToArray();
            Solve(ballStart);
        }

        private static void Solve(int[] startCoords)
        {
            var currentCoords = new[] {startCoords[0], 0, startCoords[1]};
            string currentCell = GetCellValue(currentCoords);

            while (true)
            {
                var previousCoords = new int[3];
                Array.Copy(currentCoords, previousCoords, 3);
                switch (currentCell[1])
                {
                    case 'S':
                    case 'E':
                        var tempCoords = Directions[currentCell];
                        currentCoords[0] += tempCoords[0];
                        currentCoords[1] += tempCoords[1];
                        currentCoords[2] += tempCoords[2];
                        break;
                    case 'B':
                        Console.WriteLine("No");
                        Console.WriteLine("{0} {1} {2}", currentCoords[0], currentCoords[1], currentCoords[2]);
                        return;
                    case 'T':
                        currentCoords[0] = currentCell[3] - '0';
                        currentCoords[2] = currentCell[5] - '0';
                        break;
                }
                if (currentCoords[0] >= _cube.GetLength(0) || currentCoords[1] >= _cube.GetLength(1) || currentCoords[2] >= _cube.GetLength(2))
                {
                    Console.WriteLine("Yes");
                    Console.WriteLine("{0} {1} {2}", previousCoords[0], previousCoords[1], previousCoords[2]);
                    break;
                }
                currentCell = GetCellValue(currentCoords);
            }
        }

        private static string GetCellValue(int[] coords)
        {
            return _cube[coords[0], coords[1], coords[2]];
        }

        private static void FillCube(int[] cubeSize)
        {
            _cube = new string[cubeSize[0], cubeSize[1], cubeSize[2]];

            for (int height = 0; height < cubeSize[1]; height++)
            {
                var rows = Console.ReadLine().Trim().Split(new[] { " | " }, StringSplitOptions.RemoveEmptyEntries);

                for (int depth = 0; depth < cubeSize[2]; depth++)
                {
                    var matches = Regex.Matches(rows[depth].Trim(), @"\((.{0,5})\)");
                    //TODO:!!
                    //var row = rows[depth].Split(new[] { ")" }, StringSplitOptions.RemoveEmptyEntries);
                    for (int width = 0; width < cubeSize[0]; width++)
                    {
                        _cube[width, height, depth] = matches[width].Value;
                        //_cube[width, height, depth] = row
                    }
                }
            }
        }
    }
}