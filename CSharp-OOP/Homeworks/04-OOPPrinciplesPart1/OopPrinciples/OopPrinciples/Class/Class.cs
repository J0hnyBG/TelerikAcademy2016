namespace OopPrinciples.Class
{
    using System.Collections.Generic;
    using People;
    internal class Class
    {
        private string uniqueIdentifier;
        private HashSet<Teacher> setOfTeachers;

        public Class(string uniqueIdentifier, HashSet<Teacher> setOfTeachers)
        {
            this.UniqueIdentifier = uniqueIdentifier;
            this.SetOfTeachers = setOfTeachers;
        }

        public string UniqueIdentifier
        {
            get { return uniqueIdentifier; }
            set { uniqueIdentifier = value; }
        }

        public HashSet<Teacher> SetOfTeachers
        {
            get { return setOfTeachers; }
            set { setOfTeachers = value; }
        }
    }
}
