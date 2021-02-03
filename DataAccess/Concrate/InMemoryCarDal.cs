using DataAccess.Abstract;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrate
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _car;
        public InMemoryCarDal()
        {
            _car = new List<Car>
            {
                new Car{Id=1,BrandId=1, ColorId=1, DailyPrice=300, ModelYear="2000", Description="Car1"},
                new Car{Id=2,BrandId=2, ColorId=1, DailyPrice=400, ModelYear="2001", Description="Car2"},
                new Car{Id=3,BrandId=2, ColorId=2, DailyPrice=500, ModelYear="2002", Description="Car3"},
                new Car{Id=4,BrandId=3, ColorId=1, DailyPrice=600, ModelYear="2003", Description="Car4"},
                new Car{Id=5,BrandId=4, ColorId=3, DailyPrice=700, ModelYear="2004", Description="Car5"}
            };
        }
        public void Add(Car car)
        {
            _car.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _car.SingleOrDefault(c => c.Id == car.Id);
            _car.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _car;
        }

        public List<Car> GetAllByCategory(int Id)
        {
            return _car.Where(c => c.Id == Id).ToList();
        }

        public void Update(Car car)
        {
            
            Car carToUpdate = _car.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.Id = car.Id;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
        }
    }
}
