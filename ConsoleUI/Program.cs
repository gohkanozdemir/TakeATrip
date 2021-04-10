using Business.Concrete;
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
            CarManager carManager = new CarManager(new InMemoryCarDal());
            CategoryManager categoryManager = new CategoryManager(new InMemoryCategoryDal());

            List<Car> cars = carManager.GetAll();
            foreach (Car car in cars)
            {
                Console.WriteLine(" Araba bilgisi: " + car.Description);
            }

            List<Category> categories = categoryManager.GetAll();
            foreach (Category category in categories)
            {
                Console.WriteLine(" Category bilgisi: " + category.CategoryName);
            }
        }
    }
}
