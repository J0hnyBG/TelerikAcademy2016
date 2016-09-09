using System;
using System.Collections.Generic;

using Minesweeper.Constants;
using Minesweeper.Models;

namespace Minesweeper.Engine
{
    public class GameEngine
    {
        private const char MineChar = '*';
        private const char EmptyCellChar = '-';
        private const char UnknownCellChar = '?';
        private const int RevealedCellsToWin = 35;
        private const int NumberOfRows = 5;
        private const int NumberOfCols = 10;
        private const int TopPlayersCount = 5;
        private const int MinCommandLength = 3;

        public GameEngine()
        {
        }

        public void StartGame()
        {
            string command = string.Empty;
            char[,] gameField = CreateGameField();
            char[,] bombs = CreateBombArray();
            int revealedCellCount = 0;
            bool playerSteppedOnBomb = false;
            List<Score> playerScores = new List<Score>(6);
            int row = 0;
            int col = 0;
            bool isFirstRun = true;
            bool isGameWon = false;

            do
            {
                if (isFirstRun)
                {
                    Console.WriteLine(StringConstants.GreetingMessage);
                    WriteArrayToConsole(gameField);
                    isFirstRun = false;
                }

                Console.Write(StringConstants.AskForRowAndCol);
                command = Console.ReadLine().Trim();
                if (command.Length >= MinCommandLength)
                {
                    if (int.TryParse(command[0].ToString(), out row) && int.TryParse(command[2].ToString(), out col) &&
                        row <= gameField.GetLength(0) && col <= gameField.GetLength(1))
                    {
                        command = StringConstants.TurnCommand;
                    }
                }

                switch (command)
                {
                    case StringConstants.TopScoresCommand:
                        ShowLeaderBoard(playerScores);
                        break;
                    case StringConstants.RestartGameCommand:
                        gameField = CreateGameField();
                        bombs = CreateBombArray();
                        WriteArrayToConsole(gameField);
                        playerSteppedOnBomb = false;
                        isFirstRun = false;
                        break;
                    case StringConstants.ExitGameCommand:
                        Console.WriteLine(StringConstants.ExitMessage);
                        break;
                    case StringConstants.TurnCommand:
                        var moveIsValid = row < gameField.GetLength(0) && row >= 0 && col < gameField.GetLength(1) &&
                                          col >= 0;

                        if (!moveIsValid)
                        {
                            Console.WriteLine(StringConstants.InvalidCommandMessage);
                            break;
                        }

                        if (bombs[row, col] != MineChar)
                        {
                            if (bombs[row, col] == EmptyCellChar)
                            {
                                UpdateGameFields(gameField, bombs, row, col);
                                revealedCellCount++;
                            }

                            if (RevealedCellsToWin == revealedCellCount)
                            {
                                isGameWon = true;
                            }
                            else
                            {
                                WriteArrayToConsole(gameField);
                            }
                        }
                        else
                        {
                            playerSteppedOnBomb = true;
                        }

                        break;
                    default:
                        Console.WriteLine(StringConstants.InvalidCommandMessage);
                        break;
                }

                if (playerSteppedOnBomb)
                {
                    WriteArrayToConsole(bombs);
                    Console.Write(StringConstants.PlayerDeadMessage, revealedCellCount);
                    string playerNickName = GetPlayerName();
                    Score currentPlayerScore = new Score(playerNickName, revealedCellCount);
                    if (playerScores.Count < TopPlayersCount)
                    {
                        playerScores.Add(currentPlayerScore);
                    }
                    else
                    {
                        for (int i = 0; i < playerScores.Count; i++)
                        {
                            if (playerScores[i].PointCount < currentPlayerScore.PointCount)
                            {
                                playerScores.Insert(i, currentPlayerScore);
                                playerScores.RemoveAt(playerScores.Count - 1);
                                break;
                            }
                        }
                    }

                    playerScores.Sort((Score r1, Score r2) => r2.Name.CompareTo(r1.Name));
                    playerScores.Sort((Score r1, Score r2) => r2.PointCount.CompareTo(r1.PointCount));
                    ShowLeaderBoard(playerScores);

                    gameField = CreateGameField();
                    bombs = CreateBombArray();
                    revealedCellCount = 0;
                    playerSteppedOnBomb = false;
                    isFirstRun = true;
                }

                if (isGameWon)
                {
                    Console.WriteLine(StringConstants.PlayerWinMessage);
                    WriteArrayToConsole(bombs);
                    string name = GetPlayerName();

                    Score score = new Score(name, revealedCellCount);
                    playerScores.Add(score);
                    ShowLeaderBoard(playerScores);
                    gameField = CreateGameField();
                    bombs = CreateBombArray();
                    revealedCellCount = 0;
                    isGameWon = false;
                    isFirstRun = true;
                }
            } while (command != StringConstants.ExitGameCommand);

            Console.Read();
        }

