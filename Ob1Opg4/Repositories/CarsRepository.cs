using FirstObOpgUnit;

namespace Ob1Opg4.Repositories
{
    public class CarsRepository
    {
        private int _nextID;
        private List<Car> _cars;

        public CarsRepository()
        {
            _nextID = 1;
            _cars = new List<Car>()
            {
                new Car() {Id = _nextID++, Model = "Pikachu", Price = 9999, License = "fssghj"},
                new Car() {Id = _nextID++, Model = "Charmander", Price = 1000, License = "sdgvwfe"},
                new Car() {Id = _nextID++, Model = "Arbok", Price = 20, License = "jshdoc"}
            };
        }

        public List<Car> GetAll()
        {
            return new List<Car>(_cars);
        }

        public Car AddCar(Car newCar)
        {
            newCar.Id = _nextID++;
            _cars.Add(newCar);
            //newCar.Validate();
            return newCar;
        }

        public Car? GetById(int id)
        {
            return _cars.Find(Car => Car.Id == id);
        }

        public Car? DeleteCar(int id)
        {
            Car? Car = GetById(id);
            if (Car == null) return null;
            _cars.Remove(Car);
            return Car;
        }

        public Car? UpdateCar(int id, Car update)
        {
            //update.Validate();
            Car? upCar = GetById(id);
            if (upCar == null)
            {
                return null;
            }
            upCar.Model = update.Model;
            upCar.Price = update.Price;
            upCar.License = update.License;
            return upCar;
        }
    }
}
