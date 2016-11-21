using System;

namespace SortingHomework.Tests.TestData
{
    internal class Foo : IComparable<Foo>, IEquatable<Foo>
    {
        public Foo(int salary, string name)
        {
            this.Salary = salary;
            this.Name = name;
        }

        public int Salary { get; set; }
        public string Name { get; set; }

        public int CompareTo(Foo other)
        {
            // Alphabetic sort if salary is equal. [A to Z]
            if (this.Salary == other.Salary)
            {
                return this.Name.CompareTo(other.Name);
            }
            // Default to salary sort. [High to low]
            return other.Salary.CompareTo(this.Salary);
        }

        public bool Equals(Foo other)
        {
            return this.Salary == other.Salary && this.Name == other.Name;
        }
    }
}
