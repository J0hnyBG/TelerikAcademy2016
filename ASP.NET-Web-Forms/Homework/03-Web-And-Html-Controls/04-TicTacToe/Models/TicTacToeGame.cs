using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Ninject;

using _04_TicTacToe.Core;

namespace _04_TicTacToe.Models
{
    public class TicTacToeGame
    {
        [Inject]
        public ITicTacToeBoard Board { get; set; }
    }
}