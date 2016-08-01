using FastAndFurious.ConsoleApplication.Common.Utils;
using FastAndFurious.ConsoleApplication.Contracts;

namespace FastAndFurious.ConsoleApplication.Models.Common
{
    public class Identifiable : IIdentifiable
    {
        private readonly int id;

        protected Identifiable()
        {
            this.Id = DataGenerator.GenerateId();
        }

        public int Id { get; private set; }
    }
}
