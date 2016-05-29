using System;
using System.Linq;
using System.Numerics;

internal class BitShiftMatrix
{
    private static bool[,] _visitedCells;
    private static Pawn _pawn;

    private static BigInteger GetCellScore(int x, int y)
    {
        BigInteger result = (BigInteger)1 << ( _visitedCells.GetLength(0) - x - 1 ) + y ;
        return result;
    }

    private static void MovePawn(long targetX, long targetY)
    {
        int deltaCol = _pawn.Col > targetY ? -1 : 1;
        while ( _pawn.Col != targetY )
        {
            if ( !isVisited(_pawn.Row, _pawn.Col) )
            {
                _pawn.TotalScore += GetCellScore(_pawn.Row, _pawn.Col);
                _visitedCells[_pawn.Row, _pawn.Col] = true;
            }
            _pawn.Col += deltaCol;
        }

        int deltaRow = _pawn.Row > targetX ? -1 : 1;
        while ( _pawn.Row != targetX )
        {
            if ( !isVisited(_pawn.Row, _pawn.Col) )
            {
                _pawn.TotalScore += GetCellScore(_pawn.Row, _pawn.Col);
                _visitedCells[_pawn.Row, _pawn.Col] = true;
            }
            _pawn.Row += deltaRow;
        }
        if ( !isVisited(_pawn.Row, _pawn.Col) )
        {
            _pawn.TotalScore += GetCellScore(_pawn.Row, _pawn.Col);
            _visitedCells[_pawn.Row, _pawn.Col] = true;
        }
    }

    private static bool isVisited(int x, int y)
    {
        return _visitedCells[x, y];
    }

    private static void Main()
    {
        int totalRows = int.Parse(Console.ReadLine());
        int totalCols = int.Parse(Console.ReadLine());

        _visitedCells = new bool[totalRows, totalCols];
        _pawn = new Pawn(totalRows - 1);

        int coeff = Math.Max(totalRows, totalCols);
        int n = int.Parse(Console.ReadLine());

        int[] directions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        foreach ( var direction in directions )
        {
            var row = direction / coeff;
            var col = direction % coeff;
            MovePawn(row, col);

        }
        if ( !isVisited(_pawn.Row, _pawn.Col) )
        {
            _pawn.TotalScore += GetCellScore(_pawn.Row, _pawn.Col);
            _visitedCells[_pawn.Row, _pawn.Col] = true;
        }
        Console.WriteLine(_pawn.TotalScore);
    }
}

internal class Pawn
{
    public int Row { get; set; }
    public int Col { get; set; }
    public BigInteger TotalScore { get; set; }

    public Pawn(int startingRow, int startingCol = 0)
    {
        this.Row = startingRow;
        this.Col = startingCol;
        this.TotalScore = 0;
    }
}