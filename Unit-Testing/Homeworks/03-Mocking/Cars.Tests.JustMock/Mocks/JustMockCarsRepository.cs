using System;

namespace Cars.Tests.JustMock.Mocks
{
    using System.Linq;

    using Cars.Contracts;
    using Cars.Models;

    using Telerik.JustMock;

    public class JustMockCarsRepository : CarRepositoryMock, ICarsRepositoryMock
    {
        protected override void ArrangeCarsRepositoryMock()
        {
            this.CarsData = Mock.Create<ICarsRepository>();
            Mock.Arrange(() => this.CarsData.Add(Arg.IsAny<Car>())).DoNothing();
            Mock.Arrange(() => this.CarsData.All()).Returns(this.FakeCarCollection);
            Mock.Arrange(() => this.CarsData.Search(Arg.AnyString)).Returns(this.FakeCarCollection.Where(c => c.Make == "BMW").ToList());
            //HW
            Mock.Arrange(() => this.CarsData.GetById(Arg.IsInRange(1, int.MaxValue, RangeKind.Inclusive))).Returns(this.FakeCarCollection.First());
            Mock.Arrange(() => this.CarsData.GetById(Arg.IsInRange(int.MinValue, 0, RangeKind.Inclusive))).Returns((Car)null);
            Mock.Arrange(() => this.CarsData.SortedByMake()).Returns(this.FakeCarCollection.OrderBy(x => x.Make).ToList());
            Mock.Arrange(() => this.CarsData.SortedByYear()).Returns(this.FakeCarCollection.OrderBy(x => x.Year).ToList());
        }
    }
}
