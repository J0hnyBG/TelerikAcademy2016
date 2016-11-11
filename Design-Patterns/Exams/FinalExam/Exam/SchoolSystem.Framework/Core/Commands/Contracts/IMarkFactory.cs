using SchoolSystem.Framework.Models.Contracts;
using SchoolSystem.Framework.Models.Enums;

namespace SchoolSystem.Framework.Core.Commands.Contracts
{
    public interface IMarkFactory
    {
        IMark GetMark(Subject subject, float value);
    }
}
