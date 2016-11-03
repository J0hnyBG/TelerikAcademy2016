namespace Strategy
{
    using Robots;
    using Robots.Behaviours;

    internal class Startup
    {
        private static void Main()
        {
            var robot = new Robot("Mr. Robot", new PassiveBehaviour());
            robot.ProcessMove();

            robot.Behaviour = new AgressiveBehaviour();
            robot.ProcessMove();
        }
    }
}
