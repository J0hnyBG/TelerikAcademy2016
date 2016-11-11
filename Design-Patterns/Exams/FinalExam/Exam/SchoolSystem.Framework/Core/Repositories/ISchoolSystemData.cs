using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Models.Contracts;

namespace SchoolSystem.Framework.Core.Repositories
{
    public interface ISchoolSystemData
    {
        IKeyedRepository<IStudent> Students { get; }

        IKeyedRepository<ITeacher> Teachers { get; }
    }
}