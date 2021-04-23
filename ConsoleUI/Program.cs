using Business.Concrete;
using Core.Entities.Concrete;
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

            //BrandManagerTest();

            //UserManagerTest();
           // RentalManagerTest();

        }

        private static void RentalManagerTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.GetRentalByCarId(1);
            bool isAvailableCar = rentalManager.CarIsAvailable(result.Data);
            if (isAvailableCar)
            {
                rentalManager.Add(new Rental
                {
                    CarId = 1,
                    CustomerId = 1,
                    RentDate = DateTime.Now,
                    ReturnDate = (DateTime)System.Data.SqlTypes.SqlDateTime.Null
                });
            }
            else
            {
                Console.WriteLine(result.Data.CarId + " Car is not Available ");
            }
        }

        private static void UserManagerTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            //userManager.Add(new User { FirstName = "Hikmet", LastName = "Kandemir", Email = "email1@gmail.com", Password = "123456789" });
            //userManager.Add(new User { FirstName = "Ahmet", LastName = "Guzel", Email = "email2@gmail.com", Password = "123456789" });
            //userManager.Add(new User { FirstName = "Hakki", LastName = "Tanriverdi", Email = "email3@gmail.com", Password = "123456789" });

            var result = userManager.GetAll();
            foreach (User user in result.Data)
            {
                Console.WriteLine(" User bilgisi: " + user.FirstName + " " + user.LastName);
            }

            var result2 = userManager.GetUserById(1);
            Console.WriteLine(" GetUserById User bilgisi: " + result2.Data.FirstName + " " + result2.Data.LastName);

            var result3 = userManager.GetUserByName("Ahmet");
            Console.WriteLine(" GetUserByName User bilgisi: " + result3.Data.FirstName + " " + result3.Data.LastName);

            var result4 = userManager.GetUserByFullName("Ahmet", "Guzel");
            Console.WriteLine(" GetUserByFullName User bilgisi: " + result4.Data.FirstName + " " + result4.Data.LastName);

            var result5 = userManager.GetUserByFullName("Ahmet", "Guzelll");
            if (result5.Data == null)
            {
                Console.WriteLine("kayit bulunamadi!!!");
            }
            else
            {
                Console.WriteLine(" GetUserByFullName false User bilgisi: " + result5.Data.FirstName + " " + result5.Data.LastName);
            }
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
                Console.WriteLine(" Category bilgisi: " + category.CarCategoryId);
            }

            var resultCategoriesByName = categoryManager.GetCategoryByCategoryId(2);
            foreach (Category category in resultCategoriesByName.Data)
            {
                Console.WriteLine(" Category : " + category.CarCategoryId);
            }

            var resultCategoriesByNameByDoors2 = categoryManager.GetCategoryByDoors(2);
            foreach (Category category in resultCategoriesByNameByDoors2.Data)
            {
                Console.WriteLine(" Category  2 kapililar: " + category.CarCategoryId);
            }

            var resultCategoriesByNameByDoors4 = categoryManager.GetCategoryByDoors(4);
            foreach (Category category in resultCategoriesByNameByDoors4.Data)
            {
                Console.WriteLine(" Category  4 kapililar: " + category.CarCategoryId);
            }

            var resultCategoriesByNameBySeats = categoryManager.GetCategoryBySeats(4);
            foreach (Category category in resultCategoriesByNameBySeats.Data)
            {
                Console.WriteLine(" Category  4 kisilikler: " + category.CarCategoryId);
            }
        }

        private static void CarManagerDTOTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarsDetails();
            foreach (CarDetailDto car in result.Data)
            {
                Console.WriteLine(" Car Name: " + car.CarName
                                    + " BrandName:" + car.BrandName
                                    + " ColorName:" + car.ColorName
                                    + " CategoryName:" + car.CategoryName);
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
            Console.WriteLine(islem.Success + " " + islem.Message);

            Result islem2 = (Result)carManager.Delete(result4.Data);
            Console.WriteLine(islem2.Success + " " + islem2.Message);

            var result3 = carManager.GetCarsByModelYear(2021);
            foreach (Car car in result3.Data)
            {
                Console.WriteLine(" Araba Model yili bilgisi: " + car.ModelYear);
            }
        }
    }
}
