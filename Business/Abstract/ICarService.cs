using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface ICarService
    {
        List<Car> GetAll(); //tüm ürünleri listeler
        List<Car> GetCarsByColorId(int id);

        List<Car> GetCarsByBrandId(int id);
        List<Car> GetByDailyPrice(decimal min, decimal max);
        List<Car> GetByModelYear(string year);
        Car GetById(int id);

        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);

    }
}
