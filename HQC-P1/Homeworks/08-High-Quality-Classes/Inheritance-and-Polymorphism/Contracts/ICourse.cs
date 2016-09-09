using System.Collections.Generic;

namespace InheritanceAndPolymorphism.Contracts
{
    public interface ICourse
    {
        string Name { get; set; }

        string TeacherName { get; set; }

        IList<string> Students { get; set; }
    }
}
