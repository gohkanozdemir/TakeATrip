using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentalContext>, ICarDal
    {
        public List<CarDetailDto> GetCarsDetails()
        {
            using (RentalContext context = new RentalContext())
            {
                var result = from c in context.Cars
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

        public CarDetailDto GetCarDetailsById(int carId)
        {
            using (RentalContext context = new RentalContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join cl in context.Colors
                             on c.ColorId equals cl.Id
                             join ct in context.Categories
                             on c.CategoryId equals ct.Id
                             //join cf in context.CarFeatures  // Car Fatures bilgilerine ihtiyac olursa eklenir
                             //on ct.Id equals cf.CategoryId
                             where c.Id == carId
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

        public List<CarDetailDto> GetCarsDetailsByCategoryId(int categoryId)
        {
            using (RentalContext context = new RentalContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join cl in context.Colors
                             on c.ColorId equals cl.Id
                             join ct in context.Categories
                             on c.CategoryId equals ct.Id
                             //join cf in context.CarFeatures  // Car Fatures bilgilerine ihtiyac olursa eklenir
                             //on ct.Id equals cf.CategoryId
                             where c.CategoryId == categoryId
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
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarsDetailsByColorId(int colorId)
        {
            using (RentalContext context = new RentalContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join cl in context.Colors
                             on c.ColorId equals cl.Id
                             join ct in context.Categories
                             on c.CategoryId equals ct.Id
                             //join cf in context.CarFeatures  // Car Fatures bilgilerine ihtiyac olursa eklenir
                             //on ct.Id equals cf.CategoryId
                             where c.ColorId == colorId
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
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarsDetailsByBrandId(int brandId)
        {
            using (RentalContext context = new RentalContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join cl in context.Colors
                             on c.ColorId equals cl.Id
                             join ct in context.Categories
                             on c.CategoryId equals ct.Id
                             //join cf in context.CarFeatures  // Car Fatures bilgilerine ihtiyac olursa eklenir
                             //on ct.Id equals cf.CategoryId
                             where c.BrandId == brandId
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
                return result.ToList();
            }
        }
    }
}
