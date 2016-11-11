using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Models.Contracts;

namespace SchoolSystem.Framework.Core.Repositories
{
    public class SchoolSystemData : ISchoolSystemData
    {
        public SchoolSystemData(IKeyedRepository<IStudent> students, IKeyedRepository<ITeacher> teachers)
        {
            this.Students = students;
            this.Teachers = teachers;
        }

        public IKeyedRepository<IStudent> Students { get; }

        public IKeyedRepository<ITeacher> Teachers { get; }
    }
}
