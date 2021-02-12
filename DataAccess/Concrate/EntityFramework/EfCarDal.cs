using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrate;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrate.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentACarContext context= new RentACarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join clr in context.Colors
                            on c.ColorId equals clr.ColorId
                             select new CarDetailDto
                             {
                                 CarId=c.CarId,
                                 BrandId=b.BrandId,
                                 ColorId=clr.ColorId,
                                 BrandName=b.BrandName,
                                 ColorName=clr.ColorName,
                                 ModelYear=c.ModelYear,
                                 DailyPrice=c.DailyPrice,
                                 Descriptions=c.Descriptions
                             };
                return result.ToList();
            }
        }
    }
}
