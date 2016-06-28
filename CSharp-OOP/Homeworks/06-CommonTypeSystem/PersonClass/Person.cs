namespace PersonClass
{
    using System;

    internal class Person
    {
        private string _name;
        private uint? _age;

        public Person(string name, uint? age = null)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be empty!");
                }
                _name = value;
            }
        }

        public uint? Age
        {
            get { return _age; }
            set { _age = value; }
        }

        
        public override string ToString()
        {
            return this.Age == null ? $"Name: {this.Name}, Age: Not specified" 
                                    : $"Name: {this.Name}, Age: {this.Age}";
        }
    }
}