        private static void ShowLeaderBoard(IList<Score> playerScores)
        {
            Console.WriteLine(StringConstants.PointsMessage);
            if (playerScores.Count > 0)
            {
                for (int i = 0; i < playerScores.Count; i++)
                {
                    Console.WriteLine(
                                      StringConstants.PlayerScoreMessageTemplate,
                                      i + 1,
                                      playerScores[i].Name,
                                      playerScores[i].PointCount);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine(StringConstants.EmptyLeaderBoardMessage);
            }
        }

        private static void UpdateGameFields(char[,] gameField, char[,] bombArray, int row, int col)
        {
            char bombCount = CountBombs(bombArray, row, col);
            bombArray[row, col] = bombCount;
            gameField[row, col] = bombCount;
        }

        private static void WriteArrayToConsole(char[,] board)
        {
            int rowCount = board.GetLength(0);
            int colCount = board.GetLength(1);
            Console.WriteLine(StringConstants.ColsMessage);
            Console.WriteLine(StringConstants.BlankRow);
            for (int i = 0; i < rowCount; i++)
            {
                Console.Write(StringConstants.RowItemTemplate, i);
                for (int j = 0; j < colCount; j++)
                {
                    Console.Write(string.Format(StringConstants.RowItemTemplateNoDelimiter, board[i, j]));
                }

                Console.Write(StringConstants.ColDelimiter);
                Console.WriteLine();
            }

            Console.WriteLine(StringConstants.BlankRow + "\n");
        }

        private static char[,] CreateGameField()
        {
            int rowCount = NumberOfRows;
            int colCount = NumberOfCols;
            char[,] gameField = new char[rowCount, colCount];
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    gameField[i, j] = UnknownCellChar;
                }
            }

            return gameField;
        }

        private static char[,] CreateBombArray()
        {
            int rowCount = NumberOfRows;
            int colCount = NumberOfCols;
            char[,] bombField = new char[rowCount, colCount];

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    bombField[i, j] = EmptyCellChar;
                }
            }

            IList<int> randomNumberCollection = new List<int>();
            while (randomNumberCollection.Count < (NumberOfRows + NumberOfCols))
            {
                var random = new Random();
                int randomNumber = random.Next(50);
                if (!randomNumberCollection.Contains(randomNumber))
                {
                    randomNumberCollection.Add(randomNumber);
                }
            }

            foreach (int randomNumber in randomNumberCollection)
            {
                int currentCol = randomNumber / colCount;
                int currentRow = randomNumber % colCount;
                if (currentRow == 0 && randomNumber != 0)
                {
                    currentCol--;
                    currentRow = colCount;
                }
                else
                {
                    currentRow++;
                }

                bombField[currentCol, currentRow - 1] = MineChar;
            }

            return bombField;
        }

        private static void PlaceBombCounts(char[,] gameField)
        {
            int rowCount = gameField.GetLength(0);
            int colCount = gameField.GetLength(1);

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    if (gameField[i, j] != MineChar)
                    {
                        char bombCount = CountBombs(gameField, i, j);
                        gameField[i, j] = bombCount;
                    }
                }
            }
        }

        private static char CountBombs(char[,] bombArray, int row, int col)
        {
            int bombCount = 0;
            int totalRowCount = bombArray.GetLength(0);
            int totalColCount = bombArray.GetLength(1);

            if (row - 1 >= 0)
            {
                if (bombArray[row - 1, col] == MineChar)
                {
                    bombCount++;
                }
            }

            if (row + 1 < totalRowCount)
            {
                if (bombArray[row + 1, col] == MineChar)
                {
                    bombCount++;
                }
            }

            if (col - 1 >= 0)
            {
                if (bombArray[row, col - 1] == MineChar)
                {
                    bombCount++;
                }
            }

            if (col + 1 < totalColCount)
            {
                if (bombArray[row, col + 1] == MineChar)
                {
                    bombCount++;
                }
            }

            if ((row - 1 >= 0) && (col - 1 >= 0))
            {
                if (bombArray[row - 1, col - 1] == MineChar)
                {
                    bombCount++;
                }
            }

            if ((row - 1 >= 0) && (col + 1 < totalColCount))
            {
                if (bombArray[row - 1, col + 1] == MineChar)
                {
                    bombCount++;
                }
            }

            if ((row + 1 < totalRowCount) && (col - 1 >= 0))
            {
                if (bombArray[row + 1, col - 1] == MineChar)
                {
                    bombCount++;
                }
            }

            if ((row + 1 < totalRowCount) && (col + 1 < totalColCount))
            {
                if (bombArray[row + 1, col + 1] == MineChar)
                {
                    bombCount++;
                }
            }

            return char.Parse(bombCount.ToString());
        }

        private static string GetPlayerName()
        {
            Console.Write(StringConstants.AskForNickname);
            var name = Console.ReadLine();
            Console.WriteLine();

            while (string.IsNullOrEmpty(name))
            {
                Console.Write(StringConstants.AskForNickname);
                name = Console.ReadLine();
                Console.WriteLine();
            }

            return name;
        }
    }
}
