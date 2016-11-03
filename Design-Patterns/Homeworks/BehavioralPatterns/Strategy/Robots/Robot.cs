namespace Strategy.Robots
{
    using Behaviours.Contracts;

    public class Robot
    {
        public Robot(string name, IBehaviour behaviour)
        {
            this.Name = name;
            this.Behaviour = behaviour;
        }
        public string Name { get; set; }

        public IBehaviour Behaviour { get; set; }

        public void ProcessMove()
        {
            this.Behaviour.Act(this.Name);
        }
    }
}
