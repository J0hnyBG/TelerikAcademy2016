using System;
using System.Collections.Generic;

namespace _03_ExtensionMethodsAndStuff.Students
{
    //Problems 3-5, 10-16
    public class Student
    {
        private int age;

        public Student(int age, string firstName, string lastName, string fn, string tel, string email, List<int> marks, int groupNumber)
        {
            this.age = age;
            FirstName = firstName;
            LastName = lastName;
            FN = fn;
            Tel = tel;
            Email = email;
            Marks = marks;
            GroupNumber = groupNumber;
        }

        public int Age
        {
            get
            {
                return age;
            }

            set
            {
                if (value < 0 || value > 150)
                {
                    throw new ArgumentOutOfRangeException("The entered age is invalid!");
                }
                age = value;
            }
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FN { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public List<int> Marks { get; set; }
        public int GroupNumber { get; set; }

        public string FullName
        {
            get { return $"{this.FirstName} {this.LastName}"; }
        }


    }
}
