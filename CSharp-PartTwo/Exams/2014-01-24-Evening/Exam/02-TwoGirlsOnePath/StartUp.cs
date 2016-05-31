using System;
using System.Linq;
using System.Numerics;
using System.Threading;

namespace _02_TwoGirlsOnePath
{

    internal class StartUp
    {
        private static long[] _flowersInCell;
        private static Girl molly;
        private static Girl dolly;

        private static void Main()
        {
            _flowersInCell = Console.ReadLine().Split().Select(long.Parse).ToArray();
            molly = new Girl(0, 1, 0, _flowersInCell.Length);
            dolly = new Girl(_flowersInCell.Length - 1, -1, 0, _flowersInCell.Length);

            while (true)
            {
                if ( _flowersInCell[molly.CurrentCell] == 0 || _flowersInCell[dolly.CurrentCell] == 0 )
                {
                    if ( _flowersInCell[molly.CurrentCell] == 0 && _flowersInCell[dolly.CurrentCell] == 0 )
                    {
                        Console.WriteLine("Draw");

                    }
                    else if ( _flowersInCell[molly.CurrentCell] == 0 )
                    {
                        Console.WriteLine("Dolly");
                    }
                    else if ( _flowersInCell[dolly.CurrentCell] == 0 )
                    {
                        Console.WriteLine("Molly");
                    }
                    molly.IncreaseScore(_flowersInCell[molly.CurrentCell]);
                    dolly.IncreaseScore(_flowersInCell[dolly.CurrentCell]);
                    Console.WriteLine("{0} {1}", molly.TotalScore, dolly.TotalScore);

                    break;
                }

                if (molly.CurrentCell == dolly.CurrentCell)
                {
                    molly.IncreaseScore(_flowersInCell[molly.CurrentCell] / 2);
                    dolly.IncreaseScore(_flowersInCell[dolly.CurrentCell] / 2);

                    molly.Move(_flowersInCell[molly.CurrentCell]);
                    dolly.Move(_flowersInCell[dolly.CurrentCell]);

                    _flowersInCell[dolly.PreviousCell] = _flowersInCell[dolly.PreviousCell] % 2;
                }
                else
                {
                    molly.IncreaseScore(_flowersInCell[molly.CurrentCell]);
                    dolly.IncreaseScore(_flowersInCell[dolly.CurrentCell]);
                    molly.Move(_flowersInCell[molly.CurrentCell]);
                    dolly.Move(_flowersInCell[dolly.CurrentCell]);

                    _flowersInCell[molly.PreviousCell] = 0;
                    _flowersInCell[dolly.PreviousCell] = 0;
                }

            }
        }

        private class Girl
        {
            public long CurrentCell { get; private set; }
            public long PreviousCell { get; private set; }
            private int Direction { get; set; }
            private int MaxJumps { get; set; }
            public BigInteger TotalScore { get; private set; }

            public Girl(long currentCell, int direction, BigInteger totalScore, int maxJumps)
            {
                CurrentCell = currentCell;
                Direction = direction;
                TotalScore = totalScore;
                MaxJumps = maxJumps;
                PreviousCell = currentCell;
            }

            public void Move(long numberOfJumps)
            {
                PreviousCell = CurrentCell;
                CurrentCell += Direction * numberOfJumps;
                if (CurrentCell > MaxJumps - 1 || CurrentCell < 0)
                {
                    CurrentCell = ( CurrentCell % MaxJumps + MaxJumps ) % MaxJumps;
                }
            }

            public void IncreaseScore(long amount)
            {
                TotalScore += amount;
                //Console.WriteLine("Totalscore: " + TotalScore);
                //Thread.Sleep(500);
            }
        }
    }
}
