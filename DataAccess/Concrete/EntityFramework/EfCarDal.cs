using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
                             join cc in context.CarCategories
                             on ct.CarCategoryId equals cc.Id
                             select new CarDetailDto
                             {
                                 CarName = c.CarName,
                                 BrandName = b.Name,
                                 ColorName = cl.Name,
                                 CategoryName = cc.CategoryName,
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
                             join cc in context.CarCategories
                             on ct.CarCategoryId equals cc.Id
                             where c.Id == carId
                             select new CarDetailDto
                             {
                                 CarName = c.CarName,
                                 BrandName = b.Name,
                                 ColorName = cl.Name,
                                 CategoryName = cc.CategoryName,
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
                             join cc in context.CarCategories
                             on ct.CarCategoryId equals cc.Id
                             where c.CategoryId == categoryId
                             select new CarDetailDto
                             {
                                 CarName = c.CarName,
                                 BrandName = b.Name,
                                 ColorName = cl.Name,
                                 CategoryName = cc.CategoryName,
                             };
                return result.ToList();
            }
        }
    }
}
