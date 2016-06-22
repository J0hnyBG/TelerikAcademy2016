namespace OopPrinciples.People
{
    using System.Collections.Generic;
    using Disciplines;
    internal class Teacher : Person
    {
        private HashSet<Discipline> setOfDisciplines;

        public Teacher(string name, HashSet<Discipline> setOfDisciplines, string comment = null) : base(name, comment)
        {
            this.SetOfDisciplines = setOfDisciplines;
        }

        public HashSet<Discipline> SetOfDisciplines
        {
            get { return setOfDisciplines; }
            set { setOfDisciplines = value; }
        }
    }
}
