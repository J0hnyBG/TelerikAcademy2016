namespace OopPrinciples.People
{
    using System.Collections.Generic;
    using Disciplines;
    internal class Teacher : Person
    {
        private HashSet<Discipline> setOfDisciplines;

        public Teacher(HashSet<Discipline> setOfDisciplines)
        {
            this.setOfDisciplines = setOfDisciplines;
        }

        public HashSet<Discipline> SetOfDisciplines
        {
            get { return setOfDisciplines; }
            set { setOfDisciplines = value; }
        }
    }
}
