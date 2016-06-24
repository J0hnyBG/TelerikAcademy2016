namespace AnimalHierarchy.Models
{
    using System;

    internal class Kitten : Cat
    {
        private char sex;

        public override char Sex
        {
            get { return sex; }
            set
            {
                if ( value != 'F' && value != 'f' )
                {
                    throw new ArgumentException("Kittens must be female!");
                }
                sex = value;
            }
        }

        public Kitten(int age, string name, char sex) : base(age, name, sex)
        {
            this.Sex = sex;
        }
    }
}
