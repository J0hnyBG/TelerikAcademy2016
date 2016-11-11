using SchoolSystem.Framework.Models.Contracts;
using SchoolSystem.Framework.Models.Enums;

namespace SchoolSystem.Framework.Core.Commands.Contracts
{
    public interface IStudentFactory
    {
        IStudent GetStudent(string firstName, string lastName, Grade grade);
    }
}
