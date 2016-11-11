using SchoolSystem.Framework.Core.Repositories;

namespace SchoolSystem.Framework.Core.Contracts
{
    public interface ISchoolSystemEngine : IEngine
    {
        ISchoolSystemData Data { get; }
    }
}
