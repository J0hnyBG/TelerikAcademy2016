using System;

namespace _04_TicTacToe.Core
{
    public interface ITicTacToeBoard : ICloneable
    {
        int Rows { get; }

        int Cols { get; }

        Piece WinningPiece { get; set; }

        int[] OpenPositions { get; }

        void Reset();

        Piece GetPieceAtPoint(int row, int column);

        Piece GetOponentPiece(Piece yourPiece);

        bool MakeMove(int position, Piece piece);

        bool IsValidPosition(int position);

        bool HasWinner();

        bool IsValidSquare(int position);

        Piece GetPieceAtPosition(int position);
    }
}