using Microsoft.VisualStudio.TestTools.UnitTesting;
using FirstObOpgUnit;
using Ob1Opg4.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ob1Opg4.Repositories.Tests
{
    [TestClass()]
    public class CarsRepositoryTests
    {
        CarsRepository repository = new CarsRepository();
        Car car = new Car() {Id = 1, Model = "Mustang", Price = 1000, License = "fdtgcjs"};

        [TestMethod()]
        public void CarsRepositoryTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetAllTest()
        {
            List<Car> cars = repository.GetAll();
            Assert.IsNotInstanceOfType(cars, typeof(Car));
            Assert.AreEqual(cars.Count, 3);
            Assert.AreEqual(cars[0].Id, 1);
            Assert.AreEqual(cars[1].Model, "Mustang");
            Assert.IsNotNull(cars);
            var idSet = new HashSet<int>();
            foreach (var c in cars)
            {
                Assert.IsFalse(idSet.Contains(c.Id));
                idSet.Add(c.Id);
            }
        }

        [TestMethod()]
        public void AddCarTest()
        {
            repository.AddCar(car);
            List<Car> cars = repository.GetAll();
            Assert.AreEqual(4, cars.Count);
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            repository.GetById(1);
            List<Car> cars = repository.GetAll();
            Assert.IsNotNull(cars);
            Assert.AreEqual(cars[0].Id, 1);
            Assert.IsNotInstanceOfType(cars, typeof(Car));
        }

        [TestMethod()]
        public void DeleteCarTest()
        {
            repository.DeleteCar(2);
            List<Car> cars = repository.GetAll();
            Assert.AreEqual(2, cars.Count);
            Car? deleteCar = repository.GetById(2);
            Assert.IsNull(repository.GetById(2));
        }

        [TestMethod()]
        public void UpdateCarTest()
        {
            repository.UpdateCar(2, car);
            Assert.AreEqual("Mustang", repository.GetById(2).Model);
            
        }
    }
}