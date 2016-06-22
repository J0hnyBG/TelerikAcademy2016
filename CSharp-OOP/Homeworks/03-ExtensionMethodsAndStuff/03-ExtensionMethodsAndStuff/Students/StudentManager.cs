using System;

namespace _03_ExtensionMethodsAndStuff.Students
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    public static class StudentManager
    {
        //Problem 3
        public static IEnumerable<Student> GetFirstBeforeLast(IEnumerable<Student> coll)
        {
            return coll.Where(x => (x.FirstName).CompareTo(x.LastName) < 0);
        }
        //Problem 4
        public static IEnumerable<Student> InAgeRange(IEnumerable<Student> coll)
        {
            return coll.Where(x => x.Age <= 24 && x.Age >= 18);
        }
        //Problem 5.1
        public static IEnumerable<Student> SortWithExtensions(IEnumerable<Student> coll)
        {
            return coll.OrderByDescending(x => x.FirstName)
                        .ThenByDescending(x => x.LastName);
        }
        //Problem 5.2
        public static IEnumerable<Student> SortWithLinq(IEnumerable<Student> coll)
        {
            var result = from student in coll
                orderby student.FirstName descending, student.LastName descending
                select student;
            
            return result;
        }

        //Problem 10
        public static IEnumerable<Student> GetStudentsFromGroup(IEnumerable<Student> coll, int group)
        {
            return coll.Where(x => x.GroupNumber == group).OrderBy(x => x.FirstName);
        }
        //Problem 9
        public static IEnumerable<Student> GetStudentsFromGroupLinq(IEnumerable<Student> coll, int group)
        {
            return from st in coll
                where st.GroupNumber == 2
                orderby st.FirstName
                select st;
        }
        //Problem 11
        public static IEnumerable<Student> GetStudentsInSpecificDomain(IEnumerable<Student> coll, string domain)
        {
            //return coll.Where(x => x.Email.EndsWith(domain)).OrderBy(x => x.FirstName);
            return from st in coll
                where st.Email.EndsWith(domain)
                select st;
        }

        //Problem 12
        public static IEnumerable<Student> GetStudentsByPhone(IEnumerable<Student> coll, string areaCode)
        {
            //return coll.Where(x => x.Tel.StartsWith(areaCode)).OrderBy(x => x.FirstName);
            return from st in coll
                where st.Tel.StartsWith(areaCode)
                select st;
        }
        //Problem 13
        public static IEnumerable<Student> GetStudentsByMarks(IEnumerable<Student> coll, int mark)
        {
            return from st in coll
                where st.Marks.Contains(mark)
                select st;
        }
        //Problem 14
        public static IEnumerable<Student> GetStudentsWithSpecificNumberOfMarks(IEnumerable<Student> coll, int nOfMarks)
        {
            return coll.Where(x => x.Marks.Count == nOfMarks);
        }

        //Problem 15
        private static IEnumerable<Student> ExtractAllStudentsFromYear(IEnumerable<Student> coll, string year)
        {
            string shortYear = year.Substring(2, 2);
            return coll.Where(x => x.FN.EndsWith(shortYear));
        }

        public static List<int> ExtractAllMarksFromYear(IEnumerable<Student> coll, int year)
        {
            var yearString = year.ToString();
            var studentsFromYear = ExtractAllStudentsFromYear(coll, yearString);
            var marks = new List<int>();

            foreach (var st in studentsFromYear)
            {
                var studentMarks = st.Marks;
                foreach (var mark in studentMarks)
                {
                    marks.Add(mark);
                }
            }
            return marks;
        }
        //Problem 17
        public static string FindLongest(string[] coll)
        {
            return coll.Aggregate("", (max, cur) => max.Length > cur.Length ? max : cur);
        }
        //Problem 18
        public static void GroupByGroupLinq(IEnumerable<Student> coll)
        {
            var s = from st in coll
                group st.FullName by st.GroupNumber
                into g
                select new {GroupNumber = g.Key, Fullnames = g.ToList()};

            foreach (var b in s)
            {
                Console.WriteLine($"Group number: {b.GroupNumber}");
                foreach (var name in b.Fullnames)
                {
                    Console.WriteLine($"Name: {name}");
                }
            }
        }
        //Problem 19
        public static void GroupByGroup(IEnumerable<Student> coll)
        {
            var s = coll.GroupBy(st => st.GroupNumber,
                st => st.FullName,
                (key, g) => new
                {
                    GroupNumber = key,
                    FullNames = g.ToList()
                });

            foreach ( var b in s )
            {
                Console.WriteLine($"Group number: {b.GroupNumber}");
                foreach ( var name in b.FullNames )
                {
                    Console.WriteLine($"Name: {name}");
                }
            }
        }
    }
}
