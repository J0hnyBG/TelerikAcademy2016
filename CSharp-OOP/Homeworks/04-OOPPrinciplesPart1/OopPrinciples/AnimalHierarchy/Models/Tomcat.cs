namespace AnimalHierarchy.Models
{
    using System;

    internal class TomCat : Animal
    {
        private char sex;

        public override char Sex
        {
            get { return sex; }
            set
            {
                if ( value != 'M' && value != 'm' )
                {
                    throw new ArgumentException("Invalid sex!");
                }
                sex = value;
            }
        }

        public TomCat(int age, string name, char sex) : base(age, name)
        {
            this.Sex = sex;
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Miao miao tomcat miao.");
        }
    }
}
