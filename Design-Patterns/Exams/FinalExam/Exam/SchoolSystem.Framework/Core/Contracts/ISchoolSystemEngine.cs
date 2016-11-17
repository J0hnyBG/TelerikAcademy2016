using SchoolSystem.Framework.Core.Repositories.Contracts;

namespace SchoolSystem.Framework.Core.Contracts
{
    public interface ISchoolSystemEngine : IEngine
    {
        ISchoolSystemData Data { get; }
    }
}
