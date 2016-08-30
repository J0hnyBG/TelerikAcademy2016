namespace Minesweeper.Constants
{
    public static class StringConstants
    {
        public const string GreetingMessage = "Let's play Minesweeper! Try your best to find all mines without stepping on one!" +
                                      "\n'top' command displays the leaderboard, 'restart' command resets the game, 'exit' command exits the game. ";
        public const string AskForRowAndCol = "Enter row and column: ";
        public const string InvalidCommandMessage = "\nInvalid command!\n";
        public const string PlayerDeadMessage = "\nYou died! Your total score is: {0} points. ";
        public const string PlayerWinMessage = "\nWell done! You revealed 35 cells without dying! ";
        public const string ExitMessage = "Bye!";
        public const string AskForNickname = "Enter your nickname: ";
        public const string EmptyLeaderBoardMessage = "The leaderboard is empty!\n";
        public const string PlayerScoreMessageTemplate = "{0}. {1} --> {2} cells";
        public const string PointsMessage = "\nPoints:";

        public const string ExitGameCommand = "exit";
        public const string TurnCommand = "turn";
        public const string RestartGameCommand = "restart";
        public const string TopScoresCommand = "top";

        public const string ColsMessage = "\n    0 1 2 3 4 5 6 7 8 9";
        public const string BlankRow = "   ---------------------";
        public const string RowItemTemplate = "{0} | ";
        public const string RowItemTemplateNoDelimiter = "{0} ";
        public const string ColDelimiter = "|";

        public const string ValueCannotBeLessThanErrorMessage = "{0} cannot be less than {1}! ";
        public const string MoveOutOfRangeErrorMessage = "Move cannot be out of bounds of the minefield! Please enter valid coordinates! ";


    }
}
