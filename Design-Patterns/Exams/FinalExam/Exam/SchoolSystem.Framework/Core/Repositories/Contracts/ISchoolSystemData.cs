using SchoolSystem.Framework.Models.Contracts;

namespace SchoolSystem.Framework.Core.Repositories.Contracts
{
    public interface ISchoolSystemData
    {
        IRepository<IStudent> Students { get; }

        IRepository<ITeacher> Teachers { get; }
    }
}