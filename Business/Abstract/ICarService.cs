using Entities.Concrate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface ICarService
    { //dış dünyaya ne göstermek istiyorsak burda tanımlıyoruz 
        List<Car> GetAll(); //tüm ürünleri listeler
        Car GetById(int id);
        List<Car> GetCarsByColorId(int id);

        List<Car> GetCarsByBrandId(int id);
        List<Car> GetByDailyPrice(decimal min, decimal max);
        List<Car> GetByModelYear(string year);
        List<CarDetailDto> GetCarDetails();



        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);

    }
}
