using Minesweeper.Engine;

namespace Minesweeper
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var gameEngine = new GameEngine();
            gameEngine.StartGame();
        }
    }
}
