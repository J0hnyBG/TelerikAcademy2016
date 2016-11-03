namespace Strategy.Robots.Behaviours
{
    using System;

    using Contracts;

    internal class PassiveBehaviour : IBehaviour
    {
        public void Act(string name)
        {
            Console.WriteLine($"{name} stays still...");
        }
    }
}
