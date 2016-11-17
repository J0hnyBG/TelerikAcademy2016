using SchoolSystem.Framework.Core.Repositories.Contracts;
using SchoolSystem.Framework.Models.Contracts;

namespace SchoolSystem.Framework.Core.Repositories
{
    public class SchoolSystemData : ISchoolSystemData
    {
        public SchoolSystemData(IRepository<IStudent> students, IRepository<ITeacher> teachers)
        {
            this.Students = students;
            this.Teachers = teachers;
        }

        public IRepository<IStudent> Students { get; }

        public IRepository<ITeacher> Teachers { get; }
    }
}
