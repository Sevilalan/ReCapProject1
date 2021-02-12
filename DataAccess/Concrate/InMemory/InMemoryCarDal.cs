using DataAccess.Abstract;
using Entities.Concrate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrate.InMemory
{
  public  class InMemoryCarDal: ICarDal
    {
        List<Car> _car;
        public InMemoryCarDal()
        {
            _car = new List<Car>
            {
                new Car{CarId=1,BrandId=1, ColorId=1, DailyPrice=300, ModelYear="2000", Descriptions="Car1"},
                new Car{CarId=2,BrandId=2, ColorId=1, DailyPrice=400, ModelYear="2001", Descriptions="Car2"},
                new Car{CarId=3,BrandId=2, ColorId=2, DailyPrice=500, ModelYear="2002", Descriptions="Car3"},
                new Car{CarId=4,BrandId=3, ColorId=1, DailyPrice=600, ModelYear="2003", Descriptions="Car4"},
                new Car{CarId=5,BrandId=4, ColorId=3, DailyPrice=700, ModelYear="2004", Descriptions="Car5"}
            };
        }
        public void Add(Car car)
        {
            _car.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _car.SingleOrDefault(c => c.CarId == car.CarId);
            _car.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _car;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {

            Car carToUpdate = _car.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.CarId = car.CarId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Descriptions = car.Descriptions;
        }
    }
}
