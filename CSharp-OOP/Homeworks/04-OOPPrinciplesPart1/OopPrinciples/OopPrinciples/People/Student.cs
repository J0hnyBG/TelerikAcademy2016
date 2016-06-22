namespace OopPrinciples.People
{
    internal class Student : Person
    {
        private string name;
        private int classNumber;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int ClassNumber
        {
            get { return classNumber; }
            set { classNumber = value; }
        }
    }
}