namespace OopPrinciples.Class
{
    using System;
    using System.Collections.Generic;
    using People;
    internal class Class
    {
        internal static List<string> uniqueIdentifiers = new List<string>();
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
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Classes unique identifier cannot be null or empty!");
                }
                if (Class.uniqueIdentifiers.Contains(value))
                {
                    throw new ArgumentException("Classes unique identifier already exists!");

                }
                Class.uniqueIdentifiers.Add(value);
                uniqueIdentifier = value;
            }
        }

        public HashSet<Teacher> SetOfTeachers
        {
            get { return setOfTeachers; }
            set { setOfTeachers = value; }
        }
    }
}
