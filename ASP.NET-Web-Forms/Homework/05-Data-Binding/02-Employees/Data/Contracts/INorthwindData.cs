using System;

namespace _02_Employees.Data.Contracts
{
    public interface INorthwindData : IDisposable
    {
        void Commit();
    }
}