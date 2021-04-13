using Business.Concrete;
using Core.Utilities.Results;
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
             ColorManagerTest();

            BrandManagerTest();

        }

        private static void BrandManagerTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var brandList = brandManager.GetAll();
            foreach (Brand brand in brandList.Data)
            {
                Console.WriteLine(" Marka bilgisi: " + brand.Name);
            }
        }

        private static void ColorManagerTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var colorList = colorManager.GetAll();
            foreach (Color color in colorList.Data)
            {
                Console.WriteLine(" Color bilgisi: " + color.Name);
            }
        }

        private static void CategoryManagerTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            var resultCategories  = categoryManager.GetAll();
            foreach (Category category in resultCategories.Data)
            {
                Console.WriteLine(" Category bilgisi: " + category.CategoryName);
            }

            var resultCategoriesByName = categoryManager.GetCategoryByCategoryName("Economy");
            foreach (Category category in resultCategoriesByName.Data)
            {
                Console.WriteLine(" Category : " + category.CategoryName);
            }

            var resultCategoriesByNameByDoors2 = categoryManager.GetCategoryByDoors(2);
            foreach (Category category in resultCategoriesByNameByDoors2.Data)
            {
                Console.WriteLine(" Category  2 kapililar: " + category.CategoryName);
            }

            var resultCategoriesByNameByDoors4 = categoryManager.GetCategoryByDoors(4);
            foreach (Category category in resultCategoriesByNameByDoors4.Data)
            {
                Console.WriteLine(" Category  4 kapililar: " + category.CategoryName);
            }

            var resultCategoriesByNameBySeats = categoryManager.GetCategoryBySeats(4);
            foreach (Category category in resultCategoriesByNameBySeats.Data)
            {
                Console.WriteLine(" Category  4 kisilikler: " + category.CategoryName);
            }
        }

        private static void CarManagerDTOTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            foreach (CarDetailDto car in result.Data)
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

            var result = carManager.GetCarsByBrandId(3);
            foreach (Car car in result.Data)
            {
                Console.WriteLine(" Araba Marka bilgisi: " + car.Description);
            }

            var result2 = carManager.GetCarsByColorId(2);
            foreach (Car car in result2.Data)
            {
                Console.WriteLine(" Araba renk bilgisi: " + car.Description);
            }

            var result4 = carManager.GetCarById(2002);
            result4.Data.Description = " bu kayit guncellendi..";
            carManager.Update(result4.Data);
            Result islem = (Result)carManager.Update(result4.Data);
            Console.WriteLine(islem.Succsess + " " + islem.Message);

            Result islem2 = (Result)carManager.Delete(result4.Data);
            Console.WriteLine(islem2.Succsess + " " + islem2.Message);

            var result3 = carManager.GetCarsByModelYear(2021);
            foreach (Car car in result3.Data)
            {
                Console.WriteLine(" Araba Model yili bilgisi: " + car.ModelYear);
            }
        }
    }
}
