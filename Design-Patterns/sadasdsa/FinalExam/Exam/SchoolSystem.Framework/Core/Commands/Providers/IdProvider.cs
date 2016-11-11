using SchoolSystem.Framework.Core.Commands.Contracts;

namespace SchoolSystem.Framework.Core.Commands.Providers
{
    public class IdProvider : IIdProvider
    {
        private int currentId;

        public IdProvider()
        {
            this.currentId = 0;
        }

        public int Current
        {
            get { return this.currentId; }
        }

        public int GetNext()
        {
            return this.currentId++;
        }
    }
}
