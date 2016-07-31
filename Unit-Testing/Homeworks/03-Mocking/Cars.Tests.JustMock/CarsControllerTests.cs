namespace Cars.Tests.JustMock
{
    using System;
    using System.Collections.Generic;
    using Telerik.JustMock;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Cars.Contracts;
    using Cars.Tests.JustMock.Mocks;
    using Cars.Controllers;
    using Cars.Models;

    [TestClass]
    public class CarsControllerTests
    {
        private readonly ICarsRepository carsData;
        private CarsController controller;

        public CarsControllerTests()
            : this(new JustMockCarsRepository())
         //: this(new MoqCarsRepository())
        {
        }

        private CarsControllerTests(ICarsRepositoryMock carsDataMock)
        {
            this.carsData = carsDataMock.CarsData;
        }

        [TestInitialize]
        public void CreateController()
        {
            this.controller = new CarsController(this.carsData);
        }

        //Homework
        [TestMethod]
        public void SortingCars_ShouldCallSortedByMakeMethodOnce()
        {
            this.GetModel(() => this.controller.Sort("make"));

            Mock.Assert(() => this.carsData.SortedByMake(), Occurs.Once());
        }

        [TestMethod]
        public void SortingCars_ShouldCallSortedByYearMethodOnce()
        {
            this.GetModel(() => this.controller.Sort("year"));

            Mock.Assert(() => this.carsData.SortedByYear(), Occurs.Once());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SortingCars_ShouldThrowArgumentException_WhenInvalidCritetiaIsProvided()
        {
            this.controller.Sort("byInvalidCriteria_sdf45dfruyuXsdASDAs34324432#$AS@!");
        }

        [TestMethod]
        public void Search_ShouldCallRepositorySearchMethodOnce()
        {
            this.GetModel(() => this.controller.Search("BMW"));

            Mock.Assert(() => this.carsData.Search("BMW"), Occurs.Once());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Details_ShouldThrowWhenNoCarWithId()
        {
            this.GetModel(() => this.controller.Details(-500));
        }

        [TestMethod]
        public void Details_ShouldReturnCar()
        {
            var model = (Car)this.GetModel(() => this.controller.Details(1));

            Assert.AreEqual(1, model.Id);
            Assert.AreEqual("Audi", model.Make);
            Assert.AreEqual("A5", model.Model);
            Assert.AreEqual(2005, model.Year);
        }
        //End homework
        [TestMethod]
        public void IndexShouldReturnAllCars()
        {
            var model = (ICollection<Car>)this.GetModel(() => this.controller.Index());

            Assert.AreEqual(4, model.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarIsNull()
        {
            var model = (Car)this.GetModel(() => this.controller.Add(null));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarMakeIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = "",
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarModelIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        public void AddingCarShouldReturnADetail()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));

            Assert.AreEqual(1, model.Id);
            Assert.AreEqual("Audi", model.Make);
            Assert.AreEqual("A5", model.Model);
            Assert.AreEqual(2005, model.Year);
        }

        private object GetModel(Func<IView> funcView)
        {
            var view = funcView();
            return view.Model;
        }
    }
}
