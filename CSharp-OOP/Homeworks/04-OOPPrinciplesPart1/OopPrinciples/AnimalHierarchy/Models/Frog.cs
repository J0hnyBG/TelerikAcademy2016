namespace AnimalHierarchy.Models
{
    using System;

    internal class Frog : Animal
    {
        private char sex;

        public override char Sex
        {
            get { return sex; }
            set
            {
                if ( value != 'M' && value != 'm' && value != 'F' && value != 'f' )
                {
                    throw new ArgumentException("Invalid sex!");
                }
                sex = value;
            }
        }

        public Frog(int age, string name, char sex) : base(age, name)
        {
            this.Sex = sex;
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Croak croak, I'm a frog.");
        }
    }
}
