using System;

using _02_Employees.Data.Contracts;

namespace _02_Employees.Data
{
    public class NorthwindData : INorthwindData
    {
        private INorthwindEntities context;

        public NorthwindData(INorthwindEntities context)
        {
            if (context == null)
            {
                throw new ArgumentException();
            }

            this.context = context;
        }

        public void Commit()
        {
            this.context.SaveChanges();
        }

        public void Dispose()
        {
        }
    }
}
