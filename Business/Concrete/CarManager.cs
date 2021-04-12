using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public List<Car> GetAll()
        {
           return _carDal.GetAll();
        }
        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _carDal.GetAll(p => p.BrandId == brandId);
        }
        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carDal.GetAll(p => p.ColorId == colorId);
        }

        public void Add(Car car)
        {
            if (car.CarName.Length <= 2)
            {
                Console.WriteLine("Operation failed. The car name must be greater then 2 chcracters.");
                return;
            }
            else if(car.DailyPrice <= 0)
            {
                Console.WriteLine("Operation failed. The car daily price must be greater then 0.");
                return;
            }
            else
            {
                _carDal.Add(car);
                Console.WriteLine("Car added successfully.");
            }            
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
            Console.WriteLine(car.Id + " Car updated successfully.");
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
            Console.WriteLine(car.Id + " Car deleted successfully.");

        }

        public Car GetCarById(int carId)
        {
            return _carDal.Get(p => p.Id == carId);
        }

        public List<Car> GetCarsByModelYear(int modelYear)
        {
            return _carDal.GetAll(p => p.ModelYear == modelYear);
        }

        public List<Car> GetCarsByDailyPrice(decimal dailyPrice)
        {
            return _carDal.GetAll(p => p.DailyPrice == dailyPrice);
        }

        public List<Car> GetCarsByCarName(string carName)
        {
            return _carDal.GetAll(p => p.CarName== carName);
        }

        //public Car GetCarByName(string carName)
        //{
        //    return _carDal.GetFirst(p => p.CarName == carName);
        //}
    }
}
