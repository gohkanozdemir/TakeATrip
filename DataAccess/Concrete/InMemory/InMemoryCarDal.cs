using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            CreateCars();
        }
        public void Add(Car car)
        {
            _cars.Add(car);
            Console.WriteLine(car.Description + " eklendi.");
        }

        public void Delete(Car car)
        {
            var carDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carDelete);
            Console.WriteLine(car.Description + " silindi.");
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _cars;
        }

        public Car GetById(int carId)
        {
            return _cars.SingleOrDefault(c => c.Id == carId);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public CarDetailDto GetCarDetailsById(int carId)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarsDetails()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarsDetailsByCategoryId(int categoryId)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            var carUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carUpdate.Description = car.Description;
            Console.WriteLine(car.Description + " guncellendi.");
        }

        private void CreateCars()
        {
            _cars = new List<Car>
            {
                new Car{Id=1, BrandId=1, ColorId=1, CategoryId=1, DailyPrice=50, ModelYear=2021, Description= "Kia Picanto"},
                new Car{Id=2, BrandId=2, ColorId=2, CategoryId=1, DailyPrice=50, ModelYear=2021, Description= "Fiat 500"},
                new Car{Id=3, BrandId=3, ColorId=2, CategoryId=2, DailyPrice=60, ModelYear=2021, Description= "Hyundai i10"},
                new Car{Id=4, BrandId=4, ColorId=1, CategoryId=2, DailyPrice=60, ModelYear=2021, Description= "Peugeot 108"},
                new Car{Id=5, BrandId=5, ColorId=3, CategoryId=4, DailyPrice=70, ModelYear=2021, Description= "Ford Fiesta"},
                new Car{Id=6, BrandId=6, ColorId=1, CategoryId=4, DailyPrice=70, ModelYear=2021, Description= "Citroen C3"},
                new Car{Id=7, BrandId=5, ColorId=2, CategoryId=7, DailyPrice=80, ModelYear=2021, Description= "Ford Focus"},
                new Car{Id=8, BrandId=4, ColorId=1, CategoryId=7, DailyPrice=80, ModelYear=2021, Description= "Peugeot 308"},
                new Car{Id=9, BrandId=7, ColorId=1, CategoryId=8, DailyPrice=100, ModelYear=2021, Description= "Renault Megane Estate"},
                new Car{Id=10, BrandId=5, ColorId=3, CategoryId=8, DailyPrice=100, ModelYear=2021, Description= "Ford Focus Estate"},
                new Car{Id=11, BrandId=8, ColorId=2, CategoryId=9, DailyPrice=120, ModelYear=2021, Description= "Chevrolet Cruze"},
                new Car{Id=12, BrandId=9, ColorId=2, CategoryId=9, DailyPrice=120, ModelYear=2021, Description= "Skoda Octavia"},
                new Car{Id=13, BrandId=10, ColorId=2, CategoryId=9, DailyPrice=120, ModelYear=2021, Description= "Volkswagen Jetta"},
                new Car{Id=14, BrandId=11, ColorId=1, CategoryId=10, DailyPrice=140, ModelYear=2021, Description= "BMW 3 Series Tourer"},
                new Car{Id=15, BrandId=7, ColorId=2, CategoryId=10, DailyPrice=140, ModelYear=2021, Description= "Renault Talisman"},
                new Car{Id=16, BrandId=10, ColorId=2, CategoryId=11, DailyPrice=160, ModelYear=2021, Description= "Volkswagen Passat"},
                new Car{Id=17, BrandId=5, ColorId=2, CategoryId=11, DailyPrice=160, ModelYear=2021, Description= "Ford Mondeo"},
                new Car{Id=18, BrandId=6, ColorId=1, CategoryId=12, DailyPrice=180, ModelYear=2021, Description= "Citroen C-5 Tourer"},
                new Car{Id=19, BrandId=12, ColorId=2, CategoryId=12, DailyPrice=180, ModelYear=2021, Description= "Vauxhall/Opel Insignia Estate"},
                new Car{Id=20, BrandId=13, ColorId=1, CategoryId=13, DailyPrice=300, ModelYear=2021, Description= "Audi S6"},
                new Car{Id=21, BrandId=14, ColorId=1, CategoryId=13, DailyPrice=200, ModelYear=2021, Description= "Alpha Romeo Giulia"},
                new Car{Id=22, BrandId=15, ColorId=1, CategoryId=14, DailyPrice=250, ModelYear=2021, Description= "Mercedes Benz E-Class Estate"},
                new Car{Id=23, BrandId=9, ColorId=1, CategoryId=14, DailyPrice=220, ModelYear=2021, Description= "Skoda Superb Estate"},
                new Car{Id=24, BrandId=15, ColorId=1, CategoryId=15, DailyPrice=300, ModelYear=2021, Description= "Mercedes-Benz E-Class"},
                new Car{Id=25, BrandId=16, ColorId=1, CategoryId=15, DailyPrice=300, ModelYear=2021, Description= " Jaguar XE"},
                new Car{Id=26, BrandId=11, ColorId=1, CategoryId=15, DailyPrice=305, ModelYear=2021, Description= "BMW 5-series"},
                new Car{Id=27, BrandId=12, ColorId=1, CategoryId=16, DailyPrice=250, ModelYear=2021, Description= "Opel Cascada Cabrio"},
                new Car{Id=28, BrandId=13, ColorId=1, CategoryId=16, DailyPrice=400, ModelYear=2021, Description= "Audi A5 Convertible"},
                new Car{Id=29, BrandId=10, ColorId=1, CategoryId=17, DailyPrice=500, ModelYear=2021, Description= "Volkswagen Tiguan"},
                new Car{Id=30, BrandId=17, ColorId=1, CategoryId=17, DailyPrice=500, ModelYear=2021, Description= "Nissan Pathfinder"},
                new Car{Id=31, BrandId=10, ColorId=1, CategoryId=18, DailyPrice=400, ModelYear=2021, Description= "Volkswagen Sharan"},
                new Car{Id=32, BrandId=18, ColorId=1, CategoryId=18, DailyPrice=400, ModelYear=2021, Description= "Seat Alhambra"},
                new Car{Id=33, BrandId=10, ColorId=1, CategoryId=18, DailyPrice=800, ModelYear=2021, Description= "Volkswagen Transporter"}
            };
        }

        Car IEntityRepository<Car>.Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
