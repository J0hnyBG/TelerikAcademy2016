namespace StudentClass
{
    using System;

    internal class Student : ICloneable, IComparable<Student>
    {
        private string _address;
        private string _email;
        private string _firstName;
        private string _lastName;
        private string _middleName;
        private string _mobilePhone;
        private string _ssn;

        public Student(string firstName, string middleName, string lastName, string ssn, string address,
            string mobilePhone, string email, uint course, SpecialitiesEnum speciality, UniversitiesEnum university,
            FacultiesEnum faculty)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.Ssn = ssn;
            this.Address = address;
            this.MobilePhone = mobilePhone;
            this.Email = email;
            Course = course;
            Speciality = speciality;
            University = university;
            Faculty = faculty;
        }

        internal string FirstName
        {
            get { return _firstName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException();
                }
                _firstName = value;
            }
        }

        internal string MiddleName
        {
            get { return _middleName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException();
                }
                _middleName = value;
            }
        }

        internal string LastName
        {
            get { return _lastName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException();
                }
                _lastName = value;
            }
        }

        internal string Ssn
        {
            get { return _ssn; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException();
                }
                _ssn = value;
            }
        }

        internal string Address
        {
            get { return _address; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException();
                }
                _address = value;
            }
        }

        internal string MobilePhone
        {
            get { return _mobilePhone; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException();
                }
                _mobilePhone = value;
            }
        }

        internal string Email
        {
            get { return _email; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException();
                }
                _email = value;
            }
        }

        internal uint Course { get; set; }

        internal SpecialitiesEnum Speciality { get; set; }

        internal UniversitiesEnum University { get; set; }

        internal FacultiesEnum Faculty { get; set; }

        public override bool Equals(object param)
        {
            if (!(param is Student))
            {
                return false;
            }
            var student = (Student) param;

            if (!Equals(FirstName, student.FirstName)
                || !Equals(MiddleName, student.MiddleName)
                || !Equals(LastName, student.LastName)
                || !Equals(Ssn, student.Ssn)
                || !Equals(Address, student.Address)
                || !Equals(MobilePhone, student.MobilePhone)
                || !Equals(Email, student.Email))
            {
                return false;
            }
            if (this.Course != student.Course
                || this.Faculty != student.Faculty
                || this.Speciality != student.Speciality
                || this.University != student.University)
            {
                return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            return FirstName.GetHashCode() ^ MiddleName.GetHashCode()
                   ^ LastName.GetHashCode() ^ Address.GetHashCode()
                   ^ Email.GetHashCode() ^ MobilePhone.GetHashCode()
                   ^ Ssn.GetHashCode();
        }

        public static bool operator ==(Student s1, Student s2)
        {
            return s1.Equals(s2);
        }

        public static bool operator !=(Student s1, Student s2)
        {
            return !(s1.Equals(s2));
        }


        public override string ToString()
        {
            return
                $"Name: {FirstName} {MiddleName} {LastName}\nContact: {MobilePhone}, {Email}\nAddress: {Address}\nSSN: {Ssn}\nUniversity: {University}\nSpeciality: {Speciality}\nFaculty: {Faculty}\nCourse: {Course}.";
        }

        public object Clone()
        {
            var firstName = (string) FirstName.Clone();
            var middleName = (string) MiddleName.Clone();
            var lastName = (string) LastName.Clone();
            var mobilePhone = (string) MobilePhone.Clone();
            var email = (string) Email.Clone();
            var address = (string) Address.Clone();
            var ssn = (string) Ssn.Clone();

            return new Student(firstName, middleName, lastName, ssn, address, mobilePhone, email, Course, Speciality,
                University, Faculty);
        }

        public int CompareTo(Student s)
        {
            if (this.FirstName.CompareTo(s.FirstName) > 0)
            {
                return 1;
            }
            if (this.FirstName.CompareTo(s.FirstName) < 0)
            {
                return -1;
            }
            else
            {
                if ( this.Ssn.CompareTo(s.Ssn) > 0 )
                {
                    return 1;
                }
                if ( this.Ssn.CompareTo(s.Ssn) < 0 )
                {
                    return -1;
                }
                return 0;
            }
        }
    }
}