using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using WebFormsMvp;

using _04_TicTacToe.Core;

namespace _04_TicTacToe.Logic
{
    public class TicTacToePresenter : Presenter<IView<TicTacToeBoard>>
    {
        public TicTacToePresenter(IView<TicTacToeBoard> view) : base(view)
        {
        }


    }
}