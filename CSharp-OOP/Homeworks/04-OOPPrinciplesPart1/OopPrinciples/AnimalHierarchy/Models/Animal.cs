namespace AnimalHierarchy.Models
{
    using System;
    using Interfaces;

    internal abstract class Animal : ISound
    {
        private int age;
        private string name;
        private char sex;

        protected Animal(int age, string name /*char sex*/)
        {
            this.Age = age;
            this.Name = name;
            //this.Sex = sex;
        }

        public int Age
        {
            get { return age; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Invalid age!");
                }
                age = value;
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid name!");
                }
                name = value;
            }
        }

        public abstract char Sex { get; set; }

        public abstract void ProduceSound();
    }
}