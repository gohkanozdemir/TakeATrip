using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            carManager.Add(new Car { Id = 8, BrandId = 3, ColorId = 3, CategoryId = 4, ModelYear = 2021, Description = "ilk car ekleme denemesi", CarName = "Hundai", DailyPrice = 250 });

            List<Car> cars = carManager.GetCarsByBrandId(3);
            foreach (Car car in cars)
            {
                Console.WriteLine(" Araba Marka bilgisi: " + car.Description);
            }

            List<Car> cars2 = carManager.GetCarsByColorId(2);
            foreach (Car car in cars)
            {
                Console.WriteLine(" Araba renk bilgisi: " + car.Description);
            }

            List<Category> categories = categoryManager.GetAll();
            foreach (Category category in categories)
            {
                Console.WriteLine(" Category bilgisi: " + category.CategoryName);
            }
        }
    }
}
