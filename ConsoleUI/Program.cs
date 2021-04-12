using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarManagerDTOTest();
            //CarManagerTest();

            //CategoryManagerTest();
            // ColorManagerTest();

            BrandManagerTest();

        }

        private static void BrandManagerTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            List<Brand> brands = brandManager.GetAll();
            foreach (Brand brand in brands)
            {
                Console.WriteLine(" Color bilgisi: " + brand.Name);
            }
        }

        private static void ColorManagerTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            List<Color> colors = colorManager.GetAll();
            foreach (Color color in colors)
            {
                Console.WriteLine(" Color bilgisi: " + color.Name);
            }
        }

        private static void CategoryManagerTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            List<Category> categories = categoryManager.GetAll();
            foreach (Category category in categories)
            {
                Console.WriteLine(" Category bilgisi: " + category.CategoryName);
            }

            List<Category> categories2 = categoryManager.GetCategoryByCategoryName("Economy");
            foreach (Category category in categories2)
            {
                Console.WriteLine(" Category : " + category.CategoryName);
            }

            List<Category> categories3 = categoryManager.GetCategoryByDoors(2);
            foreach (Category category in categories3)
            {
                Console.WriteLine(" Category  2 kapililar: " + category.CategoryName);
            }

            List<Category> categories4 = categoryManager.GetCategoryByDoors(4);
            foreach (Category category in categories4)
            {
                Console.WriteLine(" Category  4 kapililar: " + category.CategoryName);
            }

            List<Category> categories5 = categoryManager.GetCategoryBySeats(4);
            foreach (Category category in categories5)
            {
                Console.WriteLine(" Category  4 kisilikler: " + category.CategoryName);
            }
        }

        private static void CarManagerDTOTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            List<CarDetailDto> cars = carManager.GetCarDetails();
            foreach (CarDetailDto car in cars)
            {
                Console.WriteLine(" Car Name: " + car.CarName
                                    + " BrandName:" + car.BrandName
                                    + " ColorName:" + car.ColorName
                                    + " CategoryName:" + car.CategoryName
                                    + " DailyPrice:" + car.DailyPrice);
            }
        }

        private static void CarManagerTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            //carManager.Add(new Car { BrandId = 3, ColorId = 3, CategoryId = 4, ModelYear = 2021, Description = "ilk car ekleme denemesi", CarName = "Hundai", DailyPrice = 250 });

            List<Car> cars = carManager.GetCarsByBrandId(3);
            foreach (Car car in cars)
            {
                Console.WriteLine(" Araba Marka bilgisi: " + car.Description);
            }

            List<Car> cars2 = carManager.GetCarsByColorId(2);
            foreach (Car car in cars2)
            {
                Console.WriteLine(" Araba renk bilgisi: " + car.Description);
            }

            Car car1 = carManager.GetCarById(1002);
            car1.Description = " bu kayit guncellendi..";
            carManager.Update(car1);

            carManager.Delete(car1);

            List<Car> cars3= carManager.GetCarsByModelYear(2021);
            foreach (Car car in cars3)
            {
                Console.WriteLine(" Araba Model yili bilgisi: " + car.ModelYear);
            }
        }
    }
}
