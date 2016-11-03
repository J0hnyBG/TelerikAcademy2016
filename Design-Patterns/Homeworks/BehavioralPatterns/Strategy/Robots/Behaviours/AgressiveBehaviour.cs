namespace Strategy.Robots.Behaviours
{
    using System;

    using Contracts;

    internal class AgressiveBehaviour : IBehaviour
    {
        public void Act(string name)
        {
            Console.WriteLine($"{name} kills all humans...");
        }
    }
}
