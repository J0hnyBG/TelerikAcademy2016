using System;
using System.Collections.Generic;
using System.Drawing;

namespace _04_TicTacToe.Core
{
    public class TicTacToeBoard : ITicTacToeBoard
    {
        public const int ROWS = 3;
        public const int COLS = 3;

        private const int WinningLength = 3;

        protected int[,] Board;

        private bool haveWinner;

        protected Piece winningPiece;

        public TicTacToeBoard()
        {
            this.Board = new int[this.Rows, this.Cols];
        }

        public TicTacToeBoard(int[,] gameState)
            : this()
        {
            for (var i = 0; i <= gameState.GetUpperBound(0); i++)
            {
                for (var j = 0; j <= gameState.GetUpperBound(1); j++)
                {
                    this.Board[i, j] = gameState[i, j];
                }
            }
        }

        public int Rows { get { return ROWS; } }
        public int Cols { get { return COLS; }  }

        public Piece WinningPiece
        {
            get { return this.winningPiece; }
            set { this.winningPiece = value; }
        }

        public int[] OpenPositions
        {
            get
            {
                var positions = new List<int>();
                for (var i = 0; i < this.Board.Length; i++)
                {
                    if (!this.IsOccupied(i))
                    {
                        positions.Add(i);
                    }
                }

                return positions.ToArray();
            }
        }

        public void Reset()
        {
            this.Board = new int[this.Rows, this.Cols];
            this.winningPiece = 0;
            this.haveWinner = false;
        }

        public object Clone()
        {
            var b = new TicTacToeBoard(this.Board);
            return b;
        }

        public Piece GetPieceAtPoint(int row, int column)
        {
            return this.GetPieceAtPosition(this.GetPositionFromPoint(new Point(row, column)));
        }

        public Piece GetOponentPiece(Piece yourPiece)
        {
            if (yourPiece == Piece.X)
            {
                return Piece.O;
            }
            else if (yourPiece == Piece.O)
            {
                return Piece.X;
            }
            else
            {
                throw new Exception("Invalid Piece!");
            }
        }

        public bool MakeMove(int position, Piece piece)
        {
            if (!this.IsValidSquare(position))
            {
                return false;
            }

            var pieceNumber = (int)piece;
            var point = this.GetPoint(position);

            this.Board[point.X, point.Y] = pieceNumber;
            return true;
        }

        public bool IsValidPosition(int position)
        {
            return position >= 0 && position <= this.Cols * this.Rows - 1;
        }

        public bool HasWinner()
        {
            for (var i = 0; i < this.Board.Length; i++)
            {
                if (this.IsWinnerAt(i))
                {
                    this.haveWinner = true;
                    this.SetWinnerAtPosition(i);
                    return true;
                }
            }

            return false;
        }

        public bool IsValidSquare(int position)
        {
            var p = this.GetPoint(position);

            if (p.X >= 0 && p.X < this.Rows && p.Y >= 0 && p.Y < this.Cols && this.IsPositionOpen(p.X, p.Y))
            {
                return true;
            }

            return false;
        }

        public Piece GetPieceAtPosition(int position)
        {
            if (!this.IsOccupied(position))
            {
                return Piece.Empty;
            }

            if (this.GetBoardPiece(position) == 1)
            {
                return Piece.X;
            }

            return Piece.O;
        }

        protected int GetPositionFromPoint(Point p)
        {
            return p.X * this.Cols + p.Y;
        }

        protected Point GetPoint(int position)
        {
            var p = new Point
                    {
                        X = position / this.Cols,
                        Y = position % this.Rows
                    };

            return p;
        }

        private void SetWinnerAtPosition(int position)
        {
            this.WinningPiece = this.GetPieceAtPosition(position);
        }

        private int GetBoardPiece(int position)
        {
            var p = this.GetPoint(position);

            return this.Board[p.X, p.Y];
        }

        private bool IsOccupied(int position)
        {
            var p = this.GetPoint(position);

            return this.Board[p.X, p.Y] != 0;
        }

        private bool IsPositionOpen(int row, int col)
        {
            return this.Board[row, col] == 0;
        }

        private bool IsWinnerAt(int position)
        {
            if (this.IsWinnerToTheRight(position) || this.IsWinnerFromTopToBottom(position)
                || this.IsWinnerDiagonallyToRightUp(position) || this.IsWinnerDiagonallyToRightDown(position))
            {
                return true;
            }

            return false;
        }

        private bool IsWinnerToTheRight(int position)
        {
            var p = this.GetPoint(position);

            if (!this.IsOccupied(position))
            {
                return false;
            }

            if (p.Y + WinningLength - 1 >= this.Cols)
            {
                return false;
            }

            var piece = this.GetPieceAtPosition(position);

            for (var i = 1; i < WinningLength; i++)
            {
                if (this.GetPieceAtPosition(position + i) != piece)
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsWinnerFromTopToBottom(int position)
        {
            var p = this.GetPoint(position);

            if (!this.IsOccupied(position))
            {
                return false;
            }

            if (p.X + WinningLength - 1 >= this.Rows)
            {
                return false;
            }

            var piece = this.GetPieceAtPosition(position);

            for (var i = 1; i < WinningLength; i++)
            {
                if (piece != this.GetPieceAtPosition(position + 3 * i))
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsWinnerDiagonallyToRightDown(int position)
        {
            if (!this.IsOccupied(position))
            {
                return false;
            }

            var piece = this.GetPieceAtPosition(position);

            var last = this.GetPoint(position);
            for (var i = 1; i < WinningLength; i++)
            {
                last.X += 1;
                last.Y += 1;
                if (!this.IsPointInBounds(last))
                {
                    return false;
                }

                if (piece != this.GetPieceAtPosition(this.GetPositionFromPoint(last)))
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsWinnerDiagonallyToRightUp(int position)
        {
            if (!this.IsOccupied(position))
            {
                return false;
            }

            var piece = this.GetPieceAtPosition(position);

            var last = this.GetPoint(position);
            for (var i = 1; i < WinningLength; i++)
            {
                last.X -= 1;
                last.Y += 1;

                if (!this.IsPointInBounds(last))
                {
                    return false;
                }

                if (piece != this.GetPieceAtPosition(this.GetPositionFromPoint(last)))
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsPointInBounds(Point p)
        {
            return p.X >= 0 && p.X < this.Rows && p.Y >= 0 && p.Y < this.Cols;
        }
    }
}
