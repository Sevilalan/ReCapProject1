
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrate
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            if (car.Descriptions.Length<2)
            {
                return new ErrorResult(Messages.CarDailyPriceInvalid);
            }
          
                _carDal.Add(car);
                return new SuccessResult(Messages.CarAdded);
          
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
          return new SuccessResult((Messages.CarDeleted));
            
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour==1)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarListed);
        }

        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult< List < Car >>( _carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max),Messages.CarDailyPriceInvalid);
        }

        public IDataResult< Car> GetById(int id)
        {
            return new SuccessDataResult<Car>( _carDal.Get(c => c.CarId == id),Messages.CarDetail);
        }

        public IDataResult<List<Car>> GetByModelYear(string year)
        {
            return new SuccessDataResult< List < Car >> (_carDal.GetAll(c => c.ModelYear.Contains(year) == true),"model yılı listelendi");
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>( _carDal.GetCarDetails(),"detay tablosu listelendi");
        }

        public IDataResult<List<Car>>  GetCarsByBrandId(int id)
        {
            return  new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id),"Tüm markalar listelendi");
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c=>c.ColorId==id));
        }

        public IResult Update(Car car)
        {
            if (car.DailyPrice > 0)
            {
                return new ErrorResult(Messages.CarDailyPriceInvalid);

            }
            else
            {
                _carDal.Update(car);
                return new SuccessResult(Messages.CarUpdated);
            }
        }
    }
}
