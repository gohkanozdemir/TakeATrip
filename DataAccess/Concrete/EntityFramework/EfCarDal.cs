using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentalContext>, ICarDal
    {
        public List<CarDetailDto> GetCarsDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (RentalContext context = new RentalContext())
            {
                var result = from c in filter == null ? context.Cars : context.Cars.Where(filter)
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join cl in context.Colors
                             on c.ColorId equals cl.Id
                             join ct in context.Categories
                             on c.CategoryId equals ct.Id
                             //join cf in context.CarFeatures  // Car Fatures bilgilerine ihtiyac olursa eklenir
                             //on ct.Id equals cf.CategoryId
                             select new CarDetailDto
                             {
                                 Id= c.Id,
                                 CarName = c.CarName,
                                 BrandName = b.Name,
                                 ColorName = cl.Name,
                                 CategoryName = ct.CategoryName,
                                 ModelYear= c.ModelYear,
                                 DailyPrice= c.DailyPrice,
                                 Description = c.Description
                             };
                return result.ToList();
            }
        }

        public CarDetailDto GetCarDetailsById(Expression<Func<Car, bool>> filter = null)
        {
            using (RentalContext context = new RentalContext())
            {
                var result = from c in filter == null ? context.Cars : context.Cars.Where(filter)
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join cl in context.Colors
                             on c.ColorId equals cl.Id
                             join ct in context.Categories
                             on c.CategoryId equals ct.Id
                             //join cf in context.CarFeatures  // Car Fatures bilgilerine ihtiyac olursa eklenir
                             //on ct.Id equals cf.CategoryId
                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 CarName = c.CarName,
                                 BrandName = b.Name,
                                 ColorName = cl.Name,
                                 CategoryName = ct.CategoryName,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description
                             };
                return result.FirstOrDefault();
            }
        }
    }
}
