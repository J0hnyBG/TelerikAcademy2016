using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Ninject;

using _04_TicTacToe.Core;

namespace _04_TicTacToe
{
    public partial class _Default : Page
    {
        [Inject]
        public ITicTacToeBoard Board { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            var buttons = new List<Button>();
            foreach (var control in this.GameField.Controls)
            {
                var button = control as Button;
                if (button == null)
                {
                    continue;
                }

                if (button.CssClass == "game-box")
                {
                    buttons.Add(button);
                }
            }

            for (var i = 0; i < buttons.Count; i++)
            {
                var piece = this.Board.GetPieceAtPosition(i);
                switch (piece)
                {
                    case Piece.Empty:
                        buttons[i].Text = "";
                        break;
                    case Piece.O:
                        buttons[i].Text = "O";
                        break;
                    case Piece.X:
                        buttons[i].Text = "X";
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        protected void OnTurnCommand(object sender, CommandEventArgs e)
        {
            if (e.CommandName != "ProcessTurn")
            {
                throw new ArgumentException("Command not implemented: " + e.CommandName);
            }

            this.Result.InnerHtml = "";

            var position = int.Parse((string)e.CommandArgument);
            var result = this.Board.MakeMove(position, Piece.X);

            if (!result)
            {
                this.Result.InnerHtml = "Invalid move!";
                return;
            }

            if (this.Board.HasWinner())
            {
                this.Board.Reset();
                this.Result.InnerHtml = "You won!";
                return;
            }

            // Computer random strategy
            var openPositions = this.Board.OpenPositions;
            var r = new Random();
            var rn = r.Next(0, openPositions.Length);
            if (openPositions.Length > 0)
            {
                this.Board.MakeMove(openPositions[rn], Piece.O);
            }
            else
            {
                this.Board.Reset();
                this.Result.InnerHtml = "It's a tie!";
            }

            if (this.Board.HasWinner())
            {
                this.Board.Reset();
                this.Result.InnerHtml = "Computer won!";
                return;
            }
        }

        protected void ButtonReset_OnClick(object sender, EventArgs e)
        {
            this.Board.Reset();
            this.Result.InnerHtml = "";
        }
    }
}
